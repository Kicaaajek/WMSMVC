using System;
using System.Collections.Generic;
using System.Text;

namespace WMSMVC.Application.ViewModels.Items
{
    public class ListItemsVM
    {
        public List<ItemVM> Items { get; set; }
        public int Count { get; set; }
    }
}
