using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using Console = Colorful.Console;

namespace Bank
{
    public class Bank
    {
        private readonly FileHandler file = new FileHandler();

        public void StartBank(string path)
        {
            file.ReadInfo(path);
            PrintMenu();
        }

        private void PrintMenu()
        {
            Console.WriteLine(@"
        ______     __     __     ______     _____     ______     ______     __   __     __  __    
       /\  ___\   /\ \  _ \ \   /\  ___\   /\  __-.  /\  == \   /\  __ \   /\ ""-.\ \   /\ \/ /    
       \ \___  \  \ \ \/ "".\ \  \ \  __\   \ \ \/\ \ \ \  __<   \ \  __ \  \ \ \-.  \  \ \  _""-.  
        \/\_____\  \ \__/"".~\_\  \ \_____\  \ \____-  \ \_____\  \ \_\ \_\  \ \_\\""\_\  \ \_\ \_\ 
         \/_____/   \/_/   \/_/   \/_____/   \/____/   \/_____/   \/_/\/_/   \/_/ \/_/   \/_/\/_/ 
                                                                                           
", Color.Orchid);
            Console.Write("Getting customer data", Color.LightSteelBlue);
            for (var i = 0; i < 3; i++)
            {
                Thread.Sleep(800);
                Console.Write(".", Color.LightSteelBlue);
            }

            Thread.Sleep(500);
            file.GetData();
            ShowMenu();

            var input = string.Empty;
            while (input != "0" || input != "exit" || input != "EXIT")
            {
                Console.WriteLine();
                Console.Write("> ", Color.AntiqueWhite);
                input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                    case "exit":
                    case "EXIT":
                        Console.Write("Saving file", Color.LightSteelBlue);
                        for (var i = 0; i < 3; i++)
                        {
                            Thread.Sleep(800);
                            Console.Write(".", Color.LightSteelBlue);
                        }

                        System.Console.WriteLine();
                        file.SaveInfo();
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;

                    case "1":
                        file.SearchCustomers();

                        break;

                    case "2":

                        file.ShowCustomer();
                        break;

                    case "3":

                        file.CreateCustomer();
                        break;

                    case "4":

                        file.RemoveCustomer();
                        break;

                    case "5":

                        file.AddAccount();
                        break;

                    case "6":

                        file.RemoveAccount();
                        break;

                    case "7":

                        Deposit();
                        break;

                    case "8":

                        Withdraw();
                        break;

                    case "9":

                        TransferCash();
                        break;

                    case "10":

                        file.GetAccount();
                        break;

                    case "11":
                        AccountCredit();
                        break;

                    case "12":
                        ChangeDebit();
                        break;

                    case "13":
                        ChangeInterest();
                        break;

                    case "14":
                        AddInterest();
                        break;

                    case "menu":
                    case "M":
                    case "m":
                        ShowMenu();
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine(@"
                                   __________________________________________    
                                  | Main menu                                | 
                                  |------------------------------------------|   
                                  |[0]  Save and exit                        |   
                                  |[1]  Search for customer                  |   
                                  |[2]  Show customer                        |   
                                  |[3]  Create customer                      |   
                                  |[4]  Remove customer                      |   
                                  |[5]  Create account                       |   
                                  |[6]  Remove account                       |   
                                  |[7]  Deposit                              |   
                                  |[8]  Withdraw                             |  
                                  |[9]  Transfer                             | 
                                  |[10] Show account                         | 
                                  |[11] Change credit                        | 
                                  |[12] Change debit                         | 
                                  |[13] Change interest                      |
                                  |[14] Add interest to accounts             | 
                                  |__________________________________________| ");
        }

        public void AccountCredit()
        {
            Console.WriteLine("Change credit", Color.Goldenrod);
            var accId = ConsoleUtils.InputInt("Account ID: ");

            var account = file.FindAccount(accId);
            if (account == null)
            {
                Console.WriteLine("\nAccount not found", Color.Firebrick);
            }
            else
            {
                account.SetCredit(accId);
            }
        }

        public void ChangeDebit()
        {
            Console.WriteLine("Change debit", Color.Goldenrod);
            var accId = ConsoleUtils.InputInt("Account ID: ");

            var account = file.FindAccount(accId);
            if (account == null)
            {
                Console.WriteLine("\nAccount not found", Color.Firebrick);
            }
            else
            {
                account.SetDebit(accId);
            }
        }

        public void ChangeInterest()
        {
            Console.WriteLine("Change interest", Color.Goldenrod);
            var accId = ConsoleUtils.InputInt("Account ID: ");

            var account = file.FindAccount(accId);
            if (account == null)
            {
                Console.WriteLine("\nAccount not found", Color.Firebrick);
            }
            else
            {
                account.SetInterest(accId);
            }
        }

        public void AddInterest()
        {
            var getAccounts = from account in file.Accounts select account;
            foreach (var acc in getAccounts)
            {
                decimal balance = 0;

                if (acc.Balance < 0)
                {
                    balance = -acc.Balance;
                    acc.Balance += decimal.Round(-balance * acc.DebitInterest/100, 2);
                    var transaction = new Transaction(DateTime.Now.ToString(), acc.Id, acc.Id, decimal.Round(-balance * acc.DebitInterest / 100, 2), acc.Balance, "Interest");
                    acc.Transactions.Add(transaction);
                    file.SaveTransactions(transaction);

                }
                else
                {
                    balance = acc.Balance;
                    acc.Balance += decimal.Round(balance * acc.Interest / 100, 2);
                    var transaction = new Transaction(DateTime.Now.ToString(), acc.Id, acc.Id, decimal.Round(balance * acc.Interest / 100, 2), acc.Balance, "Interest");
                    acc.Transactions.Add(transaction);
                    file.SaveTransactions(transaction);
                }
            }

            Console.WriteLine("\nInterest added to all accounts.", Color.Goldenrod);
        }

        public void TransferCash()
        {
            //Gör en check så det är mellan konton som tillhör samma kundnummer
            Console.WriteLine("Transfer", Color.Goldenrod);
            var custId = ConsoleUtils.InputInt("Customer ID: ");

            var customer = file.FindCustomer(custId);
            var accounts = file.FindAllAccounts(customer);

            if (file.Customers.Contains(customer))
            {
                Console.WriteLine("\nAccounts", Color.Orchid);
                foreach (var account in accounts)
                {
                    Console.Write($"{account.Id}: ");
                    Console.Write($"{account.Balance}\n", Color.Goldenrod);
                }

                var accId = ConsoleUtils.InputInt("Choose first account: ");

                var acc = file.FindAccount(accId);
                if (acc == null || acc.CustomerId != custId)
                {
                    Console.WriteLine("\nAccount not found", Color.Firebrick);
                    return;
                }

                var currency = ConsoleUtils.InputDecimal("Amount to transfer: ");

                if (currency >= 0)
                {
                    if (acc.Balance - currency < 0)
                    {
                        Console.WriteLine("\nYou don't have that much money in your account", Color.Firebrick);
                    }
                    else
                    {
                        var accId2 = ConsoleUtils.InputInt("Choose second account: ");

                        var acc2 = file.FindAccount(accId2);
                        if (acc2 == null)
                        {
                            Console.WriteLine("\nAccount not found", Color.Firebrick);
                            return;
                        }

                        acc.Balance -= decimal.Add(currency, 0.00M);
                        Console.Write("\nBalance in account ");
                        Console.Write($"{accId} ", Color.Yellow);
                        Console.Write("has changed to: ");
                        Console.Write($"{acc.Balance} \n", Color.Yellow);

                        acc2.Balance += decimal.Add(currency, 0.00M);
                        Console.Write("Balance in account ");
                        Console.Write($"{accId2} ", Color.Yellow);
                        Console.Write("has changed to: ");
                        Console.Write($"{acc2.Balance} \n", Color.Yellow);

                        var transaction = ConsoleUtils.SaveTransfer(acc, acc2, acc.Balance, currency, "Transfer");
                        var transaction2 = ConsoleUtils.SaveTransfer(acc, acc2, acc2.Balance, currency, "Transfer");
                        acc.Transactions.Add(transaction);
                        acc.Transactions.Add(transaction2);
                        file.SaveTransactions(transaction);
                        file.SaveTransactions(transaction2);
                    }
                }
                else
                {
                    Console.WriteLine("\nNegative values is not allowed ", Color.Firebrick);
                }
            }
            else
            {
                Console.WriteLine("\nCouldn't find customer", Color.Firebrick);
            }
        }

        public void Withdraw()
        {
            //Ta ut pengar från konto 
            Console.WriteLine("Withdraw", Color.Goldenrod);
            var custId = ConsoleUtils.InputInt("Customer ID: ");

            var customer = file.FindCustomer(custId);
            var accounts = file.FindAllAccounts(customer);

            if (file.Customers.Contains(customer))
            {
                Console.WriteLine("\nAccounts", Color.Orchid);
                foreach (var account in accounts)
                {
                    Console.Write($"{account.Id}: ");
                    Console.Write($"{account.Balance}\n", Color.Goldenrod);
                }

                var accId = ConsoleUtils.InputInt("Choose account ID: ");

                var acc = file.FindAccount(accId);
                if (acc == null || acc.CustomerId != custId)
                {
                    Console.WriteLine("\nAccount not found", Color.Firebrick);
                    return;
                }

                var currency = ConsoleUtils.InputDecimal("Enter amount to withdraw: ");
                if (currency >= 0)
                {
                    if (acc.Balance - currency < - acc.Credit)
                    {
                        Console.WriteLine("\nYou don't have that much money in your account", Color.Firebrick);
                        Console.Write("Your credit for this account is currently set to: ");
                        Console.Write($"{acc.Credit}\n", Color.Goldenrod);
                    }
                    else
                    {
                        acc.Balance -= decimal.Add(currency, 0.00M);
                        Console.Write("\nBalance in account ");
                        Console.Write($"{accId} ", Color.Yellow);
                        Console.Write("has changed to: ");
                        Console.Write($"{acc.Balance} \n", Color.Yellow);

                        var transaction = ConsoleUtils.SaveTransaction(acc, currency, "Withdrawal");
                        acc.Transactions.Add(transaction);
                        file.SaveTransactions(transaction);
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\nNegative values is not allowed ", Color.Firebrick);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\nCouldn't find customer", Color.Firebrick);
            }
        }

        public void Deposit()
        {
            //Lägg till pengar på konto
            Console.WriteLine("Deposit", Color.Goldenrod);
            var custId = ConsoleUtils.InputInt("Customer ID: ");

            var customer = file.FindCustomer(custId);
            var accounts = file.FindAllAccounts(customer);

            if (file.Customers.Contains(customer))
            {
                Console.WriteLine("\nAccounts", Color.Orchid);
                foreach (var account in accounts)
                {
                    Console.Write($"{account.Id}: ");
                    Console.Write($"{account.Balance}\n", Color.Goldenrod);
                }

                var accId = ConsoleUtils.InputInt("Choose account ID: ");

                var acc = file.FindAccount(accId);
                if (acc == null || acc.CustomerId != custId)
                {
                    Console.WriteLine("\nAccount not found", Color.Firebrick);
                    return;
                }

                var currency = ConsoleUtils.InputDecimal("Enter amount to deposit:  ");
                {
                    if (currency >= 0)
                    {
                        acc.Balance += decimal.Add(currency, 0.00M);

                        Console.Write("\nBalance in account ");
                        Console.Write($"{accId} ", Color.Yellow);
                        Console.Write("has changed to: ");
                        Console.Write($"{acc.Balance} \n", Color.Yellow);

                        var transaction = ConsoleUtils.SaveTransaction(acc, currency, "Deposit");
                        acc.Transactions.Add(transaction);
                        file.SaveTransactions(transaction);
                    }
                    else
                    {
                        Console.WriteLine("\nNegative values is not allowed ", Color.Firebrick);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nCouldn't find customer", Color.Firebrick);
            }
        }

    }
}