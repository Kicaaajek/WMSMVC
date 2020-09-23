using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WMSMVC.Web.Models;

namespace WMSMVC.Domain.Intefaces
{
    public interface ICategoryRepository
    {
        void AddCategory(string name);
        void RemoveCategory(string name);
        List<Category> GetCategories();
    }
}
