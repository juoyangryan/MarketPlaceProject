using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DomainLayer.Models;
using DomainLayer.Interfaces;
using System.Threading.Tasks;

namespace MarketPlaceProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICategoryService _categoryService;

        public SearchController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories; // Pass categories to the view via ViewBag
            return View();
        }
    }
}
