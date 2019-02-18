using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Webshop.IdentityData;
using Webshop.Models;
using Microsoft.AspNetCore.Authorization;

namespace Webshop.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public IActionResult Register()
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

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userIdentity, isPersistent: false);
            }

            return View();
        }

        private async Task createRole(string roleName)
        {
            //bool x = await _roleManager.RoleExistsAsync(roleName);
            var role = new IdentityRole();
            role.Name = roleName;
            await _roleManager.CreateAsync(role);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegisterUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Webshop");
            }
            return View();
        }
    }
}