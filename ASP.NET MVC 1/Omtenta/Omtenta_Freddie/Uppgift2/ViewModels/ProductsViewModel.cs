using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgift2.Models;

namespace Uppgift2.ViewModels
{
    public class ProductsViewModel
    {

        public Products Product { get; set; }
        public List<Products> ListOfProducts { get; set; }

        public int Quantity
        {
            get
            {
                return ListOfProducts.Sum(x => x.UnitsOnOrder * (int)x.UnitPrice ?? 0);
            }
        }

        public ProductsViewModel()
        {
            ListOfProducts = new List<Products>();
        }
    }
}
