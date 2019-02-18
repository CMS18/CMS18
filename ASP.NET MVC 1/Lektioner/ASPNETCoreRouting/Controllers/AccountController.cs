using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreRouting.Controllers
{
    public class AccountController : Controller
    {
        [Route("Login")]
        public IActionResult VerifyUser()
        {
            return View();
        }
    }
}