using System.Threading.Tasks;
using System.Web.Mvc;
using DomainLayer.Models;
using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace MarketPlaceProject.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<ActionResult> Index()
        {
            var items = await _itemService.GetAllAsync();
            if (items == null)
            {
                items = new List<Item>(); // Ensure items is never null
            }
            return View(items);
        }



        public async Task<ActionResult> Details(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // Add methods for Create, Edit, Delete, etc.
    }
}
