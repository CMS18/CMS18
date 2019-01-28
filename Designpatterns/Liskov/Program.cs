using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    // using a classic example
    // SOLID - the L stand for LISKOV 
    // Scenario: A derived class can not seamless become a type of its base-class without problems. 
    // We can see this below, the base-class is a rectangle and the derived class a square.
    // When the square is of rectangle type the calculation for area fails

    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

    }

    public class Square : Rectangle
    {
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        public new int Height
        {
            set { base.Width = base.Height = value; }
        }

    }

    public class Demo
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}");


            Rectangle rec = new Square();
            rec.Width = 5;

            Console.WriteLine($"{rec} has area {Area(rec)}");
        }
    }
}
