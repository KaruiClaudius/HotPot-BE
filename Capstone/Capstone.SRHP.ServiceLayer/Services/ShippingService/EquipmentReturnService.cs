using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.ShippingService
{
    public class EquipmentReturnService : IEquipmentReturnService
    {
        private readonly IUnitOfWork _unitOfWork;

        public readonly IStaffAssignmentService _staffAssignmentService;
        private readonly ILogger<EquipmentReturnService> _logger;

        public EquipmentReturnService(
            IUnitOfWork unitOfWork,
            IStaffAssignmentService staffAssignmentService,
            ILogger<EquipmentReturnService> logger)
        {
            _unitOfWork = unitOfWork;

            _staffAssignmentService = staffAssignmentService;
            _logger = logger;
        }

        public async Task<bool> CompletePickupAssignmentAsync(int assignmentId, EquipmentReturnRequest returnRequest)
        {
            try
            {
                _logger.LogInformation("Completing pickup assignment {AssignmentId}", assignmentId);

                // Pass both parameters to the staff assignment service
                return await _staffAssignmentService.CompleteAssignmentAsync(assignmentId, returnRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error completing pickup assignment {AssignmentId}", assignmentId);
                throw;
            }
        }

        public async Task<RentOrder> GetRentOrderAsync(int orderId)
        {
            var rentOrder = await _unitOfWork.Repository<RentOrder>()
                .AsQueryable()
                .Include(r => r.Order)
                    .ThenInclude(o => o.User)
                .Include(r => r.RentOrderDetails)
                    .ThenInclude(d => d.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                .FirstOrDefaultAsync(r => r.OrderId == orderId && !r.IsDelete);

            if (rentOrder == null)
                throw new NotFoundException($"Rent order with ID {orderId} not found");

            return rentOrder;
        }

    }

}

