using System;
using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;
using Math = System.Math;

namespace Bank
{
    public class Account
    {
        //private decimal _Balance;
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        public decimal DebitInterest { get; set; }
        public int Credit { get; set; }
        public List<Transaction> Transactions = new List<Transaction>();

        public void SetCredit(int accId)
        {
            Console.Write("\nCurrent credit for the account is: ");
            Console.Write($"{Credit}\n", Color.Goldenrod);
            var newCredit = ConsoleUtils.InputInt("Enter new credit amount: ");
            if (newCredit <= 10000 && newCredit > 0)
            {
                Credit = newCredit;
                Console.Write("\nCredit has been set to: ");
                Console.Write($"{Credit}", Color.Goldenrod);

            }
            else
            {
                Console.WriteLine("Invalid input, please choose a value between 0 and 10.000", Color.Firebrick);
            }
        }

        public void SetDebit(int accId)
        {
            if (DebitInterest <= 0)
            {
                var setDebit = ConsoleUtils.InputDecimal("\nEnter new debit percentage: ");
                if (setDebit <= 50 && setDebit > 0)
                {
                    DebitInterest = setDebit;
                    Console.Write("Debit interest set to: ");
                    Console.Write($"{DebitInterest}", Color.Goldenrod);
                    Console.Write("%");
                    Console.Write("\nCurrent debit for the year on this account is: ");
                    Console.Write($"{Math.Round(GetInterest(Balance, DebitInterest))}\n", Color.Goldenrod);
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose a value between 0 and 50", Color.Firebrick);
                }
            }
            else
            {
                Console.Write("\nCurrent debit for the year on this account is: ");
                Console.Write($"{Math.Round(GetInterest(Balance, DebitInterest))}\n", Color.Goldenrod);
                Console.Write("Expected payback in a year is: ");
                Console.Write($"{Math.Round(GetTotal(Balance, DebitInterest))}\n", Color.Goldenrod);

                var newDebit = ConsoleUtils.InputDecimal("\nEnter new debit percentage: ");
                if (newDebit <= 50 && newDebit > 0)
                {
                    DebitInterest = newDebit;
                    Console.Write("Debit interest set to: ");
                    Console.Write($"{DebitInterest}", Color.Goldenrod);
                    Console.Write("%");
                    Console.Write("\nCurrent interest value for the year on this account is: ");
                    Console.Write($"{Math.Round(GetInterest(Balance, DebitInterest))}\n", Color.Goldenrod);
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose a value between 0 and 50", Color.Firebrick);
                }
            }
            
        }

        public void SetInterest(int accId)
        {
            if (Interest <= 0)
            {
                var setInterest = ConsoleUtils.InputDecimal("\nEnter new interest percentage: ");
                if (setInterest <= 50 && setInterest > 0)
                {
                    Interest = setInterest;
                    Console.Write("Interest set to: ");
                    Console.Write($"{Interest}", Color.Goldenrod);
                    Console.Write("%");
                    Console.Write("\nCurrent interest for the year on this account is: ");
                    Console.Write($"{Math.Round(GetInterest(Balance, Interest))}\n", Color.Goldenrod);
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose a value between 0 and 50", Color.Firebrick);
                }
            }
            else
            {
                Console.Write("\nCurrent interest for the year on this account is: ");
                Console.Write($"{Math.Round(GetInterest(Balance, Interest))}\n", Color.Goldenrod);
                Console.Write("Expected interest in a year is: ");
                Console.Write($"{Math.Round(GetTotal(Balance, Interest))}\n", Color.Goldenrod);

                var newInterest = ConsoleUtils.InputDecimal("\nEnter new interest percentage: ");
                if (newInterest <= 50 && newInterest > 0)
                {
                    Interest = newInterest;
                    Console.Write("Interest set to: ");
                    Console.Write($"{Interest}", Color.Goldenrod);
                    Console.Write("%");
                    Console.Write("\nCurrent interest value for the year on this account is: ");
                    Console.Write($"{Math.Round(GetInterest(Balance, Interest))}\n", Color.Goldenrod);
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose a value between 0 and 50", Color.Firebrick);
                }
            }
        }

        public Account() { }

        public Account(int id, int customerId, decimal balance)
        {
            Id = id;
            CustomerId = customerId;
            Balance = balance;
        }

        public bool Deposit(decimal amount)
        {
            if (amount < 0)
            {
                return false;
            }
            Balance += amount;
            return true;

        }

        public bool Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                return false;
            }
            Balance -= amount;
            return true;

        }

        public static decimal GetInterest(decimal balance, decimal interest)
        {
            var result = balance * (interest / 100);
            return result;
        }

        public static decimal GetTotal(decimal balance, decimal interest)
        {
            var result = balance * (interest / 100 + 1);
            return result;
        }
    }
}
