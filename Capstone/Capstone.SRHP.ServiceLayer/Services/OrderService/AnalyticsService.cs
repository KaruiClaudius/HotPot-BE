using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Dashboard;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly ILogger<AnalyticsService> _logger;

        public AnalyticsService(
            IUnitOfWork unitOfWork,
            IOrderService orderService,
            ILogger<AnalyticsService> logger)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _logger = logger;
        }

        public async Task<DashboardSummary> GetDashboardSummaryAsync(DateTime fromDate, DateTime toDate)
        {
            try
            {
                // Get all orders in the date range
                var orders = await _unitOfWork.Repository<Order>()
                    .FindAll(o => !o.IsDelete && o.CreatedAt >= fromDate && o.CreatedAt <= toDate)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so != null ? so.SellOrderDetails : null)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro != null ? ro.RentOrderDetails : null)
                    .ToListAsync();

                // Calculate total revenue
                decimal totalRevenue = orders.Sum(o => o.TotalPrice);

                // Count total orders
                int totalOrders = orders.Count;

                // Count unique customers
                int totalCustomers = orders.Select(o => o.UserId).Distinct().Count();

                // Calculate average order value
                decimal averageOrderValue = totalOrders > 0 ? totalRevenue / totalOrders : 0;

                // Count orders by status
                var ordersByStatus = new OrderCountByStatus
                {
                    Pending = orders.Count(o => o.Status == OrderStatus.Pending),
                    Processing = orders.Count(o => o.Status == OrderStatus.Processing),
                    Shipping = orders.Count(o => o.Status == OrderStatus.Shipping),
                    Delivered = orders.Count(o => o.Status == OrderStatus.Delivered),
                    Cancelled = orders.Count(o => o.Status == OrderStatus.Cancelled),
                    Returning = orders.Count(o => o.Status == OrderStatus.Returning),
                    Completed = orders.Count(o => o.Status == OrderStatus.Completed)
                };

                // Calculate revenue by product type
                var revenueByProductType = await CalculateRevenueByProductTypeAsync(fromDate, toDate);

                // Get top selling items
                var topSellingItems = await GetTopSellingItemsAsync("All", fromDate, toDate, 5);

                // Get sales trend
                var salesTrend = await GetSalesTrendAsync("daily", fromDate, toDate);

                return new DashboardSummary
                {
                    TotalRevenue = totalRevenue,
                    TotalOrders = totalOrders,
                    TotalCustomers = totalCustomers,
                    AverageOrderValue = averageOrderValue,
                    OrdersByStatus = ordersByStatus,
                    RevenueByProductType = revenueByProductType,
                    TopSellingItems = topSellingItems,
                    SalesTrend = salesTrend
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting dashboard summary");
                throw;
            }
        }

        public async Task<List<TopSellingItemDto>> GetTopSellingItemsAsync(
            string itemType, DateTime fromDate, DateTime toDate, int limit)
        {
            try
            {
                var result = new List<TopSellingItemDto>();

                // Normalize item type
                itemType = itemType?.ToLower() ?? "all";

                // Get all orders in the date range
                var orders = await _unitOfWork.Repository<Order>()
                    .FindAll(o => !o.IsDelete && o.CreatedAt >= fromDate && o.CreatedAt <= toDate)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so != null ? so.SellOrderDetails : null)
                            .ThenInclude(d => d.Ingredient)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so != null ? so.SellOrderDetails : null)
                            .ThenInclude(d => d.Combo)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so != null ? so.SellOrderDetails : null)
                            .ThenInclude(d => d.Customization)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro != null ? ro.RentOrderDetails : null)
                            .ThenInclude(d => d.Utensil)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro != null ? ro.RentOrderDetails : null)
                            .ThenInclude(d => d.HotpotInventory)
                                .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .ToListAsync();

                // Process sell order details
                if (itemType == "all" || itemType == "ingredient" || itemType == "combo" || itemType == "customization")
                {
                    var sellDetails = orders
                        .Where(o => o.SellOrder != null)
                        .SelectMany(o => o.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                        .ToList();

                    // Process ingredients
                    if (itemType == "all" || itemType == "ingredient")
                    {
                        var ingredientSales = sellDetails
                            .Where(d => d.IngredientId.HasValue && d.Ingredient != null)
                            .GroupBy(d => new { d.IngredientId, d.Ingredient.Name, ImageUrl = d.Ingredient.ImageURL })
                            .Select(g => new
                            {
                                ItemId = g.Key.IngredientId.Value,
                                ItemName = g.Key.Name,
                                ItemType = "Ingredient",
                                ImageUrl = g.Key.ImageUrl,
                                // Replace the problematic line with the following:
                                QuantitySold = g.Sum(d => (int?)d.Quantity ?? 1),
                                Revenue = g.Sum(d => d.UnitPrice * d.Quantity),
                                AveragePrice = g.Average(d => d.UnitPrice)
                            })
                            .OrderByDescending(x => x.Revenue)
                            .Take(limit)
                            .ToList();

                        result.AddRange(ingredientSales.Select(i => new TopSellingItemDto
                        {
                            ItemId = i.ItemId,
                            ItemName = i.ItemName,
                            ItemType = i.ItemType,
                            ImageUrl = i.ImageUrl,
                            QuantitySold = i.QuantitySold,
                            Revenue = i.Revenue,
                            AveragePrice = i.AveragePrice
                        }));
                    }

                    // Process combos
                    if (itemType == "all" || itemType == "combo")
                    {
                        var comboSales = sellDetails
                            .Where(d => d.ComboId.HasValue && d.Combo != null)
                            .GroupBy(d => new { d.ComboId, d.Combo.Name, ImageUrl = d.Combo.ImageURL })
                            .Select(g => new
                            {
                                ItemId = g.Key.ComboId.Value,
                                ItemName = g.Key.Name,
                                ItemType = "Combo",
                                ImageUrl = g.Key.ImageUrl,
                                QuantitySold = g.Sum(d => (int?)d.Quantity ?? 1),
                                Revenue = g.Sum(d => d.UnitPrice * d.Quantity),
                                AveragePrice = g.Average(d => d.UnitPrice)
                            })
                            .OrderByDescending(x => x.Revenue)
                            .Take(limit)
                            .ToList();

                        result.AddRange(comboSales.Select(i => new TopSellingItemDto
                        {
                            ItemId = i.ItemId,
                            ItemName = i.ItemName,
                            ItemType = i.ItemType,
                            ImageUrl = i.ImageUrl,
                            QuantitySold = i.QuantitySold,
                            Revenue = i.Revenue,
                            AveragePrice = i.AveragePrice
                        }));
                    }

                    // Process customizations
                    if (itemType == "all" || itemType == "customization")
                    {
                        var customizationSales = sellDetails
                            .Where(d => d.CustomizationId.HasValue && d.Customization != null)
                            .GroupBy(d => new { d.CustomizationId, d.Customization.Name })
                            .Select(g => new
                            {
                                ItemId = g.Key.CustomizationId.Value,
                                ItemName = g.Key.Name,
                                ItemType = "Customization",
                                ImageUrl = (string)null,
                                QuantitySold = g.Sum(d => (int?)d.Quantity ?? 1),
                                Revenue = g.Sum(d => d.UnitPrice * d.Quantity),
                                AveragePrice = g.Average(d => d.UnitPrice)
                            })
                            .OrderByDescending(x => x.Revenue)
                            .Take(limit)
                            .ToList();

                        result.AddRange(customizationSales.Select(i => new TopSellingItemDto
                        {
                            ItemId = i.ItemId,
                            ItemName = i.ItemName,
                            ItemType = i.ItemType,
                            ImageUrl = i.ImageUrl,
                            QuantitySold = i.QuantitySold,
                            Revenue = i.Revenue,
                            AveragePrice = i.AveragePrice
                        }));
                    }
                }

                // Process rent order details
                if (itemType == "all" || itemType == "hotpot" || itemType == "utensil")
                {
                    var rentDetails = orders
                        .Where(o => o.RentOrder != null)
                        .SelectMany(o => o.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                        .ToList();

                    // Process hotpots
                    if (itemType == "all" || itemType == "hotpot")
                    {
                        var hotpotSales = rentDetails
                            .Where(d => d.HotpotInventoryId.HasValue && d.HotpotInventory?.Hotpot != null)
                            .GroupBy(d => new
                            {
                                d.HotpotInventory.HotpotId,
                                d.HotpotInventory.Hotpot.Name,
                                ImageUrl = d.HotpotInventory.Hotpot.ImageURLs?.FirstOrDefault()
                            })
                            .Select(g => new
                            {
                                ItemId = g.Key.HotpotId,
                                ItemName = g.Key.Name,
                                ItemType = "Hotpot",
                                ImageUrl = g.Key.ImageUrl,
                                QuantitySold = g.Sum(d => d.Quantity),
                                Revenue = g.Sum(d => d.RentalPrice * d.Quantity),
                                AveragePrice = g.Average(d => d.RentalPrice)
                            })
                            .OrderByDescending(x => x.Revenue)
                            .Take(limit)
                            .ToList();

                        result.AddRange(hotpotSales.Select(i => new TopSellingItemDto
                        {
                            ItemId = i.ItemId,
                            ItemName = i.ItemName,
                            ItemType = i.ItemType,
                            ImageUrl = i.ImageUrl,
                            QuantitySold = i.QuantitySold,
                            Revenue = i.Revenue,
                            AveragePrice = i.AveragePrice
                        }));
                    }

                    // Process utensils
                    if (itemType == "all" || itemType == "utensil")
                    {
                        var utensilSales = rentDetails
                            .Where(d => d.UtensilId.HasValue && d.Utensil != null)
                            .GroupBy(d => new { d.UtensilId, d.Utensil.Name, ImageUrl = d.Utensil.ImageURL })
                            .Select(g => new
                            {
                                ItemId = g.Key.UtensilId.Value,
                                ItemName = g.Key.Name,
                                ItemType = "Utensil",
                                ImageUrl = g.Key.ImageUrl,
                                QuantitySold = g.Sum(d => d.Quantity),
                                Revenue = g.Sum(d => d.RentalPrice * d.Quantity),
                                AveragePrice = g.Average(d => d.RentalPrice)
                            })
                            .OrderByDescending(x => x.Revenue)
                            .Take(limit)
                            .ToList();

                        result.AddRange(utensilSales.Select(i => new TopSellingItemDto
                        {
                            ItemId = i.ItemId,
                            ItemName = i.ItemName,
                            ItemType = i.ItemType,
                            ImageUrl = i.ImageUrl,
                            QuantitySold = i.QuantitySold,
                            Revenue = i.Revenue,
                            AveragePrice = i.AveragePrice
                        }));
                    }
                }

                // Take the top items across all types
                return result
                    .OrderByDescending(i => i.Revenue)
                    .Take(limit)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting top selling items");
                throw;
            }
        }



        public async Task<List<SalesTrendDto>> GetSalesTrendAsync(
            string period, DateTime fromDate, DateTime toDate)
        {
            try
            {
                // Normalize period
                period = period?.ToLower() ?? "daily";

                // Get all orders in the date range
                var orders = await _unitOfWork.Repository<Order>()
                    .FindAll(o => !o.IsDelete && o.CreatedAt >= fromDate && o.CreatedAt <= toDate)
                    .ToListAsync();

                // Group orders by the specified period
                var groupedOrders = new List<IGrouping<DateTime, Order>>();

                switch (period)
                {
                    case "daily":
                        groupedOrders = orders
                            .GroupBy(o => o.CreatedAt.Date)
                            .ToList();
                        break;

                    case "weekly":
                        groupedOrders = orders
                            .GroupBy(o => StartOfWeek(o.CreatedAt))
                            .ToList();
                        break;

                    case "monthly":
                        groupedOrders = orders
                            .GroupBy(o => new DateTime(o.CreatedAt.Year, o.CreatedAt.Month, 1))
                            .ToList();
                        break;
                }

                // Create a complete date range for the period
                var dateRange = new List<DateTime>();
                var currentDate = fromDate;

                while (currentDate <= toDate)
                {
                    switch (period)
                    {
                        case "daily":
                            dateRange.Add(currentDate.Date);
                            currentDate = currentDate.AddDays(1);
                            break;

                        case "weekly":
                            dateRange.Add(StartOfWeek(currentDate));
                            currentDate = currentDate.AddDays(7);
                            break;

                        case "monthly":
                            dateRange.Add(new DateTime(currentDate.Year, currentDate.Month, 1));
                            currentDate = currentDate.AddMonths(1);
                            break;
                    }
                }

                // Create the sales trend data
                var salesTrend = dateRange.Distinct().Select(date =>
                {
                    var ordersInPeriod = groupedOrders.FirstOrDefault(g => g.Key == date);

                    return new SalesTrendDto
                    {
                        Date = date,
                        Revenue = ordersInPeriod?.Sum(o => o.TotalPrice) ?? 0,
                        OrderCount = ordersInPeriod?.Count() ?? 0
                    };
                }).ToList();

                return salesTrend;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting sales trend");
                throw;
            }
        }

        public async Task<OrdersByStatusDto> GetOrdersByStatusAsync(
     DateTime fromDate, DateTime toDate, int limit)
        {
            try
            {
                // Get orders for each status
                var pendingOrders = await GetOrdersByStatusAsync(OrderStatus.Pending, fromDate, toDate, limit);
                var processingOrders = await GetOrdersByStatusAsync(OrderStatus.Processing, fromDate, toDate, limit);
                var shippingOrders = await GetOrdersByStatusAsync(OrderStatus.Shipping, fromDate, toDate, limit);
                var deliveredOrders = await GetOrdersByStatusAsync(OrderStatus.Delivered, fromDate, toDate, limit);
                var cancelledOrders = await GetOrdersByStatusAsync(OrderStatus.Cancelled, fromDate, toDate, limit);
                var returningOrders = await GetOrdersByStatusAsync(OrderStatus.Returning, fromDate, toDate, limit);
                var completedOrders = await GetOrdersByStatusAsync(OrderStatus.Completed, fromDate, toDate, limit);

                return new OrdersByStatusDto
                {
                    PendingOrders = pendingOrders,
                    ProcessingOrders = processingOrders,
                    ShippingOrders = shippingOrders,
                    DeliveredOrders = deliveredOrders,
                    CancelledOrders = cancelledOrders,
                    ReturningOrders = returningOrders,
                    CompletedOrders = completedOrders
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting orders by status");
                throw;
            }
        }

        private async Task<List<OrderResponse>> GetOrdersByStatusAsync(
            OrderStatus status, DateTime fromDate, DateTime toDate, int limit)
        {
            // Get orders with the specified status
            var pagedResult = await _orderService.GetOrdersAsync(
                status: status.ToString(),
                fromDate: fromDate,
                toDate: toDate,
                pageNumber: 1,
                pageSize: limit,
                sortBy: "CreatedAt",
                ascending: false);

            // Map to response DTOs
            return pagedResult.Items.Select(MapOrderToResponse).ToList();
        }

        private async Task<RevenueByProductType> CalculateRevenueByProductTypeAsync(
     DateTime fromDate, DateTime toDate)
        {
            // Get all orders in the date range
            var orders = await _unitOfWork.Repository<Order>()
                .FindAll(o => !o.IsDelete && o.CreatedAt >= fromDate && o.CreatedAt <= toDate)
                .Include(o => o.SellOrder)
                    .ThenInclude(so => so != null ? so.SellOrderDetails : null)
                .Include(o => o.RentOrder)
                    .ThenInclude(ro => ro != null ? ro.RentOrderDetails : null)
                .ToListAsync();

            var result = new RevenueByProductType();

            // Calculate revenue from sell order details
            foreach (var order in orders)
            {
                if (order.SellOrder?.SellOrderDetails != null)
                {
                    foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                    {
                        decimal itemRevenue = detail.UnitPrice * detail.Quantity;

                        if (detail.IngredientId.HasValue)
                        {
                            result.Ingredients += itemRevenue;
                        }
                        else if (detail.ComboId.HasValue)
                        {
                            result.Combos += itemRevenue;
                        }
                        else if (detail.CustomizationId.HasValue)
                        {
                            result.Customizations += itemRevenue;
                        }
                    }
                }

                if (order.RentOrder?.RentOrderDetails != null)
                {
                    foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                    {
                        decimal itemRevenue = detail.RentalPrice * detail.Quantity;

                        if (detail.UtensilId.HasValue)
                        {
                            result.Utensils += itemRevenue;
                        }
                        else if (detail.HotpotInventoryId.HasValue)
                        {
                            result.Hotpots += itemRevenue;
                        }
                    }
                }
            }

            return result;
        }

        private DateTime StartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private OrderResponse MapOrderToResponse(Order order)
        {
            if (order == null) return null;

            var response = new OrderResponse
            {
                OrderId = order.OrderId,
                Address = order.Address,
                Notes = order.Notes,
                TotalPrice = order.TotalPrice,
                Status = order.Status.ToString(),
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                User = order.User != null ? new UserInfo
                {
                    UserId = order.User.UserId,
                    Name = order.User.Name,
                    PhoneNumber = order.User.PhoneNumber,
                    Email = order.User.Email
                } : null,
                Items = new List<OrderItemResponse>(),
                Discount = null,
                Payment = null
            };

            // Add hotpot deposit from RentOrder if available
            if (order.RentOrder != null)
            {
                response.HotpotDeposit = order.RentOrder.HotpotDeposit;

                // Add rental dates to the response
                response.RentalStartDate = order.RentOrder.RentalStartDate;
                response.ExpectedReturnDate = order.RentOrder.ExpectedReturnDate;
                response.ActualReturnDate = order.RentOrder.ActualReturnDate;
            }
            else
            {
                response.HotpotDeposit = 0;
            }

            // Map sell order details
            if (order.SellOrder?.SellOrderDetails != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    string itemType = "";
                    string itemName = "Unknown";
                    string imageUrl = null;
                    int? itemId = null;

                    if (detail.IngredientId.HasValue && detail.Ingredient != null)
                    {
                        itemType = "Ingredient";
                        itemName = detail.Ingredient.Name;
                        imageUrl = detail.Ingredient.ImageURL;
                        itemId = detail.IngredientId;

                        response.Items.Add(new OrderItemResponse
                        {
                            OrderDetailId = detail.SellOrderDetailId,
                            Quantity = detail.Quantity,
                            UnitPrice = detail.UnitPrice,
                            TotalPrice = detail.UnitPrice * detail.Quantity,
                            ItemType = itemType,
                            ItemName = itemName,
                            ImageUrl = imageUrl,
                            ItemId = itemId,
                            IsSellable = true
                        });

                        // Skip the default add below for ingredients
                        continue;
                    }
                    else if (detail.CustomizationId.HasValue && detail.Customization != null)
                    {
                        itemType = "Customization";
                        itemName = detail.Customization.Name;
                        itemId = detail.CustomizationId;
                    }
                    else if (detail.ComboId.HasValue && detail.Combo != null)
                    {
                        itemType = "Combo";
                        itemName = detail.Combo.Name;
                        imageUrl = detail.Combo.ImageURL;
                        itemId = detail.ComboId;
                    }

                    response.Items.Add(new OrderItemResponse
                    {
                        OrderDetailId = detail.SellOrderDetailId,
                        Quantity = detail.Quantity,
                        UnitPrice = detail.UnitPrice,
                        TotalPrice = detail.UnitPrice * detail.Quantity,
                        ItemType = itemType,
                        ItemName = itemName,
                        ImageUrl = imageUrl,
                        ItemId = itemId,
                        IsSellable = true
                    });
                }
            }

            // Map rent order details
            if (order.RentOrder?.RentOrderDetails != null)
            {
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    string itemType = "";
                    string itemName = "Unknown";
                    string imageUrl = null;
                    int? itemId = null;

                    if (detail.UtensilId.HasValue && detail.Utensil != null)
                    {
                        itemType = "Utensil";
                        itemName = detail.Utensil.Name;
                        imageUrl = detail.Utensil.ImageURL;
                        itemId = detail.UtensilId;
                    }
                    else if (detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null)
                    {
                        itemType = "Hotpot";
                        itemName = detail.HotpotInventory.Hotpot.Name;
                        imageUrl = detail.HotpotInventory.Hotpot.ImageURLs?.FirstOrDefault();
                        itemId = detail.HotpotInventory.HotpotId;
                    }

                    response.Items.Add(new OrderItemResponse
                    {
                        OrderDetailId = detail.RentOrderDetailId,
                        Quantity = detail.Quantity,
                        UnitPrice = detail.RentalPrice,
                        TotalPrice = detail.RentalPrice * detail.Quantity,
                        ItemType = itemType,
                        ItemName = itemName,
                        ImageUrl = imageUrl,
                        ItemId = itemId,
                        IsSellable = false
                    });
                }
            }

            // Map discount if available
            if (order.Discount != null)
            {
                response.Discount = new DiscountInfo
                {
                    DiscountId = order.Discount.DiscountId,
                    Title = order.Discount.Title,
                    Description = order.Discount.Description,
                    Percent = order.Discount.DiscountPercentage,
                    DiscountAmount = order.TotalPrice * (order.Discount.DiscountPercentage / 100)
                };
            }

            // Map payment if available
            if (order.Payment != null)
            {
                response.Payment = new PaymentInfo
                {
                    PaymentId = order.Payment.PaymentId,
                    Type = order.Payment.Type.ToString(),
                    Status = order.Payment.Status.ToString(),
                    Amount = order.Payment.Price,
                    UpdateAt = order.Payment.UpdatedAt
                };
            }

            return response;
        }
    }
}
