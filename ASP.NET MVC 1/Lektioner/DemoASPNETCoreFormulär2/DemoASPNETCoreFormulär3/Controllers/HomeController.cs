using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoASPNETCoreFormulär3.Models;
using DemoASPNETCoreFormulär3.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoASPNETCoreFormulär3.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            PersonViewModel model = new PersonViewModel();

            //Fyller på med regioner som skall visas i dropdownlistan
            model.Regions.Add(new SelectListItem { Text = "Norrbotten", Value = "1" });
            model.Regions.Add(new SelectListItem { Text = "Stockholm", Value = "2" });
            model.Regions.Add(new SelectListItem { Text = "Skåne", Value = "3" });
            model.Regions.Add(new SelectListItem { Text = "Östergötland", Value = "4" });
            model.Regions.Add(new SelectListItem { Text = "Värmland", Value = "5" });

            //Värden som skall visas som radiobuttons
            model.PersonTypes.Add(new PersonType(1, "Student"));
            model.PersonTypes.Add(new PersonType(2, "Barn"));
            model.PersonTypes.Add(new PersonType(3, "Vuxen"));
            model.PersonTypes.Add(new PersonType(4, "Pensionär"));

            return View(model);
        }


        //Tar emor svaret från vyn. Formulärdata finns i CurrentPerson objektet
        [HttpPost]
        public IActionResult Createperson(PersonViewModel values)
        {
            return View(values);


        }
    }
}
