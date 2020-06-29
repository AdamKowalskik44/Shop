using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.CustomFieldTypes;
using Shop.Data.ProductTypes;

namespace Shop.Helpers
{
    public class FilterBuilder
    {
        public List<IFilter> BuildFilters(List<ProductDTO> productDTOs)
        {
            List<Filter> filters = new List<Filter>();

            foreach (var productDTO in productDTOs)
            {
                foreach (var field in productDTO.Fields)
                {
                    bool found = false;
                    foreach (var filter in filters)
                    {
                        if (filter.CustomField.CustomFieldId == field.Key.CustomFieldId)
                        {
                            if (field.Value is ProductFieldValueInt productFieldValueInt)
                            {
                                IntFilter actualFilter = (IntFilter)filter;
                                if (productFieldValueInt.Value > actualFilter.MaxAvalibleIntValue)
                                {
                                    actualFilter.MaxAvalibleIntValue = productFieldValueInt.Value;
                                }
                                else if (productFieldValueInt.Value < actualFilter.MinAvalibleIntValue)
                                {
                                    actualFilter.MinAvalibleIntValue = productFieldValueInt.Value;
                                }
                            }
                            else if (field.Value is ProductFieldValueFloat productFieldValueFloat)
                            {
                                FloatFilter actualFilter = (FloatFilter)filter;
                                if (productFieldValueFloat.Value > actualFilter.MaxAvalibleFloatValue)
                                {
                                    actualFilter.MaxAvalibleFloatValue = (float)Math.Round(productFieldValueFloat.Value, MidpointRounding.ToPositiveInfinity);
                                }
                                else if (productFieldValueFloat.Value < actualFilter.MinAvalibleFloatValue)
                                {
                                    actualFilter.MinAvalibleFloatValue = (float)Math.Round(productFieldValueFloat.Value, MidpointRounding.ToNegativeInfinity);
                                }
                            }
                            else if (field.Value is ProductFieldValueBool productFieldValueBool)
                            {
                                //nothing to do here
                            }
                            else
                            {
                                StringFilter actualFilter = (StringFilter)filter;
                                actualFilter.AddAvalibleValue(ProductDTO.GetProductFieldValue(field.Value));
                            }
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Filter filterToAdd = field.Value switch
                        {
                            ProductFieldValueBool productFieldValue => new BoolFilter(field.Key)
                            {
                                FalseValue = false,
                                TrueValue = false
                            },
                            ProductFieldValueInt productFieldValue => new IntFilter(field.Key)
                            {
                                MaxAvalibleIntValue = productFieldValue.Value,
                                MinAvalibleIntValue = productFieldValue.Value,
                            },
                            ProductFieldValueFloat productFieldValue => new FloatFilter(field.Key)
                            {
                                MaxAvalibleFloatValue = (float)Math.Round(productFieldValue.Value, MidpointRounding.ToPositiveInfinity),
                                MinAvalibleFloatValue = (float)Math.Round(productFieldValue.Value, MidpointRounding.ToNegativeInfinity)

                            },
                            _ => new StringFilter(field.Key, ProductDTO.GetProductFieldValue(field.Value)),
                        };
                        filters.Add(filterToAdd);
                    }
                }
            }

            foreach (var filter in filters)
            {
                switch (filter)
                {
                    case IntFilter intFilter:
                        intFilter.MaxIntValue = intFilter.MaxAvalibleIntValue;
                        intFilter.MinIntValue = intFilter.MinAvalibleIntValue;
                        break;
                    case FloatFilter floatFilter:
                        floatFilter.MaxFloatValue = floatFilter.MaxAvalibleFloatValue;
                        floatFilter.MinFloatValue = floatFilter.MinAvalibleFloatValue;
                        break;
                    default:
                        break;
                }
            }

            PriceFilter priceFilter = new PriceFilter();
            bool firstIteration = true;
            foreach (var productDTO in productDTOs)
            {
                if (firstIteration)
                {
                    priceFilter.MaxAvaliblePrice = (float)Math.Round(productDTO.Product.Price, MidpointRounding.ToPositiveInfinity);
                    priceFilter.MinAvaliblePrice = (float)Math.Round(productDTO.Product.Price, MidpointRounding.ToNegativeInfinity);
                    firstIteration = false;
                }
                else
                {
                    if (productDTO.Product.Price > priceFilter.MaxAvaliblePrice)
                    {
                        priceFilter.MaxAvaliblePrice = (float)Math.Round(productDTO.Product.Price, MidpointRounding.ToPositiveInfinity);
                    }
                    else if (productDTO.Product.Price < priceFilter.MinAvaliblePrice)
                    {
                        priceFilter.MinAvaliblePrice = (float)Math.Round(productDTO.Product.Price, MidpointRounding.ToNegativeInfinity);
                    }
                }
            }
            priceFilter.MaxPrice = priceFilter.MaxAvaliblePrice;
            priceFilter.MinPrice = priceFilter.MinAvaliblePrice;

            List<IFilter> result = new List<IFilter>
            {
                priceFilter
            };
            foreach (var filter in filters)
            {
                result.Add(filter);
            }
            return result;
        }

        public Dictionary<ProductDTO, bool> FilterProductDTOs(List<ProductDTO> productDTOs, List<IFilter> filters)
        {
            Dictionary<ProductDTO, bool> result = new Dictionary<ProductDTO, bool>();

            foreach (var productDTO in productDTOs)
            {
                if (Filter(productDTO, filters))
                {
                    result.Add(productDTO, true);
                }
                else
                {
                    result.Add(productDTO, false);
                }
            }

            return result;
        }

        private bool Filter(ProductDTO productDTO, List<IFilter> filters)
        {
            foreach (var filter in filters)
            {
                if (IsFilterActive(filter))
                {
                    ProductFieldValue productFieldValue = ExtractCustomField(productDTO, filter);
                    if (productFieldValue != null || filter is PriceFilter)
                    {
                        switch (filter)
                        {
                            case BoolFilter boolFilter:
                                ProductFieldValueBool productFieldValueBool = (ProductFieldValueBool)productFieldValue;
                                if (productFieldValueBool.Value && boolFilter.TrueValue || !productFieldValueBool.Value && boolFilter.FalseValue)
                                {
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            case StringFilter stringFilter:
                                List<string> filteredValues = GetAvalibleStringValues(stringFilter);
                                if (filteredValues.Count == 0)
                                {
                                    continue;
                                }
                                bool found = false;
                                foreach (var filteredValue in filteredValues)
                                {
                                    if (filteredValue == ProductDTO.GetProductFieldValue(productFieldValue))
                                    {
                                        found = true;
                                    }
                                }
                                if (found)
                                {
                                    continue;
                                }
                                return false;
                            case FloatFilter floatFilter:
                                ProductFieldValueFloat productFieldValueFloat = (ProductFieldValueFloat)productFieldValue;
                                if (productFieldValueFloat.Value >= floatFilter.MinFloatValue && productFieldValueFloat.Value <= floatFilter.MaxFloatValue)
                                {
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            case PriceFilter priceFilter:
                                if (productDTO.Product.Price >= priceFilter.MinPrice && productDTO.Product.Price <= priceFilter.MaxPrice)
                                {
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            case IntFilter intFilter:
                                ProductFieldValueInt productFieldValueInt = (ProductFieldValueInt)productFieldValue;
                                if (productFieldValueInt.Value >= intFilter.MinIntValue && productFieldValueInt.Value <= intFilter.MaxIntValue)
                                {
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            default:
                                continue;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsFilterActive(IFilter filter)
        {
            switch (filter)
            {
                case BoolFilter boolFilter:
                    if (!boolFilter.TrueValue && !boolFilter.FalseValue)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case StringFilter stringFilter:
                    if (GetAvalibleStringValues(stringFilter).Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case FloatFilter floatFilter:
                    if (floatFilter.MaxAvalibleFloatValue == floatFilter.MaxFloatValue && floatFilter.MinAvalibleFloatValue == floatFilter.MinFloatValue)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case IntFilter intFilter:
                    if (intFilter.MaxAvalibleIntValue == intFilter.MaxIntValue && intFilter.MinAvalibleIntValue == intFilter.MinIntValue)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return true;
            }
        }

        private List<string> GetAvalibleStringValues(StringFilter stringFilter)
        {
            List<string> filteredValues = new List<string>();
            foreach (var value in stringFilter.AvalibleValues)
            {
                if (value.Value)
                {
                    filteredValues.Add(value.Key);
                }
            }
            return filteredValues;
        }

        private ProductFieldValue ExtractCustomField(ProductDTO productDTO, IFilter filter)
        {
            if (filter is PriceFilter)
            {
                return null;
            }
            else
            {
                Filter filter_ = (Filter)filter;
                foreach (var field in productDTO.Fields)
                {
                    if (field.Value.CustomFieldId == filter_.CustomField.CustomFieldId)
                    {
                        return field.Value;
                    }
                }
                return null;
            }
        }
    }
}
