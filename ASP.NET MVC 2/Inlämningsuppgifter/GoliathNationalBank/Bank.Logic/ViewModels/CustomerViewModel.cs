using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Logic.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            Customers = new List<Customer>();
        }

        public string CustomerName { get; set; }
        public int CountOfCustomers { get; set; }
        public int CountOfAccounts { get; set; }
        public decimal TotalBalance { get; set; }

        public string Streetaddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTime? DoB { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string TelephoneCountryCode { get; set; }
        public string Phonenumber { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public IEnumerable<BankAccountViewModel> Accounts { get; set; }

        public AccountViewModel AccountViewModel { get; set; }
    }
}