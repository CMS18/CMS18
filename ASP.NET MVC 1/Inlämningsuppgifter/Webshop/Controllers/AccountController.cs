using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webshop.IdentityData;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private TomasosContext _context { get; set; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TomasosContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
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
                UserName = user.Username,
                Address = user.Address,
                City = user.City,
                ZipCode = user.ZipCode,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Email = user.Email,
            };

            var result = await _userManager.CreateAsync(userIdentity, user.Password);
            await _userManager.AddToRoleAsync(userIdentity, "RegularUser");

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userIdentity, isPersistent: false);
                return RedirectToAction("Webshop", "Webshop");
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UserDetails()
        {
            var user = await _userManager.GetUserAsync(User);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserDetails(ApplicationUser user)
        {
            var model = await _userManager.GetUserAsync(User);

            model.Name = user.Name;
            model.ZipCode = user.ZipCode;
            model.Address = user.Address;
            model.Email = user.Email;
            model.City = user.City;
            model.PhoneNumber = user.PhoneNumber;

            IdentityResult result = await _userManager.UpdateAsync(model);

            if (result.Succeeded)
            {
                return View("UserDetails");
            }

            return View("UserDetails");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Webshop", "Webshop");
            }
            return View();
        }
    }
}