using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreIdentity2.Models;
using Microsoft.AspNetCore.Identity;
using ASPNETCoreIdentity2.ModelsIdentity;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCoreIdentity2.Controllers
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

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            var userIdentity = new ApplicationUser
            {
                UserName = user.Username
            };

            var result = await _userManager.CreateAsync(userIdentity, user.Password);

            var resultRole = await _userManager.AddToRoleAsync(userIdentity, user.RoleName);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userIdentity, isPersistent: false);
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(RegisterUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}