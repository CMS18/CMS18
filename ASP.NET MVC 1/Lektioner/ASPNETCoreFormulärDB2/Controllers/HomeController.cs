using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreFormulärDB2.Models;

namespace ASPNETCoreIntro2.Controllers
{
    public class HomeController : Controller
    {
        private PeronDBContext _contex;

        public HomeController(PeronDBContext context)
        {
            _contex = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewPersonList()
        {

            List<Person> model = _contex.Person.ToList();

            return View(model);
        }

        public IActionResult ViewPerson()
        {

            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Remove()
        {
            return View();
        }
    }
}