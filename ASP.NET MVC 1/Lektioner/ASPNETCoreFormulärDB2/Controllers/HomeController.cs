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
        private PeronDBContext _context;

        public HomeController(PeronDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewPersonList()
        {

            List<Person> model = _context.Person.ToList();

            return View(model);
        }

        public IActionResult ViewPerson(int id)
        {
            var model = _context.Person.SingleOrDefault(p => p.PersonId == id);
            return View(model);
        }

        public IActionResult Update(Person newPersonValues)
        {
            var oldPersonValues = _context.Person.SingleOrDefault(p => p.PersonId == newPersonValues.PersonId);

            // Dåligt och gammalt sätt att skriva
            //oldPersonValues.FirstName = newPersonValues.FirstName;
            //oldPersonValues.Email = newPersonValues.Email;

            //Bättre och snyggare
            _context.Entry(oldPersonValues).CurrentValues.SetValues(newPersonValues);

            // Sparar alla ändringar
            _context.SaveChanges();

            return View();
        }

        public IActionResult Remove(int id)
        {
            var person = _context.Person.SingleOrDefault(p => p.PersonId == id);

            _context.Person.Remove(person);
            _context.SaveChanges();
            return View();
        }
    }
}