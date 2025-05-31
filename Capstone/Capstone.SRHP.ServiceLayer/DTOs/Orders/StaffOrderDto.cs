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
        public int? PreparationAssignmentId { get; set; }
        public DateTime? PreparationAssignedDate { get; set; }
        public DateTime? PreparationCompletedDate { get; set; }

        // Shipping information
        public int? ShippingStaffId { get; set; }
        public string ShippingStaffName { get; set; }
        public int? ShippingAssignmentId { get; set; }
        public DateTime? ShippingAssignedDate { get; set; }
        public DateTime? ShippingCompletedDate { get; set; }
        public bool IsDelivered { get; set; }

        // Pickup information
        public int? PickupStaffId { get; set; }
        public string PickupStaffName { get; set; }
        public int? PickupAssignmentId { get; set; }
        public DateTime? PickupAssignedDate { get; set; }
        public DateTime? PickupCompletedDate { get; set; }

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

        // All assignments for this order
        public List<StaffAssignmentInfoDto> Assignments { get; set; } = new List<StaffAssignmentInfoDto>();
    }

    public class StaffAssignmentInfoDto
    {
        public int AssignmentId { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public StaffTaskType TaskType { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class StaffAssignedOrderBaseDto
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AssignedAt { get; set; }
    }

    // Specialized DTO for preparation staff
    public class PreparationStaffOrderDto : StaffAssignedOrderBaseDto
    {
        // Preparation-specific details
        public List<OrderItemSummaryDto> OrderItems { get; set; } = new List<OrderItemSummaryDto>();
        public List<HotpotSummaryDto> HotpotItems { get; set; } = new List<HotpotSummaryDto>();
        public string Notes { get; set; }
        public bool HasSellItems { get; set; }
        public bool HasRentItems { get; set; }
    }

    // Specialized DTO for shipping staff
    public class ShippingStaffOrderDto : StaffAssignedOrderBaseDto
    {
        // Shipping-specific details
        public List<OrderItemSummaryDto> OrderItems { get; set; } = new List<OrderItemSummaryDto>();
        public List<HotpotSummaryDto> HotpotItems { get; set; } = new List<HotpotSummaryDto>();
        public string CustomerPhone { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public VehicleInfoDto Vehicle { get; set; }
        public OrderSize OrderSize { get; set; }
        public bool IsDelivered { get; set; }
        public bool HasSellItems { get; set; }
        public bool HasRentItems { get; set; }
    }

    // Summary DTO for order items (ingredients, combos, etc.)
    public class OrderItemSummaryDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public int Quantity { get; set; }
    }

    // Summary DTO for hotpot items
    public class HotpotSummaryDto
    {
        public int HotpotInventoryId { get; set; }
        public string HotpotName { get; set; }
        public string SeriesNumber { get; set; }
        public int Quantity { get; set; }
    }
}
