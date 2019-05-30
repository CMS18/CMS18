using Bank.Data;
using Bank.Domain.Entities;
using Bank.Logic.ViewModels;
using Bank.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly BankContext _context;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger, BankContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return NotFound();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Creating new user");

                var customer = new Customer
                {
                    Gender = cust.Gender,
                    Givenname = cust.Givenname,
                    Surname = cust.Surname,
                    Streetaddress = cust.Streetaddress,
                    City = cust.City,
                    Zipcode = cust.Zipcode,
                    Country = cust.Country,
                    CountryCode = cust.CountryCode,
                    Birthday = cust.Birthday,
                    NationalId = cust.NationalId,
                    Telephonenumber = cust.Telephonenumber,
                    Telephonecountrycode = cust.Telephonecountrycode,
                    Emailaddress = cust.Emailaddress
                };

                var account = new Account
                {
                    Frequency = "Monthly",
                    Created = DateTime.Now,
                    Balance = 0
                };

                var disposition = new Disposition
                {
                    Account = account,
                    Customer = customer,
                    Type = "OWNER",
                };

                _context.Dispositions.Add(disposition);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Withdraw(int id)
        {
            var model = new TransactionViewModel
            {
                Account = _context.Accounts.SingleOrDefault(x => x.AccountId == id)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(TransactionViewModel values)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Creating transaction");
                var account = _context.Accounts.SingleOrDefault(a => a.AccountId == values.Account.AccountId);
                if (values.Transaction.Amount > account.Balance)
                {
                    TempData["alertMessage"] = "You can't withdraw more than what is currently in your account";
                }
                else
                {
                    values.Transaction.AccountId = values.Account.AccountId;
                    values.Transaction.Date = DateTime.Now;
                    values.Transaction.Date.ToShortDateString();
                    values.Transaction.Type = "Debit";
                    values.Transaction.Operation = "Withdrawal in Cash";

                    values.Account.Frequency = account.Frequency;
                    values.Account.Created = account.Created;
                    values.Transaction.Balance = account.Balance + (-(values.Transaction.Amount));
                    values.Account.Balance = values.Transaction.Balance;
                    _context.Entry(account).CurrentValues.SetValues(values.Account);

                    _context.Transactions.Add(values.Transaction);
                    _context.SaveChanges();
                    ModelState.Clear();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}