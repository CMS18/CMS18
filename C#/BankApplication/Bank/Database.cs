using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Console = Colorful.Console;

namespace Bank
{
    public class Database
    {
        public List<Account> Accounts = new List<Account>();
        public List<Customer> Customers = new List<Customer>();
        public int CustomerCount { get; set; }
        public int AccountCount { get; set; }

        public void GetData()
        {
            var countOfCustomers = Customers.Count;
            var accountList = from account in Accounts
                join customer in Customers on account.CustomerId equals customer.Id
                select new
                {
                    AccountNo = account.Id,
                    CustomerNo = customer.Id,
                    CustomerName = customer.Name,
                    account.Balance
                };

            var accounts = accountList.ToList();
            var totalBalance2 = accounts.Sum(a => a.Balance);

            //List of total accounts in list

            Console.Write("\nNumber of customers: ");
            Console.Write($"{countOfCustomers} \n", Color.Goldenrod);
            Console.Write("Number of accounts: ");
            Console.Write($"{accounts.Count} \n", Color.Goldenrod);
            Console.Write("Total value: ");
            Console.Write($"{totalBalance2} \n", Color.Goldenrod);
        }

        public void RemoveCustomer()
        {
            Console.WriteLine("Remove customer", Color.Goldenrod);
            var custId = ConsoleUtils.InputInt("Customer ID: ");

            var customer = FindCustomer(custId);
            var account = FindAllAccounts(customer);

            if (Customers.Contains(customer))
            {
                var accountsAreEmpty = account.All(a => a.Balance <= 0.00M);

                if (accountsAreEmpty)
                {
                    Customers.RemoveAll(c => c.Id == customer.Id);
                    Accounts.RemoveAll(a => a.CustomerId == customer.Id);

                    Console.Write("\nCustomer ");
                    Console.Write($"{customer.Id} ", Color.Yellow);
                    Console.Write("has been removed.\n");
                }
                else
                {
                    Console.WriteLine("\nCustomer still has an account with balance left in it", Color.Firebrick);
                }
            }
            else
            {
                Console.WriteLine("\nCouldn't find customer", Color.Firebrick);
            }
        }

        public void RemoveAccount()
        {
            Console.WriteLine("Remove account from customer", Color.Goldenrod);
            var custId = ConsoleUtils.InputInt("Customer ID: ");

            var customer = FindCustomer(custId);
            var accounts = FindAllAccounts(customer);

            if (Customers.Contains(customer))
            {
                Console.WriteLine("\nAccounts", Color.Orchid);
                foreach (var account in accounts)
                {
                    Console.Write($"{account.Id}: ");
                    Console.Write($"{account.Balance}\n", Color.Goldenrod);
                }

                var accId = ConsoleUtils.InputInt("Choose account ID: ");
                var acc = FindAccount(accId);
                if (acc == null)
                {
                    Console.WriteLine("\nAccount not found", Color.Firebrick);
                    return;
                }

                var balance = acc.Balance == 0.00M;

                if (balance)
                {
                    Accounts.Remove(acc);
                    Console.WriteLine();
                    Console.Write("Account ");
                    Console.Write($"{accId} ", Color.Yellow);
                    Console.Write("was removed from customer ");
                    Console.Write($"{custId} \n", Color.Yellow);
                }
                else
                {
                    Console.WriteLine("\nAccount is not empty", Color.Firebrick);
                }
            }
            else
            {
                Console.WriteLine("\nCouldn't find customer", Color.Firebrick);
            }
        }

        public void ShowCustomer()
        {
            Console.WriteLine("Show customer ", Color.Goldenrod);
            var custId = ConsoleUtils.InputInt("Customer or account ID: ");

            var acc = FindAccount(custId);
            var customer = FindCustomer(custId);
            var accounts = FindAllAccounts(customer);

            if (Accounts.Contains(acc))
            {
                customer = Customers.SingleOrDefault(c => c.Id == acc.CustomerId);
                accounts = FindAllAccounts(customer);
                PrintCustomer(customer, accounts);
            }
            else if (Customers.Contains(customer))
            {
                PrintCustomer(customer, accounts);
            }
            else
            {
                Console.WriteLine("\nCouldn't find customer", Color.Firebrick);
            }
        }

        public void SearchCustomers()
        {
            Console.WriteLine("Search for customer", Color.Goldenrod);
            Console.Write("Enter name or city: ");
            var search = Console.ReadLine();

            var findCust = Customers.Where(c =>
                (c.Name.ToUpper().Contains(search.ToUpper()) || c.City.ToUpper().Contains(search.ToUpper())) && !string.IsNullOrWhiteSpace(search));

            var cust = findCust.ToList();
            if (!cust.Any())
            {
                Console.WriteLine("\nCouldn't find customer", Color.Firebrick);
            }
            else
            {
                Console.WriteLine();
                foreach (var customer in cust)
                {
                    Console.Write($"{customer.Id} ", Color.Orchid);
                    Console.Write(" | ", Color.Chartreuse);
                    Console.Write($" {customer.Name}" + "\r\n", Color.Orchid);
                }
            }
        }

        public void AddAccount()
        {
            var acc = new Account();
            var latestAcc = (from a in Accounts select a.Id).Max();
            acc.Id = latestAcc + 1;

            Console.WriteLine("Add account", Color.Goldenrod);
            var custId = ConsoleUtils.InputInt("Customer ID: ");
            var customer = FindCustomer(custId);

            if (Customers.Contains(customer))
                AddAccountToCustomer(acc, custId);
            else
                Console.WriteLine("\nCouldn't find any customers", Color.Firebrick);
        }

        public void CreateCustomer()
        {
            var acc = new Account();
            var cust = new Customer();
            var latestCust = (from c in Customers select c.Id).Max();
            cust.Id = latestCust + 1;
            var latestAcc = (from a in Accounts select a.Id).Max();
            acc.Id = latestAcc + 1;

            Console.WriteLine();
            Console.WriteLine("Add customer", Color.Goldenrod);
            Console.WriteLine("Entries marked with * are required");
            Console.Write("Organization number*: ");
            cust.OrganizationId = Console.ReadLine();
            Console.Write("Name*: ");
            cust.Name = Console.ReadLine();
            Console.Write("Address*: ");
            cust.Address = Console.ReadLine();
            Console.Write("City*: ");
            cust.City = Console.ReadLine();
            Console.Write("Zipcode*: ");
            cust.ZipCode = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(cust.OrganizationId) && !string.IsNullOrWhiteSpace(cust.Name) &&
                !string.IsNullOrWhiteSpace(cust.Address)
                && !string.IsNullOrWhiteSpace(cust.City) && !string.IsNullOrWhiteSpace(cust.ZipCode))
            {
                Console.Write("Region: ");
                cust.Region = Console.ReadLine();
                Console.Write("Country: ");
                cust.Country = Console.ReadLine();
                Console.Write("Phone number: ");
                cust.PhoneNumber = Console.ReadLine();
                Console.WriteLine();
                Customers.Add(cust);
                CustomerCount++;
                Console.Write("Customer ");
                Console.Write($"{cust.Id} ", Color.Yellow);
                Console.Write("was added.\n");
                acc.Balance = decimal.Add(0, .00M);
                AddAccountToCustomer(acc, cust.Id);
            }
            else
            {
                Console.WriteLine("\nYou missed something that was required", Color.Firebrick);
                Console.WriteLine("Customer was not created", Color.Firebrick);
            }
        }

        public void GetAccount()
        {
            Console.WriteLine("Show account ", Color.Goldenrod);

            var accId = ConsoleUtils.InputInt("Account ID: ");

            var acc = FindAccount(accId);
            if (acc == null)
            {
                Console.WriteLine("\nAccount not found", Color.Firebrick);
            }
            else
            {
                FindTransactions(acc);
                var getTransfers = (from transaction in acc.Transactions
                    select transaction).ToList();
                if (getTransfers.Count != 0)
                {
                    foreach (var transaction in getTransfers)
                    {
                        GetTransactions(transaction);
                    }
                }
                else
                {
                    Console.WriteLine("\nNo recent activity on this account", Color.Firebrick);
                }
            }
        }


        //Functions to call
        private void AddAccountToCustomer(Account acc, int custId)
        {
            acc.CustomerId = custId;
            acc.Balance = decimal.Add(0, .00M);
            Accounts.Add(acc);
            AccountCount++;

            Console.WriteLine();
            Console.Write("Account ");
            Console.Write($"{acc.Id} ", Color.Yellow);
            Console.Write("was added to customer ");
            Console.Write($"{custId} \n", Color.Yellow);
        }

        private static void PrintCustomer(Customer customer, IEnumerable<Account> accounts)
        {
            Console.Write("\nCustomer ID: ");
            Console.Write($"{customer.Id}\n", Color.Goldenrod);
            Console.Write("Organization ID: ");
            Console.Write($"{customer.OrganizationId}\n", Color.Goldenrod);
            Console.Write("Name: ");
            Console.Write($"{customer.Name}\n", Color.Goldenrod);
            Console.Write("Address: ");
            Console.Write($"{customer.Address}\n", Color.Goldenrod);
            Console.Write("City: ");
            Console.Write($"{customer.City}\n", Color.Goldenrod);
            Console.Write("Region: ");
            Console.Write($"{customer.Region}\n", Color.Goldenrod);
            Console.Write("Zipcode: ");
            Console.Write($"{customer.ZipCode}\n", Color.Goldenrod);
            Console.Write("Country: ");
            Console.Write($"{customer.Country}\n", Color.Goldenrod);
            Console.Write("Phone number: ");
            Console.Write($"{customer.PhoneNumber}\n", Color.Goldenrod);

            Console.WriteLine("\nAccounts", Color.Orchid);
            decimal totalBalance = 0;
            foreach (var account in accounts)
            {
                Console.Write($"{account.Id}: ");
                Console.Write($"{account.Balance}\n", Color.Goldenrod);
                totalBalance += account.Balance;
            }

            Console.Write("Total balance: ");
            Console.Write($"{totalBalance}\n", Color.Goldenrod);
        }

        private static void GetTransactions(Transaction transaction)
        {
            if (transaction.Sender == transaction.Receiver)
            {
                Console.Write("\nTransaction type: ");
                Console.Write($"{transaction.Type}\n", Color.Goldenrod);
                Console.Write("Date: ");
                Console.Write($"{transaction.Date}\n", Color.Goldenrod);
                Console.Write("Amount: ");
                Console.Write($"{transaction.Amount}\n", Color.Goldenrod);
                Console.Write("Current balance: ");
                Console.Write($"{transaction.CurrentBalance}\n", Color.Goldenrod);

            }
            else
            {
                Console.Write("\nTransaction type: ");
                Console.Write($"{transaction.Type}\n", Color.Goldenrod);
                Console.Write("Date: ");
                Console.Write($"{transaction.Date}\n", Color.Goldenrod);
                Console.Write("Sender: ");
                Console.Write($"{transaction.Sender}\n", Color.Goldenrod);
                Console.Write("Receiver: ");
                Console.Write($"{transaction.Receiver}\n", Color.Goldenrod);
                Console.Write("Amount: ");
                Console.Write($"{transaction.Amount}\n", Color.Goldenrod);
                Console.Write("Current balance: ");
                Console.Write($"{transaction.CurrentBalance}\n", Color.Goldenrod);

            }
        }

        private static void FindTransactions(Account findAcc)
        {
            Console.Write("\nAccount ID: ");
            Console.Write($"{findAcc.Id}\n", Color.Orchid);
            Console.Write("Customer ID: ");
            Console.Write($"{findAcc.CustomerId}\n", Color.Orchid);
            Console.Write("\nBalance: ");
            Console.Write($"{findAcc.Balance}\n", Color.Goldenrod);
            Console.Write($"Credit: ");
            Console.Write($"{findAcc.Credit}\n", Color.Goldenrod);
            Console.Write($"Interest: ");
            Console.Write($"{findAcc.Interest}\n", Color.Goldenrod);
            Console.Write($"Debit interest: ");
            Console.Write($"{findAcc.DebitInterest}\n", Color.Goldenrod);
        }

        public Customer FindCustomer(int id)
        {
            return Customers.SingleOrDefault(c => c?.Id == id);
        }

        public Account FindAccount(int id)
        {
            return Accounts.SingleOrDefault(a => a?.Id == id);
        }

        public IEnumerable<Account> FindAllAccounts(Customer customer)
        {
            return Accounts.Where(a => a.CustomerId == customer?.Id);
        }
    }
}