using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tentamen.Models;

namespace Tentamen.ViewModels
{
    public class NewBookViewModel
    {
        public NewBook Book { get; set; }

        public List<InStock> Stock { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public NewBookViewModel()
        {
            Stock = new List<InStock>();
            Categories = new List<SelectListItem>();
        }
    }
}
