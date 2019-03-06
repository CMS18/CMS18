using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DemoASPNETCoreFormulär3.Models
{
    public class Person
    {
        [DisplayName("Ange namn")]
        public string Name { get; set; }

        [DisplayName("Ange personens kategori")]
        public int PersonTypeID { get; set; }

        [DisplayName("Ange region")]
        public int RegionID { get; set; }




    }
}
