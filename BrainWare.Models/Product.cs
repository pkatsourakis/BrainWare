using System;
using System.Collections.Generic;
using System.Text;

namespace BrainWare.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
