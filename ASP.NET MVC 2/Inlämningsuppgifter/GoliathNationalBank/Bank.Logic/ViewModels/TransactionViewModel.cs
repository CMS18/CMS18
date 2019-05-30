using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Logic.ViewModels
{
    public class TransactionViewModel
    {
        public Account Account { get; set; }
        public Transaction Transaction { get; set; }

        public TransactionViewModel()
        {
            Account = new Account();
            Transaction = new Transaction();
        }
    }
}