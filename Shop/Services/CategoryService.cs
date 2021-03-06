﻿using Microsoft.EntityFrameworkCore.Internal;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public int GetCategoryId(string categoryName)
        {
            Category category = _db.Categories.FirstOrDefault(u => u.CategoryName == categoryName);
            if (category != null)
            {
                return category.CategoryId;
            }
            else
            {
                return 0;
            }
        }

        public List<Category> GetCategories(int parentCategoryId)
        {
            List<Category> categories = _db.Categories.ToList();
            List<Category> result = new List<Category>();
            foreach (var category in categories)
            {
                if (category.ParentCategoryId != 0 && category.ParentCategoryId == parentCategoryId)
                {
                    result.Add(category);
                }
            }
            return result;
        }

        public List<Category> GetRootCategories()
        {
            List<Category> categories = _db.Categories.ToList();
            List<Category> result = new List<Category>();
            foreach (var item in categories)
            {
                if (GetCategory(item.ParentCategoryId) == null)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<Category> GetCategoriesInheritenceDown(Category category)
        {
            List<Category> categories = GetCategories(category.CategoryId);
            List<Category> result = new List<Category>();
            foreach (var cat in categories)
            {
                List<Category> cats = GetCategoriesInheritenceDown(cat);
                foreach (var item in cats)
                {
                    result.Add(item);
                }
            }
            result.Add(category);
            return result;
        }

        public List<Category> GetCategoriesInheritenceUp(Category category)
        {
            List<Category> result;
            Category categoryToAdd = GetCategory(category.ParentCategoryId);
            if (categoryToAdd != null)
            {
                result = GetCategoriesInheritenceUp(categoryToAdd);
            }
            else
            {
                result = new List<Category>();
            }
            result.Add(category);
            return result;
        }

        public Category GetCategory(int categoryId)
        {
            Category category = new Category();
            return _db.Categories.FirstOrDefault(u => u.CategoryId == categoryId);
        }

        public bool CreateCategory(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                //async?
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteCategory(Category category)
        {
            if(_db.Categories.Contains(category))
            {
                _db.Categories.Remove(category);
                //async?
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            Category category = GetCategory(categoryId);
            if (_db.Categories.Contains(category))
            {
                _db.Categories.Remove(category);
                //async?
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                var existingCategory = _db.Categories.FirstOrDefault(u => u.CategoryId == category.CategoryId);
                if (existingCategory != null)
                {
                    existingCategory.CategoryName = category.CategoryName;
                    existingCategory.ParentCategoryId = category.ParentCategoryId;
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

        public Stack<string> GetCategoryPath(int categoryId, Stack<string> categories)
        {
            Category category = _db.Categories.FirstOrDefault(u => u.CategoryId == categoryId);
            if (category != null)
            {
                categories.Push(category.CategoryName);
                if (category.ParentCategoryId != 0)
                {
                    GetCategoryPath(category.ParentCategoryId, categories);
                }
            }
            return categories;
        }

        public bool HasChildCategories(int categoryId)
        {
            Category category = _db.Categories.FirstOrDefault(u => u.ParentCategoryId == categoryId);
            if (category == null)
            {
                return false;
            }
            return true;
        }
    }
}
