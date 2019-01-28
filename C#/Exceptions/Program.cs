using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static double GoBoom(double a, double b)
        {
            var result = a / b;
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GoBoom(100, 0));
        }
    }
}
