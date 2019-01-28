using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Övningsuppgift4.Controllers
{
    public class MyFormsController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult RegisterConfirmation()
        {
            
            return View();
        }

    }
}