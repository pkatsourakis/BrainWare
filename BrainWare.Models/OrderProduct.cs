using System;
using System.Collections.Generic;
using System.Text;

namespace BrainWare.Models
{
    public class OrderProduct
    {
        public int Quantity { get; set; }

        public Product Product { get; set; }

        public decimal OrderTotal {
            get
            {
                decimal orderTotal = 0;

                if (Product != null)
                {
                    orderTotal = Quantity * Product.Price;
                }

                return orderTotal;
            }}
    }
}
