
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

namespace MarketPlaceProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subcategoryService;

        public HomeController(ICategoryService categoryService, ISubCategoryService subcategoryService)
        {
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
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


        public ActionResult Result()
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

        private bool isValidUser(string usernameOrEmail, string password)
        {
            return true;
        }
    }
}