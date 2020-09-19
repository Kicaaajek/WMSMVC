using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMSMVC.Web.Models;

namespace WMSMVC.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult ViewListOfCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category(1, "Fruits"));
            categories.Add(new Category(2, "Vegetables"));
            return View(categories);
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category(1, "Fruits"));
            categories.Add(new Category(2, "Vegetables"));
            return View(id);
        }
    }
}
