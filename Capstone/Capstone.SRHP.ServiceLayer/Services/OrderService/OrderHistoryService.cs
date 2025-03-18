using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderHistoryService> _logger;

        public OrderHistoryService(
            IUnitOfWork unitOfWork,
            ILogger<OrderHistoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PagedResult<OrderHistoryDto>> GetOrderHistoryAsync(OrderHistoryFilterRequest filter)
        {
            try
            {
                _logger.LogInformation("Getting order history with filters");

                // Start with all orders that aren't deleted
                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => !o.IsDelete);

                // Apply filters
                if (filter.StartDate.HasValue)
                {
                    query = query.Where(o => o.CreatedAt >= filter.StartDate.Value);
                }

                if (filter.EndDate.HasValue)
                {
                    // Add one day to include the end date fully
                    var endDatePlusOne = filter.EndDate.Value.AddDays(1);
                    query = query.Where(o => o.CreatedAt < endDatePlusOne);
                }

                if (filter.Status.HasValue)
                {
                    query = query.Where(o => o.Status == filter.Status.Value);
                }

                if (!string.IsNullOrWhiteSpace(filter.CustomerName))
                {
                    query = query.Where(o => o.User.Name.Contains(filter.CustomerName));
                }

                // Include related data for both sell and rent order details
                query = query
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                    .Include(o => o.Feedback)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Ingredient)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Customization)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Combo)
                    .Include(o => o.RentOrderDetails)
                        .ThenInclude(rd => rd.Utensil)
                    .Include(o => o.RentOrderDetails)
                        .ThenInclude(rd => rd.HotpotInventory)
                            .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .OrderByDescending(o => o.CreatedAt);

                // Get total count for pagination
                var totalCount = await query.CountAsync();

                // Apply pagination
                var pageNumber = filter.PageNumber ?? 1;
                var pageSize = filter.PageSize ?? 10;

                var orders = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to DTOs
                var orderDtos = orders.Select(MapToOrderHistoryDto).ToList();

                return new PagedResult<OrderHistoryDto>
                {
                    Items = orderDtos,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order history");
                throw;
            }
        }

        public async Task<OrderHistoryDto> GetOrderDetailsAsync(int orderId)
        {
            try
            {
                _logger.LogInformation("Getting details for order ID: {OrderId}", orderId);

                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderId == orderId && !o.IsDelete)
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                    .Include(o => o.Feedback)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Ingredient)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Customization)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Combo)
                    .Include(o => o.RentOrderDetails)
                        .ThenInclude(rd => rd.Utensil)
                    .Include(o => o.RentOrderDetails)
                        .ThenInclude(rd => rd.HotpotInventory)
                            .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .FirstOrDefaultAsync();

                if (order == null)
                {
                    throw new NotFoundException($"Order with ID {orderId} not found");
                }

                return MapToOrderHistoryDto(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order details for ID: {OrderId}", orderId);
                throw;
            }
        }

        public async Task<PagedResult<OrderHistoryDto>> GetOrdersByStatusAsync(OrderStatus status, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Getting orders with status: {Status}", status);

                var filter = new OrderHistoryFilterRequest
                {
                    Status = status,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return await GetOrderHistoryAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders with status: {Status}", status);
                throw;
            }
        }

        public async Task<PagedResult<OrderHistoryDto>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Getting orders between {StartDate} and {EndDate}", startDate, endDate);

                var filter = new OrderHistoryFilterRequest
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return await GetOrderHistoryAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders between {StartDate} and {EndDate}", startDate, endDate);
                throw;
            }
        }

        // Helper method to map Order entity to OrderHistoryDto
        private OrderHistoryDto MapToOrderHistoryDto(Order order)
        {
            if (order == null) return null;

            var dto = new OrderHistoryDto
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                CustomerName = order.User?.Name ?? "Unknown",
                Address = order.Address,
                Notes = order.Notes ?? string.Empty,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                HotpotDeposit = order.HotpotDeposit,
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                HasShipping = order.ShippingOrder != null,
                HasFeedback = order.Feedback != null,
                Items = new List<OrderItemDto>()
            };

            // Map sell order details to order items
            if (order.OrderDetails != null && order.OrderDetails.Any())
            {
                foreach (var detail in order.OrderDetails)
                {
                    string itemName = "Unknown";
                    string itemType = "Unknown";
                    decimal price = detail.UnitPrice;

                    if (detail.Ingredient != null)
                    {
                        itemName = detail.Ingredient.Name;
                        itemType = "Ingredient";
                    }
                    else if (detail.Customization != null)
                    {
                        itemName = detail.Customization.Name;
                        itemType = "Customization";
                    }
                    else if (detail.Combo != null)
                    {
                        itemName = detail.Combo.Name;
                        itemType = "Combo";
                    }

                    dto.Items.Add(new OrderItemDto
                    {
                        OrderDetailId = detail.SellOrderDetailId,
                        ItemName = itemName,
                        ItemType = itemType,
                        Quantity = detail.Quantity ?? 0,
                        VolumeWeight = detail.VolumeWeight,
                        Unit = detail.Unit,
                        Price = price,
                        IsRental = false
                    });
                }
            }

            // Map rental order details to order items
            if (order.RentOrderDetails != null && order.RentOrderDetails.Any())
            {
                foreach (var rental in order.RentOrderDetails)
                {
                    string itemName = "Unknown";
                    string itemType = "Rental";

                    if (rental.Utensil != null)
                    {
                        itemName = rental.Utensil.Name;
                        itemType = "Utensil Rental";
                    }
                    else if (rental.HotpotInventory != null && rental.HotpotInventory.Hotpot != null)
                    {
                        itemName = rental.HotpotInventory.Hotpot.Name;
                        itemType = "Hotpot Rental";
                    }

                    dto.Items.Add(new OrderItemDto
                    {
                        OrderDetailId = rental.RentableOrderDetailId,
                        ItemName = itemName,
                        ItemType = itemType,
                        Quantity = rental.Quantity,
                        Price = rental.RentalPrice,
                        IsRental = true,
                        RentalStartDate = rental.RentalStartDate,
                        ExpectedReturnDate = rental.ExpectedReturnDate,
                        ActualReturnDate = rental.ActualReturnDate,
                        LateFee = rental.LateFee,
                        DamageFee = rental.DamageFee,
                        RentalNotes = rental.RentalNotes,
                        ReturnCondition = rental.ReturnCondition
                    });
                }
            }

            return dto;
        }
    }
}