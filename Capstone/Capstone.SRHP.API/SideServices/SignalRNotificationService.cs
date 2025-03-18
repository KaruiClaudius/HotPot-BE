using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
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

            await _hubContext.Clients.User(request.Customer.UserId.ToString()).SendAsync("ReceiveReplacementUpdate",
                request.ReplacementRequestId,
                request.EquipmentType.ToString(),
                equipmentName,
                request.Status.ToString(),
                request.ReviewNotes ?? "",
                DateTime.UtcNow);
        }
    }
}
