using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uppgift1.Models;

namespace Uppgift1.Controllers
{
    public class Uppgift1Controller : Controller
    {
        public IActionResult Index()
        {
            var model = new Favourites();
            model.Seasons.Add("Vår");
            model.Seasons.Add("Sommar");
            model.Seasons.Add("Höst");
            model.Seasons.Add("Vinter");

            model.Candies.Add("Center");
            model.Candies.Add("Colaflaskor");
            model.Candies.Add("Plopp");
            model.Candies.Add("Gelehallon");
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFavourite(Favourites fav)
        {

            if (ModelState.IsValid)
            {
                var model = new Favourites
                {
                    Name = fav.Name,
                    Candy = fav.Candy,
                    Season = fav.Season

                };

                return View("AddFavourite", model);
            }
            else
            {
                return View("Index");
            }

        }


    }
}
