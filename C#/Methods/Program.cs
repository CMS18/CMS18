using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        
        static double ToPercentage(double input)
        {
            double percent = input * 100;
            return percent;

        }



        static void Main(string[] args)
        {
            Console.WriteLine("Enter age: ");
            var age = int.Parse(Console.ReadLine());
            IsOfAge(age);

            //Console.WriteLine("Enter number between 0 and 1: ");
            //double input = double.Parse(Console.ReadLine());
            //double percent = ToPercentage(input);

            //Console.WriteLine(percent);

            //Console.WriteLine("Enter string one: ");
            //var input1 = Console.ReadLine();
            //Console.WriteLine("Enter string two: ");
            //var input2 = Console.ReadLine();

            //MyMethod(input1, input2);

            //Console.Write("Enter sum: ");
            //int sum = int.Parse(Console.ReadLine());
            //int taxValue = Taxes(sum);
            //Console.WriteLine();
            //Console.WriteLine("Moms: " + taxValue);

        }


        static void IsOfAge(int age)
        {
            if (age < 18)
            {
                Console.WriteLine("Too young dude.");
            }
            else
            {
                Console.WriteLine("Welcome in!");
            }
        }

        static int Taxes(int taxes)
        {
            double taxValue = taxes * 0.25;
            return Convert.ToInt32(taxValue);
        }

        static void MyMethod(string input1, string input2)
        {
            Console.WriteLine(input1 + input2);
        }
    }
}
