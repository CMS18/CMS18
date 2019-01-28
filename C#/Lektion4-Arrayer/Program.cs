using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion4_Arrayer
{
    class Program
    {
        static void Main(string[] args)
        {
           int [] myArray = new int[20];

            for (int array = 0; array < myArray.Length; array++)
            {
                myArray[array] = array * 5;
                Console.WriteLine(myArray[array]);
            }

            Console.ReadKey();


            char[] myArray1 = Console.ReadLine().ToCharArray();
            char[] myArray2 = Console.ReadLine().ToCharArray();

            if (myArray1.SequenceEqual(myArray2))
            {
                Console.WriteLine("They are equal");
            }
            else
            {
                Console.WriteLine("They are not equal");
            }

        }
    }
}
