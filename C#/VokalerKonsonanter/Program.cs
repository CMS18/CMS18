using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VokalerKonsonanter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv in ett ord");
            string dittOrd = Console.ReadLine().ToLower();
            int antalVokaler = 0;
            int antalKonsonanter = 0;
            char[] vok = new char[] { 'a', 'e', 'i', 'o', 'u', 'y', 'å', 'ä', 'ö' };
            Console.WriteLine($"Antal bokstäver {dittOrd.Length}");

            foreach (var bokstav in dittOrd)
            {
                antalKonsonanter++;
                foreach (var vokal in vok)
                {
                    if (bokstav == vokal)
                    {
                        antalVokaler++;
                        antalKonsonanter--;
                    }
                }
            }

            Console.WriteLine($"Antal vokaler {antalVokaler}");
            Console.WriteLine($"Antal konsonanter {antalKonsonanter}");
            Console.ReadLine();


            
        }

        private const string vokaler = "AOUÅEIYÄÖ";

        private static bool isVowel(char letter)
        {
            return vokaler.Contains(letter);
        }
    }
}
