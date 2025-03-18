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
            [FromQuery] bool? hasHotpot = null,
            [FromQuery] string paymentStatus = null,
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

                // Use the existing GetOrdersAsync method with all filters
                var pagedResult = await _orderService.GetOrdersAsync(
                    searchTerm: searchTerm,
                    userId: userId,
                    status: status,
                    fromDate: fromDate,
                    toDate: toDate,
                    minPrice: minPrice,
                    maxPrice: maxPrice,
                    hasHotpot: hasHotpot,
                    paymentStatus: paymentStatus,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    sortBy: sortBy,
                    ascending: ascending);

                // Map to response
                var orderResponses = pagedResult.Items.Select(MapOrderToResponse).ToList();

                return Ok(new PagedResult<OrderResponse>
                {
                    Items = orderResponses,
                    TotalCount = pagedResult.TotalCount,
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

            // Map sell order details
            if (order.SellOrderDetails != null)
            {
                foreach (var detail in order.SellOrderDetails.Where(d => !d.IsDelete))
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

                        // Add volume/weight information for ingredients
                        response.Items.Add(new OrderItemResponse
                        {
                            OrderDetailId = detail.SellOrderDetailId,
                            Quantity = detail.Quantity,
                            VolumeWeight = detail.VolumeWeight,
                            Unit = detail.Unit ?? detail.Ingredient.MeasurementUnit,
                            UnitPrice = detail.UnitPrice,
                            TotalPrice = detail.VolumeWeight.HasValue ?
                                detail.UnitPrice * detail.VolumeWeight.Value :
                                detail.UnitPrice * (detail.Quantity ?? 1),
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
                        TotalPrice = detail.UnitPrice * (detail.Quantity ?? 1),
                        ItemType = itemType,
                        ItemName = itemName,
                        ImageUrl = imageUrl,
                        ItemId = itemId,
                        IsSellable = true
                    });
                }
            }

            // Map rent order details
            if (order.RentOrderDetails != null)
            {
                foreach (var detail in order.RentOrderDetails.Where(d => !d.IsDelete))
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
                        IsSellable = false,
                        RentalStartDate = detail.RentalStartDate,
                        ExpectedReturnDate = detail.ExpectedReturnDate,
                        ActualReturnDate = detail.ActualReturnDate
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
    }
}

