using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion6_Objektorienterat
{
    class Meddelande
    {
        public string Text { get; set; }

        public Meddelande()
        {

        }

        public string VisaMeddelande()
        {
            return "Hello world!! " + Text;
        }
    }
}
