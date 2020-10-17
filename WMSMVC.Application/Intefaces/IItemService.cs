using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.ViewModels.Items;
using WMSMVC.Web.Models;

namespace WMSMVC.Application.Intefaces
{
    public interface IItemService
    {
        int Add(ItemVM item);
        void Remove(int id);
        void Update(ItemVM item);
        ItemVM GetItem(int id);
        ListItemsVM GetItems();
        ListItemsVM GetItemsByCategory(int id);
        void EditPrice(int id);
        void EditQuantity(int id);
    }
}
