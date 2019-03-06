using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DemoASPNETCoreFormulär3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoASPNETCoreFormulär3.ViewModels
{
    public class PersonViewModel
    {
        //Det objekt som används för att skicka tillbaka 
        //värden från formuläret
        public Person CurrentPerson { get; set; }

        //Skickar värden till formuläret som visas som radiobuttons
        public List<PersonType> PersonTypes { get; set; }

        //Skickar värden till formuläret som visas som en dropdownlista
        public List<SelectListItem> Regions { get; set; }

        public PersonViewModel()
        {
            PersonTypes = new List<PersonType>();
            Regions = new List<SelectListItem>();
        }

    }
}
