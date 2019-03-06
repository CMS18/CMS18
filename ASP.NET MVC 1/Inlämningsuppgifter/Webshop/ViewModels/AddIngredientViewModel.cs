using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.ViewModels
{
    public class AddIngredientViewModel
    {
        public Produkt NewIngredient { get; set; }
        public List<Produkt> ListIngredients { get; set; }
    }
}
