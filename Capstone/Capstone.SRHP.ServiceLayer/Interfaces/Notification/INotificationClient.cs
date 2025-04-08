using Capstone.HPTY.ServiceLayer.DTOs.Notification;
using System;
using System.Threading.Tasks;

namespace Capstone.HPTY.API.Hubs
{
    public interface INotificationClient
    {
        // Equipment notifications
        Task ReceiveConditionAlert(EquipmentAlertDto alert);
        Task ReceiveLowStockAlert(StockAlertDto alert);
        Task ReceiveStatusChangeAlert(EquipmentStatusDto status);
        Task ReceiveStatusUpdate(EquipmentStatusUpdateDto statusUpdate);

        // Feedback notifications
        Task ReceiveFeedbackResponse(FeedbackResponseDto response);
        Task ReceiveNewFeedback(int feedbackId, string customerName, string feedbackTitle, DateTime timestamp);
        Task ReceiveApprovedFeedback(int feedbackId, string feedbackTitle, string adminName, DateTime timestamp);

        // Schedule notifications
        Task ReceiveScheduleUpdate(ScheduleUpdateDto update);
        Task ReceiveAllScheduleUpdates();

        // Resolution notifications
        Task ReceiveResolutionUpdate(int conditionLogId, string status, DateTime estimatedResolutionTime, string message);
        Task ReceiveEquipmentUpdate(int conditionLogId, string equipmentName, string status, DateTime estimatedResolutionTime, string message);

        // Rental notifications
        Task ReceiveRentalNotification(NotificationDto notification);

        // Replacement notifications
        Task ReceiveReplacementNotification(NotificationDto notification);
        Task ReceiveDirectNotification(CustomerDirectNotificationDto notification);
    }
}