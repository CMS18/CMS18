using Bank.Domain.Entities;
using Bank.Logic.Queries;
using Bank.Logic.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace Bank.Logic.Services
{
    public interface ICustomerService
    {
        CustomerViewModel SearchForCustomer(string name, string city, int currentPage, int pageSize = 10);

        CustomerViewModel CustomerDetails(int customerId);

        CustomerViewModel GetStatistics();

        CustomerViewModel TransactionDetails(int id, int page);
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
                CountOfAccounts = _customerInfo.CountOfAllAcounts(),
                CountOfCustomers = _customerInfo.CountOfAllCustomers(),
                TotalBalance = _customerInfo.SumOfAccounts()
            };

            return model;
        }

        public CustomerViewModel SearchForCustomer(string name, string city, int currentPage, int pageSize = 10)
        {
            _logger.LogInformation($"Getting customer info for user {name}");

            var model = new CustomerViewModel
            {
                Count = _customerInfo.GetCustomer(name, city).Count(),
                CustomerName = name,
                City = city,
            };
            List<Customer> customer;

            if (currentPage == 0)
            {
                customer = _customerInfo.GetCustomer(name, city).Skip(currentPage * pageSize).Take(pageSize).ToList();
            }
            else
            {
                customer = _customerInfo.GetCustomer(name, city).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            }

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
                Birthday = customer.Birthday,
                Country = customer.Country,
                Emailaddress = customer.Emailaddress,
                Zipcode = customer.Zipcode,
                NationalId = customer.NationalId,
                CustomerID = id,
            };
            var dispositions = _customerInfo.GetDispositions(id);

            var accounts = dispositions.Select(d => _customerInfo.GetAccount(d.AccountId));

            var name = $"{customer.Givenname} {customer.Surname}";

            model.CustomerName = name;
            model.Accounts = accounts.Select(a => new Account
            {
                AccountId = a.AccountId,
                Balance = a.Balance,
            });

            model.TotalBalance = accounts.Sum(c => c.Balance);

            return model;
        }

        public CustomerViewModel TransactionDetails(int id, int currentPage)
        {
            const int pageSize = 20;

            _logger.LogInformation($"Getting transaction details for account {id}");

            var model = new CustomerViewModel
            {
                AccountId = id,
                Count = _customerInfo.GetTransactions(id).Count(),
                CurrentPage = currentPage,
            };
            List<Transaction> transactions;

            transactions = _customerInfo.GetTransactions(id).Skip(currentPage * pageSize).Take(pageSize).ToList();

            foreach (var item in transactions)
            {
                model.Transactions.Add(item);
            }

            return model;
        }
    }
}