using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tentamen.Models;
using Tentamen.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tentamen.Controllers
{
    public class Uppgift1Controller : Controller
    {
        public IActionResult Index()
        {
            var model = new NewBookViewModel();
            {
                model.Categories.Add(new SelectListItem { Text = "Barn", Value = "1" });
                model.Categories.Add(new SelectListItem { Text = "Deckare", Value = "2" });
                model.Categories.Add(new SelectListItem { Text = "Roman", Value = "3" });
                model.Categories.Add(new SelectListItem { Text = "Fakta", Value = "4" });


                model.Stock.Add(new InStock(1, "I lager"));
                model.Stock.Add(new InStock(2, "Ej i lager"));

            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatedBook(NewBookViewModel values)
        {                

            if (ModelState.IsValid)
            {
                return View(values);

            }

            return View();
        }
    }
}