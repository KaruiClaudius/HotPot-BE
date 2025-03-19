using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Shipping
{
    public class StaffPickupAssignmentDto
    {
        public int AssignmentId { get; set; }
        public int RentOrderDetailId { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Notes { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }

    public class PickupAssignmentRequestDto
    {
        public int StaffId { get; set; }
        public int RentOrderDetailId { get; set; }
        public string Notes { get; set; }
    }

    public class CompletePickupRequestDto
    {
        public int AssignmentId { get; set; }
        public DateTime CompletedDate { get; set; }
        public string ReturnCondition { get; set; }
        public decimal? DamageFee { get; set; }
    }
}
