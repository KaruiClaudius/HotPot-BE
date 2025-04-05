using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class RevenueByProductType
    {
        public decimal Ingredients { get; set; }
        public decimal Combos { get; set; }
        public decimal Customizations { get; set; }
        public decimal Hotpots { get; set; }
        public decimal Utensils { get; set; }
        public decimal HotpotDeposits { get; set; }
    }

}
