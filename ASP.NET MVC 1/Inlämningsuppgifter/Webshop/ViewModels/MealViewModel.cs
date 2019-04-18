using System.Collections.Generic;
using Webshop.Models;

namespace Webshop.ViewModels
{
    public class MealViewModel
    {
        public Matratt Matratt { get; set; }
        public List<Produkt> Ingredients { get; set; }
        public MatrattTyp Category { get; set; }
        public int MealID { get; set; }

        public MealViewModel()
        {
            Ingredients = new List<Produkt>();
        }
    }
}