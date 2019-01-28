using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreFormulär3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETCoreFormulär3.ViewModels
{
    public class PersonViewModel
    {
        public Person CurrentPerson { get; set; }
        public List<PersonType> PersonTypes { get; set; }
        public List<SelectListItem> Regions { get; set; }


        public PersonViewModel()
        {
            PersonTypes = new List<PersonType>();
            Regions = new List<SelectListItem>();
        }
    }
}
