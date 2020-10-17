using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Web.Models;

namespace WMSMVC.Domain.Model
{
    public class Basket
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double TotalPay { get; set; }
        public bool IsRealised { get; set; }
        public ICollection<Item> Items { get; set; }
        public virtual Client Client { get; set; }
    }
}
