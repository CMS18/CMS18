using System;

namespace Lektion5_Recursion
{
    internal class Program
    {
        private static int GreatestCommonDivisor(int value1, int value2)
        {
            //345 % 150 = 45
            //150 % 45= 15

            //45 % 15 = 0
            if (value2 == 0) return value1;

            return GreatestCommonDivisor(value2, value1 % value2);
        }

        private static void Main(string[] args)
        {
            var divisor = GreatestCommonDivisor(345, 150);

            Console.WriteLine($"Divisir: {divisor}");
        }
    }
}