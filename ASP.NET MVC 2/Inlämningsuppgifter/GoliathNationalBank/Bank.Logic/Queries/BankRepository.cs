using Bank.Data;
using Bank.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bank.Logic.Queries
{
    public interface IBankRepository
    {
        IQueryable<Customer> GetCustomer(string name, string city);

        Customer ViewCustomerDetails(int id);

        int CountOfAllAcounts();

        int CountOfAllCustomers();

        IEnumerable<Disposition> GetDispositions(int customerId);

        Account GetAccount(int id);

        decimal SumOfAccounts();

        IQueryable<Transaction> GetTransactions(int id);
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
            return _context.Accounts.FirstOrDefault(a => a.AccountId == id);
        }

        public int CountOfAllAcounts()
        {
            var accounts = _context.Accounts.Count();

            return accounts;
        }

        public int CountOfAllCustomers()
        {
            var customers = _context.Customers.Count();

            return customers;
        }

        public decimal SumOfAccounts()
        {
            var balance = _context.Accounts.Sum(b => b.Balance);

            return balance;
        }

        public IQueryable<Customer> GetCustomer(string name, string city)
        {
            if (name == null && !(city == null))
            {
                return _context.Customers.OrderBy(i => i.Surname).Where(c => c.City == city);
            }
            else if (city == null && !(name == null))
            {
                return _context.Customers.OrderBy(i => i.Surname).Where(n => n.Givenname == name);
            }
            else if (!(city == null) && !(name == null))
            {
                return _context.Customers.Where(c => c.City == city).OrderBy(i => i.Surname).Where(n => n.Givenname == name);
            }
            else
            {
                return null;
            }
        }

        public Customer ViewCustomerDetails(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public IQueryable<Transaction> GetTransactions(int id)
        {
            return _context.Transactions.OrderByDescending(d => d.TransactionId).Where(t => t.AccountId == id);
        }

        public IEnumerable<Disposition> GetDispositions(int customerId)
        {
            return _context.Dispositions.Where(d => d.CustomerId == customerId);
        }
    }
}