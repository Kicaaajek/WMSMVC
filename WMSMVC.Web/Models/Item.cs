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
        public Item(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
