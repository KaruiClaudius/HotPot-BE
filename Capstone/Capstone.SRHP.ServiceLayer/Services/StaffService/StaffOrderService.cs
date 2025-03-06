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
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Utensil)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Ingredient)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Hotpot)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Customization)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Combo)
                .Where(o => o.Status == OrderStatus.Processing && !o.IsDelete)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            return await _unitOfWork.Repository<Order>()
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Utensil)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Ingredient)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Hotpot)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Customization)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Combo)
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

            await _orderService.UpdateAsync(orderId, order);

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
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .Where(o => !o.IsDelete);

            // Apply filters
            if (status.HasValue)
                query = query.Where(o => o.Status == status.Value);

            if (startDate.HasValue)
                query = query.Where(o => o.CreatedAt >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(o => o.CreatedAt <= endDate.Value);

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
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Utensil)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Ingredient)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Hotpot)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Customization)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Combo)
                .Include(o => o.Discount)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDelete);

            if (order == null)
                throw new NotFoundException($"Order with ID {orderId} not found");

            return order;
        }
    }
}
