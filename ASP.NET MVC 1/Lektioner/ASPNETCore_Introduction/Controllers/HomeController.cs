using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore_Introduction.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {            
            ViewBag.Message = "Detta är en text från controllern";
            return View("index");
        }
    }
}