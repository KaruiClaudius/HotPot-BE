using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Capstone.HPTY.API.SideServices
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<NotificationHub, INotificationClient> _hubContext;
        private readonly IConnectionManager _connectionManager;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(
            IUnitOfWork unitOfWork,
            IHubContext<NotificationHub, INotificationClient> hubContext,
            IConnectionManager connectionManager,
            ILogger<NotificationService> logger)
        {
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
            _connectionManager = connectionManager;
            _logger = logger;
        }

        public async Task<int> CreateNotificationAsync(string type, string title, string message, string targetType, string targetId, Dictionary<string, object> data = null)
        {
            try
            {
                var notification = new Notification
                {
                    Type = type,
                    Title = title,
                    Message = message,
                    TargetType = targetType,
                    TargetId = targetId,
                    DataJson = data != null ? JsonSerializer.Serialize(data) : null
                };

                await _unitOfWork.Repository<Notification>().InsertAsync(notification);
                await _unitOfWork.CommitAsync();

                return notification.NotificationId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating notification");
                throw;
            }
        }

        public async Task<int> CreateUserNotificationAsync(int notificationId, int userId)
        {
            try
            {
                var userNotification = new UserNotification
                {
                    NotificationId = notificationId,
                    UserId = userId,
                    IsRead = false,
                    IsDelivered = false
                };

                await _unitOfWork.Repository<UserNotification>().InsertAsync(userNotification);
                await _unitOfWork.CommitAsync();

                return userNotification.UserNotificationId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user notification");
                throw;
            }
        }

        public async Task NotifyUserAsync(int userId, string type, string title, string message, Dictionary<string, object> data = null)
        {
            try
            {
                // Create notification in database
                int notificationId = await CreateNotificationAsync(type, title, message, "User", userId.ToString(), data);

                // Create user-specific notification record
                await CreateUserNotificationAsync(notificationId, userId);

                // Send real-time notification if user is connected
                if (_connectionManager.IsUserConnected(userId))
                {
                    var notificationDto = new NotificationDto
                    {
                        Id = notificationId,
                        Type = type,
                        Title = title,
                        Message = message,
                        Timestamp = DateTime.UtcNow.AddHours(7),
                        Data = data ?? new Dictionary<string, object>()
                    };

                    await _hubContext.Clients.Group($"User_{userId}").ReceiveNotification(notificationDto);

                    // Mark as delivered
                    await MarkAsDeliveredAsync(notificationId, userId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error notifying user {userId}");
                throw;
            }
        }

        public async Task NotifyRoleAsync(string role, string type, string title, string message, Dictionary<string, object> data = null)
        {
            try
            {
                // Create notification in database
                int notificationId = await CreateNotificationAsync(type, title, message, "Role", role, data);

                // Get all users with this role - FIXED QUERY
                var usersWithRole = await _unitOfWork.Repository<User>()
                    .GetWhere(u => u.Role.Name.ToLower() == role.ToLower() && !u.IsDelete);

                foreach (var user in usersWithRole)
                {
                    // Create user-specific notification record
                    await CreateUserNotificationAsync(notificationId, user.UserId);
                }

                // Rest of the method remains unchanged
                var notificationDto = new NotificationDto
                {
                    Id = notificationId,
                    Type = type,
                    Title = title,
                    Message = message,
                    Timestamp = DateTime.UtcNow.AddHours(7),
                    Data = data ?? new Dictionary<string, object>()
                };

                await _hubContext.Clients.Group(role).ReceiveNotification(notificationDto);

                // Mark as delivered for connected users
                foreach (var user in usersWithRole)
                {
                    if (_connectionManager.IsUserConnected(user.UserId))
                    {
                        await MarkAsDeliveredAsync(notificationId, user.UserId);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error notifying role {role}");
                throw;
            }
        }

        public async Task NotifyAllAsync(string type, string title, string message, Dictionary<string, object> data = null)
        {
            try
            {
                // Create notification in database
                int notificationId = await CreateNotificationAsync(type, title, message, "All", "All", data);

                // Get all active users
                var allUsers = await _unitOfWork.Repository<User>()
                    .GetWhere(u => !u.IsDelete);

                foreach (var user in allUsers)
                {
                    // Create user-specific notification record
                    await CreateUserNotificationAsync(notificationId, user.UserId);
                }

                // Send real-time notification to all connected users
                var notificationDto = new NotificationDto
                {
                    Id = notificationId,
                    Type = type,
                    Title = title,
                    Message = message,
                    Timestamp = DateTime.UtcNow.AddHours(7),
                    Data = data ?? new Dictionary<string, object>()
                };

                await _hubContext.Clients.All.ReceiveNotification(notificationDto);

                // Mark as delivered for connected users
                foreach (var user in allUsers)
                {
                    if (_connectionManager.IsUserConnected(user.UserId))
                    {
                        await MarkAsDeliveredAsync(notificationId, user.UserId);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error notifying all users");
                throw;
            }
        }

        public async Task<List<NotificationDto>> GetUserNotificationsAsync(int userId, bool includeRead = false, int page = 1, int pageSize = 20)
        {
            try
            {
                var userNotificationsQuery = _unitOfWork.Repository<UserNotification>()
                    .AsQueryable(un => un.UserId == userId && !un.IsDelete);

                if (!includeRead)
                {
                    userNotificationsQuery = userNotificationsQuery.Where(un => !un.IsRead);
                }

                var userNotifications = await userNotificationsQuery
                    .Include(un => un.Notification)
                    .OrderByDescending(un => un.Notification.CreatedAt)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return userNotifications.Select(un => new NotificationDto
                {
                    Id = un.Notification.NotificationId,
                    Type = un.Notification.Type,
                    Title = un.Notification.Title,
                    Message = un.Notification.Message,
                    Timestamp = un.Notification.CreatedAt,
                    Data = un.Notification.DataJson != null
                        ? JsonSerializer.Deserialize<Dictionary<string, object>>(un.Notification.DataJson)
                        : new Dictionary<string, object>(),
                    IsRead = un.IsRead,
                    ReadAt = un.ReadAt,
                    IsDelivered = un.IsDelivered,
                    DeliveredAt = un.DeliveredAt
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting notifications for user {userId}");
                throw;
            }
        }

        public async Task<int> GetUnreadNotificationCountAsync(int userId)
        {
            try
            {
                return await _unitOfWork.Repository<UserNotification>()
                    .CountAsync(un => un.UserId == userId && !un.IsRead && !un.IsDelete);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting unread notification count for user {userId}");
                throw;
            }
        }

        public async Task MarkAsReadAsync(int notificationId, int userId)
        {
            try
            {
                var userNotification = await _unitOfWork.Repository<UserNotification>()
                    .FindAsync(un => un.NotificationId == notificationId && un.UserId == userId);

                if (userNotification != null && !userNotification.IsRead)
                {
                    userNotification.MarkAsRead();
                    await _unitOfWork.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error marking notification {notificationId} as read for user {userId}");
                throw;
            }
        }

        public async Task MarkAllAsReadAsync(int userId)
        {
            try
            {
                var unreadNotifications = await _unitOfWork.Repository<UserNotification>()
                    .FindList(un => un.UserId == userId && !un.IsRead && !un.IsDelete);

                foreach (var notification in unreadNotifications)
                {
                    notification.MarkAsRead();
                }

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error marking all notifications as read for user {userId}");
                throw;
            }
        }

        public async Task MarkAsDeliveredAsync(int notificationId, int userId)
        {
            try
            {
                var userNotification = await _unitOfWork.Repository<UserNotification>()
                    .FindAsync(un => un.NotificationId == notificationId && un.UserId == userId);

                if (userNotification != null && !userNotification.IsDelivered)
                {
                    userNotification.MarkAsDelivered();
                    await _unitOfWork.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error marking notification {notificationId} as delivered for user {userId}");
                throw;
            }
        }

    }
}