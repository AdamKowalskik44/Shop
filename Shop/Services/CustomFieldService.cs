using Shop.Data;
using Shop.Data.CustomFieldTypes;
using Shop.Data.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CustomFieldService
    {
        private readonly ApplicationDbContext _db;
        private readonly DropDownItemService dropDownItemService;

        public CustomFieldService(ApplicationDbContext db)
        {
            _db = db;
            dropDownItemService = new DropDownItemService(_db);
        }

        /// <summary>
        /// Gets all CustomFields from DataBase
        /// </summary>
        /// <returns></returns>
        public List<CustomField> GetCustomFields()
        {
            return _db.CustomFields.ToList();
        }

        /// <summary>
        /// Gets all CustomFields from DataBase where categoryId matches
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<CustomField> GetCustomFields(int categoryId)
        {
            List<CustomField> customFields = _db.CustomFields.ToList();
            List<CustomField> result = new List<CustomField>();
            foreach (CustomField item in customFields)
            {
                if (item.CategoryId == categoryId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public CustomField GetCustomField(int customFieldId)
        {
            CustomField customField = new CustomField();
            return _db.CustomFields.FirstOrDefault(u => u.CustomFieldId == customFieldId);
        }

        public bool CreateCustomField(CustomField customField)
        {
            try
            {
                _db.CustomFields.Add(customField);
                _db.SaveChanges();
                if (customField is CustomFieldDTO customFieldDTO)
                {
                    foreach (var dropDownItem in customFieldDTO.DropDownItems)
                    {
                        dropDownItem.CustomFieldId = customField.CustomFieldId;
                        dropDownItemService.CreateDropDownItem(dropDownItem);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteCustomField(CustomField customField)
        {
            if (_db.CustomFields.Contains(customField))
            {
                _db.CustomFields.Remove(customField);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool UpdateCustomField(CustomField customField)
        {
            try
            {
                var existingCustomField = _db.CustomFields.FirstOrDefault(u => u.CustomFieldId == customField.CustomFieldId);
                if (existingCustomField != null)
                {
                    if (existingCustomField.FieldType != customField.FieldType)
                    {
                        //Delete all productFieldValues whern type was changed
                        List<ProductFieldValue> productFieldValues = _db.ProductFieldValues.ToList();
                        foreach (var productFieldValue in productFieldValues)
                        {
                            if (productFieldValue.CustomFieldId == existingCustomField.CustomFieldId)
                            {
                                _db.ProductFieldValues.Remove(productFieldValue);
                            }
                        }
                    }
                    existingCustomField.CustomFieldName = customField.CustomFieldName;
                    existingCustomField.CategoryId = customField.CategoryId;
                    existingCustomField.Category = customField.Category;
                    existingCustomField.FieldType = customField.FieldType;
                    
                    _db.SaveChanges();
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
    }
}
