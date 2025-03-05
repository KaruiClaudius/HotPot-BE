using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Order.Customer
{
    public class DiscountInfo
    {
        public int DiscountId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Percent { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
