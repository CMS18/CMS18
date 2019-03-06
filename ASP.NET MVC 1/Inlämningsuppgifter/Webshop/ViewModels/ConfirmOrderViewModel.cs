using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.ViewModels
{
    public class ConfirmOrderViewModel
    {
        public Bestallning Order { get; set; }
        public BestallningMatratt MealOrder { get; set; }
    }
}
