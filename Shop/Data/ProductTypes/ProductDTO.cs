using Shop.Data.CustomFieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.ProductTypes;
using Shop.Helpers;

namespace Shop.Data.ProductTypes
{
    public class ProductDTO
    {
        public Product Product { get; set; }

        public Dictionary<CustomField, ProductFieldValue> Fields { get; set; }

        public List<Photo> Photos { get; set; }

        public Stack<string> CategoryPath { get; set; }

        public ProductDTO()
        {
            Fields = new Dictionary<CustomField, ProductFieldValue>();
            Photos = new List<Photo>();
            CategoryPath = new Stack<string>();
        }

        public Photo GetMainPhoto()
        {
            foreach (var photo in Photos)
            {
                if (photo.MainPhoto)
                {
                    return photo;
                }
            }
            return null;
        }

        public static string GetProductFieldValue(ProductFieldValue pfv)
        {
            switch (pfv)
            {
                case ProductFieldValueBool productFieldValue:
                    if(productFieldValue.Value)
                    {
                        return "yes";   
                    }
                    else
                    {
                        return "no";
                    }
                case ProductFieldValueInt productFieldValue:
                    return productFieldValue.Value.ToString();
                case ProductFieldValueFloat productFieldValue:
                    return productFieldValue.Value.ToString();
                case ProductFieldValueString productFieldValue:
                    if (productFieldValue.Value == null)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return productFieldValue.Value.ToString();
                    }
                case ProductFieldValueDDI productFieldValue:
                    if (productFieldValue.Value == null)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return productFieldValue.Value.ToString();
                    }
                default:
                    return string.Empty;
            }
        }
    }
}
