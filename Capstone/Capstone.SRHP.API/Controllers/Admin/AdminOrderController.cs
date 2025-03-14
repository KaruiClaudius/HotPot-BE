using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [Route("api/admin/orders")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminOrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ILogger<AdminOrderController> _logger;

        public AdminOrderController(
            IOrderService orderService,
            IUserService userService,
            ILogger<AdminOrderController> logger)
        {
            _orderService = orderService;
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Get all orders with pagination, filtering, and sorting
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PagedResult<OrderResponse>>> GetOrders(
            [FromQuery] string searchTerm = null,
            [FromQuery] int? userId = null,
            [FromQuery] string status = null,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "CreatedAt",
            [FromQuery] bool ascending = false)
        {
            try
            {
                // Validate pagination parameters
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;
                if (pageSize > 50) pageSize = 50;

                // Get paged orders
                var pagedResult = await _orderService.GetPagedAsync(pageNumber, pageSize);

                // Apply filters
                var filteredItems = pagedResult.Items.AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    filteredItems = filteredItems.Where(o =>
                        (o.Address != null && o.Address.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                        (o.Notes != null && o.Notes.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                        (o.User != null && o.User.Name != null && o.User.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                        (o.User != null && o.User.Email != null && o.User.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));
                }

                if (userId.HasValue)
                {
                    filteredItems = filteredItems.Where(o => o.UserID == userId.Value);
                }

                if (!string.IsNullOrEmpty(status) && Enum.TryParse<OrderStatus>(status, true, out var orderStatus))
                {
                    filteredItems = filteredItems.Where(o => o.Status == orderStatus);
                }

                if (fromDate.HasValue)
                {
                    filteredItems = filteredItems.Where(o => o.CreatedAt >= fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    filteredItems = filteredItems.Where(o => o.CreatedAt <= toDate.Value);
                }

                if (minPrice.HasValue)
                {
                    filteredItems = filteredItems.Where(o => o.TotalPrice >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    filteredItems = filteredItems.Where(o => o.TotalPrice <= maxPrice.Value);
                }

                // Apply sorting
                filteredItems = ApplySorting(filteredItems, sortBy, ascending);

                // Convert to list and map to response
                var filteredList = filteredItems.ToList();
                var orderResponses = filteredList.Select(MapOrderToResponse).ToList();

                return Ok(new PagedResult<OrderResponse>
                {
                    Items = orderResponses,
                    TotalCount = pagedResult.TotalCount, // Keep original total count
                    PageNumber = pageNumber,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders");
                return StatusCode(500, new { message = "An error occurred while retrieving orders" });
            }
        }

        /// <summary>
        /// Get orders by status
        /// </summary>
        [HttpGet("by-status/{status}")]
        public async Task<ActionResult<PagedResult<OrderResponse>>> GetOrdersByStatus(
            string status,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                // Validate pagination parameters
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;
                if (pageSize > 50) pageSize = 50;

                // Parse status
                if (!Enum.TryParse<OrderStatus>(status, true, out var orderStatus))
                {
                    return BadRequest(new { message = $"Invalid order status: {status}" });
                }

                var pagedResult = await _orderService.GetOrdersByStatusPagedAsync(orderStatus, pageNumber, pageSize);
                var orderResponses = pagedResult.Items.Select(MapOrderToResponse).ToList();

                return Ok(new PagedResult<OrderResponse>
                {
                    Items = orderResponses,
                    TotalCount = pagedResult.TotalCount,
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders by status {Status}", status);
                return StatusCode(500, new { message = "An error occurred while retrieving orders" });
            }
        }

        /// <summary>
        /// Get order by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrderById(int id)
        {
            try
            {
                var order = await _orderService.GetByIdAsync(id);
                var orderResponse = MapOrderToResponse(order);
                return Ok(orderResponse);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order {OrderId}", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the order" });
            }
        }

        /// <summary>
        /// Update order status
        /// </summary>
        [HttpPut("{id}/status")]
        public async Task<ActionResult<OrderResponse>> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusRequest request)
        {
            try
            {
                var updatedOrder = await _orderService.UpdateStatusAsync(id, request.Status);
                var orderResponse = MapOrderToResponse(updatedOrder);
                return Ok(orderResponse);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating status for order {OrderId}", id);
                return StatusCode(500, new { message = "An error occurred while updating the order status" });
            }
        }

        // Helper methods
        private OrderResponse MapOrderToResponse(Order order)
        {
            if (order == null) return null;

            var response = new OrderResponse
            {
                OrderId = order.OrderId,
                Address = order.Address,
                Notes = order.Notes,
                TotalPrice = order.TotalPrice,
                IngredientsDeposit = order.IngredientsDeposit ?? 0,
                HotpotDeposit = order.HotpotDeposit ?? 0,
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

            // Map order details
            if (order.OrderDetails != null)
            {
                foreach (var detail in order.OrderDetails.Where(d => !d.IsDelete))
                {
                    string itemType = "";
                    string itemName = "Unknown";
                    string imageUrl = null;
                    int? itemId = null;

                    if (detail.Utensil != null)
                    {
                        itemType = "Utensil";
                        itemName = detail.Utensil.Name;
                        imageUrl = detail.Utensil.ImageURL;
                        itemId = detail.UtensilID;
                    }
                    else if (detail.Ingredient != null)
                    {
                        itemType = "Ingredient";
                        itemName = detail.Ingredient.Name;
                        imageUrl = detail.Ingredient.ImageURL;
                        itemId = detail.IngredientID;
                    }
                    else if (detail.Hotpot != null)
                    {
                        itemType = "Hotpot";
                        itemName = detail.Hotpot.Name;
                        imageUrl = detail.Hotpot.ImageURLs?.FirstOrDefault();
                        itemId = detail.HotpotID;
                    }
                    else if (detail.Customization != null)
                    {
                        itemType = "Customization";
                        itemName = detail.Customization.Name;
                        itemId = detail.CustomizationID;
                    }
                    else if (detail.Combo != null)
                    {
                        itemType = "Combo";
                        itemName = detail.Combo.Name;
                        imageUrl = detail.Combo.ImageURL;
                        itemId = detail.ComboID;
                    }

                    response.Items.Add(new OrderItemResponse
                    {
                        OrderDetailId = detail.OrderDetailId,
                        Quantity = detail.Quantity,
                        UnitPrice = detail.UnitPrice,
                        TotalPrice = detail.UnitPrice * detail.Quantity,
                        ItemType = itemType,
                        ItemName = itemName,
                        ImageUrl = imageUrl,
                        ItemId = itemId
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
                    DiscountAmount = CalculateDiscountAmount(order.TotalPrice, order.Discount.DiscountPercentage)
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
                    CreatedAt = order.Payment.CreatedAt
                };
            }

            return response;
        }

        private decimal CalculateDiscountAmount(decimal totalPrice, decimal discountPercent)
        {
            return totalPrice * (discountPercent / 100);
        }

        private IQueryable<Order> ApplySorting(IQueryable<Order> query, string sortBy, bool ascending)
        {
            return sortBy.ToLower() switch
            {
                "createdat" => ascending ? query.OrderBy(o => o.CreatedAt) : query.OrderByDescending(o => o.CreatedAt),
                "updatedat" => ascending ? query.OrderBy(o => o.UpdatedAt) : query.OrderByDescending(o => o.UpdatedAt),
                "totalprice" => ascending ? query.OrderBy(o => o.TotalPrice) : query.OrderByDescending(o => o.TotalPrice),
                "status" => ascending ? query.OrderBy(o => o.Status) : query.OrderByDescending(o => o.Status),
                "username" => ascending ? query.OrderBy(o => o.User.Name) : query.OrderByDescending(o => o.User.Name),
                _ => query.OrderByDescending(o => o.CreatedAt)
            };
        }
    }
}

