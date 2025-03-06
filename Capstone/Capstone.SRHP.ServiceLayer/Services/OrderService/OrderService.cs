using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IUnitOfWork unitOfWork, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => !o.IsDelete)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all orders");
                throw;
            }
        }

        public async Task<PagedResult<Order>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => !o.IsDelete)
                    .OrderByDescending(o => o.CreatedAt);

                var totalCount = await query.CountAsync();
                var items = await query
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving paged orders");
                throw;
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            try
            {
                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .FirstOrDefaultAsync(o => o.OrderId == id && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {id} not found");

                return order;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order {OrderId}", id);
                throw;
            }
        }

        public async Task<Order> CreateAsync(Order entity)
        {
            try
            {
                // Validate order
                if (entity.UserID <= 0)
                    throw new ValidationException("User ID is required");

                if (string.IsNullOrWhiteSpace(entity.Address))
                    throw new ValidationException("Delivery address is required");

                if (entity.OrderDetails == null || !entity.OrderDetails.Any())
                    throw new ValidationException("Order must contain at least one item");

                // Set initial status
                entity.Status = OrderStatus.Pending;

                // Insert order
                _unitOfWork.Repository<Order>().Insert(entity);
                await _unitOfWork.CommitAsync();

                // Reload order with all related entities
                return await GetByIdAsync(entity.OrderId);
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                throw;
            }
        }

        public async Task UpdateAsync(int id, Order entity)
        {
            try
            {
                var existingOrder = await GetByIdAsync(id);
                if (existingOrder == null)
                    throw new NotFoundException($"Order with ID {id} not found");

                // Validate order
                if (entity.UserID <= 0)
                    throw new ValidationException("User ID is required");

                if (string.IsNullOrWhiteSpace(entity.Address))
                    throw new ValidationException("Delivery address is required");

                // Update order
                entity.SetUpdateDate();
                await _unitOfWork.Repository<Order>().Update(entity, id);
                await _unitOfWork.CommitAsync();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order {OrderId}", id);
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var order = await GetByIdAsync(id);
                if (order == null)
                    throw new NotFoundException($"Order with ID {id} not found");

                // Soft delete
                order.SoftDelete();
                await _unitOfWork.CommitAsync();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting order {OrderId}", id);
                throw;
            }
        }

        public async Task<PagedResult<Order>> GetUserOrdersPagedAsync(int userId, int pageNumber, int pageSize)
        {
            try
            {
                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => o.UserID == userId && !o.IsDelete)
                    .OrderByDescending(o => o.CreatedAt);

                var totalCount = await query.CountAsync();
                var items = await query
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving paged orders for user {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            try
            {
                return await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .OrderByDescending(o => o.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders with status {Status}", status);
                throw;
            }
        }

        public async Task<PagedResult<Order>> GetOrdersByStatusPagedAsync(OrderStatus status, int pageNumber, int pageSize)
        {
            try
            {
                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .OrderByDescending(o => o.CreatedAt);

                var totalCount = await query.CountAsync();
                var items = await query
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving paged orders with status {Status}", status);
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
        {
            try
            {
                return await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => o.UserID == userId && !o.IsDelete)
                    .OrderByDescending(o => o.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders for user {UserId}", userId);
                throw;
            }
        }

        public async Task<OrderStatistics> GetOrderStatisticsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                // Set default date range if not provided
                startDate ??= DateTime.UtcNow.AddDays(-30);
                endDate ??= DateTime.UtcNow;

                // Get orders within date range
                var orders = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => !o.IsDelete && o.CreatedAt >= startDate && o.CreatedAt <= endDate)
                    .ToListAsync();

                // Calculate statistics
                var statistics = new OrderStatistics
                {
                    TotalOrders = orders.Count,
                    PendingOrders = orders.Count(o => o.Status == OrderStatus.Pending),
                    ProcessingOrders = orders.Count(o => o.Status == OrderStatus.Processing),
                    ShippingOrders = orders.Count(o => o.Status == OrderStatus.Shipping),
                    DeliveredOrders = orders.Count(o => o.Status == OrderStatus.Delivered),
                    FinishedOrders = orders.Count(o => o.Status == OrderStatus.Finished),
                    CancelledOrders = orders.Count(o => o.Status == OrderStatus.Cancelled),
                    TotalRevenue = orders.Where(o => o.Status == OrderStatus.Delivered || o.Status == OrderStatus.Finished)
                                        .Sum(o => o.TotalPrice),
                    AverageOrderValue = orders.Any() ? orders.Average(o => o.TotalPrice) : 0,
                    StartDate = startDate.Value,
                    EndDate = endDate.Value
                };

                return statistics;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating order statistics");
                throw;
            }
        }

        public async Task<decimal> CalculateTotalPriceAsync(ICollection<OrderDetail> orderDetails, int? discountId)
        {
            decimal total = 0;

            foreach (var detail in orderDetails)
            {
                total += detail.Quantity * detail.UnitPrice;
            }

            if (discountId.HasValue)
            {
                var discount = await _unitOfWork.Repository<Discount>()
                    .FindAsync(d => d.DiscountId == discountId && !d.IsDelete);
                if (discount != null)
                {
                    total -= total * (discount.DiscountPercentage / 100.0m);
                }
            }

            return total;
        }

        public async Task<Order> UpdateStatusAsync(int orderId, OrderStatus status)
        {
            try
            {
                var order = await GetByIdAsync(orderId);
                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                // Validate status transition
                ValidateStatusTransition(order.Status, status);

                // Update status
                order.Status = status;
                order.SetUpdateDate();
                await _unitOfWork.Repository<Order>().Update(order, orderId);
                await _unitOfWork.CommitAsync();

                return order;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating status for order {OrderId}", orderId);
                throw;
            }
        }

        private void ValidateStatusTransition(OrderStatus currentStatus, OrderStatus newStatus)
        {
            // Define valid status transitions
            bool isValidTransition = (currentStatus, newStatus) switch
            {
                (OrderStatus.Pending, OrderStatus.Processing) => true,
                (OrderStatus.Pending, OrderStatus.Cancelled) => true,
                (OrderStatus.Processing, OrderStatus.Shipping) => true,
                (OrderStatus.Processing, OrderStatus.Cancelled) => true,
                (OrderStatus.Shipping, OrderStatus.Delivered) => true,
                (OrderStatus.Delivered, OrderStatus.Finished) => true,
                _ => false
            };

            if (!isValidTransition)
            {
                throw new ValidationException($"Invalid status transition from {currentStatus} to {newStatus}");
            }
        }
    }
}
