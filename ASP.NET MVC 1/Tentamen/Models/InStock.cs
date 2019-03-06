using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tentamen.Models
{
    public class InStock
    {

        public int StockId { get; set; }
        public string InStockValue { get; set; }

        public InStock(int id, string name)
        {
            StockId = id;
            InStockValue = name;
        }

    }
}
