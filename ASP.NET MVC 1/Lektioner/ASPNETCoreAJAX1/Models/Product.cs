using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreAJAX1.Models
{
    public class Product
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        //public Product (int id, string name, int price, string description)
        //{
        //    ID = id;
        //    Name = name;
        //    Price = price;
        //    Description = description;

        //}
    }
}
