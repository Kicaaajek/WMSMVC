using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMSMVC.Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public Category(string name)
        {
            Name = name;
        }
    }
}
