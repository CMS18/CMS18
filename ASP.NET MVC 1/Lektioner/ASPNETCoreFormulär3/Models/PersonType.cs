using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreFormulär3.Models
{
    public class PersonType
    {
        public int PersonTypeId { get; set; }
        public string Name { get; set; }

        public PersonType(int id, string name)
        {
            PersonTypeId = id;
            Name = name;
        }

    }
}
