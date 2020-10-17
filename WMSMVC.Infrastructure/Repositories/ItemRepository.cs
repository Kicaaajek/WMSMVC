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
        public int AddItem(Item item)
        {
            _context.Items.Add(item);
            var id = item.Id;
            return id;
        }
        public void RemoveItem(int id)
        {
            var it = _context.Items.Find(id);
            if (it != null)
            {
                _context.Items.Remove(it);
                _context.SaveChanges();
            }
        }

        public IQueryable<Item> GetItems()
        {
            var items = _context.Items;
            return items;
        }

        public IQueryable<Item> GetItemsByCategory(int catid)
        {
            var items = _context.Items.Where(a => a.CategoryId == catid);
            return items;
        }

        public IQueryable<Item> IsLow()
        {
            var lists = _context.Items.Where(i => i.Quantity < 5);
            return lists;
        }
        public void UpdateItem(Item item)
        {
            _context.Attach(item);
            _context.Entry(item).Property("Name").IsModified = true;
            _context.Entry(item).Property("Quantity").IsModified = true;
            _context.Entry(item).Property("Price").IsModified = true;
            _context.SaveChanges();
        }
        public void EditQuantity(int id)
        {
            var item=_context.Items.FirstOrDefault(i => i.Id == id);
            _context.Attach(item);
            _context.Entry(item).Property("Quantity").IsModified = true;
            _context.SaveChanges();
        }
        public void EditPrice(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            _context.Attach(item);
            _context.Entry(item).Property("Price").IsModified = true;
            _context.SaveChanges();
        }
        public Item GetItem(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            return item;
        }

        public int GetQuantity(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            var quantity = item.Quantity;
            return quantity;
        }

        public Item GetItemByName(string name)
        {
            var item = _context.Items.FirstOrDefault(i => i.Name == name);
            return item;
        }
    }
}
