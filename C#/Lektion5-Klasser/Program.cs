using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion5_Klasser
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Freddie");
            p1.Age = 31;
            p1.PrintPerson();


            Person p2 = new Person("Freddie");
            p2.Name = "Sandra";
            p2.Age = 20;
            p2.ShoeSize = 40;
            p2.Hometown = "Sundsvall";
            p2.PrintPerson();
        }
    }
}
