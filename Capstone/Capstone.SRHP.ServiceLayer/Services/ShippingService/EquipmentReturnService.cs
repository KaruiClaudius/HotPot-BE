using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.ShippingService
{
    public class EquipmentReturnService : IEquipmentReturnService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;
        private readonly IUtensilService _utensilService;
        private readonly ILogger<EquipmentReturnService> _logger;

        public EquipmentReturnService(
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            IUtensilService utensilService,
            ILogger<EquipmentReturnService> logger)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _utensilService = utensilService;
            _logger = logger;
        }

        public async Task<bool> CompletePickupAssignmentAsync(
            int assignmentId,
            EquipmentReturnRequest request)
        {
            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // Get the assignment
                var assignment = await _unitOfWork.Repository<StaffPickupAssignment>()
                    .GetById(assignmentId);

                if (assignment == null)
                    throw new NotFoundException($"Assignment with ID {assignmentId} not found");

                // Update assignment
                assignment.CompletedDate = request.ReturnDate;
                assignment.Notes = string.IsNullOrEmpty(assignment.Notes)
                    ? $"Return condition: {request.ReturnCondition}"
                    : $"{assignment.Notes}\nReturn condition: {request.ReturnCondition}";
                assignment.SetUpdateDate();

                await _unitOfWork.Repository<StaffPickupAssignment>().UpdateDetached(assignment);

                // Process the equipment return
                var rentOrderDetailId = assignment.RentOrderDetailId;
                await ProcessEquipmentReturnInternalAsync(rentOrderDetailId, request);

                // Send notifications
                await _notificationService.NotifyStaffAssignmentCompletedAsync(
                    request.StaffId, assignmentId);

                var staff = await _unitOfWork.Repository<User>().GetById(request.StaffId);
                await _notificationService.NotifyManagerAssignmentCompletedAsync(
                    assignmentId,
                    request.StaffId,
                    staff?.Name ?? "Staff member");

                return true;
            });
        }
        public async Task<RentOrderDetail> GetRentOrderDetailAsync(int rentOrderDetailId)
        {
            var rentOrderDetail = await _unitOfWork.Repository<RentOrderDetail>()
                .AsQueryable()
                .Include(r => r.Order)
                    .ThenInclude(o => o.User)
                .Include(r => r.Utensil)
                .Include(r => r.HotpotInventory)
                    .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                .FirstOrDefaultAsync(r => r.RentOrderDetailId == rentOrderDetailId && !r.IsDelete);

            if (rentOrderDetail == null)
                throw new NotFoundException($"Rent order detail with ID {rentOrderDetailId} not found");

            return rentOrderDetail;
        }

        public async Task<bool> ProcessEquipmentReturnAsync(EquipmentReturnRequest request)
        {
            if (!request.RentOrderDetailId.HasValue)
                throw new ValidationException("RentOrderDetailId is required");

            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                await ProcessEquipmentReturnInternalAsync(
                    request.RentOrderDetailId.Value, request);

                // Send notification to the customer
                var rentOrderDetail = await GetRentOrderDetailAsync(request.RentOrderDetailId.Value);
                if (rentOrderDetail.Order?.UserId != null)
                {
                    await _notificationService.NotifyCustomerRentalReturnedAsync(
                        rentOrderDetail.Order.UserId,
                        request.RentOrderDetailId.Value);
                }

                return true;
            });
        }

        private async Task ProcessEquipmentReturnInternalAsync(
            int rentOrderDetailId,
            EquipmentReturnRequest request)
        {
            // Get the rent order detail
            var rentOrderDetail = await GetRentOrderDetailAsync(rentOrderDetailId);

            // Validate request
            if (request.ReturnDate < rentOrderDetail.RentalStartDate)
                throw new ValidationException("Return date cannot be earlier than rental start date");

            // Update rent order detail
            rentOrderDetail.ActualReturnDate = request.ReturnDate;
            rentOrderDetail.ReturnCondition = request.ReturnCondition;

            // Calculate late fee if applicable
            if (request.ReturnDate > rentOrderDetail.ExpectedReturnDate)
            {
                var daysLate = (request.ReturnDate - rentOrderDetail.ExpectedReturnDate).Days;
                rentOrderDetail.LateFee = daysLate * (rentOrderDetail.RentalPrice * 0.1m); // 10% of rental price per day
            }

            // Set damage fee if applicable
            if (!string.IsNullOrEmpty(request.ReturnCondition) && request.DamageFee.HasValue)
            {
                rentOrderDetail.DamageFee = request.DamageFee;
            }

            // Update notes
            if (!string.IsNullOrEmpty(request.Notes))
            {
                rentOrderDetail.RentalNotes = string.IsNullOrEmpty(rentOrderDetail.RentalNotes)
                    ? request.Notes
                    : $"{rentOrderDetail.RentalNotes}\n{request.Notes}";
            }

            rentOrderDetail.SetUpdateDate();
            await _unitOfWork.Repository<RentOrderDetail>().UpdateDetached(rentOrderDetail);

            // Check if all rentals for this order have been returned
            await UpdateOrderStatusIfAllReturned(rentOrderDetail.OrderId);

            // Update inventory status
            await UpdateInventoryStatus(rentOrderDetail);
        }

        private async Task UpdateOrderStatusIfAllReturned(int orderId)
        {
            var order = await _unitOfWork.Repository<Order>().GetById(orderId);
            var allRentals = await _unitOfWork.Repository<RentOrderDetail>()
                .AsQueryable(r => r.OrderId == orderId && !r.IsDelete)
                .ToListAsync();

            if (allRentals.All(r => r.ActualReturnDate.HasValue))
            {
                // All items returned, update order status if it's in Returning status
                if (order.Status == OrderStatus.Returning)
                {
                    order.Status = OrderStatus.Completed;
                    order.SetUpdateDate();
                    await _unitOfWork.Repository<Order>().UpdateDetached(order);
                }
            }
        }

        private async Task UpdateInventoryStatus(RentOrderDetail rentOrderDetail)
        {
            if (rentOrderDetail.UtensilId.HasValue)
            {
                var utensil = await _utensilService.GetUtensilByIdAsync(rentOrderDetail.UtensilId.Value);
                if (utensil != null)
                {
                    // Update utensil quantity
                    await _utensilService.UpdateUtensilQuantityAsync(utensil.UtensilId, rentOrderDetail.Quantity);
                }
            }
            else if (rentOrderDetail.HotpotInventoryId.HasValue)
            {
                var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>().GetById(rentOrderDetail.HotpotInventoryId.Value);
                if (hotpotInventory != null)
                {
                    // Set hotpot inventory to maintenance status
                    hotpotInventory.Status = false; // Maintenance mode
                    hotpotInventory.SetUpdateDate();
                    await _unitOfWork.Repository<HotPotInventory>().UpdateDetached(hotpotInventory);

                    // Update hotpot quantity
                    if (hotpotInventory.Hotpot != null)
                    {
                        hotpotInventory.Hotpot.Quantity += 1;
                        hotpotInventory.Hotpot.SetUpdateDate();
                        await _unitOfWork.Repository<Hotpot>().UpdateDetached(hotpotInventory.Hotpot);
                    }
                }
            }
        }

    }

}

