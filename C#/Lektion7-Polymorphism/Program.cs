using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion7_Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape1 = new Circle();
            Circle circle2 = new Circle();

            Shape shape3 = new Rectangle();
            Rectangle rectangle4 = new Rectangle();

            Shape shape5;
            Rectangle rectangle6;

            shape5 = shape3;
            rectangle6 = shape1 as Rectangle;

            Console.WriteLine(rectangle6);


        }
    }
}
