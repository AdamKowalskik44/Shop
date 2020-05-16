using Shop.Data;
using Shop.Data.CustomFieldTypes;
using Shop.Data.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;
        private readonly CategoryService categoryService;
        private readonly PhotoService photoService;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
            categoryService = new CategoryService(_db);
            photoService = new PhotoService(_db);
        }

        public ProductDTO GetProductDTO(int productId)
        {
            //Attach a product
            ProductDTO result = new ProductDTO();
            result.Product = _db.Products.FirstOrDefault(u => u.ProductId == productId);
            if (result.Product == null)
            {
                return null;
            }

            //Find category path
            result.CategoryPath = categoryService.GetCategoryPath(result.Product.CategoryId, result.CategoryPath);

            //Find and attach all custom fields and their values
            List<CustomField> customFields = _db.CustomFields.ToList();
            foreach (var customField in customFields)
            {
                //TODO add category inheritance
                if (customField.CategoryId == result.Product.CategoryId)
                {
                    ProductFieldValue productFieldValue = _db.ProductFieldValues.FirstOrDefault
                        (u => (u.CustomFieldId == customField.CustomFieldId && u.ProductId == result.Product.ProductId));
                    if (customField.FieldType == CustomFieldType.dropDown)
                    {
                        CustomFieldDTO customFieldDTO = new CustomFieldDTO(customField);
                        List<DropDownItem> dropDownItems = _db.DropDownItems.ToList();
                        foreach (var dropDownItem in dropDownItems)
                        {
                            if (dropDownItem.CustomFieldId == customField.CustomFieldId)
                            {
                                customFieldDTO.DropDownItems.Add(dropDownItem);
                            }
                        }
                        result.Fields.Add(customFieldDTO, productFieldValue);
                    }
                    else
                    {
                        result.Fields.Add(customField, productFieldValue);
                    }
                }
            }

            //attach photos
            result.Photos = photoService.GetPhotos(productId);

            return result;
        }

        public ProductDTO GetProductDTO(Product product)
        {
            return GetProductDTO(product.ProductId);
        }

        public List<Product> GetProducts()
        {
            return _db.Products.ToList();
        }

        public bool UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                //save product
                var existingProduct = _db.Products.FirstOrDefault(u => u.ProductId == productDTO.Product.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = productDTO.Product.ProductName;
                    existingProduct.ProducDescription = productDTO.Product.ProducDescription;

                    //save ProductFieldValues
                    foreach (var productFieldValue in productDTO.Fields)
                    {
                        if (!UpdateProductFieldValue(productFieldValue.Value))
                        {
                            return false;
                        }
                    }

                    //dump old photos
                    List <Photo> oldPhotos = photoService.GetPhotos(productDTO.Product.ProductId);
                    foreach (var photo in oldPhotos)
                    {
                        if (!photoService.DeletePhoto(photo))
                        {
                            return false;
                        }
                    }

                    //save new Photos
                    foreach (var photo in productDTO.Photos)
                    {
                        photo.ProductId = productDTO.Product.ProductId;
                        if (!photoService.CreatePhoto(photo))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }

            _db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Saves a ProductFieldValue - no dataBase update - intentional
        /// </summary>
        /// <param name="productFieldValue"></param>
        /// <returns></returns>
        private bool UpdateProductFieldValue(ProductFieldValue productFieldValue)
        {
            try
            {
                var existingProductFieldValue = _db.ProductFieldValues.FirstOrDefault(u => u.ProductFieldValueId == productFieldValue.ProductFieldValueId);
                if (existingProductFieldValue != null)
                {
                    switch (productFieldValue)
                    {
                        case ProductFieldValueBool newProductFieldValue:
                            ProductFieldValueBool boolProductFieldValue = existingProductFieldValue as ProductFieldValueBool;
                            boolProductFieldValue.Value = newProductFieldValue.Value;
                            break;
                        case ProductFieldValueInt newProductFieldValue:
                            ProductFieldValueInt intProductFieldValue = existingProductFieldValue as ProductFieldValueInt;
                            intProductFieldValue.Value = newProductFieldValue.Value;
                            break;
                        case ProductFieldValueFloat newProductFieldValue:
                            ProductFieldValueFloat floatProductFieldValue = existingProductFieldValue as ProductFieldValueFloat;
                            floatProductFieldValue.Value = newProductFieldValue.Value;
                            break;
                        case ProductFieldValueString newProductFieldValue:
                            ProductFieldValueString stringProductFieldValue = existingProductFieldValue as ProductFieldValueString;
                            stringProductFieldValue.Value = newProductFieldValue.Value;
                            break;
                        case ProductFieldValueDDI newProductFieldValue:
                            ProductFieldValueDDI ddiProductFieldValue = existingProductFieldValue as ProductFieldValueDDI;
                            ddiProductFieldValue.Value = newProductFieldValue.Value;
                            break;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        public bool CreateProduct(ProductDTO productDTO)
        {
            try
            {
                //save product
                _db.Products.Add(productDTO.Product);

                //save ProductFieldValues
                foreach (var productFieldValue in productDTO.Fields)
                {
                    productFieldValue.Value.CustomFieldId = productFieldValue.Key.CustomFieldId;
                    productFieldValue.Value.ProductId = productDTO.Product.ProductId;
                    if (!CreateFieldValue(productFieldValue.Value))
                    {
                        return false;
                    }
                }

                //save photos
                foreach (var photo in productDTO.Photos)
                {
                    photo.ProductId = productDTO.Product.ProductId;
                    if (!photoService.CreatePhoto(photo))
                    {
                        return false;
                    }
                }

                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool CreateFieldValue(ProductFieldValue productFieldValue)
        {
            try
            {
                _db.ProductFieldValues.Add(productFieldValue);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public ProductDTO GetNewProductDTO(int categoryId)
        {
            ProductDTO result = new ProductDTO();
            result.Product = new Product();
            result.Product.ProductId = 0;
            result.Product.CategoryId = categoryId;
            result.CategoryPath = categoryService.GetCategoryPath(result.Product.CategoryId, result.CategoryPath);

            List<CustomField> customFields = _db.CustomFields.ToList();
            foreach (var customField in customFields)
            {
                //TODO add category inheritance
                if (customField.CategoryId == result.Product.CategoryId)
                {
                    switch (customField.FieldType)
                    {
                        case CustomFieldType.tf:
                            result.Fields.Add(customField, new ProductFieldValueBool());
                            break;
                        case CustomFieldType.integer:
                            result.Fields.Add(customField, new ProductFieldValueInt());
                            break;
                        case CustomFieldType.floating:
                            result.Fields.Add(customField, new ProductFieldValueFloat());
                            break;
                        case CustomFieldType.dropDown:
                            {
                                CustomFieldDTO customFieldDTO = new CustomFieldDTO(customField);
                                List<DropDownItem> dropDownItems = _db.DropDownItems.ToList();
                                foreach (var dropDownItem in dropDownItems)
                                {
                                    if (dropDownItem.CustomFieldId == customField.CustomFieldId)
                                    {
                                        customFieldDTO.DropDownItems.Add(dropDownItem);
                                    }
                                }
                                result.Fields.Add(customFieldDTO, new ProductFieldValueDDI());
                                break;
                            }
                        case CustomFieldType.word:
                            result.Fields.Add(customField, new ProductFieldValueString());
                            break;
                        default:
                            break;
                    }
                }
            }

            return result;
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                List<ProductFieldValue> productFieldValues = _db.ProductFieldValues.ToList();
                foreach (var productFieldValue in productFieldValues)
                {
                    if (productFieldValue.ProductId == product.ProductId)
                    {
                        _db.ProductFieldValues.Remove(productFieldValue);
                    }
                }
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
