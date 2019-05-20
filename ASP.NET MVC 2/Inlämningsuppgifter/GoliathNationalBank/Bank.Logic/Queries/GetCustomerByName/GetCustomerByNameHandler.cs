using Bank.Data;
using Bank.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Logic.Queries.GetCustomerByName
{
    public interface IBankRepository
    {
        Customer GetCustomer(int id);

        int GetCountOfCustomers(string name);

        IEnumerable<Disposition> GetDispositions(int customerId);

        Account GetAccount(int id);
    }

    public class BankRepository : IBankRepository
    {
        private readonly BankContext _context;

        public BankRepository(BankContext bankContext)
        {
            _context = bankContext;
        }

        public Account GetAccount(int id)
        {
            return _context.Accounts.FirstOrDefault(a => id == a.AccountId);
        }

        public int GetCountOfCustomers(string name)
        {
            var customers = _context.Customers.Where(c => c.Givenname == name).Count();

            return customers;
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault(c => id == c.CustomerId);
        }

        public IEnumerable<Disposition> GetDispositions(int customerId)
        {
            return _context.Dispositions.Where(d => d.CustomerId == customerId);
        }
    }
}