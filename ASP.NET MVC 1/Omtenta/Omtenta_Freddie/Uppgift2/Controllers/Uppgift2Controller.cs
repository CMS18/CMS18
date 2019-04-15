using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uppgift2.Models;
using Uppgift2.ViewModels;

namespace Uppgift2.Controllers
{
    public class Uppgift2Controller : Controller
    {
        private NorthwindContext _context;

        public Uppgift2Controller(NorthwindContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new ProductsViewModel
            {
                ListOfProducts = _context.Products.Where(c => c.CategoryId == 1).ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductsViewModel form)
        {
            ProductsViewModel model = null;

            string str = HttpContext.Session.GetString("Product");

            //if (!String.IsNullOrWhiteSpace(str))
            //{
            //    model = JsonConvert.DeserializeObject<ProductsViewModel>(str);
            //}

            //if (model == null)
            //{
            //    model = new ProductsViewModel();
            //    model.ListOfProducts = new List<Products>();
            //}

            // ^This is the same thing as this

            if (!String.IsNullOrWhiteSpace(str)) model = JsonConvert.DeserializeObject<ProductsViewModel>(str);

            if (model == null) model = new ProductsViewModel() { ListOfProducts = new List<Products>() };

            // just cleaner

            model.Product = _context.Products.SingleOrDefault(c => c.ProductId == form.Product.ProductId);

            foreach (var b in model.ListOfProducts)
            {
                if (b.ProductId == form.Product.ProductId)
                {
                    TempData["ErrorMessage"] = "Produkten existerar redan i listan";
                    return RedirectToAction("Index", model);
                }
            }

            if (model.ListOfProducts.Count < 4)
            {
                if (model.ListOfProducts.Any(x => x.ProductId == form.Product.ProductId))
                {

                    TempData["ErrorMessage"] = "Produkten existerar redan";
                    return RedirectToAction("Index", "Uppgift2");
                }
                else
                {
                    model.Product.UnitsOnOrder = form.Product.UnitsOnOrder;
                    model.ListOfProducts.Add(model.Product);
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Det går max att välja 4 produkter";
                return RedirectToAction("Index", "Uppgift2");
            }

            var values = JsonConvert.SerializeObject(model);
            HttpContext.Session.SetString("Product", values);
            return RedirectToAction("Index", model);
        }

        public IActionResult ShowProduct()
        {
            var str = HttpContext.Session.GetString("Product");
            var model = JsonConvert.DeserializeObject<ProductsViewModel>(str);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
