using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreRazor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            List<string> myList = new List<string>();
            myList.Add("Lista");
            myList.Add("Kalle");
            myList.Add("Anna");

            ViewBag.NameList = myList;

            ViewBag.Number = 1337;

            return View();
        }


        public IActionResult SendQuestion()
        {

            return View();
        }


        public IActionResult ReceiveQuestion()
        {
            return View();
        }

        public IActionResult Update()
        {
            ViewBag.CurrentTime = DateTime.Now;
            return View();
        }
    }
}