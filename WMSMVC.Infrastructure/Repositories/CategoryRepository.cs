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
        public void AddCategory(string name)
        {
            _context.Categories.Add(new Category(name));
            _context.SaveChanges();
        }
        public void RemoveCategory(string name)
        {
            var category = _context.Categories.Find(name);
            if(category!=null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public List<Category> GetCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }
    }
}
