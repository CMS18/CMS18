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
        public IActionResult SearchCustomer([FromQuery]string name, [FromQuery]string city, int currentPage, int pageSize = 10)
        {
            return PartialView("_CustomerListPartial", _customerService.SearchForCustomer(name, city, currentPage, pageSize));
        }

        [HttpGet]
        [Route("Transactions/")]
        public IActionResult GetTransactions([FromQuery]int id, int currentPage)
        {
            return PartialView("_TransactionListPartial", _customerService.TransactionDetails(id, currentPage));
        }

        [HttpGet]
        [Route("Customer/{id}")]
        public IActionResult CustomerDetails(int id)
        {
            return View(_customerService.CustomerDetails(id));
        }
    }
}