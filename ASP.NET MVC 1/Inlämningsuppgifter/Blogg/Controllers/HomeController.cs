using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blogg.Models;

namespace Blogg.Controllers
{
    public class HomeController : Controller
    {
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

            return View();
        }
        public IActionResult Contact()
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
