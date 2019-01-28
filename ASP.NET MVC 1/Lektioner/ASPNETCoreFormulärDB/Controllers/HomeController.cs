using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreFormulärDB.Models;
using ASPNETCoreFormulärDB.ViewModels;

namespace ASPNETCoreIntro2.Controllers
{

    public class HomeController : Controller
    {

        public HomeController(PeronDBContext context)
        {
            _context = context;
        }

        private PeronDBContext _context;
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
            return View();
        }


        public IActionResult Search()
        {
            SearchPersonViewModel model= new SearchPersonViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SearchPersonViewModel values)
        {
            SearchPersonViewModel model = new SearchPersonViewModel();
            model.SearchPerson = _context.Person.Where(p => p.FirstName.Contains(values.SearchValue)).ToList();
            ModelState.Clear();
            return View(model);
        }
    }
}