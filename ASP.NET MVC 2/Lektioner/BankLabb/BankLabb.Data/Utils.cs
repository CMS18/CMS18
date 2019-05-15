using BankLabb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankLabb.Data
{
    public class Utils
    {
        private readonly BankAppDataContext _context;
        private readonly IList<Customer> allCustomers;

        public Utils()
        {
            _context = new BankAppDataContext();
        }

        private int pageNumber = 0;
        private int linesPerPage = 0;

        public int GetCountOfCustomers(string name)
        {
            var customers = _context.Customers.Where(c => c.Givenname == name).Count();

            return customers;
        }

        public IList<Customer> GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }
    }
}