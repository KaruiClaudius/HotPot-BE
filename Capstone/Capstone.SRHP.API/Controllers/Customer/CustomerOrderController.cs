using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;
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
                    return Unauthorized(new { message = "Invalid user identification" });
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
                    if (effectivePageSize > 50) effectivePageSize = 50;
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
                return StatusCode(500, new { message = "An error occurred while retrieving orders" });
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
                return StatusCode(500, new { message = "An error occurred while retrieving the order" });
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
                    return Unauthorized(new { message = "User ID not found in token" });
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
                return StatusCode(500, new { message = "An error occurred while creating the order" });
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
                    return Unauthorized(new { message = "Invalid user identification" });
                }

                if (request.Items == null || !request.Items.Any())
                {
                    return BadRequest(new { message = "No items to update" });
                }

                var updatedCart = await _orderService.UpdateCartItemsQuantityAsync(userId, request.Items);

                if (updatedCart == null)
                {
                    return Ok(new { message = "Cart is now empty" });
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
                return StatusCode(500, new { message = "An error occurred while updating the cart" });
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
                return StatusCode(500, new { message = "An error occurred while updating the order" });
            }
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin,Staff")]
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
                return StatusCode(500, new { message = "An error occurred while deleting the order" });
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
            if (order == null) return null;

            var response = new OrderResponse
            {
                OrderId = order.OrderId,
                Address = order.Address,
                Notes = order.Notes,
                TotalPrice = order.TotalPrice,
                Status = order.Status.ToString(),
                CreatedAt = order.CreatedAt,
                UpdatedAt = (DateTime)order.UpdatedAt,
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
            if (order.SellOrder?.SellOrderDetails != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    // Existing code for mapping sell order details...
                }
            }

            // Map rent order details
            if (order.RentOrder?.RentOrderDetails != null)
            {
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    // Existing code for mapping rent order details...
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
    }
}
