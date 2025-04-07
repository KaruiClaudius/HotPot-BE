using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer
{
    public class DiscountInfo
    {
        public int DiscountId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Percent { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
