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

        // Staff assignment status
        public bool IsPreparationStaffAssigned { get; set; }
        public bool IsShippingStaffAssigned { get; set; }

        // Staff assignments (simplified for list view)
        public StaffAssignmentSummaryDTO PreparationAssignment { get; set; }
        public StaffAssignmentSummaryDTO ShippingAssignment { get; set; }

        // Shipping information
        public ShippingInfoDTO ShippingInfo { get; set; }

        // Vehicle Information
        public VehicleInfoDto VehicleInfo { get; set; }
    }

    public class StaffAssignmentSummaryDTO
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime AssignedDate { get; set; }
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
        // Common properties
        public int AssignmentId { get; set; }
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime AssignedAt { get; set; }
        public StaffTaskType TaskType { get; set; }

        // Shipping-specific properties
        public int? ShippingOrderId { get; set; }
        public bool? IsDelivered { get; set; }
        public int? VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public VehicleType? VehicleType { get; set; }
        public OrderSize? OrderSize { get; set; }

        // Pickup-specific properties
        public DateTime? RentalStartDate { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
    }


    public class StaffAssignmentDto
    {
        // Assignment properties
        public int AssignmentId { get; set; }
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public StaffTaskType TaskType { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsActive { get; set; }

        // Customer properties
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }

        // Task-specific details
        public ShippingDetailsDto ShippingDetails { get; set; }
        public RentalDetailsDto RentalDetails { get; set; }
    }
    public class ShippingDetailsDto
    {
        public int ShippingOrderId { get; set; }
        public bool IsDelivered { get; set; }
        public int? VehicleId { get; set; }
        public string VehicleName { get; set; }
        public VehicleType? VehicleType { get; set; }
        public OrderSize OrderSize { get; set; }
    }

    public class RentalDetailsDto
    {
        public DateTime RentalStartDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public string EquipmentSummary { get; set; }
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

        // Staff assignments
        public StaffAssignmentDTO PreparationAssignment { get; set; }
        public StaffAssignmentDTO ShippingAssignment { get; set; }

        // Shipping information
        public ShippingDetailDTO ShippingInfo { get; set; }

        // Order details    
        public bool HasSellItems { get; set; }
        public bool HasRentItems { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

        public RentalInfoDTO RentalInfo { get; set; }
        public VehicleInfoDto VehicleInfo { get; set; }
    }
    public class StaffAssignmentDTO
    {
        public int AssignmentId { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public StaffTaskType TaskType { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
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

    public class MultiStaffAssignmentRequest
    {
        [Required]
        public string OrderCode { get; set; }

        public List<int>? PreparationStaffIds { get; set; }

        public int? ShippingStaffId { get; set; }

        public int? VehicleId { get; set; }
    }
    public class MultiStaffAssignmentResponse
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public OrderStatus Status { get; set; }

        // Preparation details
        // Replace single preparation staff properties with a collection
        public List<StaffAssignmentSummaryDTO> PreparationStaffAssignments { get; set; } = new List<StaffAssignmentSummaryDTO>();

        // Shipping details
        public int? ShippingStaffId { get; set; }
        public string ShippingStaffName { get; set; }
        public int? ShippingAssignmentId { get; set; }
        public DateTime? ShippingAssignedAt { get; set; }
        public int? ShippingOrderId { get; set; }
        public bool IsDelivered { get; set; }
        public int? VehicleId { get; set; }
        public string VehicleName { get; set; }
        public VehicleType? VehicleType { get; set; }
        public OrderSize OrderSize { get; set; }
    }

}
