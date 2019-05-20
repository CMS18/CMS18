using Bank.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index([FromQuery]int customerId = 1337)
        {
            return Ok(_customerService.GetCustomer(customerId));
        }
    }
}