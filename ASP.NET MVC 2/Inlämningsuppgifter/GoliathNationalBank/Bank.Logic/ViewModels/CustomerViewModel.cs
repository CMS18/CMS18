using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Logic.ViewModels
{
    public class CustomerViewModel
    {
        public string CustomerName { get; set; }
        public IEnumerable<BankAccountViewModel> Accounts { get; set; }
    }
}