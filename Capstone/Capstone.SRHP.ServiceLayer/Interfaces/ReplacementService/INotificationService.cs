using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using System;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService
{
    public interface INotificationService
    {
        // Equipment condition notifications
        Task NotifyConditionIssue(int conditionLogId, string equipmentType, string equipmentName,
            string issueName, string description, string scheduleType);
        Task NotifyLowStock(string equipmentType, string equipmentName, int currentQuantity, int threshold);
        Task NotifyStatusChange(string equipmentType, int equipmentId, string equipmentName, bool isAvailable, string reason);
        Task NotifyEquipmentStatusChange(int conditionLogId, string equipmentType, string equipmentName,
            string issueName, string status);

        // Feedback notifications
        Task NotifyFeedbackResponse(int userId, int feedbackId, string responseMessage, string managerName);
        Task NotifyNewFeedback(int feedbackId, string customerName, string feedbackTitle);
        Task NotifyFeedbackApproved(int feedbackId, string adminName, string feedbackTitle);

        // Schedule notifications
        Task NotifyScheduleUpdate(int userId, DateTime shiftDate);
        Task NotifyAllScheduleUpdates();

        // Resolution notifications
        Task SendResolutionUpdate(int conditionLogId, string status, DateTime estimatedResolutionTime, string message);
        Task SendCustomerUpdate(int customerId, int conditionLogId, string equipmentName, string status,
            DateTime estimatedResolutionTime, string message);

        // Rental notifications
        Task NotifyCustomerRentalExtendedAsync(int userId, int rentalId, DateTime newReturnDate);
        Task NotifyCustomerRentalReturnedAsync(int userId, int rentalId);
        Task NotifyStaffNewAssignmentAsync(int staffId, int assignmentId, StaffPickupAssignmentDto assignment);
        Task NotifyStaffAssignmentCompletedAsync(int staffId, int assignmentId);
        Task NotifyManagerNewPickupRequestAsync(int rentalId, string customerName);
        Task NotifyManagerAssignmentCompletedAsync(int assignmentId, int staffId, string staffName);
        Task NotifyAllStaffNewPendingPickupAsync(int rentalId, string customerName);

        // Replacement notifications
        Task NotifyNewReplacementRequestAsync(ReplacementRequest request);
        Task NotifyReplacementStatusChangeAsync(ReplacementRequest request);
        Task NotifyCustomerAboutReplacementAsync(ReplacementRequest request);
        Task NotifyStaffReplacementAssignmentAsync(int staffId, int requestId, string equipmentName,
            string requestReason, string status);
        Task NotifyCustomerDirectlyAsync(int customerId, int conditionLogId, string message,
            DateTime estimatedResolutionTime);
    }
}