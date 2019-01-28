using System;
using System.Globalization;
using System.IO;
using System.Threading;
using Console = Colorful.Console;

namespace Bank
{
    public class FileHandler : Database
    {
        public void SaveTransactions(Transaction transaction)
        {
            using (var writer = new StreamWriter("TransactionLog.txt", true))
            {
                var line = string.Join(";",
                    transaction.Date,
                    transaction.Sender.ToString(),
                    transaction.Receiver.ToString(),
                    transaction.Amount.ToString(CultureInfo.InvariantCulture),
                    transaction.CurrentBalance.ToString(CultureInfo.InvariantCulture),
                    transaction.Type);
                writer.WriteLine(line);
            }
        }


        public void SaveInfo()
        {
            var date = DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt";
            using (var writer = new StreamWriter(date))
            {
                writer.WriteLine(Customers.Count);
                foreach (var c in Customers)
                {
                    writer.WriteLine(
                        $"{c.Id};" +
                        $"{c.OrganizationId};" +
                        $"{c.Name};" +
                        $"{c.Address};" +
                        $"{c.City};" +
                        $"{c.Region};" +
                        $"{c.ZipCode};" +
                        $"{c.Country};" +
                        $"{c.PhoneNumber}");
                }

                writer.WriteLine(Accounts.Count);
                foreach (var a in Accounts)
                {
                    writer.WriteLine(
                        $"{a.Id};" +
                        $"{a.CustomerId};" +
                        $"{a.Balance.ToString(CultureInfo.InvariantCulture)}");
                }
            }

            Console.WriteLine($"\nFile saved as {date}");
            GetData();
            Thread.Sleep(500);
        }

        public void ReadInfo(string path)
        {
            using (var reader = new StreamReader(path))
            {
                int customersCount = int.Parse(reader.ReadLine());

                for (int i = 0; i < customersCount; i++)
                {
                    string line = reader.ReadLine();
                    string[] columns = line.Split(';');

                    var customer = new Customer
                    {
                        Id = int.Parse(columns[0]),
                        OrganizationId = columns[1],
                        Name = columns[2],
                        Address = columns[3],
                        City = columns[4],
                        Region = columns[5],
                        ZipCode = columns[6],
                        Country = columns[7],
                        PhoneNumber = columns[8]
                    };

                    Customers.Add(customer);
                }

                var countOfAccounts = int.Parse(reader.ReadLine());

                for (int i = 0; i < countOfAccounts; i++)
                {
                    string line = reader.ReadLine();
                    string[] columns = line.Split(';');

                    var account = new Account
                    (int.Parse(columns[0]),
                        int.Parse(columns[1]),
                        decimal.Parse(columns[2], CultureInfo.InvariantCulture));

                    Accounts.Add(account);
                }
            }
        }

    }
}
