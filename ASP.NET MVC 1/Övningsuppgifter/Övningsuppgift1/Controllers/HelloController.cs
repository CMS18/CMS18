using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Övningsuppgift_1.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult ViewHello()
        {
            ViewBag.Message = "Hello MVC-Nu kör vi!";
            return View();
        }

        public IActionResult RandomNumber()
        {
            var rnd = new Random();
            var num = rnd.Next(1,11);

            if (num >= 1 && num <= 3)
            {
                ViewBag.Message = "Talet är mellan 1 och 3: " + num;
            }
            else if (num >= 4 && num <= 6)
            {
                ViewBag.Message = "Talet är mellan 4 och 6: " + num;
            }
            else if (num >= 7 && num <= 10)
            {
                ViewBag.Message = "Talet är mellan 6 och 10: " + num;
            }

            return View();
        }

        public IActionResult ViewListData()
        {

            List<string> list = new List<string>();
            list.Add("Svart");
            list.Add("Grön");
            list.Add("Röd");
            list.Add("Blå");
            list.Add("Vit");

            ViewBag.List = list;

            return View();
        }

        public IActionResult UpdateDateTime()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public IActionResult SendQuestion()
        {
            var loggedIn = true;
            ViewBag.User = loggedIn;
            ViewBag.Time = DateTime.Now.ToShortTimeString();
            return View();
        }

        public IActionResult ReceiveQuestion()
        {

            return View();
        }
    }
}