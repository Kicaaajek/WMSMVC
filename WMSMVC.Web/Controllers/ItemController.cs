using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMSMVC.Web.Models;

namespace WMSMVC.Web.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult ViewListofItems()
        {
            List<Item> items = new List<Item>
            {
                new Item(1, "Apples", 34),
                new Item(2, "Bananas", 12),
                new Item(3, "Onions", 45),
                new Item(4, "Potatos", 24)
            };
            return View(items);
        }
                
    }
}
