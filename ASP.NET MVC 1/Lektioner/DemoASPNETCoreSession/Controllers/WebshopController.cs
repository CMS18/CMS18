using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoASPNETCoreSession.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoASPNETCoreSession.Controllers
{
    public class WebshopController : Controller
    {

        public IActionResult ViewProducts()
        {
            //Visa en lista med produkter
            return View(GetData());
        }


        public IActionResult AddProduct(int id)
        {
            List<Product> cartList;

            //Hämta vald produkt från datakällan
            Product selectedProduct = GetData().SingleOrDefault(p => p.ID == id);
            

            //Om det är första produkten som skall läggas till är varukorgen tom dvs = null
            if (HttpContext.Session.GetString("Cart") == null)
            {
                cartList = new List<Product>();
            }
            else
            {
                //Om det inte är första produkten. Ta fram JSON värden från sessionsvariabeln
                var cartValues = HttpContext.Session.GetString("Cart");

                //Gör om json värden till den datatyp som vi vill arbeta med
                cartList = JsonConvert.DeserializeObject<List<Product>>(cartValues);
            }

            //Lägger till produkten i listan
            cartList.Add(selectedProduct);

            //Gör om vår produktlista till JSON
            var values = JsonConvert.SerializeObject(cartList);

            //Lägg in värdena i sessionsvariabeln
            HttpContext.Session.SetString("Cart", values);

            //Skicka tillbaka till vyn med produkter
            return RedirectToAction("ViewProducts");
        }

        public IActionResult Checkout()
        {
            //Ta fram värden från sessionsvariabeln
            var cartValues = HttpContext.Session.GetString("Cart");

            //Konvertera från json till en lista av produkter
            List<Product> model = JsonConvert.DeserializeObject<List<Product>>(cartValues);

            return View(model);
        }


        private List<Product> GetData()
        {
            //Vanligtvis hämtas detta från en databas
            List<Product> prodlist = new List<Product>
            {
                new Product(1, "Iphone 6", 5000),
                new Product(2, "Samasung Galaxy", 6000),
                new Product(3, "Huawei Honor", 7000)
            };


            return prodlist;

        }

    }
}
