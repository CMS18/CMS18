using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion7_Bank
{
    class Account : Bank
    {
        public decimal Balance { get; private set; }
        public string AccountNumber { get; private set; }

        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
        }
    }
}
