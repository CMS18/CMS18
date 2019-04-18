using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Webshop.IdentityData;
using Webshop.Models;
using Webshop.ViewModels;

namespace Webshop.Controllers
{
    [Authorize]
    public class WebshopController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private TomasosContext _context { get; set; }

        public WebshopController(TomasosContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult AddProductToCart(int id)
        {
            List<MealViewModel> cartList;
            var newProduct = GetMeals().SingleOrDefault(p => p.Matratt.MatrattId == id);

            switch (HttpContext.Session.GetString("cart"))
            {
                case null:
                    cartList = new List<MealViewModel>();
                    break;

                default:
                    {
                        var tempCart = HttpContext.Session.GetString("cart");
                        cartList = JsonConvert.DeserializeObject<List<MealViewModel>>(tempCart);
                        break;
                    }
            }

            cartList.Add(newProduct);

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartList, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));

            return PartialView("_CartDetails", cartList);
        }

        public IActionResult Checkout()
        {
            var cartValues = HttpContext.Session.GetString("cart");

            //Konvertera från json till en lista av produkter
            List<MealViewModel> model = JsonConvert.DeserializeObject<List<MealViewModel>>(cartValues);

            return View(model);
        }

        public List<MealViewModel> GetMeals()
        {
            List<MealViewModel> MealList = new List<MealViewModel>();

            foreach (var meal in _context.Matratt.ToList())
            {
                MealList.Add(new MealViewModel
                {
                    Matratt = meal,
                    Category = _context.MatrattTyp.SingleOrDefault(x => x.MatrattTyp1 == meal.MatrattTyp),
                    Ingredients = (from p in _context.Produkt join mp in _context.MatrattProdukt on p.ProduktId equals mp.ProduktId where mp.MatrattId == meal.MatrattId select p).ToList()
                });
            }
            return MealList;
        }

        public IActionResult Webshop()
        {
            var MealList = GetMeals();

            return View(MealList);
        }

        //**GAMMAL ORDERHANTERING**

        //public async Task<IActionResult> ConfirmOrder()
        //{
        //    List<MealViewModel> cart;
        //    var currentUser = await _userManager.GetUserAsync(HttpContext.User);

        //    var temp = HttpContext.Session.GetString("cart");
        //    cart = JsonConvert.DeserializeObject<List<MealViewModel>>(temp);

        //    var cartList = cart.Select(x => x.Matratt.MatrattId).Distinct().ToList();
        //    List<MealViewModel> cartMeal = new List<MealViewModel>();

        //    foreach (var item in cartList)
        //    {
        //        var query = (from c in cart where c.Matratt.MatrattId == item select c).First();
        //        cartMeal.Add(query);
        //    }

        //    var order = new Bestallning
        //    {
        //        KundId = currentUser.Id,
        //        BestallningDatum = DateTime.Now,
        //        Levererad = false,
        //        Totalbelopp = cart.Sum(x => x.Matratt.Pris),

        //    };

        //    _context.Bestallning.Add(order);

        //    var mealOrder = new BestallningMatratt();

        //    foreach (var item in cartMeal)
        //    {
        //        mealOrder = new BestallningMatratt
        //        {
        //            BestallningId = order.BestallningId,
        //            Antal = cart.Where(x => x.Matratt.MatrattId == item.Matratt.MatrattId).Count(),
        //            MatrattId = item.Matratt.MatrattId,

        //        };
        //        _context.BestallningMatratt.Add(mealOrder);
        //    }

        //    //Ta fram värden från sessionsvariabeln
        //    var cartValues = HttpContext.Session.GetString("cart");

        //    //Konvertera från json till en lista av produkter
        //    List<BestallningMatratt> model = JsonConvert.DeserializeObject<List<BestallningMatratt>>(cartValues);

        //    return View(cartValues);

        //}
    }
}