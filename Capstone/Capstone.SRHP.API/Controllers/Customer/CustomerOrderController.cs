using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;

using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [Route("api/customer/orders")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class CustomerOrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IHotpotService _hotpotService;
        private readonly IUserService _userService;
        private readonly ILogger<CustomerOrderController> _logger;

        public CustomerOrderController(
            IOrderService orderService,
            IHotpotService hotpotService,
            IUserService userService,
            ILogger<CustomerOrderController> logger)
        {
            _orderService = orderService;
            _hotpotService = hotpotService;
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Get user orders with optional pagination and filtering
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<object>> GetUserOrders(
            [FromQuery] int? pageNumber = null,
            [FromQuery] int? pageSize = null,
            [FromQuery] string searchTerm = null,
            [FromQuery] string status = null,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] bool? hasHotpot = null,
            [FromQuery] string paymentStatus = null,
            [FromQuery] string sortBy = "CreatedAt",
            [FromQuery] bool ascending = false)
        {
            try
            {
                // Get current user ID
                var userIdClaim = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                {
                    // This returns UnauthorizedObjectResult
                    return Unauthorized(new { message = "Thông tin xác thực người dùng không hợp lệ" });
                }

                // Determine if pagination is requested
                bool isPaginated = pageNumber.HasValue || pageSize.HasValue;

                // Set default pagination values if needed
                int effectivePageNumber = pageNumber ?? 1;
                int effectivePageSize = pageSize ?? int.MaxValue;

                // Validate pagination parameters if pagination is requested
                if (isPaginated)
                {
                    if (effectivePageNumber < 1) effectivePageNumber = 1;
                    if (effectivePageSize < 1) effectivePageSize = 10;
                }

                // Use the GetOrdersAsync method with all parameters
                var pagedResult = await _orderService.GetOrdersAsync(
                    userId: userId,
                    searchTerm: searchTerm,
                    status: status,
                    fromDate: fromDate,
                    toDate: toDate,
                    minPrice: minPrice,
                    maxPrice: maxPrice,
                    hasHotpot: hasHotpot,
                    paymentStatus: paymentStatus,
                    pageNumber: effectivePageNumber,
                    pageSize: effectivePageSize,
                    sortBy: sortBy,
                    ascending: ascending);

                // Map to response objects
                var orderResponses = pagedResult.Items.Select(MapOrderToResponse).ToList();

                // Return appropriate response based on whether pagination was requested
                if (isPaginated)
                {
                    return Ok(new PagedResult<OrderResponse>
                    {
                        Items = orderResponses,
                        TotalCount = pagedResult.TotalCount,
                        PageNumber = effectivePageNumber,
                        PageSize = effectivePageSize
                    });
                }
                else
                {
                    return Ok(orderResponses);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user orders");
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi lấy danh sách đơn hàng" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrderById(int id)
        {
            try
            {
                var userIdClaim = User.FindFirstValue("id");
                var userId = int.Parse(userIdClaim);
                var order = await _orderService.GetByIdAsync(id);

                // Verify the order belongs to the current user or user is admin
                if (order.UserId != userId && !User.IsInRole("Admin"))
                    return Forbid();

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
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi lấy thông tin đơn hàng" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                var userIdClaim = User.FindFirstValue("id");

                if (string.IsNullOrEmpty(userIdClaim))
                {
                    _logger.LogError("User ID claim not found in token");
                    return Unauthorized(new { message = "Không tìm thấy ID người dùng trong token" });
                }

                var userId = int.Parse(userIdClaim);

                // Create order with just the items
                var order = await _orderService.CreateAsync(request, userId);
                var orderResponse = MapOrderToResponse(order);
                return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, orderResponse);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi tạo đơn hàng" });
            }
        }

        /// <summary>
        /// Update quantities of items in the cart (set quantity to 0 to remove an item)
        /// </summary>
        [HttpPut("cart/items")]
        public async Task<ActionResult<OrderResponse>> UpdateCartItems([FromBody] UpdateCartItemsRequest request)
        {
            try
            {
                var userIdClaim = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                {
                    return Unauthorized(new { message = "Thông tin xác thực người dùng không hợp lệ" });
                }

                if (request.Items == null || !request.Items.Any())
                {
                    return BadRequest(new { message = "Không có sản phẩm nào để cập nhật" });
                }

                var updatedCart = await _orderService.UpdateCartItemsQuantityAsync(userId, request.Items);

                if (updatedCart == null)
                {
                    return Ok(new { message = "Giỏ hàng hiện đang trống" });
                }

                var cartResponse = MapOrderToResponse(updatedCart);
                return Ok(cartResponse);
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
                _logger.LogError(ex, "Error updating cart items");
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi cập nhật giỏ hàng" });
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<OrderResponse>> UpdateOrder(int id, [FromBody] UpdateOrderRequest request)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue("id"));
                var order = await _orderService.GetByIdAsync(id);

                // Verify the order belongs to the current user or user is admin
                if (order.UserId != userId && !User.IsInRole("Admin"))
                    return Forbid();

                // Use the new UpdateAsync method that takes UpdateOrderRequest directly
                var updatedOrder = await _orderService.UpdateAsync(id, request);
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
                _logger.LogError(ex, "Error updating order {OrderId}", id);
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi cập nhật đơn hàng" });
            }
        }

        [HttpPut("{id}/status")]
        
        public async Task<ActionResult<OrderResponse>> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusRequest request)
        {
            try
            {
                var userIdClaim = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                {
                    // This returns UnauthorizedObjectResult
                    return Unauthorized(new { message = "Thông tin xác thực người dùng không hợp lệ" });
                }

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
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi cập nhật trạng thái đơn hàng" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue("id"));
                var order = await _orderService.GetByIdAsync(id);

                // Verify the order belongs to the current user or user is admin
                if (order.UserId != userId && !User.IsInRole("Admin"))
                    return Forbid();

                await _orderService.DeleteAsync(id);
                return NoContent();
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
                _logger.LogError(ex, "Error deleting order {OrderId}", id);
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi xóa đơn hàng" });
            }
        }

        //[HttpPost("calculate-deposit")]
        //public async Task<ActionResult> CalculateDeposit([FromBody] List<OrderItemRequest> items)
        //{
        //    try
        //    {
        //        // Calculate hotpot deposit manually
        //        decimal hotpotDeposit = 0;

        //        foreach (var item in items)
        //        {
        //            if (item.HotpotID.HasValue)
        //            {
        //                var hotpot = await _hotpotService.GetByIdAsync(item.HotpotID.Value);
        //                if (hotpot != null)
        //                {
        //                    // Calculate hotpot deposit (70% of hotpot price)
        //                    hotpotDeposit += (decimal)(hotpot.Price * 0.7m * item.Quantity);
        //                }
        //            }
        //        }

        //        return Ok(new
        //        {
        //            hotpotDeposit,
        //            totalDeposit = hotpotDeposit
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error calculating deposit");
        //        return StatusCode(500, new { message = "An error occurred while calculating the deposit" });
        //    }
        //}


        // Helper methods
        private OrderResponse MapOrderToResponse(Order order)
        {
            // Keep the existing mapping method as is
            // This method is already well-implemented
            if (order == null) return null;

            var response = new OrderResponse
            {
                OrderId = order.OrderId,
                OrderCode = order.OrderCode,
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
                Payment = null,
                AdditionalPayments = new List<PaymentInfo>()
            };

            var addedSellDetailIds = new HashSet<int>();
            var addedRentDetailIds = new HashSet<int>();

            // Add hotpot deposit from RentOrder if available
            if (order.RentOrder != null)
            {
                // Add rental dates to the response
                response.RentalStartDate = order.RentOrder.RentalStartDate;
                response.ExpectedReturnDate = order.RentOrder.ExpectedReturnDate;
                response.ActualReturnDate = order.RentOrder.ActualReturnDate;

                // Add late fee and damage fee information
                response.LateFee = order.RentOrder.LateFee;
                response.DamageFee = order.RentOrder.DamageFee;
                response.RentalNotes = order.RentOrder.RentalNotes;
                response.ReturnCondition = order.RentOrder.ReturnCondition;
            }

            // Map sell order details
            // Map sell order details
            if (order.SellOrder?.SellOrderDetails != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    // Skip if we've already added this detail
                    if (!addedSellDetailIds.Add(detail.SellOrderDetailId))
                    {
                        _logger.LogWarning($"Duplicate sell detail ID found: {detail.SellOrderDetailId}");
                        continue;
                    }

                    string itemType = "";
                    string itemName = "Unknown";
                    string imageUrl = null;
                    int? itemId = null;
                    string formattedQuantity = "";

                    if (detail.IngredientId.HasValue && detail.Ingredient != null)
                    {
                        itemType = "Ingredient";
                        itemName = detail.Ingredient.Name;
                        imageUrl = detail.Ingredient.ImageURL;
                        itemId = detail.IngredientId;
                        formattedQuantity = FormatQuantity(detail.Ingredient.MeasurementValue, detail.Ingredient.Unit);
                    }
                    else if (detail.UtensilId.HasValue && detail.Utensil != null)
                    {
                        itemType = "Utensil";
                        itemName = detail.Utensil.Name;
                        imageUrl = detail.Utensil.ImageURL;
                        itemId = detail.UtensilId;
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
                        FormattedQuantity = formattedQuantity,
                        ItemId = itemId,
                        IsSellable = true
                    });
                }
            }

            // Group hotpot items by hotpot type
            var hotpotGroups = new Dictionary<int, List<RentOrderDetail>>();
            var nonHotpotItems = new List<RentOrderDetail>();

            // Map rent order details
            if (order.RentOrder?.RentOrderDetails != null)
            {
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    // Skip if we've already added this detail
                    if (!addedRentDetailIds.Add(detail.RentOrderDetailId))
                    {
                        _logger.LogWarning($"Duplicate rent detail ID found: {detail.RentOrderDetailId}");
                        continue;
                    }

                    // Separate hotpot items from other rental items
                    if (detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null)
                    {
                        int hotpotId = detail.HotpotInventory.HotpotId;

                        if (!hotpotGroups.ContainsKey(hotpotId))
                        {
                            hotpotGroups[hotpotId] = new List<RentOrderDetail>();
                        }

                        hotpotGroups[hotpotId].Add(detail);
                    }
                    else
                    {
                        nonHotpotItems.Add(detail);
                    }
                }

                // Process non-hotpot rental items (this should be empty now that utensils are in sell order)
                foreach (var detail in nonHotpotItems)
                {
                    string itemType = "Unknown";
                    string itemName = "Unknown Rental Item";
                    string imageUrl = null;
                    int? itemId = null;

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

                // Process grouped hotpot items
                foreach (var group in hotpotGroups)
                {
                    var details = group.Value;
                    if (details.Count == 0) continue;

                    // Get the first detail to extract common information
                    var firstDetail = details.First();
                    var hotpot = firstDetail.HotpotInventory.Hotpot;

                    // Create a grouped item response
                    var groupedItem = new OrderItemResponse
                    {
                        // Use the first detail's ID as the primary ID
                        OrderDetailId = firstDetail.RentOrderDetailId,
                        // Set quantity to the number of items in the group
                        Quantity = details.Count,
                        // Use the rental price from the first item
                        UnitPrice = firstDetail.RentalPrice,
                        // Calculate total price for all items
                        TotalPrice = firstDetail.RentalPrice * details.Count,
                        ItemType = "Hotpot",
                        ItemName = hotpot.Name,
                        ImageUrl = hotpot.ImageURLs?.FirstOrDefault(),
                        ItemId = hotpot.HotpotId,
                        IsSellable = false,
                        // Add a list of all detail IDs in this group
                        RelatedDetailIds = details.Select(d => d.RentOrderDetailId).ToList(),
                        // Add a list of all inventory IDs (serial numbers) in this group
                        SerialNumbers = details.Select(d => d.HotpotInventory.SeriesNumber).ToList()
                    };

                    response.Items.Add(groupedItem);
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

            // Map payments if available
            if (order.Payments != null && order.Payments.Any())
            {
                // If you have a PaymentPurpose enum
                if (order.Payments.Any(p => p.Purpose == PaymentPurpose.OrderPayment))
                {
                    // Get the main order payment
                    var mainPayment = order.Payments
                        .Where(p => p.Purpose == PaymentPurpose.OrderPayment)
                        .OrderByDescending(p => p.CreatedAt)
                        .FirstOrDefault();

                    if (mainPayment != null)
                    {
                        response.Payment = new PaymentInfo
                        {
                            PaymentId = mainPayment.PaymentId,
                            TransactionCode = mainPayment.TransactionCode,
                            Type = mainPayment.Type.ToString(),
                            Status = mainPayment.Status.ToString(),
                            Amount = mainPayment.Price,
                            UpdateAt = mainPayment.UpdatedAt,
                            Purpose = mainPayment.Purpose.ToString()
                        };
                    }
                }
                else
                {
                    // If no specific order payment, use the first payment as the main one
                    var firstPayment = order.Payments.OrderBy(p => p.CreatedAt).FirstOrDefault();
                    if (firstPayment != null)
                    {
                        response.Payment = new PaymentInfo
                        {
                            PaymentId = firstPayment.PaymentId,
                            TransactionCode = firstPayment.TransactionCode,
                            Type = firstPayment.Type.ToString(),
                            Status = firstPayment.Status.ToString(),
                            Amount = firstPayment.Price,
                            UpdateAt = firstPayment.UpdatedAt,
                            Purpose = firstPayment.Purpose.ToString()
                        };
                    }
                }

                // Map all other payments as additional payments
                foreach (var payment in order.Payments)
                {
                    // Skip the main payment that we already mapped
                    if (response.Payment != null && payment.PaymentId == response.Payment.PaymentId)
                        continue;

                    response.AdditionalPayments.Add(new PaymentInfo
                    {
                        PaymentId = payment.PaymentId,
                        TransactionCode = payment.TransactionCode,
                        Type = payment.Type.ToString(),
                        Status = payment.Status.ToString(),
                        Amount = payment.Price,
                        UpdateAt = payment.UpdatedAt,
                        Purpose = payment.Purpose.ToString()
                    });
                }
            }

            return response;
        }

        private decimal CalculateDiscountAmount(decimal totalPrice, decimal discountPercent)
        {
            return totalPrice * (discountPercent / 100);
        }

        private string FormatQuantity(double quantity, string unit)
        {
            if (string.IsNullOrEmpty(unit))
                return quantity.ToString("0.##");

            return $"{quantity.ToString("0.##")} {unit}";
        }
    }
}
