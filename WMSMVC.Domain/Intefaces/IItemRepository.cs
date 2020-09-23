using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Web.Models;

namespace WMSMVC.Domain.Intefaces
{
    public interface IItemRepository
    {
        void AddItem(string name, int quantity, int categoryId);
        public void RemoveItem(string name);
        List<Item> GetItems();
        //IQueryable<Item> GetItemsByCategory(string categoryName);
        void UpdateItem(string name, int quantity);
        List<Item> IsLow();
        
    }
}
