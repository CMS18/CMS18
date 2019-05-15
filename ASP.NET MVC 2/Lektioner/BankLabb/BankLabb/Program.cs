using System;
using BankLabb.Data;

namespace BankLabb
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = new Utils();

            Console.Write("Enter client name: ");
            var name = Console.ReadLine();
            //Console.Write("How many results do you want? ");
            //int.TryParse(Console.ReadLine(), out int limit);

            var customers = data.GetAllCustomers();
            Console.WriteLine($"{customers} {name} exists");
        }
    }
}