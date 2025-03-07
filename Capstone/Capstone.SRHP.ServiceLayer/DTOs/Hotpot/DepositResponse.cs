using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Hotpot
{
    public class DepositResponse
    {
        public int HotpotId { get; set; }
        public int Quantity { get; set; }
        public decimal DepositAmount { get; set; }
        public int DepositPercentage { get; set; }
    }
}
