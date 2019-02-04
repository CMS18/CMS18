using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blogg.Models;
using Blogg.ViewModels;

namespace Blogg.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext _context;
        public HomeController(BlogContext context)
        {
            _context = context;

        }
        public IActionResult Home()
        {
            return View();
        }


        public IActionResult About()
        {

            return View();
        }

        public IActionResult Webshop()
        {

            return View();
        }
        public IActionResult Blog()
        {
            PostViewModel post = new PostViewModel();
            post.BlogPosts = _context.BlogPosts.ToList();
            return View(post);
        }
        public IActionResult Contact()
        {

            return View();
        }

        public IActionResult ViewPost(int id)
        {
            var model = _context.BlogPosts.SingleOrDefault(p => p.PostId == id);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
