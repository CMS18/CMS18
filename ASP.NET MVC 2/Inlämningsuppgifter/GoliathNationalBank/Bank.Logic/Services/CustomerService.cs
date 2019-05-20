using Bank.Domain.Entities;
using Bank.Logic.Queries.GetCustomerByName;
using Bank.Logic.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank.Logic.Services
{
    public interface ICustomerService
    {
        CustomerViewModel GetCustomer(int customerId);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IBankRepository _getCustomerByNameHandler;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IBankRepository getCustomerByNameHandler, ILogger<CustomerService> logger)
        {
            _getCustomerByNameHandler = getCustomerByNameHandler;
            _logger = logger;
        }

        public CustomerViewModel GetCustomer(int customerId)
        {
            _logger.LogInformation($"get customer info for user {customerId}");

            var model = new CustomerViewModel();

            var customer = _getCustomerByNameHandler.GetCustomer(customerId);
            var dispositions = _getCustomerByNameHandler.GetDispositions(customerId);

            var accounts = dispositions.Select(d => _getCustomerByNameHandler.GetAccount(d.AccountId));

            model.CustomerName = $"{customer.Givenname} {customer.Surname}";
            model.Accounts = accounts.Select(a => new BankAccountViewModel
            {
                Id = a.AccountId,
                Balance = a.Balance,
                Name = $"{customer.Givenname} {customer.Surname}"
            });

            return model;
        }
    }
}