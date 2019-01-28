using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion5_Klasser
{
    class Person
    {
        // Fields = Variabler

        // Properties

        public string Name { get; set; }
        public int Age { get; internal set; }
        public int ShoeSize { get; set; }
        public string Hometown { get; internal set; }

        // Constructor

        public Person(string name)
        {
            Name = name;
        }

        // Methods

        public void PrintPerson()
        {
            Console.WriteLine("Person");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Shoe size: {ShoeSize}");
            Console.WriteLine($"Hometown: {Hometown}");

        }


    }
}
