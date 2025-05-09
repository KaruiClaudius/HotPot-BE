using Capstone.HPTY.ServiceLayer.DTOs.Notification;
using System;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.Notification
{
    public interface INotificationClient
    {
        // Generic notification method
        Task ReceiveNotification(NotificationDto notification);

    }
}