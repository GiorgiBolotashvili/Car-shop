using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Car car { get; set; }
        public ushort price { get; set; }
        public String shopCartID { get; set; }

    }
}
