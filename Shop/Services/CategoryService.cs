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

        //TODO CreateCategory, DeleteCategory
    }
}
