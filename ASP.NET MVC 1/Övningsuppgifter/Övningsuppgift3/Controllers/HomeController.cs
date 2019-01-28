using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Övningsuppgift3.Models;
using Övningsuppgift3.ViewModels;

namespace Övningsuppgift3.Controllers
{
    public class HomeController : Controller
    {
        private NewsSiteContext _context;
        public HomeController(NewsSiteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var model = _context.Categories.ToList();
            //var articles = _context.Articles.ToList();
            ArticleViewModel model = new ArticleViewModel();
            model.Categories = _context.Categories.ToList();
            return View(model);
        }

        public IActionResult ViewArticles(int id)
        {
            var model = new ArticleViewModel();
            model.Categories = _context.Categories.ToList();
            model.SelectedArticles = _context.Articles.Where(a => a.CategoryId == id).ToList();
            //model.SelectedArticles = _context.Articles.ToList();


            return View("Index", model);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
