using System;

namespace Bank
{
    public class ConsoleUtils
    {
        public static int InputInt(string question)
        {
            Console.Write(question);
            do
            {
                var s = Console.ReadLine();
                if (int.TryParse(s, out var result)) return result;

                Console.Write(question);
            } while (true);
        }

        public static decimal InputDecimal(string question)
        {
            Console.Write(question);
            do
            {
                var amount = Console.ReadLine();
                if (decimal.TryParse(amount, out var currency)) return currency;

                Console.Write(question);
            } while (true);
        }

        public static Transaction SaveTransaction(Account acc, decimal currency, string input)
        {
            return new Transaction(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss "), acc.Id,
                acc.Id, decimal.Add(currency, 0.00M), acc.Balance, input);
        }

        public static Transaction SaveTransfer(Account acc, Account acc2, decimal balance, decimal currency, string input)
        {
            return new Transaction(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss "), acc.Id,
                acc2.Id, decimal.Add(currency, 0.00M), balance, input);
        }
    }
}