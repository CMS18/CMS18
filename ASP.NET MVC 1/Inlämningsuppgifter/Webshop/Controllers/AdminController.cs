using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webshop.Models;
using Webshop.ViewModels;

namespace Webshop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        private TomasosContext _context;
        public AdminController(TomasosContext context)
        {
            _context = context;
        }
        public IActionResult Admin()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddIngredient(AddIngredientViewModel product)
        {            
            if (ModelState.IsValid)
            {
                var checkIngredient = _context.Produkt.Any(i => i.ProduktNamn.Equals(product.NewIngredient));
                if (!checkIngredient)
                {
                    _context.Produkt.Add(product.NewIngredient);
                    _context.SaveChanges();

                }
            }
            AddIngredientViewModel model = new AddIngredientViewModel
            {
                ListIngredients = _context.Produkt.ToList()
            };

            return PartialView("_Ingredients", model);
        }

        public IActionResult GetIngredients()
        {
            
            AddIngredientViewModel model = new AddIngredientViewModel
            {
                ListIngredients = _context.Produkt.ToList()
            };

            return PartialView("_Ingredients", model);
            //return View(model);

        }
    }
}