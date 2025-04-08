using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.SideServices
{
    public class SignalRNotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public SignalRNotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyNewReplacementRequestAsync(ReplacementRequest request)
        {
            string equipmentName = "";

            if (request.EquipmentType == ModelLayer.Enum.EquipmentType.HotPot && request.HotPotInventory != null)
            {
                equipmentName = request.HotPotInventory.Hotpot?.Name ?? $"HotPot #{request.HotPotInventory.SeriesNumber}";
            }
            else if (request.EquipmentType == ModelLayer.Enum.EquipmentType.Utensil && request.Utensil != null)
            {
                equipmentName = request.Utensil.Name;
            }

            await _hubContext.Clients.Group("Managers").SendAsync("ReceiveNewReplacementRequest",
                request.ReplacementRequestId,
                request.EquipmentType.ToString(),
                equipmentName,
                request.RequestReason,
                request.Customer?.Name ?? "Unknown Customer",
                request.RequestDate);
        }

        public async Task NotifyReplacementStatusChangeAsync(ReplacementRequest request)
        {
            string equipmentName = "";

            if (request.EquipmentType == ModelLayer.Enum.EquipmentType.HotPot && request.HotPotInventory != null)
            {
                equipmentName = request.HotPotInventory.Hotpot?.Name ?? $"HotPot #{request.HotPotInventory.SeriesNumber}";
            }
            else if (request.EquipmentType == ModelLayer.Enum.EquipmentType.Utensil && request.Utensil != null)
            {
                equipmentName = request.Utensil.Name;
            }

            await _hubContext.Clients.Group("Managers").SendAsync("ReceiveReplacementStatusChange",
                request.ReplacementRequestId,
                request.EquipmentType.ToString(),
                equipmentName,
                request.Status.ToString(),
                request.AssignedStaff?.Name ?? "Unassigned",
                DateTime.UtcNow);
        }

        public async Task NotifyCustomerAboutReplacementAsync(ReplacementRequest request)
        {
            if (request.Customer?.UserId == null)
                return;

            string equipmentName = "";

            if (request.EquipmentType == ModelLayer.Enum.EquipmentType.HotPot && request.HotPotInventory != null)
            {
                equipmentName = request.HotPotInventory.Hotpot?.Name ?? $"HotPot #{request.HotPotInventory.SeriesNumber}";
            }
            else if (request.EquipmentType == ModelLayer.Enum.EquipmentType.Utensil && request.Utensil != null)
            {
                equipmentName = request.Utensil.Name;
            }

            await _hubContext.Clients.Group($"User_{request.Customer.UserId}").SendAsync("ReceiveReplacementUpdate",
                request.ReplacementRequestId,
                request.EquipmentType.ToString(),
                equipmentName,
                request.Status.ToString(),
                request.ReviewNotes ?? "",
                DateTime.UtcNow);
        }

        // Rental methods
        public async Task NotifyCustomerRentalExtendedAsync(int userId, int rentalId, DateTime newReturnDate)
        {
            await _hubContext.Clients.Group($"User_{userId}").SendAsync("ReceiveRentalNotification",
                new
                {
                    Type = "RentalExtended",
                    Title = "Rental Period Extended",
                    Message = $"Your rental period has been extended to {newReturnDate.ToShortDateString()}",
                    RentalId = rentalId,
                    NewReturnDate = newReturnDate,
                    Timestamp = DateTime.UtcNow
                });
        }

        public async Task NotifyCustomerRentalReturnedAsync(int userId, int rentalId)
        {
            await _hubContext.Clients.Group($"User_{userId}").SendAsync("ReceiveRentalNotification",
                new
                {
                    Type = "RentalReturned",
                    Title = "Rental Returned",
                    Message = "Your rental has been successfully returned",
                    RentalId = rentalId,
                    Timestamp = DateTime.UtcNow
                });
        }

        public async Task NotifyStaffNewAssignmentAsync(int staffId, int assignmentId, StaffPickupAssignmentDto assignment)
        {
            string equipmentDescription = assignment.EquipmentSummary ?? "equipment";

            await _hubContext.Clients.Group($"User_{staffId}").SendAsync("ReceiveRentalNotification",
                new
                {
                    Type = "NewAssignment",
                    Title = "New Pickup Assignment",
                    Message = $"You have been assigned to pick up {equipmentDescription} from {assignment.CustomerName}",
                    AssignmentId = assignmentId,
                    Assignment = assignment,
                    Timestamp = DateTime.UtcNow
                });
        }

        public async Task NotifyStaffAssignmentCompletedAsync(int staffId, int assignmentId)
        {
            await _hubContext.Clients.Group($"User_{staffId}").SendAsync("ReceiveRentalNotification",
                new
                {
                    Type = "AssignmentCompleted",
                    Title = "Assignment Completed",
                    Message = "You have successfully completed a pickup assignment",
                    AssignmentId = assignmentId,
                    Timestamp = DateTime.UtcNow
                });
        }

        public async Task NotifyManagerNewPickupRequestAsync(int rentalId, string customerName)
        {
            await _hubContext.Clients.Group("Manager").SendAsync("ReceiveRentalNotification",
                new
                {
                    Type = "NewPickupRequest",
                    Title = "New Pickup Request",
                    Message = $"A new pickup request has been submitted by {customerName}",
                    RentalId = rentalId,
                    CustomerName = customerName,
                    Timestamp = DateTime.UtcNow
                });
        }

        public async Task NotifyManagerAssignmentCompletedAsync(int assignmentId, int staffId, string staffName)
        {
            await _hubContext.Clients.Group("Manager").SendAsync("ReceiveRentalNotification",
                new
                {
                    Type = "AssignmentCompleted",
                    Title = "Assignment Completed",
                    Message = $"Staff member {staffName} has completed a pickup assignment",
                    AssignmentId = assignmentId,
                    StaffId = staffId,
                    StaffName = staffName,
                    Timestamp = DateTime.UtcNow
                });
        }

        public async Task NotifyAllStaffNewPendingPickupAsync(int rentalId, string customerName)
        {
            await _hubContext.Clients.Group("Staff").SendAsync("ReceiveRentalNotification",
                new
                {
                    Type = "NewPendingPickup",
                    Title = "New Pending Pickup",
                    Message = $"A new rental from {customerName} is ready for pickup",
                    RentalId = rentalId,
                    CustomerName = customerName,
                    Timestamp = DateTime.UtcNow
                });
        }       
    }
}
