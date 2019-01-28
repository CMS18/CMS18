using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreFormulärDB.Models;

namespace ASPNETCoreFormulärDB.ViewModels
{
    public class SearchPersonViewModel
    {
        public string SearchValue { get; set; }
        public List<Person> SearchPerson { get; set; }


        public SearchPersonViewModel()
        {
            SearchPerson = new List<Person>();
        }
    }


}
