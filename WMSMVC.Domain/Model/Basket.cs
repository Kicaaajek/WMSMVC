using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Web.Models;

namespace WMSMVC.Domain.Model
{
    public class Basket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double TotalPay { get; set; }
        public ICollection<Item> Items { get; set; }
        public virtual Client User { get; set; }
    }
}
