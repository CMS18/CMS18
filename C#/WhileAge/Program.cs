using System;

namespace WhileAge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var yourAge = 0;
            var summa = 0;
            Console.WriteLine("Antal personer: ");
            var line = Console.ReadLine();
            var personer = int.Parse(line);

            for (var i = 0; i < personer; i++)
            {
                Console.Write("Ålder?: ");

                yourAge = int.Parse(Console.ReadLine());
                summa += yourAge;
            }

            var avg = ((double) summa / personer);
            Console.WriteLine($"Medelålder: {Math.Round(avg)}");
            Console.ReadLine();
        }
    }
}