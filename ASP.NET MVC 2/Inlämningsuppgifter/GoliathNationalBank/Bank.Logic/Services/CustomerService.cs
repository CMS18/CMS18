using Bank.Logic.Queries;
using Bank.Logic.ViewModels;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Bank.Logic.Services
{
    public interface ICustomerService
    {
        CustomerViewModel SearchForCustomer(string name, string city);

        CustomerViewModel CustomerDetails(int customerId);

        CustomerViewModel GetStatistics();
    }

    public class CustomerService : ICustomerService
    {
        private readonly IBankRepository _customerInfo;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IBankRepository customerInfo, ILogger<CustomerService> logger)
        {
            _customerInfo = customerInfo;
            _logger = logger;
        }

        public CustomerViewModel GetStatistics()
        {
            _logger.LogInformation($"Fetching statistics");

            var model = new CustomerViewModel
            {
                CountOfAccounts = _customerInfo.GetCountOfAccounts(),
                CountOfCustomers = _customerInfo.GetCountOfCustomers(),
                TotalBalance = _customerInfo.SumOfAccounts()
            };

            return model;
        }

        public CustomerViewModel SearchForCustomer(string name, string city)
        {
            _logger.LogInformation($"Getting customer info for user {name}");

            var model = new CustomerViewModel();

            var customer = _customerInfo.GetCustomer(name, city);

            foreach (var item in customer)
            {
                model.Customers.Add(item);
            };

            return model;
        }

        public CustomerViewModel CustomerDetails(int id)
        {
            _logger.LogInformation($"Getting customer info for user {id}");

            var customer = _customerInfo.ViewCustomerDetails(id);
            var model = new CustomerViewModel
            {
                City = customer.City,
                Streetaddress = customer.Streetaddress,
                DoB = customer.Birthday,
                Country = customer.Country,
                Email = customer.Emailaddress,
                ZipCode = customer.Zipcode,
                NationalId = customer.NationalId,
                TelephoneCountryCode = customer.Telephonecountrycode,
                Phonenumber = customer.Telephonenumber
            };
            var dispositions = _customerInfo.GetDispositions(id);

            var accounts = dispositions.Select(d => _customerInfo.GetAccount(d.AccountId));

            var name = $"{customer.Givenname} {customer.Surname}";

            model.CustomerName = name;
            model.Accounts = accounts.Select(a => new BankAccountViewModel
            {
                Id = a.AccountId,
                Balance = a.Balance,
                Name = name,
            });
            model.TotalBalance = accounts.Sum(c => c.Balance);

            return model;
        }
    }
}