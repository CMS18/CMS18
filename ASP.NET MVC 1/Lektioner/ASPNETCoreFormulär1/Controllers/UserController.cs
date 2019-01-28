using Microsoft.AspNetCore.Mvc;
using ASPNETCoreFormulär1.Models;

namespace ASPNETCoreFormulär1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserInfo values)
        {
            if (values == null)
            {
                throw new System.ArgumentNullException(nameof(values));
            }

            //Gammal syntax
            var username = Request.Form["Username"];

            //Gör någon kontroll. Typ checka databasen.
            return View("Welcome", values);
        }
    }
}