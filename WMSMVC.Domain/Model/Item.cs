using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMSMVC.Web.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int Quantity { get; set; }
        //public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Item(string name, int quantity, int categoryId)
        {
            //Id = id;
            Name = name;
            Quantity = quantity;
            CategoryId = categoryId;
        }
    }
}
