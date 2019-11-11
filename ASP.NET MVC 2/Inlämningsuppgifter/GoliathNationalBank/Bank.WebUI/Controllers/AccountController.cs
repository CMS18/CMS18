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

        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountViewModel user)
        {
            if (user.Password == user.PasswordCheck)
            {
                if (ModelState.IsValid)
                {
                    var userIdentity = new IdentityUser { UserName = user.Username };

                    var _user = await _userManager.FindByNameAsync(user.Username);
                    if (_user == null)
                    {
                        var newUser = await _userManager.CreateAsync(userIdentity, user.Password);
                        if (newUser.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(userIdentity, user.Role);
                            _logger.LogInformation($"{userIdentity} created.");

                            ViewData["Message"] = "User created";
                        }
                        else
                        {
                            ViewData["Message"] = "User already in database";
                        }
                    }
                }

                return View();
            }

            ViewData["Message"] = "Password doesn't match. Try again";
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Cashier")]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cashier")]
        public IActionResult CreateCustomer(CustomerViewModel cust)
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

                TempData["Message"] = "User created";

                _context.Dispositions.Add(disposition);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            TempData["Message"] = "User already in database";
            return View(cust);
        }

        [Authorize(Roles = "Cashier")]
        public IActionResult EditCustomer(int id)
        {
            var model = new CustomerViewModel
            {
                Customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomer(CustomerViewModel cust)
        {
            if (ModelState.IsValid)
            {
                var old = _context.Customers.SingleOrDefault(c => c.CustomerId == cust.CustomerID);

                _context.Entry(old).CurrentValues.SetValues(cust);
                _context.SaveChanges();
                ModelState.Clear();

                TempData["Message"] = "User updated";

                return View(cust);
            }
            TempData["Message"] = "User not updated. Please check values";
            return View(cust);
        }

        [Authorize(Roles = "Cashier")]
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
                if (values.Transaction.Amount > account.Balance || values.Transaction.Amount < 0M)
                {
                    values.Account.Balance = account.Balance;
                    TempData["alertMessage"] = "You can't withdraw more than what is currently in your account or negative amounts";
                    return View(values);
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
                    values.Transaction.Balance = account.Balance + (-values.Transaction.Amount);
                    values.Account.Balance = values.Transaction.Balance;
                    _context.Entry(account).CurrentValues.SetValues(values.Account);

                    _context.Transactions.Add(values.Transaction);
                    _context.SaveChanges();
                    TempData["alertMessage"] = "Withdrawl complete";

                    ModelState.Clear();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [Authorize(Roles = "Cashier")]
        public IActionResult Deposit(int id)
        {
            var model = new TransactionViewModel()
            {
                Account = _context.Accounts.SingleOrDefault(a => a.AccountId == id)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TransactionViewModel values)
        {
            if (ModelState.IsValid)
            {
                var account = _context.Accounts.SingleOrDefault(a => a.AccountId == values.Account.AccountId);
                if (values.Transaction.Amount < 0M)
                {
                    values.Account.Balance = account.Balance;
                    TempData["ErrorMessage"] = "You can't deposit negative values";
                    return View(values);
                }
                else
                {
                    values.Transaction.AccountId = values.Account.AccountId;
                    values.Transaction.Date = DateTime.Now;
                    values.Transaction.Date.ToShortDateString();
                    values.Transaction.Type = "Credit";
                    values.Transaction.Operation = "Credit in Cash";

                    values.Account.Frequency = account.Frequency;
                    values.Account.Created = account.Created;
                    values.Transaction.Balance = account.Balance + values.Transaction.Amount;
                    values.Account.Balance = values.Transaction.Balance;
                    _context.Entry(account).CurrentValues.SetValues(values.Account);

                    _context.Transactions.Add(values.Transaction);
                    _context.SaveChanges();
                    ModelState.Clear();
                    TempData["ErrorMessage"] = "Deposit complete";

                    return View(values);
                }
            }

            return View();
        }

        [Authorize(Roles = "Cashier")]
        public IActionResult Transfer(int id)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.AccountId == id);
            var model = new Transaction()
            {
                AccountId = id,
                Balance = account.Balance
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(Transaction values)
        {
            if (ModelState.IsValid)
            {
                if (values.Amount < 0M)
                {
                    TempData["ErrorMessage"] = "You can't deposit negative values";
                    return View(values);
                }
                else
                {
                    var transfer = new TransferViewModel
                    {
                        Transaction = values,
                        Amount = values.Amount,
                    };

                    var from = new Transaction();
                    from = values;
                    from.Date = DateTime.Now;
                    from.Date.ToShortDateString();
                    from.Type = "Debit";
                    from.Operation = "Remittance to Another Bank";

                    var to = new Transaction
                    {
                        AccountId = int.Parse(values.Account),
                        Date = from.Date,
                        Type = "Credit",
                        Operation = "Collection from Another Bank",
                        Amount = values.Amount,
                        Symbol = values.Symbol,
                        Bank = values.Bank,
                        Account = values.AccountId.ToString()
                    };

                    var oldTo = _context.Accounts.SingleOrDefault(a => a.AccountId == int.Parse(values.Account));

                    var newTo = oldTo;
                    newTo.Balance = oldTo.Balance + values.Amount;
                    to.Balance = newTo.Balance;

                    var oldFrom = _context.Accounts.SingleOrDefault(a => a.AccountId == values.AccountId);
                    if (oldFrom.Balance < values.Amount)
                    {
                        TempData["ErrorMessage"] = "Amount is too high";
                    }

                    from.Amount = (-(values.Amount));
                    var newFrom = oldFrom;
                    newFrom.Balance = oldFrom.Balance + (values.Amount);
                    from.Balance = newFrom.Balance;

                    _context.Entry(oldFrom).CurrentValues.SetValues(newFrom);
                    _context.Entry(oldTo).CurrentValues.SetValues(newTo);
                    _context.Transactions.Add(from);
                    _context.Transactions.Add(to);
                    _context.SaveChanges();
                    TempData["ErrorMessage"] = "Transfer complete";

                    return View(values);
                }
            }

            return View("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}