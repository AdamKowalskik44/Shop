﻿using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CustomFieldService
    {
        private readonly ApplicationDbContext _db;

        public CustomFieldService(ApplicationDbContext db)
        {
            _db = db;
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

        public Category GetCategory(int categoryId)
        {
            Category category = new Category();
            return _db.Categories.FirstOrDefault(u => u.CategoryId == categoryId);
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
    }
}