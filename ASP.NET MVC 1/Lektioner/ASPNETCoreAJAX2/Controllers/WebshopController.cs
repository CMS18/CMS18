using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreAJAX2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace ASPNETCoreAJAX2.Controllers
{
    public class WebshopController : Controller
    {

        public IActionResult ViewProducts()
        {
            return View(ProductList());
        }


        public IActionResult AddProductToCart(int id)
        {
            List<Product> cartList;
            var newProduct = ProductList().SingleOrDefault(p => p.ID == id);
            

            switch (HttpContext.Session.GetString("cart"))
            {
                case null:
                    cartList = new List<Product>();
                    break;
                default:
                    {
                        var tempCart = HttpContext.Session.GetString("cart");
                        cartList = JsonConvert.DeserializeObject<List<Product>>(tempCart);
                        break;
                    }
            }

            cartList.Add(newProduct);

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartList));

            return PartialView("_CartDetails", cartList);
        }

        private List<Product> ProductList()
        {
            List<Product> allProducts = new List<Product>()
            {
                new Product {
                    ID=1, 
                    Name="Iphone 6", 
                    Price=5995, 
                    Description= "iPhone 6s kommer med en 4,7” Retina-skärm med HD-upplösning och 3D Touch. Denär gjord av aluminium i 7000-serien och starkare glas än tidigare. Den har enA9-processor med 64 bit arkitektur, som i en stationär dator, en iSight-kamerapå 12 MP med Live Photos, Touch ID, snabbare 4G LTEoch Wi-Fi1, långbatteritid2, iOS 9 och iCloud. Allt detta i en förstärkt unibody-design medövergångar som är så diskreta att de inte märks."
                    
                    },

                new Product {
                    ID=2, 
                    Name="Samsung Galaxy", 
                    Price=4995, 
                    Description="Denna eleganta Samsung Galaxy A3 (2016) smartphone har en 4,7 tumstor Super AMOLED HD - skärm och 13 - megapixel kamerasom tar fantastiska fotonoch Full HD-videor. 4.7 Super AMOLED HD - skärm13 - MP,Full HD-videor.Långbatteritid" 
                    
                    },

                new Product
                {
                    ID = 3,
                    Name = "Huawei",
                    Price = 4995,
                    Description = "Superslimmad smartphone med 5 Full HD-skärm,quad core - processor,4G och dubbla kameror. 5 Full HD - skärm Android 4.4.2 KitKat 13 - megapixelkamera"
                }
            };
            return allProducts;
        }
}
}