using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeExample.Models;

namespace PracticeExample.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> _products = new List<Product>
        {
        new Product { Id = 1, Name = "Pen", Category = "Stationary", Price = 20 },
        new Product { Id = 2, Name = "Pencil", Category = "Stationary", Price = 10 },
        new Product { Id = 3, Name = "Phone", Category = "Electronic", Price = 20000 },
        new Product { Id = 4, Name = "Laptop", Category = "Electronic", Price = 30000 }
        };

        public static List<string> _categories = _products.Select(p => p.Category).Distinct().ToList();
        

        // GET: Product
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

        public ActionResult EProductList(string Electronic)
        {
            var eProductList = _products.Where(p => p.Category == "Electronic").ToList();
            return View("ProductList", eProductList);
        }

        public ActionResult SProductList(string Stationary)
        {
            var sProductList = _products.Where(p => p.Category == "Stationary").ToList();
            return View("ProductList", sProductList);
        }

        /* public ActionResult ProductList(string category)
         {
             var productList = _products.Where(p => p.Category == category).ToList();
             return View(_products);
         }*/
        public ActionResult AddToCart()
        {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity)
        {
             if (quantity > 5)
             {
                 quantity = 5;
             }

             var product = _products.FirstOrDefault(p => p.Id == productId);

             if (product != null)
             {                
                 var cartItem = new CartItem { Product = product, Quantity = quantity };

                 var cart = ViewData["Cart"] as List<CartItem> ?? new List<CartItem>();
                 cart.Add(cartItem);

                 ViewData["Cart"] = cart;
             }

             return View();
        }
    }
}