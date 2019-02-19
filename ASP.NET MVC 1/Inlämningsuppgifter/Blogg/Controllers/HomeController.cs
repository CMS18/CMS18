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
        private readonly BlogContext _context;
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
            PostViewModel post = new PostViewModel
            {
                BlogPosts = _context.BlogPosts.OrderByDescending(p => p.DatePosted).ToList()
            };
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

        public IActionResult Remove(int id)        
        {
            var post = _context.BlogPosts.SingleOrDefault(p => p.PostId == id);
            _context.BlogPosts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Blog", "Home");
        }

        [HttpPost, ActionName("Remove")]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _context.BlogPosts.SingleOrDefault(p => p.PostId == id);
            _context.BlogPosts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Blog", "Home");
        }

        [HttpPost]
        public IActionResult Search(PostViewModel values)
        {
            switch (values.SearchValue)
            {
                case null:
                    return RedirectToAction("Blog");
                default:
                    {
                        PostViewModel model = new PostViewModel
                        {
                            BlogPosts = _context.BlogPosts.Where(p => p.PostHeader.ToLower().Contains(values.SearchValue.ToLower())).ToList()
                        };
                        ModelState.Clear();
                        return View("Blog", model);
                    }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogPosts post)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();

                _context.BlogPosts.Add(post);
                _context.SaveChanges();

                var lastPost = _context.BlogPosts.Last();
                return Redirect("ViewPost/" + lastPost.PostId);
            }
            else
            {
                return View();
            }

        }



        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
