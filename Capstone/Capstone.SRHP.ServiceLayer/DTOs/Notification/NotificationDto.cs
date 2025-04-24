using System;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;

namespace Capstone.HPTY.ServiceLayer.DTOs.Notification
{
    // Base notification DTO
    public abstract class NotificationDto
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    // General notification for basic messages
    public class GeneralNotificationDto : NotificationDto
    {
        // Inherits all properties from NotificationDto
    }

    // Equipment condition notifications
    public class EquipmentAlertDto : NotificationDto
    {
        public int ConditionLogId { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentName { get; set; }
        public string IssueName { get; set; }
        public string Description { get; set; }
        public string ScheduleType { get; set; }
    }

    public class EquipmentStatusUpdateDto : NotificationDto
    {
        public int ConditionLogId { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentName { get; set; }
        public string IssueName { get; set; }
        public string Status { get; set; }
    }

    // Equipment status notifications
    public class EquipmentStatusDto : NotificationDto
    {
        public string EquipmentType { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public bool IsAvailable { get; set; }
        public string Reason { get; set; }
    }

    // Feedback notifications
    public class FeedbackResponseDto : NotificationDto
    {
        public int FeedbackId { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponderName { get; set; }
    }

    // Schedule notifications
    public class ScheduleUpdateDto : NotificationDto
    {
        public int UserId { get; set; }
        public DateTime ShiftDate { get; set; }
    }

    // Stock notifications
    public class StockAlertDto : NotificationDto
    {
        public string EquipmentType { get; set; }
        public string EquipmentName { get; set; }
        public int CurrentQuantity { get; set; }
        public int Threshold { get; set; }
    }

    // Base replacement notification DTO
    public abstract class ReplacementNotificationDto : NotificationDto
    {
        public int ReplacementRequestId { get; set; }
    }

    // New replacement request notification
    public class ReplacementRequestNotificationDto : ReplacementNotificationDto
    {
        public string EquipmentName { get; set; }
        public string RequestReason { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }
    }

    // Replacement status update notification
    public class ReplacementStatusUpdateDto : ReplacementNotificationDto
    {
        public string EquipmentName { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
        public string ReviewNotes { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    // Customer replacement update notification
    public class CustomerReplacementUpdateDto : ReplacementNotificationDto
    {
        public string EquipmentName { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }

    // Staff replacement assignment notification
    public class StaffReplacementAssignmentDto : ReplacementNotificationDto
    {
        public string EquipmentName { get; set; }
        public string RequestReason { get; set; }
        public string Status { get; set; }
    }

    // Direct customer notification
    public class CustomerDirectNotificationDto : NotificationDto
    {
        public int ConditionLogId { get; set; }
        public DateTime EstimatedResolutionTime { get; set; }
    }

    // Rental notifications
    public class RentalExtendedDto : NotificationDto
    {
        public int RentalId { get; set; }
        public DateTime NewReturnDate { get; set; }
    }

    public class RentalReturnedDto : NotificationDto
    {
        public int RentalId { get; set; }
    }

    public class StaffAssignmentDto : NotificationDto
    {
        public int AssignmentId { get; set; }
        public StaffPickupAssignmentDto Assignment { get; set; }
    }

    public class AssignmentCompletedDto : NotificationDto
    {
        public int AssignmentId { get; set; }
    }

    public class ManagerPickupRequestDto : NotificationDto
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
    }

    public class ManagerAssignmentCompletedDto : NotificationDto
    {
        public int AssignmentId { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
    }

    public class PendingPickupDto : NotificationDto
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
    }

}