
﻿using DomainLayer.Interfaces;
﻿using MarketPlaceProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DomainLayer.Models;

namespace MarketPlaceProject.Controllers
{
    public class HomeController : Controller

    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subcategoryService;

        public HomeController(ICategoryService categoryService, ISubCategoryService subcategoryService, IItemService itemService)
        {
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
            _itemService = itemService;
        }
        // Auto Mapper
        private readonly IMapper _mapper;
        public HomeController(ICategoryService categoryService, ISubCategoryService subcategoryService, IItemService itemService, IMapper mapper)
        {
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
            _itemService = itemService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> Search()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories; // Pass categories to the view via ViewBag
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllSubcategories()
        {
            var subcategories = await _subcategoryService.GetAllAsync();
            var subcategoryData = subcategories.Select(sc => new { sc.ID, sc.Name });
            return Json(subcategoryData, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<JsonResult> GetSubcategoriesByCategoryId(int categoryId)
        {
            var subcategories = await _subcategoryService.GetByCategoryIdAsync(categoryId);
            var subcategoryData = subcategories.Select(sc => new { sc.ID, sc.Name });
            return Json(subcategoryData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> SearchItemsBySubcategoryName(string subcategoryName)
        {
            return RedirectToAction("FilterResults", new { subcategoryName = subcategoryName });
        }


        [HttpGet]
        public async Task<ActionResult> FilterResults(int? modelYearFrom = null, int? modelYearTo = null, string useType = null, decimal? powerFrom = null, decimal? powerTo = null, decimal? heightFrom = null, decimal? heightTo = null, decimal? weightFrom = null, decimal? weightTo = null, string subcategoryName = "")
        {
            // Fetch filtered items based on the provided criteria, including subcategoryName
            var items = await _itemService.GetFilteredAsync(modelYearFrom, modelYearTo, useType, powerFrom, powerTo, heightFrom, heightTo, weightFrom, weightTo, subcategoryName);

            var itemDTOs = _mapper.Map<IEnumerable<ItemDTO>>(items); // Map domain models to DTOs

            // Fetch categories for the filter sidebar in the results page
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            //pass the filter input
            ViewBag.ModelYearFrom = modelYearFrom;
            ViewBag.ModelYearTo = modelYearTo;
            ViewBag.UseType = useType;
            ViewBag.PowerFrom = powerFrom;
            ViewBag.PowerTo = powerTo;
            ViewBag.HeightFrom = heightFrom;
            ViewBag.HeightTo = heightTo;
            ViewBag.WeightFrom = weightFrom;
            ViewBag.WeightTo = weightTo;
            ViewBag.SubcategoryName = subcategoryName;

            return View("Result", itemDTOs); // Return the filtered items to the Result view
        }




        public ActionResult Result()
        {
            List<Product> products = new List<Product>()
            {
            };
            return View(products);
        }


        public ActionResult ProductSummary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Find Product from DB
            // Dummy Data for now
            Product product = new Product
            {
                ProductID = 1,
                Manufacture = "Big Ass",
                Series = "Haiku H",
                Model = "S3-150-S0-BC",
                UseType = "Commercial",
                Application = "Indoor",
                MountingLocation = "Roof",
                Accessories = "With Light",
                ModelYear = 2016,
                Power = 20.10,
                Height = 30.5,
                Weight = 13,
                ImageUrl = "~/Content/Images/fan1.jpeg"
            };
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (isValidUser(user.UsernameOrEmail, user.Password))
            {
                return RedirectToAction("Search");
            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View(user);
        }

        // POST: Home/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Save the user registration data to the database or perform other necessary actions

                // Return success partial view
                // Add Unsuccessful partial view if transaction failed
                return PartialView("_RegistrationSuccess");
            }
            else
            {
                // Return partial view with incompleted user info
                return PartialView("_RegistrationModal", user);
            }
        }

        public ActionResult Compare()
        {
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    ProductID = 1,
                    Manufacture = "Big Ass",
                    Series = "Haiku H",
                    Model = "S3-150-S0-BC",
                    UseType = "Commercial",
                    Application = "Indoor",
                    MountingLocation = "Roof",
                    Accessories = "With Light",
                    ModelYear = 2016,
                    Power = 20.10,
                    Height = 30.5,
                    Weight = 13,
                    ImageUrl = "~/Content/Images/fan1.jpeg"
                },
                new Product
                {
                    ProductID = 2,
                    Manufacture = "Big Ass",
                    Series = "Haiku H",
                    Model = "S3-150-S0-BC",
                    UseType = "Commercial",
                    Application = "Indoor",
                    MountingLocation = "Roof",
                    Accessories = "With Light",
                    ModelYear = 2016,
                    Power = 20.10,
                    Height = 30.5,
                    Weight = 13,
                    ImageUrl = "~/Content/Images/fan1.jpeg"
                }
            };
            return View(products);
        }

        private bool isValidUser(string usernameOrEmail, string password)
        {
            return true;
        }
    }
}