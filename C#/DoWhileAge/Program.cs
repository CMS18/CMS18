using System;

namespace DoWhileAge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string dinÅlder;
            var summa = 0;
            var antal = 0;
            do
            {
                Console.Write("Ålder?: ");

                dinÅlder = Console.ReadLine();
                if (dinÅlder != "")
                {
                    antal++;
                    summa += int.Parse(dinÅlder);
                }
            } while (dinÅlder != "");

            var avg = (double) summa / antal;
            Console.WriteLine($"Medelålder: {Math.Round(avg, 1)}");
        }
    }
}