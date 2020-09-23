using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Domain.Intefaces;
using WMSMVC.Web.Models;

namespace WMSMVC.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly Context _context;
        public ItemRepository(Context context)
        {
            _context = context;
        }
        public void AddItem(string name,int quantity, int categoryId)
        {
            _context.Items.Add(new Item(name, quantity, categoryId));
            _context.SaveChanges();
        }
        public void RemoveItem(string name)
        {
            var item = _context.Items.Find(name);
            if(item!=null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
        public List<Item> GetItems()
        {
            var items = _context.Items.ToList();
            return items;
        }
        /*public IQueryable<Item> GetItemsByCategory(string categoryName)
        {
            var cat = _context.Categories.Where(c => c.Name == categoryName);
            var id = cat.Id;
            var items = _context.Items.Where(a => a.CategoryId == id);
            return items;
        }*/

        public void UpdateItem(string name, int quantity)
        {
            foreach(var i in _context.Items)
            {
                if(i.Name==name)
                {
                    i.Quantity += quantity;
                    break;
                }
            }
            _context.SaveChanges();
        }
        public List<Item> IsLow()
        {
            var lists = _context.Items.Where(i => i.Quantity < 5).ToList();
            return lists;
        }
    }
}
