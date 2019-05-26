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

        public IActionResult Index()
        {
            return View(_customerService.GetStatistics());
        }

        [HttpGet]
        [Route("Search/")]
        public IActionResult SearchCustomer([FromQuery]string name, [FromQuery]string city)
        {
            return View(_customerService.SearchForCustomer(name, city));
        }

        [Route("Customer/{id}")]
        public IActionResult CustomerDetails(int id)
        {
            return View(_customerService.CustomerDetails(id));
        }
    }
}