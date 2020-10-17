using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WMSMVC.Web.Models;

namespace WMSMVC.Domain.Intefaces
{
    public interface ICategoryRepository
    {
        int AddCategory(Category category);
        void RemoveCategory(int id);
        void UpdateCategory(Category category);
        IQueryable<Category> GetCategories();
        Category GetCategory(int id);
    }
}
