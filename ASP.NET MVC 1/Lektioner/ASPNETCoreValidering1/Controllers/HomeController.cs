using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreValidering1.Models;

namespace ASPNETCoreIntro2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Person person)
        {
            // Server validation of the model
            if (ModelState.IsValid)
            {
                // Save to database
                return View();

            }
            else
            {
                // Back to form
                return View();

            }
        }
    }
}