using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreRouting.Controllers
{
    public class HomeController : Controller
    {
        [Route("OM-Oss")]
        public IActionResult Index()
        {
            return View();

        }

        [Route("OM-Ossss")]
        public IActionResult About()
        {
            return View();
        }

        [Route("OM-Osss")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}