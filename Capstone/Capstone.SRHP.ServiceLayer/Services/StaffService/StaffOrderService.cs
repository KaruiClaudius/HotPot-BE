using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffOrderService : IStaffOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;

        public StaffOrderService(IUnitOfWork unitOfWork, IOrderService orderService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
        }

        public async Task<IEnumerable<Order>> GetAssignedOrdersAsync(int staffId)
        {
            // In a real system, you'd have a way to assign orders to staff
            // For now, we'll just return orders with Processing status
            return await _unitOfWork.Repository<Order>()
                .Include(o => o.User)
                .Include(o => o.SellOrder.SellOrderDetails)
                    .ThenInclude(od => od.Ingredient)
                .Include(o => o.SellOrder.SellOrderDetails)
                    .ThenInclude(od => od.Customization)
                .Include(o => o.SellOrder.SellOrderDetails)
                    .ThenInclude(od => od.Combo)
                .Include(o => o.RentOrder.RentOrderDetails)
                    .ThenInclude(rd => rd.Utensil)
                .Include(o => o.RentOrder.RentOrderDetails)
                    .ThenInclude(rd => rd.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                .Where(o => o.Status == OrderStatus.Processing && !o.IsDelete)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            return await _unitOfWork.Repository<Order>()
                .Include(o => o.User)
                .Include(o => o.SellOrder.SellOrderDetails)
                    .ThenInclude(od => od.Ingredient)
                .Include(o => o.SellOrder.SellOrderDetails)
                    .ThenInclude(od => od.Customization)
                .Include(o => o.SellOrder.SellOrderDetails)
                    .ThenInclude(od => od.Combo)
                .Include(o => o.RentOrder.RentOrderDetails)
                    .ThenInclude(rd => rd.Utensil)
                .Include(o => o.RentOrder.RentOrderDetails)
                    .ThenInclude(rd => rd.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                .Where(o => o.Status == status && !o.IsDelete)
                .ToListAsync();
        }

        public async Task<Order> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, string notes)
        {
            var order = await _orderService.GetByIdAsync(orderId);

            if (order == null)
                throw new NotFoundException($"Order with ID {orderId} not found");

            // Update status
            await _orderService.UpdateStatusAsync(orderId, newStatus);

            // Update notes if provided
            if (!string.IsNullOrWhiteSpace(notes))
            {
                order.Notes = string.IsNullOrWhiteSpace(order.Notes)
                    ? notes
                    : $"{order.Notes}\n\nStaff update ({DateTime.UtcNow:g}): {notes}";

                await _orderService.UpdateAsync(orderId, order);
            }

            return await _orderService.GetByIdAsync(orderId);
        }

        public async Task<Order> CancelOrderAsync(int orderId, string cancellationReason)
        {
            var order = await _orderService.GetByIdAsync(orderId);

            if (order == null)
                throw new NotFoundException($"Order with ID {orderId} not found");

            // Can only cancel orders that are not already delivered or cancelled
            if (order.Status == OrderStatus.Delivered || order.Status == OrderStatus.Cancelled)
                throw new ValidationException("Cannot cancel an order that is already delivered or cancelled");

            // Update status to cancelled
            await _orderService.UpdateStatusAsync(orderId, OrderStatus.Cancelled);

            // Add cancellation reason to notes
            order.Notes = string.IsNullOrWhiteSpace(order.Notes)
                ? $"Cancelled: {cancellationReason}"
                : $"{order.Notes}\n\nCancelled ({DateTime.UtcNow:g}): {cancellationReason}";

            // Using the approach from source [0] to update entity properties
            // This is a cleaner way to update specific properties
            _unitOfWork.Context.Entry(order).Property(o => o.Notes).IsModified = true;
            await _unitOfWork.CommitAsync();

            return await _orderService.GetByIdAsync(orderId);
        }

        public async Task<PagedResult<Order>> GetOrderHistoryAsync(
            int pageNumber,
            int pageSize,
            OrderStatus? status = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var query = _unitOfWork.Repository<Order>()
                .AsQueryable()
                .Include(o => o.User)
                .Include(o => o.SellOrder.SellOrderDetails)
                .Include(o => o.RentOrder.RentOrderDetails)
                .Where(o => !o.IsDelete);

            // Apply filters
            if (status.HasValue)
                query = query.Where(o => o.Status == status.Value);

            if (startDate.HasValue)
                query = query.Where(o => o.CreatedAt >= startDate.Value);

            if (endDate.HasValue)
            {
                // Add one day to include the end date fully
                var endDatePlusOne = endDate.Value.AddDays(1);
                query = query.Where(o => o.CreatedAt < endDatePlusOne);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(o => o.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Order>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Order> GetOrderWithDetailsAsync(int orderId)
        {
            var order = await _unitOfWork.Repository<Order>()
                .AsQueryable()
                .Include(o => o.User)
                .Include(o => o.SellOrder.SellOrderDetails)
                    .ThenInclude(od => od.Ingredient)
                .Include(o => o.SellOrder.SellOrderDetails)
                    .ThenInclude(od => od.Customization)
                .Include(o => o.SellOrder.SellOrderDetails)
                    .ThenInclude(od => od.Combo)
                .Include(o => o.RentOrder.RentOrderDetails)
                    .ThenInclude(rd => rd.Utensil)
                .Include(o => o.RentOrder.RentOrderDetails)
                    .ThenInclude(rd => rd.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                .Include(o => o.Discount)
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDelete);

            if (order == null)
                throw new NotFoundException($"Order with ID {orderId} not found");

            return order;
        }

        // New method to efficiently update order properties using EF Core's SetValues
        public async Task<Order> UpdateOrderPropertiesAsync(int orderId, Order orderUpdate)
        {
            var order = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.OrderId == orderId && !o.IsDelete);

            if (order == null)
                throw new NotFoundException($"Order with ID {orderId} not found");

            // Using the approach from source [0] to update entity properties
            // This is a cleaner way to update multiple properties
            _unitOfWork.Context.Entry(order).CurrentValues.SetValues(orderUpdate);

            // Mark the entity as updated
            order.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            return await GetOrderWithDetailsAsync(orderId);
        }

        // New method to efficiently update multiple orders using ExecuteUpdate (EF Core 7+)
        public async Task<int> UpdateOrdersStatusAsync(OrderStatus currentStatus, OrderStatus newStatus)
        {
            // Using the approach from source [1] and [2] for bulk updates
            // This is much more efficient than loading all entities and updating them one by one
            return await _unitOfWork.Repository<Order>()
                .AsQueryable()
                .Where(o => o.Status == currentStatus && !o.IsDelete)
                .ExecuteUpdateAsync(o =>
                    o.SetProperty(x => x.Status, newStatus)
                     .SetProperty(x => x.UpdatedAt, DateTime.UtcNow));
        }
    }
}