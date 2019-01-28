using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreFormulär3.Models;
using ASPNETCoreFormulär3.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETCoreIntro2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PersonViewModel model = new PersonViewModel();
            model.Regions.Add(new SelectListItem
            {
                Text = "Norrbotten", 
                Value="1"
                
                });
            model.Regions.Add(new SelectListItem
            {
                Text = "Stockholm",
                Value = "2"

            });
            model.Regions.Add(new SelectListItem
            {
                Text = "Skåne",
                Value = "3"

            });
            model.Regions.Add(new SelectListItem
            {
                Text = "Östergötland",
                Value = "4"

            });
            model.Regions.Add(new SelectListItem
            {
                Text = "Värmland",
                Value = "5"

            });

            model.PersonTypes.Add(new PersonType(1, "Student"));
            model.PersonTypes.Add(new PersonType(2, "Barn"));
            model.PersonTypes.Add(new PersonType(3, "Vuxen"));
            model.PersonTypes.Add(new PersonType(4, "Pensionär"));

            return View(model);
        }

        [HttpPost]
        public IActionResult CreatePerson(PersonViewModel person)
        {

            return View();
        }
    }
}