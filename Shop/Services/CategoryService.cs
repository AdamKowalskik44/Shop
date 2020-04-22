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

        public List<Category> GetCategories(int parentCategoryId)
        {
            List<Category> categories = _db.Categories.ToList();
            List<Category> result = new List<Category>();
            foreach (var item in categories)
            {
                if (item.ParentCategoryId != 0 && item.ParentCategoryId == parentCategoryId)
                {
                    result.Add(item);
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
    }
}
