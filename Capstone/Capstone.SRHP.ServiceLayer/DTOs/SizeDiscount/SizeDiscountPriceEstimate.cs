using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount
{
    public class SizeDiscountPriceEstimate
    {
        public decimal BasePrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Total { get; set; }
        public int Size { get; set; }
    }
}
