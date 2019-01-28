using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreEF.Models;

namespace ASPNETCoreEF.ViewModels
{
    public class ProductViewModel
    {
        public List<Categories> ProductCategories { get; set; }
        public List<Products> SelectedProducts { get; set; }

        public ProductViewModel()
        {
            ProductCategories = new List<Categories>();
            SelectedProducts = new List<Products>();
        }
    }
}
