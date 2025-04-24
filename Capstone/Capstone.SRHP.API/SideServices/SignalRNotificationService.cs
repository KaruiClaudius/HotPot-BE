using System;
using System.Threading.Tasks;
using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Notification;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.SideServices
{
    public class SignalRNotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub, INotificationClient> _hubContext;
        private readonly IConnectionManager _connectionManager;

        public SignalRNotificationService(
            IHubContext<NotificationHub, INotificationClient> hubContext,
            IConnectionManager connectionManager)
        {
            _hubContext = hubContext;
            _connectionManager = connectionManager;
        }

        public async Task NotifyConditionIssue(int conditionLogId, string equipmentType, string equipmentName,
            string issueName, string description, string scheduleType)
        {
            var alert = new EquipmentAlertDto
            {
                Type = "ConditionIssue",
                Title = "Equipment Condition Issue",
                Message = $"Issue detected with {equipmentName}: {issueName}",
                ConditionLogId = conditionLogId,
                EquipmentType = equipmentType,
                EquipmentName = equipmentName,
                IssueName = issueName,
                Description = description,
                ScheduleType = scheduleType,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Administrators").ReceiveConditionAlert(alert);
        }

        public async Task NotifyLowStock(string equipmentType, string equipmentName, int currentQuantity, int threshold)
        {
            var stockAlert = new StockAlertDto
            {
                Type = "LowStock",
                Title = "Low Stock Alert",
                Message = $"Low stock for {equipmentName}: {currentQuantity} remaining (threshold: {threshold})",
                EquipmentType = equipmentType,
                EquipmentName = equipmentName,
                CurrentQuantity = currentQuantity,
                Threshold = threshold,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Administrators").ReceiveLowStockAlert(stockAlert);
        }

        public async Task NotifyStatusChange(string equipmentType, int equipmentId, string equipmentName, bool isAvailable, string reason)
        {
            var status = new EquipmentStatusDto
            {
                Type = "StatusChange",
                Title = "Equipment Status Change",
                Message = $"{equipmentName} is now {(isAvailable ? "available" : "unavailable")}: {reason}",
                EquipmentType = equipmentType,
                EquipmentId = equipmentId,
                EquipmentName = equipmentName,
                IsAvailable = isAvailable,
                Reason = reason,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Administrators").ReceiveStatusChangeAlert(status);
        }

        public async Task NotifyFeedbackResponse(int userId, int feedbackId, string responseMessage, string managerName)
        {
            var response = new FeedbackResponseDto
            {
                Type = "FeedbackResponse",
                Title = "Feedback Response",
                Message = $"Your feedback has received a response from {managerName}",
                FeedbackId = feedbackId,
                ResponseMessage = responseMessage,
                ResponderName = managerName,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group($"User_{userId}").ReceiveFeedbackResponse(response);
        }

        public async Task NotifyNewFeedback(int feedbackId, string customerName, string feedbackTitle)
        {
            var notification = new GeneralNotificationDto
            {
                Type = "NewFeedback",
                Title = "New Feedback Received",
                Message = $"New feedback from {customerName}: {feedbackTitle}",
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Admins").ReceiveNewFeedback(
                feedbackId,
                customerName,
                feedbackTitle,
                DateTime.UtcNow);
        }

        public async Task NotifyFeedbackApproved(int feedbackId, string adminName, string feedbackTitle)
        {
            var notification = new GeneralNotificationDto
            {
                Type = "FeedbackApproved",
                Title = "Feedback Approved",
                Message = $"Feedback approved by {adminName}: {feedbackTitle}",
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Managers").ReceiveApprovedFeedback(
                feedbackId,
                feedbackTitle,
                adminName,
                DateTime.UtcNow);
        }

        public async Task NotifyScheduleUpdate(int userId, DateTime shiftDate)
        {
            var update = new ScheduleUpdateDto
            {
                Type = "ScheduleUpdate",
                Title = "Schedule Update",
                Message = $"Your schedule has been updated for {shiftDate.ToShortDateString()}",
                UserId = userId,
                ShiftDate = shiftDate,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group($"User_{userId}").ReceiveScheduleUpdate(update);
        }

        public async Task NotifyAllScheduleUpdates()
        {
            var notification = new GeneralNotificationDto
            {
                Type = "AllScheduleUpdates",
                Title = "Schedule Updates",
                Message = "The staff schedule has been updated",
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Staff").ReceiveAllScheduleUpdates();
        }

        public async Task SendResolutionUpdate(int conditionLogId, string status, DateTime estimatedResolutionTime, string message)
        {
            var notification = new EquipmentStatusUpdateDto
            {
                Type = "ResolutionUpdate",
                Title = "Resolution Update",
                Message = message,
                ConditionLogId = conditionLogId,
                Status = status,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Staff").ReceiveResolutionUpdate(
                conditionLogId,
                status,
                estimatedResolutionTime,
                message);
        }

        public async Task SendCustomerUpdate(int customerId, int conditionLogId, string equipmentName, string status, DateTime estimatedResolutionTime, string message)
        {
            var notification = new EquipmentStatusUpdateDto
            {
                Type = "CustomerUpdate",
                Title = "Equipment Update",
                Message = message,
                ConditionLogId = conditionLogId,
                EquipmentName = equipmentName,
                Status = status,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group($"User_{customerId}").ReceiveEquipmentUpdate(
                conditionLogId,
                equipmentName,
                status,
                estimatedResolutionTime,
                message);
        }

        // Rental methods
        public async Task NotifyCustomerRentalExtendedAsync(int userId, int rentalId, DateTime newReturnDate)
        {
            var notification = new RentalExtendedDto
            {
                Type = "RentalExtended",
                Title = "Rental Period Extended",
                Message = $"Your rental period has been extended to {newReturnDate.ToShortDateString()}",
                RentalId = rentalId,
                NewReturnDate = newReturnDate,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group($"User_{userId}").ReceiveRentalNotification(notification);
        }

        public async Task NotifyCustomerRentalReturnedAsync(int userId, int rentalId)
        {
            var notification = new RentalReturnedDto
            {
                Type = "RentalReturned",
                Title = "Rental Returned",
                Message = "Your rental has been successfully returned",
                RentalId = rentalId,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group($"User_{userId}").ReceiveRentalNotification(notification);
        }

        public async Task NotifyStaffNewAssignmentAsync(int staffId, int assignmentId, StaffPickupAssignmentDto assignment)
        {
            string equipmentDescription = assignment.EquipmentSummary ?? "equipment";

            var notification = new StaffAssignmentDto
            {
                Type = "NewAssignment",
                Title = "New Pickup Assignment",
                Message = $"You have been assigned to pick up {equipmentDescription} from {assignment.CustomerName}",
                AssignmentId = assignmentId,
                Assignment = assignment,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group($"User_{staffId}").ReceiveRentalNotification(notification);
        }

        public async Task NotifyStaffAssignmentCompletedAsync(int staffId, int assignmentId)
        {
            var notification = new AssignmentCompletedDto
            {
                Type = "AssignmentCompleted",
                Title = "Assignment Completed",
                Message = "You have successfully completed a pickup assignment",
                AssignmentId = assignmentId,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group($"User_{staffId}").ReceiveRentalNotification(notification);
        }

        public async Task NotifyManagerNewPickupRequestAsync(int rentalId, string customerName)
        {
            var notification = new ManagerPickupRequestDto
            {
                Type = "NewPickupRequest",
                Title = "New Pickup Request",
                Message = $"A new pickup request has been submitted by {customerName}",
                RentalId = rentalId,
                CustomerName = customerName,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Managers").ReceiveRentalNotification(notification);
        }

        public async Task NotifyManagerAssignmentCompletedAsync(int assignmentId, int staffId, string staffName)
        {
            var notification = new ManagerAssignmentCompletedDto
            {
                Type = "AssignmentCompleted",
                Title = "Assignment Completed",
                Message = $"Staff member {staffName} has completed a pickup assignment",
                AssignmentId = assignmentId,
                StaffId = staffId,
                StaffName = staffName,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Managers").ReceiveRentalNotification(notification);
        }

        public async Task NotifyAllStaffNewPendingPickupAsync(int rentalId, string customerName)
        {
            var notification = new PendingPickupDto
            {
                Type = "NewPendingPickup",
                Title = "New Pending Pickup",
                Message = $"A new rental from {customerName} is ready for pickup",
                RentalId = rentalId,
                CustomerName = customerName,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Staff").ReceiveRentalNotification(notification);
        }

        public async Task NotifyEquipmentStatusChange(int conditionLogId, string equipmentType, string equipmentName,
            string issueName, string status)
        {
            var statusUpdate = new EquipmentStatusUpdateDto
            {
                Type = "StatusUpdate",
                Title = "Equipment Status Update",
                Message = $"Status updated to {status} for {equipmentName}",
                ConditionLogId = conditionLogId,
                EquipmentType = equipmentType,
                EquipmentName = equipmentName,
                IssueName = issueName,
                Status = status,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Administrators").ReceiveStatusUpdate(statusUpdate);
        }

        // Replacement request methods
        public async Task NotifyNewReplacementRequestAsync(ReplacementRequest request)
        {
            string equipmentName = GetEquipmentName(request);

            var notification = new ReplacementRequestNotificationDto
            {
                Type = "NewReplacementRequest",
                Title = "New Replacement Request",
                Message = $"New replacement request for {equipmentName}",
                ReplacementRequestId = request.ReplacementRequestId,
                EquipmentName = equipmentName,
                RequestReason = request.RequestReason,
                CustomerName = request.Customer?.Name ?? "Unknown Customer",
                Status = request.Status.ToString(),
                RequestDate = request.RequestDate,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group("Managers").ReceiveReplacementNotification(notification);
        }

        public async Task NotifyReplacementStatusChangeAsync(ReplacementRequest request)
        {
            string equipmentName = GetEquipmentName(request);
            string statusMessage = GetStatusMessage(request.Status);

            var notification = new ReplacementStatusUpdateDto
            {
                Type = "ReplacementStatusUpdate",
                Title = "Replacement Status Update",
                Message = $"Replacement request for {equipmentName} is now {statusMessage}",
                ReplacementRequestId = request.ReplacementRequestId,
                EquipmentName = equipmentName,
                Status = request.Status.ToString(),
                StatusMessage = statusMessage,
                ReviewNotes = request.ReviewNotes,
                UpdateDate = request.ReviewDate ?? DateTime.UtcNow,
                Timestamp = DateTime.UtcNow
            };

            // Notify all staff members about the status change
            await _hubContext.Clients.Group("Staff").ReceiveReplacementNotification(notification);
        }

        public async Task NotifyCustomerAboutReplacementAsync(ReplacementRequest request)
        {
            if (request.CustomerId <= 0)
                return;

            string equipmentName = GetEquipmentName(request);
            string statusMessage = GetCustomerFriendlyStatusMessage(request.Status);

            var notification = new CustomerReplacementUpdateDto
            {
                Type = "CustomerReplacementUpdate",
                Title = "Replacement Request Update",
                Message = $"Your replacement request for {equipmentName} is now {statusMessage}",
                ReplacementRequestId = request.ReplacementRequestId,
                EquipmentName = equipmentName,
                Status = statusMessage,
                Notes = request.ReviewNotes ?? "Your request is being processed.",
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group($"User_{request.CustomerId}").ReceiveReplacementNotification(notification);
        }

        public async Task NotifyStaffReplacementAssignmentAsync(int staffId, int requestId, string equipmentName, string requestReason, string status)
        {
            var notification = new StaffReplacementAssignmentDto
            {
                Type = "StaffReplacementAssignment",
                Title = "New Replacement Assignment",
                Message = $"You have been assigned to handle a replacement for {equipmentName}",
                ReplacementRequestId = requestId,
                EquipmentName = equipmentName,
                RequestReason = requestReason,
                Status = status,
                Timestamp = DateTime.UtcNow
            };
            await _hubContext.Clients.Group($"User_{staffId}").ReceiveReplacementNotification(notification);
        }

        public async Task NotifyCustomerDirectlyAsync(int customerId, int conditionLogId, string message, DateTime estimatedResolutionTime)
        {
            var notification = new CustomerDirectNotificationDto
            {
                Type = "DirectNotification",
                Title = "Equipment Update",
                Message = message,
                ConditionLogId = conditionLogId,
                EstimatedResolutionTime = estimatedResolutionTime,
                Timestamp = DateTime.UtcNow
            };

            await _hubContext.Clients.Group($"User_{customerId}").ReceiveDirectNotification(notification);
        }

        // Helper methods
        private string GetEquipmentName(ReplacementRequest request)
        {

            if (request.HotPotInventory != null && request.HotPotInventory.Hotpot != null)
            {
                return request.HotPotInventory.Hotpot.Name ?? $"HotPot #{request.HotPotInventory.SeriesNumber}";
            }

            return "Unknown Equipment";
        }

        private string GetStatusMessage(ReplacementRequestStatus status)
        {
            return status switch
            {
                ReplacementRequestStatus.Pending => "pending review",
                ReplacementRequestStatus.Approved => "approved",
                ReplacementRequestStatus.Rejected => "rejected",
                ReplacementRequestStatus.InProgress => "in progress",
                ReplacementRequestStatus.Completed => "completed",
                ReplacementRequestStatus.Cancelled => "cancelled",
                _ => status.ToString().ToLower()
            };
        }

        private string GetCustomerFriendlyStatusMessage(ReplacementRequestStatus status)
        {
            return status switch
            {
                ReplacementRequestStatus.Pending => "pending review",
                ReplacementRequestStatus.Approved => "approved and will be processed soon",
                ReplacementRequestStatus.Rejected => "rejected",
                ReplacementRequestStatus.InProgress => "being processed",
                ReplacementRequestStatus.Completed => "completed",
                ReplacementRequestStatus.Cancelled => "cancelled",
                _ => status.ToString().ToLower()
            };
        }
    }
}