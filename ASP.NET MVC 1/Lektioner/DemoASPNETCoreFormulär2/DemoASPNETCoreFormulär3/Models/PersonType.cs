using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoASPNETCoreFormulär3.Models
{
    public class PersonType
    {
        public int PersonTypeID { get; set; }
        public string Name { get; set; }

        public PersonType(int id, string name)
        {
            PersonTypeID = id;
            Name = name;
        }

    }
}
