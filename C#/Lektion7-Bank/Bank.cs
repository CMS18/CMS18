using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion7_Bank
{
    class Bank
    {
        static Random rnd = new Random();
        int accNumber = rnd.Next(1, 9);
        public string Name { get; set; }

        public Dictionary<string, Account> Accounts { get; private set; }

        public Bank()
        {
            Accounts = new Dictionary<string, Account>();
        }

        public Bank(Account account)
        {
            Accounts.Add(accNumber.ToString(), account);
        }
            

    }

    
}
