using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bank.Data;

namespace Bank.Logic.Queries.GetCustomerByName
{
    public class GetCustomerByNameHandler
    {
        private readonly BankContext _context;

        public GetCustomerByNameHandler()
        {
            _context = new BankContext();
        }

        public int GetCountOfCustomers(string name)
        {
            var customers = _context.Customers.Where(c => c.Givenname == name).Count();

            return customers;
        }
    }
}