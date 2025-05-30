using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Shipping
{
    public class StaffPickupAssignmentDto
    {
        public int AssignmentId { get; set; }
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public string EquipmentSummary { get; set; }

        // Vehicle information
        public int? VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }
    }

    public class PickupAssignmentRequestDto
    {
        public int StaffId { get; set; }
        public int RentOrderDetailId { get; set; }
        public int? VehicleId { get; set; }
        public string Notes { get; set; }
    }

    //public class CompletePickupRequestDto
    //{
    //    public int AssignmentId { get; set; }
    //    public DateTime CompletedDate { get; set; }
    //    public string ReturnCondition { get; set; }
    //    public decimal? DamageFee { get; set; }
    //}

    public class UnifiedReturnRequestDto
    {
        public int? AssignmentId { get; set; }
        public int? RentOrderId { get; set; }
        public DateTime CompletedDate { get; set; }
        public string ReturnCondition { get; set; }
        public decimal? DamageFee { get; set; }
        public string Notes { get; set; }
    }

}
