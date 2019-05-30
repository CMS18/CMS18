using Bank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank.Logic.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            Customers = new List<Customer>();
            Transactions = new List<Transaction>();
        }

        public string CustomerName { get; set; }
        public int CountOfCustomers { get; set; }
        public int CountOfAccounts { get; set; }
        public decimal TotalBalance { get; set; }

        /// <summary>
        /// PAGING
        /// </summary>
        public int CurrentPage { get; set; }

        public int AccountId { get; set; }

        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        /// <summary>
        /// Customer Info
        /// </summary>
        public string Streetaddress { get; set; }

        public string Givenname { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public DateTime? Birthday { get; set; }
        public string NationalId { get; set; }
        public string Emailaddress { get; set; }
        public string Telephonecountrycode { get; set; }
        public string Telephonenumber { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public IEnumerable<BankAccountViewModel> Accounts { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public AccountViewModel AccountViewModel { get; set; }
        public BankAccountViewModel BankAccount { get; set; }
    }
}