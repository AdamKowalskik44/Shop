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
            List<Category> categories = categoryService.GetCategoriesInheritenceUp(categoryService.GetCategory(result.Product.CategoryId));
            foreach (var customField in customFields)
            {
                foreach (var category in categories)
                {
                    if (customField.CategoryId == category.CategoryId)
                    {
                        ProductFieldValue productFieldValue = _db.ProductFieldValues.FirstOrDefault
                            (u => (u.CustomFieldId == customField.CustomFieldId && u.ProductId == result.Product.ProductId));

                        if (productFieldValue == null)
                        {
                            switch (customField.FieldType)
                            {
                                case CustomFieldType.tf:
                                    productFieldValue = new ProductFieldValueBool();
                                    break;
                                case CustomFieldType.integer:
                                    productFieldValue = new ProductFieldValueInt();
                                    break;
                                case CustomFieldType.floating:
                                    productFieldValue = new ProductFieldValueFloat();
                                    break;
                                case CustomFieldType.dropDown:
                                    productFieldValue = new ProductFieldValueDDI();
                                    break;
                                case CustomFieldType.word:
                                    productFieldValue = new ProductFieldValueString();
                                    break;
                                default:
                                    break;
                            }
                        }

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
            }

            //attach photos
            result.Photos = photoService.GetPhotos(productId);

            return result;
        }

        public ProductDTO GetProductDTO(Product product)
        {
            return GetProductDTO(product.ProductId);
        }

        public List<ProductDTO> GetIndexProductDTOs()
        {
            List<Product> products = GetProducts();
            List<ProductDTO> result = new List<ProductDTO>();
            foreach (var product in products)
            {
                if (product.DisplayOnIndex)
                {
                    result.Add(GetProductDTO(product));
                }
            }
            return result;
        }

        public List<ProductDTO> GetCategoryProductDTOsWithInheritanceDown(Category category)
        {
            List<Product> products = GetProducts();
            List<ProductDTO> result = new List<ProductDTO>();
            List<Category> categories = categoryService.GetCategoriesInheritenceDown(category);

            foreach (var product in products)
            {
                foreach (var cat in categories)
                {
                    if (product.CategoryId == cat.CategoryId)
                    {
                        result.Add(GetProductDTO(product));
                        break;
                    }
                }
            }
            return result;
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
                    existingProduct.Price = productDTO.Product.Price;
                    existingProduct.Stock = productDTO.Product.Stock;
                    existingProduct.DisplayOnIndex = productDTO.Product.DisplayOnIndex;

                    //save ProductFieldValues
                    foreach (var productFieldValue in productDTO.Fields)
                    {
                        productFieldValue.Value.CustomFieldId = productFieldValue.Key.CustomFieldId;
                        productFieldValue.Value.ProductId = productDTO.Product.ProductId;
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

                    _db.SaveChanges();

                    //save new Photos
                    foreach (var photo in productDTO.Photos)
                    {
                        photo.PhotoId = 0;
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
                    CreateFieldValue(productFieldValue);
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
                _db.SaveChanges();

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

            List<Category> categories = categoryService.GetCategoriesInheritenceUp(categoryService.GetCategory(result.Product.CategoryId));
            List<CustomField> customFields = _db.CustomFields.ToList();
            foreach (var customField in customFields)
            {
                foreach (var category in categories)
                {
                    if (customField.CategoryId == category.CategoryId)
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

        public bool SubstractStockValues(Dictionary<ProductDTO, CartEntry> products)
        {
            foreach (var product in products)
            {
                if (product.Value.Quantity <= product.Key.Product.Stock)
                {
                    SubstractStockValue(product.Key.Product, product.Value.Quantity);
                }
                else
                {
                    return false;
                }
            }
            _db.SaveChanges();
            return true;
        }

        /// <summary>
        /// No database update - intentional
        /// </summary>
        /// <param name="product">product to alter</param>
        /// <param name="value">value to substract</param>
        /// <returns></returns>
        private bool SubstractStockValue(Product product, int value)
        {
            Product existingProduct = _db.Products.FirstOrDefault(u => u.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.Stock -= value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ProductDTO> SearchProductsByPhrase(string phrase)
        {
            List<ProductDTO> result = new List<ProductDTO>();

            List<Product> products = _db.Products.ToList();
            foreach (var product in products)
            {
                if (SearchForPhraseInProduct(product, phrase))
                {
                    result.Add(GetProductDTO(product));
                }
            }

            List<ProductFieldValueString> productFieldValues = _db.ProductFieldValuesString.ToList();
            foreach (var productFieldValue in productFieldValues)
            {
                if (SearchForPhraseInProductFieldValue(productFieldValue, phrase))
                {
                    ProductDTO product = GetProductDTO(productFieldValue.ProductId);
                    bool found = false;
                    foreach (var prod in result)
                    {
                        if (prod.Product.ProductId == product.Product.ProductId)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        result.Add(product);
                    }
                }
            }

            List<ProductFieldValueDDI> productFieldValuesDDI = _db.ProductFieldValuesDDI.ToList();
            foreach (var productFieldValue in productFieldValuesDDI)
            {
                if (SearchForPhraseInProductFieldValue(productFieldValue, phrase))
                {
                    ProductDTO product = GetProductDTO(productFieldValue.ProductId);
                    bool found = false;
                    foreach (var prod in result)
                    {
                        if (prod.Product.ProductId == product.Product.ProductId)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        result.Add(product);
                    }
                }
            }
            return result;
        }

        private bool SearchForPhraseInProduct(Product product, string phrase)
        {
            if (product.ProductName.ToLower().Contains(phrase.ToLower()))
            {
                return true;
            }
            else if (product.ProducDescription.Contains(phrase))
            {
                return true;
            }
            return false;
        }

        private bool SearchForPhraseInProductFieldValue(ProductFieldValue productFieldValue, string phrase)
        {
            if (ProductDTO.GetProductFieldValue(productFieldValue).ToLower().Contains(phrase.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
