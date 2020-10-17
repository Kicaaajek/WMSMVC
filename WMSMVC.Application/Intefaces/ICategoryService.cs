using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.ViewModels.Category;
using WMSMVC.Web.Models;

namespace WMSMVC.Application.Intefaces
{
    public interface ICategoryService
    {
        int AddCategory(CategoryVM category);
        void DeleteCategory(int id);
        void UpdateCategory(CategoryVM category);
        CategoryVM GetCategory(int id);
        ListCategories GetCategories();
    }
}
