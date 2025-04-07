using System.Text;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Dashboard;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [Route("api/admin/dashboard")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IAnalyticsService _analyticsService;
        private readonly ILogger<AdminDashboardController> _logger;

        public AdminDashboardController(
            IOrderService orderService,
            IAnalyticsService analyticsService,
            ILogger<AdminDashboardController> logger)
        {
            _orderService = orderService;
            _analyticsService = analyticsService;
            _logger = logger;
        }


        /// <summary>
        /// Get consolidated dashboard data including yearly totals, monthly breakdowns, 
        /// order status distributions, and product consumption statistics
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ConsolidatedDashboardResponse>> GetDashboard(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] string status = null,
            [FromQuery] string productType = null,
            [FromQuery] bool? hasHotpot = null,
            [FromQuery] string paymentStatus = null,
            [FromQuery] int topProductsLimit = 5)
        {
            try
            {
                // Set default date range if not provided (current year)
                if (!toDate.HasValue)
                    toDate = DateTime.UtcNow;

                if (!fromDate.HasValue)
                {
                    // Default to start of current year
                    fromDate = new DateTime(toDate.Value.Year, 1, 1);
                }

                var dashboardData = await _analyticsService.GetConsolidatedDashboardDataAsync(
                    fromDate.Value,
                    toDate.Value,
                    status,
                    productType,
                    hasHotpot,
                    paymentStatus,
                    topProductsLimit);

                return Ok(dashboardData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving consolidated dashboard data");
                return StatusCode(500, new { message = "An error occurred while retrieving dashboard data" });
            }
        }

        /// <summary>
        /// Export dashboard data to CSV
        /// </summary>
        [HttpGet("export")]
        public async Task<IActionResult> ExportDashboardData(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] string status = null,
            [FromQuery] string productType = null,
            [FromQuery] bool? hasHotpot = null,
            [FromQuery] string paymentStatus = null)
        {
            try
            {
                // Set default date range if not provided (current year)
                if (!toDate.HasValue)
                    toDate = DateTime.UtcNow;

                if (!fromDate.HasValue)
                {
                    // Default to start of current year
                    fromDate = new DateTime(toDate.Value.Year, 1, 1);
                }

                // Get dashboard data with filters
                var dashboardData = await _analyticsService.GetConsolidatedDashboardDataAsync(
                    fromDate.Value,
                    toDate.Value,
                    status,
                    productType,
                    hasHotpot,
                    paymentStatus);

                // Generate CSV content
                var csvBuilder = new StringBuilder();

                // Add header
                csvBuilder.AppendLine("Dashboard Report");
                csvBuilder.AppendLine($"Period: {fromDate.Value:yyyy-MM-dd} to {toDate.Value:yyyy-MM-dd}");
                csvBuilder.AppendLine();

                // Add overall metrics
                csvBuilder.AppendLine("OVERALL METRICS");
                csvBuilder.AppendLine($"Total Revenue,{dashboardData.OverallMetrics.TotalRevenue:C}");
                csvBuilder.AppendLine($"Total Orders,{dashboardData.OverallMetrics.TotalOrders}");
                csvBuilder.AppendLine($"Total Customers,{dashboardData.OverallMetrics.TotalCustomers}");
                csvBuilder.AppendLine($"Average Order Value,{dashboardData.OverallMetrics.AverageOrderValue:C}");
                csvBuilder.AppendLine($"Hotpot Deposits Total,{dashboardData.OverallMetrics.HotpotDepositsTotal:C}");
                csvBuilder.AppendLine();

                // Add revenue by product type
                csvBuilder.AppendLine("REVENUE BY PRODUCT TYPE");
                csvBuilder.AppendLine($"Ingredients,{dashboardData.OverallMetrics.RevenueByType.Ingredients:C}");
                csvBuilder.AppendLine($"Combos,{dashboardData.OverallMetrics.RevenueByType.Combos:C}");
                csvBuilder.AppendLine($"Customizations,{dashboardData.OverallMetrics.RevenueByType.Customizations:C}");
                csvBuilder.AppendLine($"Hotpots,{dashboardData.OverallMetrics.RevenueByType.Hotpots:C}");
                csvBuilder.AppendLine($"Utensils,{dashboardData.OverallMetrics.RevenueByType.Utensils:C}");
                csvBuilder.AppendLine();

                // Add monthly data
                csvBuilder.AppendLine("MONTHLY DATA");
                csvBuilder.AppendLine("Year,Month,Revenue,Order Count");
                foreach (var month in dashboardData.MonthlyData)
                {
                    csvBuilder.AppendLine($"{month.Year},{month.MonthName},{month.Revenue:C},{month.OrderCount}");
                }
                csvBuilder.AppendLine();

                // Add orders by status
                csvBuilder.AppendLine("ORDERS BY STATUS");
                csvBuilder.AppendLine("Status,Count,Revenue,Percentage");
                foreach (var orderStatus in dashboardData.OrdersByStatus.StatusDetails)
                {
                    csvBuilder.AppendLine($"{orderStatus.Key},{orderStatus.Value.Count},{orderStatus.Value.Revenue:C},{orderStatus.Value.Percentage:F2}%");
                }
                csvBuilder.AppendLine();

                // Add top products
                csvBuilder.AppendLine("TOP OVERALL PRODUCTS");
                csvBuilder.AppendLine("Name,Type,Quantity Sold,Revenue,Average Price");
                foreach (var product in dashboardData.ProductConsumption.TopOverallProducts)
                {
                    csvBuilder.AppendLine($"{product.ItemName},{product.ItemType},{product.QuantitySold},{product.Revenue:C},{product.AveragePrice:C}");
                }

                // Set file name
                string fileName = $"Dashboard_Report_{DateTime.Now:yyyyMMdd}.csv";

                // Return CSV file
                return File(Encoding.UTF8.GetBytes(csvBuilder.ToString()), "text/csv", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error exporting dashboard data");
                return StatusCode(500, new { message = "An error occurred while exporting dashboard data" });
            }
        }

        ///// <summary>
        ///// Get all orders with pagination, filtering, and sorting
        ///// </summary>
        //[HttpGet("orders")]
        //public async Task<ActionResult<PagedResult<OrderResponse>>> GetOrders(
        //    [FromQuery] string searchTerm = null,
        //    [FromQuery] string status = null,
        //    [FromQuery] DateTime? fromDate = null,
        //    [FromQuery] DateTime? toDate = null,
        //    [FromQuery] decimal? minPrice = null,
        //    [FromQuery] decimal? maxPrice = null,
        //    [FromQuery] bool? hasHotpot = null,
        //    [FromQuery] string paymentStatus = null,
        //    [FromQuery] int pageNumber = 1,
        //    [FromQuery] int pageSize = 10,
        //    [FromQuery] string sortBy = "CreatedAt",
        //    [FromQuery] bool ascending = false)
        //{
        //    try
        //    {
        //        // Validate pagination parameters
        //        if (pageNumber < 1) pageNumber = 1;
        //        if (pageSize < 1) pageSize = 10;
        //        if (pageSize > 50) pageSize = 50;

        //        // Use the existing GetOrdersAsync method with all filters
        //        var pagedResult = await _orderService.GetOrdersAsync(
        //            searchTerm: searchTerm,
        //            status: status,
        //            fromDate: fromDate,
        //            toDate: toDate,
        //            minPrice: minPrice,
        //            maxPrice: maxPrice,
        //            hasHotpot: hasHotpot,
        //            paymentStatus: paymentStatus,
        //            pageNumber: pageNumber,
        //            pageSize: pageSize,
        //            sortBy: sortBy,
        //            ascending: ascending);

        //        // Map to response
        //        var orderResponses = pagedResult.Items.Select(MapOrderToResponse).ToList();

        //        return Ok(new PagedResult<OrderResponse>
        //        {
        //            Items = orderResponses,
        //            TotalCount = pagedResult.TotalCount,
        //            PageNumber = pageNumber,
        //            PageSize = pageSize
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error retrieving orders");
        //        return StatusCode(500, new { message = "An error occurred while retrieving orders" });
        //    }
        //}

        ///// <summary>
        ///// Get order by ID
        ///// </summary>
        //[HttpGet("orders/{id}")]
        //public async Task<ActionResult<OrderResponse>> GetOrderById(int id)
        //{
        //    try
        //    {
        //        var order = await _orderService.GetByIdAsync(id);
        //        var orderResponse = MapOrderToResponse(order);
        //        return Ok(orderResponse);
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error retrieving order {OrderId}", id);
        //        return StatusCode(500, new { message = "An error occurred while retrieving the order" });
        //    }
        //}

        ///// <summary>
        ///// Update order status
        ///// </summary>
        //[HttpPut("orders/{id}/status")]
        //public async Task<ActionResult<OrderResponse>> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusRequest request)
        //{
        //    try
        //    {
        //        var updatedOrder = await _orderService.UpdateStatusAsync(id, request.Status);
        //        var orderResponse = MapOrderToResponse(updatedOrder);
        //        return Ok(orderResponse);
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(new { message = ex.Message });
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error updating status for order {OrderId}", id);
        //        return StatusCode(500, new { message = "An error occurred while updating the order status" });
        //    }
        //}

        //// Helper methods
        //private OrderResponse MapOrderToResponse(Order order)
        //{
        //    if (order == null) return null;

        //    var response = new OrderResponse
        //    {
        //        OrderId = order.OrderId,
        //        Address = order.Address,
        //        Notes = order.Notes,
        //        TotalPrice = order.TotalPrice,
        //        Status = order.Status.ToString(),
        //        CreatedAt = order.CreatedAt,
        //        UpdatedAt = order.UpdatedAt,
        //        User = order.User != null ? new UserInfo
        //        {
        //            UserId = order.User.UserId,
        //            Name = order.User.Name,
        //            PhoneNumber = order.User.PhoneNumber,
        //            Email = order.User.Email
        //        } : null,
        //        Items = new List<OrderItemResponse>(),
        //        Discount = null,
        //        Payment = null
        //    };

        //    // Add hotpot deposit from RentOrder if available
        //    if (order.RentOrder != null)
        //    {
        //        response.HotpotDeposit = order.RentOrder.HotpotDeposit;

        //        // Add rental dates to the response
        //        response.RentalStartDate = order.RentOrder.RentalStartDate;
        //        response.ExpectedReturnDate = order.RentOrder.ExpectedReturnDate;
        //        response.ActualReturnDate = order.RentOrder.ActualReturnDate;
        //    }
        //    else
        //    {
        //        response.HotpotDeposit = 0;
        //    }

        //    // Map sell order details
        //    if (order.SellOrder?.SellOrderDetails != null)
        //    {
        //        foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
        //        {
        //            string itemType = "";
        //            string itemName = "Unknown";
        //            string imageUrl = null;
        //            int? itemId = null;

        //            if (detail.IngredientId.HasValue && detail.Ingredient != null)
        //            {
        //                itemType = "Ingredient";
        //                itemName = detail.Ingredient.Name;
        //                imageUrl = detail.Ingredient.ImageURL;
        //                itemId = detail.IngredientId;
        //            }
        //            else if (detail.CustomizationId.HasValue && detail.Customization != null)
        //            {
        //                itemType = "Customization";
        //                itemName = detail.Customization.Name;
        //                itemId = detail.CustomizationId;
        //            }
        //            else if (detail.ComboId.HasValue && detail.Combo != null)
        //            {
        //                itemType = "Combo";
        //                itemName = detail.Combo.Name;
        //                imageUrl = detail.Combo.ImageURL;
        //                itemId = detail.ComboId;
        //            }

        //            response.Items.Add(new OrderItemResponse
        //            {
        //                OrderDetailId = detail.SellOrderDetailId,
        //                Quantity = detail.Quantity,
        //                UnitPrice = detail.UnitPrice,
        //                TotalPrice = detail.UnitPrice * detail.Quantity,
        //                ItemType = itemType,
        //                ItemName = itemName,
        //                ImageUrl = imageUrl,
        //                ItemId = itemId,
        //                IsSellable = true
        //            });
        //        }
        //    }

        //    // Map rent order details
        //    if (order.RentOrder?.RentOrderDetails != null)
        //    {
        //        foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
        //        {
        //            string itemType = "";
        //            string itemName = "Unknown";
        //            string imageUrl = null;
        //            int? itemId = null;

        //            if (detail.UtensilId.HasValue && detail.Utensil != null)
        //            {
        //                itemType = "Utensil";
        //                itemName = detail.Utensil.Name;
        //                imageUrl = detail.Utensil.ImageURL;
        //                itemId = detail.UtensilId;
        //            }
        //            else if (detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null)
        //            {
        //                itemType = "Hotpot";
        //                itemName = detail.HotpotInventory.Hotpot.Name;
        //                imageUrl = detail.HotpotInventory.Hotpot.ImageURLs?.FirstOrDefault();
        //                itemId = detail.HotpotInventory.HotpotId;
        //            }

        //            response.Items.Add(new OrderItemResponse
        //            {
        //                OrderDetailId = detail.RentOrderDetailId,
        //                Quantity = detail.Quantity,
        //                UnitPrice = detail.RentalPrice,
        //                TotalPrice = detail.RentalPrice * detail.Quantity,
        //                ItemType = itemType,
        //                ItemName = itemName,
        //                ImageUrl = imageUrl,
        //                ItemId = itemId,
        //                IsSellable = false
        //            });
        //        }
        //    }

        //    // Map discount if available
        //    if (order.Discount != null)
        //    {
        //        response.Discount = new DiscountInfo
        //        {
        //            DiscountId = order.Discount.DiscountId,
        //            Title = order.Discount.Title,
        //            Description = order.Discount.Description,
        //            Percent = order.Discount.DiscountPercentage,
        //            DiscountAmount = CalculateDiscountAmount(order.TotalPrice, order.Discount.DiscountPercentage)
        //        };
        //    }

        //    // Map payment if available
        //    if (order.Payment != null)
        //    {
        //        response.Payment = new PaymentInfo
        //        {
        //            PaymentId = order.Payment.PaymentId,
        //            Type = order.Payment.Type.ToString(),
        //            Status = order.Payment.Status.ToString(),
        //            Amount = order.Payment.Price,
        //            UpdateAt = order.Payment.UpdatedAt
        //        };
        //    }

        //    return response;
        //}

        //private decimal CalculateDiscountAmount(decimal totalPrice, decimal discountPercent)
        //{
        //    return totalPrice * (discountPercent / 100);
        //}



    }
}

