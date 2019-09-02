using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Logic.ViewModels
{
    public class TransferViewModel
    {
        public Transaction Transaction { get; set; }
        public decimal Amount { get; set; }

        public TransferViewModel()
        {
            Transaction = new Transaction();
            Amount = 0;
        }
    }
}