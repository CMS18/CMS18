using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;

            if(s1==s2) // object pointer is the same
                s1.Print();


        }
    }

    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object Mutex = new object();
        private static readonly object PrintMutex = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                lock (Mutex)
                {
                    if (_instance == null)
                        _instance = new Singleton();

                    return _instance;
                }
            }
        }

        public void Print()
        {
            lock(PrintMutex)
            Console.WriteLine("Singleton works great!");
        }

    }

    // public class A : Singleton { } // cant create a derived class

}
