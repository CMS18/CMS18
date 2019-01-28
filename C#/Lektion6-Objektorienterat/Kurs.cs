using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lektion6_Objektorienterat
{
    class Kurs
    {
        public string Course { get; set; }
        public int Points { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public double BeraknaAntalKursDagar()
        {
            DateTime start = DateTime.Parse(StartDate); 
            DateTime end = DateTime.Parse(EndDate);

            TimeSpan days = end - start;
            double numbDays = days.Days;

            return numbDays;

        }

        

    }
}
