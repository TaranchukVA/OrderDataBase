using OrderDataBase.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDataBase.Data
{
    public class OrderData : TOrder
    {
        public List<ProductData> products { get; set; }
        public decimal total { get; set; }
    }
}
