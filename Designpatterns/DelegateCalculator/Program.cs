using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCalculator
{

    public delegate double PerformCalculation(double a, double b);

    class Program
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }
        public static double Subtract(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Divide(double a, double b)
        {
            if(Math.Abs(b) < 0) throw new ArithmeticException();

            return a + b;
        }

        static void Main(string[] args)
        {
            PerformCalculation add = Add;
            PerformCalculation sub = Subtract;
            PerformCalculation mul = Multiply;
            PerformCalculation div = Divide;


            Console.WriteLine(  (sub(10,5))   );

        }
    }


    // work in group and create an calculator with delegates



}
