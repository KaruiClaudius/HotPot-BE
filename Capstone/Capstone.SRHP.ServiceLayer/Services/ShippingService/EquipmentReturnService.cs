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
                var rentOrderId = assignment.OrderId;
                await ProcessEquipmentReturnInternalAsync(rentOrderId, request);

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


        public async Task<bool> ProcessEquipmentReturnAsync(EquipmentReturnRequest request)
        {
            if (!request.RentOrderId.HasValue)
                throw new ValidationException("RentOrderId is required");

            try
            {
                _logger.LogInformation("Processing equipment return request for rent order ID: {RentOrderId}", request.RentOrderId.Value);

                return await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    await ProcessEquipmentReturnInternalAsync(
                        request.RentOrderId.Value, request);

                    // Send notification to the customer
                    var rentOrder = await GetRentOrderAsync(request.RentOrderId.Value);
                    if (rentOrder.Order?.UserId != null)
                    {
                        await _notificationService.NotifyCustomerRentalReturnedAsync(
                            rentOrder.Order.UserId,
                            request.RentOrderId.Value);
                    }

                    _logger.LogInformation("Equipment return processed successfully for rent order ID: {RentOrderId}", request.RentOrderId.Value);
                    return true;
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProcessEquipmentReturnAsync for rent order ID: {RentOrderId}", request.RentOrderId.Value);
                throw;
            }
        }

        private async Task ProcessEquipmentReturnInternalAsync(
            int rentOrderId,
            EquipmentReturnRequest request)
        {
            try
            {
                _logger.LogInformation("Processing equipment return for rent order ID: {RentOrderId}", rentOrderId);

                // Get the rent order with tracking enabled
                var rentOrder = await _unitOfWork.Repository<RentOrder>()
                    .AsQueryable()
                    .Include(ro => ro.Order)
                    .Include(ro => ro.RentOrderDetails)
                    .FirstOrDefaultAsync(ro => ro.OrderId == rentOrderId && !ro.IsDelete);

                if (rentOrder == null)
                    throw new NotFoundException($"Rent order with ID {rentOrderId} not found");

                _logger.LogInformation("Found rent order: StartDate={StartDate}, ExpectedReturn={ExpectedReturn}, ActualReturn={ActualReturn}",
                    rentOrder.RentalStartDate, rentOrder.ExpectedReturnDate, rentOrder.ActualReturnDate);

                // Validate request
                if (request.ReturnDate < rentOrder.RentalStartDate)
                    throw new ValidationException("Return date cannot be earlier than rental start date");

                // Update rent order detail
                rentOrder.ActualReturnDate = request.ReturnDate;
                rentOrder.ReturnCondition = request.ReturnCondition;

                _logger.LogInformation("Updated return date to {ReturnDate} and condition to {Condition}",
                    request.ReturnDate, request.ReturnCondition);

                // Calculate late fee if applicable
                if (request.ReturnDate > rentOrder.ExpectedReturnDate)
                {
                    var daysLate = (request.ReturnDate - rentOrder.ExpectedReturnDate).Days;

                    // Calculate late fee based on the total rental price of all items
                    decimal totalRentalPrice = rentOrder.RentOrderDetails
                        .Where(d => !d.IsDelete)
                        .Sum(d => d.RentalPrice * d.Quantity);

                    rentOrder.LateFee = daysLate * (totalRentalPrice * 0.1m); // 10% of rental price per day
                    _logger.LogInformation("Calculated late fee: {LateFee} for {DaysLate} days late", rentOrder.LateFee, daysLate);
                }

                // Set damage fee if applicable
                if (!string.IsNullOrEmpty(request.ReturnCondition) && request.DamageFee.HasValue)
                {
                    rentOrder.DamageFee = request.DamageFee;
                    _logger.LogInformation("Set damage fee to {DamageFee}", request.DamageFee);
                }

                // Update notes
                if (!string.IsNullOrEmpty(request.Notes))
                {
                    rentOrder.RentalNotes = string.IsNullOrEmpty(rentOrder.RentalNotes)
                        ? request.Notes
                        : $"{rentOrder.RentalNotes}\n{request.Notes}";

                    _logger.LogInformation("Updated rental notes");
                }

                rentOrder.SetUpdateDate();

                // Use Update instead of UpdateDetached to ensure the entity is tracked
                await _unitOfWork.Repository<RentOrder>().Update(rentOrder, rentOrderId);

                // Explicitly commit the changes
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Rent order updated successfully");

                // Update order status
                await UpdateOrderStatusIfAllReturned(rentOrderId);

                // Update inventory status for all items in the order
                foreach (var detail in rentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    await UpdateInventoryStatus(detail);
                }

                // Commit again after all updates
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Equipment return process completed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing equipment return for rent order ID: {RentOrderId}", rentOrderId);
                throw;
            }
        }

        private async Task UpdateOrderStatusIfAllReturned(int orderId)
        {
            var order = await _unitOfWork.Repository<Order>().GetById(orderId);
            var allRentals = await _unitOfWork.Repository<RentOrderDetail>()
                .AsQueryable(r => r.OrderId == orderId && !r.IsDelete)
                .ToListAsync();

            if (allRentals.All(r => r.RentOrder.ActualReturnDate.HasValue))
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
            if (rentOrderDetail.HotpotInventoryId.HasValue)
            {
                var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>().GetById(rentOrderDetail.HotpotInventoryId.Value);
                if (hotpotInventory != null)
                {
                    // Set hotpot inventory to maintenance status
                    hotpotInventory.Status = HotpotStatus.Available; // Changed from Damaged to Available
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




        //// Keep this method for backward compatibility or specific item returns
        //private async Task ProcessEquipmentReturnInternalAsync(
        //    int rentOrderDetailId,
        //    EquipmentReturnRequest request)
        //{
        //    // Get the rent order detail
        //    var rentOrderDetail = await GetRentOrderDetailAsync(rentOrderDetailId);

        //    // Get the parent rent order
        //    var rentOrder = rentOrderDetail.RentOrder;

        //    // Validate request
        //    if (request.ReturnDate < rentOrder.RentalStartDate)
        //        throw new ValidationException("Return date cannot be earlier than rental start date");

        //    // Update rent order
        //    rentOrder.ActualReturnDate = request.ReturnDate;
        //    rentOrder.ReturnCondition = request.ReturnCondition;

        //    // Calculate late fee if applicable
        //    if (request.ReturnDate > rentOrder.ExpectedReturnDate)
        //    {
        //        var daysLate = (request.ReturnDate - rentOrder.ExpectedReturnDate).Days;
        //        rentOrder.LateFee = daysLate * (rentOrderDetail.RentalPrice * 0.1m); // 10% of rental price per day
        //    }

        //    // Set damage fee if applicable
        //    if (!string.IsNullOrEmpty(request.ReturnCondition) && request.DamageFee.HasValue)
        //    {
        //        rentOrder.DamageFee = request.DamageFee;
        //    }

        //    // Update notes
        //    if (!string.IsNullOrEmpty(request.Notes))
        //    {
        //        rentOrder.RentalNotes = string.IsNullOrEmpty(rentOrder.RentalNotes)
        //            ? request.Notes
        //            : $"{rentOrder.RentalNotes}\n{request.Notes}";
        //    }

        //    rentOrderDetail.SetUpdateDate();
        //    await _unitOfWork.Repository<RentOrderDetail>().UpdateDetached(rentOrderDetail);

        //    rentOrder.SetUpdateDate();
        //    await _unitOfWork.Repository<RentOrder>().UpdateDetached(rentOrder);

        //    // Check if all rentals for this order have been returned
        //    await UpdateOrderStatusIfReturned(rentOrderDetail.OrderId);

        //    // Update inventory status
        //    await UpdateInventoryStatus(rentOrderDetail);
        //}

        //private async Task UpdateOrderStatusIfReturned(int orderId)
        //{
        //    var order = await _unitOfWork.Repository<Order>().GetById(orderId);
        //    var rentOrder = await _unitOfWork.Repository<RentOrder>()
        //        .AsQueryable()
        //        .Include(r => r.RentOrderDetails)
        //        .FirstOrDefaultAsync(r => r.OrderId == orderId && !r.IsDelete);

        //    if (rentOrder != null && rentOrder.ActualReturnDate.HasValue)
        //    {
        //        // All items returned, update order status if it's in Returning status
        //        if (order.Status == OrderStatus.Returning)
        //        {
        //            order.Status = OrderStatus.Completed;
        //            order.SetUpdateDate();
        //            await _unitOfWork.Repository<Order>().UpdateDetached(order);
        //        }
        //    }
        //}

    }

}

