using System;
using System.Collections.Generic;
using System.Text;

namespace WMSMVC.Application.ViewModels.Category
{
    public class ListCategories
    {
        public List<CategoryVM> Categories { get; set; }
        public int Count { get; set; }
    }
}
