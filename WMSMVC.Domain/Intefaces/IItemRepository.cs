using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Web.Models;

namespace WMSMVC.Domain.Intefaces
{
    public interface IItemRepository
    {
        int AddItem(Item item);
        void RemoveItem(int id);
        void UpdateItem(Item item);
        Item GetItem(int id);
        int GetQuantity(int id);
        void EditPrice(int id);
        void EditQuantity(int id);
        IQueryable<Item> GetItems();
        IQueryable<Item> GetItemsByCategory(int catid);
        IQueryable<Item> IsLow();
        Item GetItemByName(string name);
    }
}
