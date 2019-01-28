using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depe
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface IWorker
    {
        void DoOperation();
    }


    class A
    {
        private IWorker X { set; get; }

        public void Method(IWorker w)
        {
            w.DoOperation();
        }

    }

    class B: IWorker
    {
        public void DoOperation()
        {
            Console.WriteLine("Working");
        }
    }



}
