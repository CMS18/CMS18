using System;

namespace Lektion5_Methods
{
    internal class Program
    {
        private static void FindHighestAndLowestValue(int tal1, int tal2, int tal3, out int maxValue, out int minValue)
        {
            maxValue = Math.Max(tal1, Math.Max(tal2, tal3));
            minValue = Math.Min(tal1, Math.Min(tal2, tal3));
        }

        private static void Main(string[] args)
        {
            int max, min;

            FindHighestAndLowestValue(15, 5, 19, out max, out min);

            Console.WriteLine($"Högsta talet är {max}");
            Console.WriteLine($"Lägsta talet är {min}");
            Console.ReadLine();




        }
    }
}