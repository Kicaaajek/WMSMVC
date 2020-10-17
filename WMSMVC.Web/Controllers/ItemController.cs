using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using WMSMVC.Application.Intefaces;
using WMSMVC.Application.ViewModels.Category;
using WMSMVC.Application.ViewModels.Items;
using WMSMVC.Web.Models;

namespace WMSMVC.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        public ItemController(IItemService itemService, ICategoryService categoryService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var model = _categoryService.GetCategories();
            if (model == null)
            {
                return View(new CategoryVM());
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ItemDetails(int id)
        {
            var item = _itemService.GetItem(id);
            return View(item);
        }

        [HttpGet]
        public IActionResult CategoryDetails(int id)
        {
            var categories = _categoryService.GetCategory(id);
            return View(categories);
        }

        [HttpGet]
        public IActionResult ItemCreate(int id)
        {
            return View(new ItemVM() { CategoryId=id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ItemCreate(ItemVM model)
        {
            var id=_itemService.Add(model);
            if (id == 0)
            {
                return RedirectToAction("ItemCreate");
            }
            else
            {
                return RedirectToAction("CategoryDetails", new { id = model.CategoryId });
            }
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View(new CategoryVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CategoryCreate(CategoryVM model)
        {
            _categoryService.AddCategory(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            var model = _itemService.GetItem(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditItem(ItemVM item)
        {
            _itemService.Update(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var model = _categoryService.GetCategory(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(CategoryVM category)
        {
            _categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(int id)
        {
            _itemService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

    }
}
