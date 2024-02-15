using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeExample.Models;

namespace PracticeExample.Controllers
{
    public class AdminController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
        new Product { Id = 1, Name = "Pen", Category = "Stationary", Price = 20 },
        new Product { Id = 2, Name = "Pencil", Category = "Stationary", Price = 10 },
        new Product { Id = 3, Name = "Phone", Category = "Electronic", Price = 20000 },
        new Product { Id = 4, Name = "Laptop", Category = "Electronic", Price = 30000 }
        };

        private static List<string> _categories = _products.Select(p => p.Category).Distinct().ToList();


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductCategories()
        {
            //var categories = _categories.ToList();
            return View();
        }

        public ActionResult ProductList(string Category)
        {
            var productList = _products.ToList();
            return View("ProductList", productList);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (_products.Any(p => p.Id == product.Id))
            {
                ModelState.AddModelError("Id", "A product with this ID already exists.");
                return View(product);
            }

            _products.Add(product);
            return View();
        }

        public ActionResult EditProduct(Product product)
        {
            if (product == null)
            {
                return HttpNotFound();
            }

            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return HttpNotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;

            return View();
        }


        public ActionResult DeleteProduct(Product product)
        {
            if (product != null)
            {
                _products.Remove(product);
            }

            return View();
        }


        /*       [HttpPost]
               [Authorize(Roles = "Admin")]
               public ActionResult AddCategory(string category)
               {
                   _categories.Add(category);
                   return RedirectToAction("ProductCategories");
               }

               [HttpPost]
               [Authorize(Roles = "Admin")]
               public ActionResult DeleteCategory(string category)
               {
                   _categories.Remove(category);

                   _products.RemoveAll(p => p.Category == category);

                   return RedirectToAction("ProductCategories");*/

    }
}