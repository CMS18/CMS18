using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Transaction
    {
        public string Date { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Type { get; set; }

        public Transaction(string dateOfTransfer, int senderId, int receiverId, decimal currency, decimal currentBalance, string typeOfTransfer)
        {
            Date = dateOfTransfer;
            Sender = senderId;
            Receiver = receiverId;
            Amount = currency;
            CurrentBalance = currentBalance;
            Type = typeOfTransfer;
        }
    }
}
