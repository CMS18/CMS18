using System;

namespace Lektion3_Loopar
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var random = new Random();

            Console.WriteLine(" +---+---+---+---+---+---+---+---+---+");
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    var rnd = random.Next(1, 10);
                    Console.Write($" | {rnd}");
                }

                Console.WriteLine(" | ");
                Console.WriteLine(" +---+---+---+---+---+---+---+---+---+");
            }

            Console.ReadLine();
        }
    }
}