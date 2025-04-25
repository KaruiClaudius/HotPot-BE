using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Management;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders
{
    public class StaffOrderDto
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeliveryTime { get; set; }

        // Preparation staff information
        public int? PreparationStaffId { get; set; }
        public string PreparationStaffName { get; set; }

        // Shipping information
        public int? ShippingStaffId { get; set; }
        public string ShippingStaffName { get; set; }
        public bool IsDelivered { get; set; }
        public string DeliveryNotes { get; set; }

        // Order details
        public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
        public List<RentalDetailDto> RentalDetails { get; set; } = new List<RentalDetailDto>();

        // Vehicle information
        public VehicleInfoDto Vehicle { get; set; }
        public OrderSize OrderSize { get; set; }

        // Payment information
        public decimal DiscountAmount { get; set; }
        public string DiscountCode { get; set; }
        public string PaymentStatus { get; set; }
    }
}
