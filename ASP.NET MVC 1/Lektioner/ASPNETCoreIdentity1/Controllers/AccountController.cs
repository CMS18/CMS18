using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreIdentity1.Models;
using Microsoft.AspNetCore.Identity;
using ASPNETCoreIdentity1.ModelsIdentity;

namespace ASPNETCoreIdentity1.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            var userIdentity = new ApplicationUser
            {
                UserName = user.Username
            };

            var result = await _userManager.CreateAsync(userIdentity, user.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userIdentity, isPersistent: false);
            }

            return View();

        }
    }
}