using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly ILogger<AnalyticsService> _logger;

        public AnalyticsService(
            IUnitOfWork unitOfWork,
            ILogger<AnalyticsService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task<ConsolidatedDashboardResponse> GetConsolidatedDashboardDataAsync(
       DateTime fromDate,
       DateTime toDate,
       string status = null,
       string productType = null,
       bool? hasHotpot = null,
       string paymentStatus = null,
       int topProductsLimit = 5)
        {
            try
            {
                // Start with base query
                var query = _unitOfWork.Repository<Order>()
                    .FindAll(o => !o.IsDelete && o.CreatedAt >= fromDate && o.CreatedAt <= toDate);

                // Apply order status filter
                if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<OrderStatus>(status, true, out var orderStatus))
                {
                    query = query.Where(o => o.Status == orderStatus);
                }

                // Apply payment status filter
                if (!string.IsNullOrWhiteSpace(paymentStatus) && Enum.TryParse<PaymentStatus>(paymentStatus, true, out var pmtStatus))
                {
                    query = query.Where(o => o.Payment != null && o.Payment.Status == pmtStatus);
                }

                // Apply hotpot filter
                if (hasHotpot.HasValue)
                {
                    if (hasHotpot.Value)
                    {
                        query = query.Where(o => o.RentOrder != null &&
                            o.RentOrder.RentOrderDetails.Any(od => od.HotpotInventoryId.HasValue && !od.IsDelete));
                    }
                    else
                    {
                        query = query.Where(o => o.RentOrder == null ||
                            !o.RentOrder.RentOrderDetails.Any(od => od.HotpotInventoryId.HasValue && !od.IsDelete));
                    }
                }

                // Apply product type filter
                if (!string.IsNullOrWhiteSpace(productType))
                {
                    productType = productType.ToLower();

                    switch (productType)
                    {
                        case "ingredient":
                            query = query.Where(o => o.SellOrder != null &&
                                o.SellOrder.SellOrderDetails.Any(d => d.IngredientId.HasValue && !d.IsDelete));
                            break;
                        case "combo":
                            query = query.Where(o => o.SellOrder != null &&
                                o.SellOrder.SellOrderDetails.Any(d => d.ComboId.HasValue && !d.IsDelete));
                            break;
                        case "customization":
                            query = query.Where(o => o.SellOrder != null &&
                                o.SellOrder.SellOrderDetails.Any(d => d.CustomizationId.HasValue && !d.IsDelete));
                            break;
                        case "hotpot":
                            query = query.Where(o => o.RentOrder != null &&
                                o.RentOrder.RentOrderDetails.Any(d => d.HotpotInventoryId.HasValue && !d.IsDelete));
                            break;
                        case "utensil":
                            query = query.Where(o => o.RentOrder != null &&
                                o.RentOrder.RentOrderDetails.Any(d => d.UtensilId.HasValue && !d.IsDelete));
                            break;
                    }
                }

                // Include all necessary related entities
                var orders = await query
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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

                // Process the data to build the consolidated response
                var response = new ConsolidatedDashboardResponse
                {
                    OverallMetrics = CalculateOverallMetrics(orders),
                    MonthlyData = CalculateMonthlyMetrics(orders),
                    OrdersByStatus = CalculateOrderStatusMetrics(orders),
                    ProductConsumption = CalculateProductConsumptionStats(orders, topProductsLimit)
                };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting consolidated dashboard data");
                throw;
            }
        }


        private DashboardSummaryMetrics CalculateOverallMetrics(List<Order> orders)
        {
            // Calculate total revenue
            decimal totalRevenue = orders.Sum(o => o.TotalPrice);

            // Count total orders
            int totalOrders = orders.Count;

            // Count unique customers
            int totalCustomers = orders.Select(o => o.UserId).Distinct().Count();

            // Calculate average order value
            decimal averageOrderValue = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            // Calculate hotpot deposits total
            decimal hotpotDepositsTotal = orders
                .Where(o => o.RentOrder != null)
                .Sum(o => o.RentOrder.HotpotDeposit);

            // Calculate revenue by product type
            var revenueByType = new RevenueByProductType
            {
                Ingredients = 0,
                Combos = 0,
                Customizations = 0,
                Hotpots = 0,
                Utensils = 0,
                HotpotDeposits = hotpotDepositsTotal
            };

            // Process sell order details
            foreach (var order in orders.Where(o => o.SellOrder?.SellOrderDetails != null))
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    decimal itemRevenue = detail.UnitPrice * detail.Quantity;

                    if (detail.IngredientId.HasValue)
                    {
                        revenueByType.Ingredients += itemRevenue;
                    }
                    else if (detail.ComboId.HasValue)
                    {
                        revenueByType.Combos += itemRevenue;
                    }
                    else if (detail.CustomizationId.HasValue)
                    {
                        revenueByType.Customizations += itemRevenue;
                    }
                }
            }

            // Process rent order details
            foreach (var order in orders.Where(o => o.RentOrder?.RentOrderDetails != null))
            {
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    decimal itemRevenue = detail.RentalPrice * detail.Quantity;

                    if (detail.UtensilId.HasValue)
                    {
                        revenueByType.Utensils += itemRevenue;
                    }
                    else if (detail.HotpotInventoryId.HasValue)
                    {
                        revenueByType.Hotpots += itemRevenue;
                    }
                }
            }

            return new DashboardSummaryMetrics
            {
                TotalRevenue = totalRevenue,
                TotalOrders = totalOrders,
                TotalCustomers = totalCustomers,
                AverageOrderValue = averageOrderValue,
                HotpotDepositsTotal = hotpotDepositsTotal,
                RevenueByType = revenueByType
            };
        }

        private List<MonthlyMetrics> CalculateMonthlyMetrics(List<Order> orders)
        {
            // Group orders by year and month
            var groupedOrders = orders
                .GroupBy(o => new { o.CreatedAt.Year, o.CreatedAt.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Orders = g.ToList()
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList();

            // Create a complete list of months in the date range
            var result = new List<MonthlyMetrics>();

            foreach (var group in groupedOrders)
            {
                // Calculate metrics for this month
                var monthlyMetrics = new MonthlyMetrics
                {
                    Year = group.Year,
                    Month = group.Month,
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Month),
                    Revenue = group.Orders.Sum(o => o.TotalPrice),
                    OrderCount = group.Orders.Count,
                    OrdersByStatus = group.Orders
                        .GroupBy(o => o.Status)
                        .ToDictionary(
                            g => g.Key.ToString(),
                            g => g.Count()
                        )
                };

                result.Add(monthlyMetrics);
            }

            return result;
        }

        private OrderStatusMetrics CalculateOrderStatusMetrics(List<Order> orders)
        {
            // Group orders by status
            var ordersByStatus = orders
                .GroupBy(o => o.Status)
                .ToDictionary(
                    g => g.Key.ToString(),
                    g => new OrderStatusDetail
                    {
                        Count = g.Count(),
                        Revenue = g.Sum(o => o.TotalPrice),
                        Percentage = orders.Count > 0 ? (decimal)g.Count() / orders.Count * 100 : 0
                    }
                );

            // Ensure all statuses are represented
            foreach (var status in Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>())
            {
                string statusName = status.ToString();
                if (!ordersByStatus.ContainsKey(statusName))
                {
                    ordersByStatus[statusName] = new OrderStatusDetail
                    {
                        Count = 0,
                        Revenue = 0,
                        Percentage = 0
                    };
                }
            }

            // Get 5 most recent orders
            var recentOrders = orders
                .OrderByDescending(o => o.CreatedAt)
                .Take(5)
                .Select(MapOrderToResponse)
                .ToList();

            return new OrderStatusMetrics
            {
                TotalOrders = orders.Count,
                StatusDetails = ordersByStatus,
                RecentOrders = recentOrders
            };
        }
        private ProductConsumptionStats CalculateProductConsumptionStats(List<Order> orders, int limit)
        {
            // Create dictionaries to track sales by product type
            var ingredientSales = new Dictionary<int, TopSellingItemDto>();
            var comboSales = new Dictionary<int, TopSellingItemDto>();
            var customizationSales = new Dictionary<int, TopSellingItemDto>();
            var hotpotSales = new Dictionary<int, TopSellingItemDto>();
            var utensilSales = new Dictionary<int, TopSellingItemDto>();

            // Process sell order details
            foreach (var order in orders.Where(o => o.SellOrder?.SellOrderDetails != null))
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    // Process ingredients
                    if (detail.IngredientId.HasValue && detail.Ingredient != null)
                    {
                        int id = detail.IngredientId.Value;
                        if (!ingredientSales.ContainsKey(id))
                        {
                            ingredientSales[id] = new TopSellingItemDto
                            {
                                ItemId = id,
                                ItemName = detail.Ingredient.Name,
                                ItemType = "Ingredient",
                                ImageUrl = detail.Ingredient.ImageURL,
                                QuantitySold = 0,
                                Revenue = 0,
                                AveragePrice = detail.UnitPrice
                            };
                        }

                        ingredientSales[id].QuantitySold += detail.Quantity;
                        ingredientSales[id].Revenue += detail.UnitPrice * detail.Quantity;
                    }
                    // Process combos
                    else if (detail.ComboId.HasValue && detail.Combo != null)
                    {
                        int id = detail.ComboId.Value;
                        if (!comboSales.ContainsKey(id))
                        {
                            comboSales[id] = new TopSellingItemDto
                            {
                                ItemId = id,
                                ItemName = detail.Combo.Name,
                                ItemType = "Combo",
                                ImageUrl = detail.Combo.ImageURL,
                                QuantitySold = 0,
                                Revenue = 0,
                                AveragePrice = detail.UnitPrice
                            };
                        }

                        comboSales[id].QuantitySold += detail.Quantity;
                        comboSales[id].Revenue += detail.UnitPrice * detail.Quantity;
                    }
                    // Process customizations
                    else if (detail.CustomizationId.HasValue && detail.Customization != null)
                    {
                        int id = detail.CustomizationId.Value;
                        if (!customizationSales.ContainsKey(id))
                        {
                            customizationSales[id] = new TopSellingItemDto
                            {
                                ItemId = id,
                                ItemName = detail.Customization.Name,
                                ItemType = "Customization",
                                ImageUrl = null, // Customizations don't have images
                                QuantitySold = 0,
                                Revenue = 0,
                                AveragePrice = detail.UnitPrice
                            };
                        }

                        customizationSales[id].QuantitySold += detail.Quantity;
                        customizationSales[id].Revenue += detail.UnitPrice * detail.Quantity;
                    }
                }
            }

            // Process rent order details
            foreach (var order in orders.Where(o => o.RentOrder?.RentOrderDetails != null))
            {
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    // Process utensils
                    if (detail.UtensilId.HasValue && detail.Utensil != null)
                    {
                        int id = detail.UtensilId.Value;
                        if (!utensilSales.ContainsKey(id))
                        {
                            utensilSales[id] = new TopSellingItemDto
                            {
                                ItemId = id,
                                ItemName = detail.Utensil.Name,
                                ItemType = "Utensil",
                                ImageUrl = detail.Utensil.ImageURL,
                                QuantitySold = 0,
                                Revenue = 0,
                                AveragePrice = detail.RentalPrice
                            };
                        }

                        utensilSales[id].QuantitySold += detail.Quantity;
                        utensilSales[id].Revenue += detail.RentalPrice * detail.Quantity;
                    }
                    // Process hotpots
                    else if (detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null)
                    {
                        int id = detail.HotpotInventory.HotpotId;
                        if (!hotpotSales.ContainsKey(id))
                        {
                            hotpotSales[id] = new TopSellingItemDto
                            {
                                ItemId = id,
                                ItemName = detail.HotpotInventory.Hotpot.Name,
                                ItemType = "Hotpot",
                                ImageUrl = detail.HotpotInventory.Hotpot.ImageURLs?.FirstOrDefault(),
                                QuantitySold = 0,
                                Revenue = 0,
                                AveragePrice = detail.RentalPrice
                            };
                        }

                        hotpotSales[id].QuantitySold += detail.Quantity;
                        hotpotSales[id].Revenue += detail.RentalPrice * detail.Quantity;
                    }
                }
            }

            // Get top items from each category
            var topIngredients = ingredientSales.Values
                .OrderByDescending(i => i.Revenue)
                .Take(limit)
                .ToList();

            var topCombos = comboSales.Values
                .OrderByDescending(i => i.Revenue)
                .Take(limit)
                .ToList();

            var topCustomizations = customizationSales.Values
                .OrderByDescending(i => i.Revenue)
                .Take(limit)
                .ToList();

            var topHotpots = hotpotSales.Values
                .OrderByDescending(i => i.Revenue)
                .Take(limit)
                .ToList();

            var topUtensils = utensilSales.Values
                .OrderByDescending(i => i.Revenue)
                .Take(limit)
                .ToList();

            // Combine all items for overall top products
            var allItems = new List<TopSellingItemDto>();
            allItems.AddRange(ingredientSales.Values);
            allItems.AddRange(comboSales.Values);
            allItems.AddRange(customizationSales.Values);
            allItems.AddRange(hotpotSales.Values);
            allItems.AddRange(utensilSales.Values);

            var topOverallProducts = allItems
                .OrderByDescending(i => i.Revenue)
                .Take(limit)
                .ToList();

            return new ProductConsumptionStats
            {
                TopOverallProducts = topOverallProducts,
                TopIngredients = topIngredients,
                TopCombos = topCombos,
                TopCustomizations = topCustomizations,
                TopHotpots = topHotpots,
                TopUtensils = topUtensils
            };
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
