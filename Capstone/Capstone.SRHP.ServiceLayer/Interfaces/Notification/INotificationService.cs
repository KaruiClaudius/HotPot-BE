using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using System;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.Notification
{
    public interface INotificationService
    {
        // Equipment and inventory
        Task NotifyEquipmentIssue(int equipmentId, string equipmentType, string equipmentName, string issue, string details);
        Task NotifyInventoryStatus(string itemType, string itemName, int quantity, int threshold, bool isLow);

        // Generic notifications
        Task NotifyUser(int userId, string type, string title, string message, Dictionary<string, object> data = null);
        Task NotifyRole(string role, string type, string title, string message, Dictionary<string, object> data = null);
        Task NotifyFeedback(string target, string targetId, string feedbackType, string title, string message, Dictionary<string, object> data = null);
    }
}