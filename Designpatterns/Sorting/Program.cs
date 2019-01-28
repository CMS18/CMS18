using System;
using System.Collections.Generic;

namespace Sorting
{

    public class Person : IComparable<Person> , IEquatable<Person>
    {
        public int Age { get; set; }
        public String Name { get; set; }


        public int CompareTo(Person other)
        {
            if (other.Age > this.Age)
                return 1;
            else if (other.Age == Age)
                return 0;
            else
                return -1;


        }

        public bool Equals(Person other)
         {
             return Name == other.Name && Age == other.Age;
         }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Person> pers = new List<Person>();

            Person p1 = new Person();
            p1.Age = 12;
            p1.Name = "Dan";
            Person p2 = new Person();
            p2.Age = 12;
            p2.Name = "Dan";
            Person p3 = new Person();
            p3.Age = 75;
            p3.Name = "Erik";

            pers.Add(p1);
            pers.Add(p2);
            pers.Add(p3);


            foreach (var p in pers)
            {
                Console.WriteLine(p.Age);
            }

            pers.Sort();

            foreach (var p in pers)
            {
                Console.WriteLine(p.Age);
            }


            if (p1.Equals(p1))
                Console.WriteLine("Equal!");
            else
                Console.WriteLine("Not Equal!");

         
            


        }
    }
}

