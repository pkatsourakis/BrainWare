using System;
using System.Collections.Generic;
using System.Text;

namespace BrainWare.Models
{
    public class CompanyOrder
    {
        public long OrderId { get; set; }
        public string OrderDescription { get; set; }

        public Company Company { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
