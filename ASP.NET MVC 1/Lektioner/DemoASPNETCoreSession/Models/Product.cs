using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoASPNETCoreSession.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }


        public Product(int id, string name, int price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

    }
}
