using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Domain.Intefaces;
using WMSMVC.Web.Models;

namespace WMSMVC.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public int AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.Id;
        }
        public void RemoveCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if(category!=null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public IQueryable<Category> GetCategories()
        {
            var categories = _context.Categories;
            return categories;
        }
        public Category GetCategory(int id)
        {
            var cat = _context.Categories.FirstOrDefault(c => c.Id == id);
            return cat;
        }

        public void UpdateCategory(Category category)
        {
            _context.Attach(category);
            _context.Entry(category).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}
