using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreEF.Models;
using ASPNETCoreEF.ViewModels;


namespace ASPNETCoreEF.Controllers
{
    public class HomeController : Controller
    {
        private NORTHWINDContext _context;
        public HomeController(NORTHWINDContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ProductViewModel model = new ProductViewModel();
            model.ProductCategories = _context.Categories.ToList();
            return View(model);
        }

        public IActionResult ViewProducts(int id)
        {
            var model = new ProductViewModel();
            model.ProductCategories = _context.Categories.ToList();
            model.SelectedProducts = _context.Products.Where(p => p.CategoryId == id).ToList();

            return View("Index", model);
        }
    }
}