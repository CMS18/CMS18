using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.StartBank(@"Files\bankdata.txt");

        }
    }
}

    