using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Shipping
{
    public class EquipmentReturnRequest
    {
        public int? RentOrderDetailId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ReturnCondition { get; set; }
        public decimal? DamageFee { get; set; }
        public string Notes { get; set; }
        public int StaffId { get; set; }
    }
}
