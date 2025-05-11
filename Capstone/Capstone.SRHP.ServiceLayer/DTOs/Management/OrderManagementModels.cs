using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.DTOs.User;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class StaffAssignmentRequest
    {
        [Required]
        public string OrderCode { get; set; }

        [Required]
        public int StaffId { get; set; }

        [Required]
        public StaffTaskType TaskType { get; set; }

        // Optional vehicle ID for shipping tasks
        public int? VehicleId { get; set; }
    }

    public class ManagerOrderStatusUpdateRequest
    {
        public OrderStatus Status { get; set; }
    }

    public class UpdateDeliveryStatusRequest
    {
        public bool IsDelivered { get; set; }

        public string? Notes { get; set; }
    }

    public class UpdateDeliveryTimeRequest
    {
        [Required]
        public DateTime DeliveryTime { get; set; }
    }

    public class UnallocatedOrderDTO
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        // User information
        public int UserId { get; set; }
        public string UserName { get; set; }

        // Order type indicators
        public bool HasSellItems { get; set; }
        public bool HasRentItems { get; set; }

    }

    public class PendingDeliveryDTO
    {
        public int ShippingOrderId { get; set; }
        public string OrderId { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string DeliveryNotes { get; set; }

        // Order information
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        // Customer information
        public int UserId { get; set; }
        public string UserName { get; set; }

        // Vehicle information
        public VehicleInfoDto VehicleInfo { get; set; }

    }

    public class OrderWithDetailsDTO
    {
        public string OrderId { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public bool HasSellItems { get; set; }
        public bool HasRentItems { get; set; }

        // User information
        public int UserId { get; set; }
        public string UserName { get; set; }

        // Shipping information (if available)
        public ShippingInfoDTO ShippingInfo { get; set; }

        // Vehicle Information
        public VehicleInfoDto VehicleInfo { get; set; }

    }

    public class ShippingOrderAllocationDTO
    {
        public int ShippingOrderId { get; set; }
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public int? VehicleId { get; set; }
        public string VehicleName { get; set; }
        public VehicleType? VehicleType { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderSize OrderSize { get; set; }

    }

    public class ShippingInfoDTO
    {
        public int ShippingOrderId { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public bool IsDelivered { get; set; }
        public string DeliveryNotes { get; set; }
        public StaffDTO Staff { get; set; }

    }
    public class StaffDTO
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
    }

    public class StaffAssignmentResponse
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime AssignedAt { get; set; }

        // Shipping-specific properties
        public int? ShippingOrderId { get; set; }
        public bool? IsDelivered { get; set; }
        public int? VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public VehicleType? VehicleType { get; set; }
        public OrderSize? OrderSize { get; set; }

        // Task type that was performed
        public StaffTaskType TaskType { get; set; }
    }

    public class StaffShippingOrderDTO
    {
        public int ShippingOrderId { get; set; }
        public string OrderId { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string DeliveryNotes { get; set; }
        public bool IsDelivered { get; set; }

        // Order information
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        // Customer information
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        // Order type indicators
        public bool HasSellItems { get; set; }
        public bool HasRentItems { get; set; }

        // Order details summary

    }
    public class OrderStatusUpdateDTO
    {
        public string OrderCode { get; set; }
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class OrderDetailDTO
    {
        public string OrderCode { get; set; }
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // User information
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }

        // Shipping information
        public ShippingDetailDTO ShippingInfo { get; set; }

        // Order details    
        public bool HasSellItems { get; set; }
        public bool HasRentItems { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

        public RentalInfoDTO RentalInfo { get; set; }
        public VehicleInfoDto VehicleInfo { get; set; }
    }

    public class OrderItemDTO
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public int? ItemId { get; set; }
    }

    public class RentalInfoDTO
    {
        public DateTime RentalStartDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }

    public class ShippingDetailDTO
    {
        public int ShippingOrderId { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string DeliveryNotes { get; set; }
        public bool IsDelivered { get; set; }
    }

    public class DeliveryStatusUpdateDTO
    {
        public int ShippingOrderId { get; set; }
        public string OrderCode { get; set; }
        public int OrderId { get; set; }

        public bool IsDelivered { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string DeliveryNotes { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class DeliveryTimeUpdateDTO
    {
        public int ShippingOrderId { get; set; }
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateTime DeliveryTime { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class OrderCountsDTO
    {
        public int PendingCount { get; set; }
        public int ProcessingCount { get; set; }
        public int ShippedCount { get; set; }
        public int DeliveredCount { get; set; }
        public int CancelledCount { get; set; }
        public int ReturningCount { get; set; }
        public int CompletedCount { get; set; }
        public int TotalCount { get; set; }
    }
}
