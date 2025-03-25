using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.payOS.Types;
using System.Security.Claims;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [Route("api/customer/payment")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class PaymentController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger, IOrderService orderService)
        {
            _paymentService = paymentService;
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet("get-orders")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _paymentService.GetOrders();
            if (response.error == 0)
            {
                return Ok(response);
            }

            _logger.LogError("Failed to get orders: {Message}", response.message);
            return BadRequest(new { response.message });
        }

        [HttpGet("get-order-user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetOrderByUser(int userId)
        {
            // Check if the user is requesting their own data or is an admin
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var isAdmin = User.IsInRole("Admin");

            if (currentUserId != userId && !isAdmin)
            {
                return Forbid();
            }

            var response = await _paymentService.GetOrderByUserId(userId);
            if (response.error == 0)
            {
                return Ok(response);
            }

            _logger.LogError("Failed to get order for user {UserId}: {Message}", userId, response.message);
            return BadRequest(new { response.message });
        }

        [HttpPost("create-payment-link")]
        [Authorize]
        public async Task<IActionResult> CreatePaymentLink([FromBody] CreatePaymentLinkRequest body, [FromQuery] string phone, [FromQuery] int postId, [FromQuery] int transactionId)
        {
            // Verify the user is creating a payment for themselves
            var currentUserPhone = User.FindFirstValue(ClaimTypes.MobilePhone);
            var isAdmin = User.IsInRole("Admin");

            if (currentUserPhone != phone && !isAdmin)
            {
                return Forbid();
            }

            var response = await _paymentService.CreatePaymentLink(body, phone, postId, transactionId);
            if (response.error == 0)
            {
                return Ok(response);
            }

            _logger.LogError("Failed to create payment link for phone {Phone}: {Message}", phone, response.message);
            return BadRequest(new { response.message });
        }

        [HttpGet("get-order/{orderCode}")]
        [Authorize]
        public async Task<IActionResult> GetOrder(int orderCode)
        {
            var response = await _paymentService.GetOrder(orderCode);
            if (response.error == 0)
            {
                // Verify the user is accessing their own payment
                var result = response.data as PaymentOrderResult;
                if (result?.Transaction != null)
                {
                    var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    var isAdmin = User.IsInRole("Admin");

                    if (result.Transaction.UserId != currentUserId && !isAdmin)
                    {
                        return Forbid();
                    }
                }

                return Ok(response);
            }

            _logger.LogError("Failed to get order {OrderCode}: {Message}", orderCode, response.message);
            return BadRequest(new { response.message });
        }

        [HttpPost("cancel-order/{orderCode}")]
        [Authorize]
        public async Task<IActionResult> CancelOrder(int orderCode, [FromQuery] string reason)
        {
            // First get the order to verify ownership
            var getResponse = await _paymentService.GetOrder(orderCode);
            if (getResponse.error != 0)
            {
                return BadRequest(new { message = getResponse.message });
            }

            // Verify the user is cancelling their own payment
            try
            {
                // Cast to object first, then access properties
                var responseData = getResponse.data as object;
                if (responseData != null)
                {
                    // Use reflection to safely access properties
                    var transactionProperty = responseData.GetType().GetProperty("Transaction");
                    if (transactionProperty != null)
                    {
                        var transaction = transactionProperty.GetValue(responseData) as Payment;
                        if (transaction != null)
                        {
                            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                            var isAdmin = User.IsInRole("Admin");

                            if (transaction.UserId != currentUserId && !isAdmin)
                            {
                                return Forbid();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error checking payment ownership for order {OrderCode}", orderCode);
                // Continue anyway if we can't verify ownership
            }

            var response = await _paymentService.CancelOrder(orderCode, reason);
            if (response.error == 0)
            {
                return Ok(response);
            }

            _logger.LogError("Failed to cancel order {OrderCode}: {Reason}, Error: {Message}", orderCode, reason, response.message);
            return BadRequest(new { response.message });
        }

        [HttpPost("confirm-webhook")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConfirmWebhook([FromBody] ConfirmWebhook body)
        {
            var response = await _paymentService.ConfirmWebhook(body);
            if (response.error == 0)
            {
                return Ok(response);
            }

            _logger.LogError("Failed to confirm webhook: {Message}", response.message);
            return BadRequest(new { response.message });
        }

        [HttpPost("check-order")]
        [Authorize]
        public async Task<IActionResult> CheckOrder([FromBody] CheckOrderRequest request, [FromQuery] string userPhone)
        {
            var response = await _paymentService.CheckOrder(request, userPhone);
            if (response.error == 0)
            {
                return Ok(response);
            }

            _logger.LogError("Failed to check order {OrderCode} for user {UserPhone}: {Message}", request.OrderCode, userPhone, response.message);
            return BadRequest(new { response.message });
        }

        [HttpPost("create-cash-payment")]
        [Authorize]
        public async Task<IActionResult> CreateCashPayment([FromBody] CreateCashPaymentRequest request)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Verify the user is creating a payment for themselves
                if (request.UserId != userId && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                var payment = await _paymentService.CreateCashPaymentAsync(
                    request.UserId,
                    request.OrderId,
                    request.Amount);

                return Ok(new
                {
                    message = "Cash payment created successfully",
                    paymentId = payment.PaymentId,
                    status = payment.Status.ToString()
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not found error creating cash payment");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating cash payment");
                return StatusCode(500, new { message = "An error occurred while creating the cash payment" });
            }
        }

        [HttpPut("{paymentId}/status")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> UpdatePaymentStatus(int paymentId, [FromBody] UpdatePaymentStatusRequest request)
        {
            try
            {
                if (!Enum.TryParse<PaymentStatus>(request.Status, true, out var status))
                {
                    return BadRequest(new { message = "Invalid payment status" });
                }

                var payment = await _paymentService.UpdatePaymentStatusAsync(paymentId, status);

                return Ok(new
                {
                    message = "Payment status updated successfully",
                    paymentId = payment.PaymentId,
                    status = payment.Status.ToString()
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not found error updating payment status for payment {PaymentId}", paymentId);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating payment status for payment {PaymentId}", paymentId);
                return StatusCode(500, new { message = "An error occurred while updating the payment status" });
            }
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetPaymentsByUser(int userId)
        {
            try
            {
                // Verify the user is accessing their own payments
                var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (currentUserId != userId && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                var payments = await _paymentService.GetPaymentsByUserIdAsync(userId);

                var paymentDtos = payments.Select(p => new PaymentDto
                {
                    PaymentId = p.PaymentId,
                    TransactionCode = p.TransactionCode,
                    Type = p.Type.ToString(),
                    Price = p.Price,
                    Status = p.Status.ToString(),
                    OrderId = p.OrderId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                });

                return Ok(paymentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payments for user {UserId}", userId);
                return StatusCode(500, new { message = "An error occurred while retrieving the payments" });
            }
        }

        [HttpGet("{paymentId}")]
        [Authorize]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByIdAsync(paymentId);

                if (payment == null)
                {
                    return NotFound(new { message = $"Payment with ID {paymentId} not found" });
                }

                // Verify the user is accessing their own payment
                var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (payment.UserId != currentUserId && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                var paymentDto = new PaymentDto
                {
                    PaymentId = payment.PaymentId,
                    TransactionCode = payment.TransactionCode,
                    Type = payment.Type.ToString(),
                    Price = payment.Price,
                    Status = payment.Status.ToString(),
                    OrderId = payment.OrderId,
                    CreatedAt = payment.CreatedAt,
                    UpdatedAt = payment.UpdatedAt
                };

                return Ok(paymentDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment {PaymentId}", paymentId);
                return StatusCode(500, new { message = "An error occurred while retrieving the payment" });
            }
        }

        [HttpGet("order/{orderId}")]
        [Authorize]
        public async Task<IActionResult> GetPaymentByOrderId(int orderId)
        {
            try
            {
                // First verify the user owns the order
                var order = await _orderService.GetByIdAsync(orderId);
                if (order == null)
                {
                    return NotFound(new { message = $"Order with ID {orderId} not found" });
                }

                var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (order.UserId != currentUserId && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);

                if (payment == null)
                {
                    return NotFound(new { message = $"Payment for order with ID {orderId} not found" });
                }

                var paymentDto = new PaymentDto
                {
                    PaymentId = payment.PaymentId,
                    TransactionCode = payment.TransactionCode,
                    Type = payment.Type.ToString(),
                    Price = payment.Price,
                    Status = payment.Status.ToString(),
                    OrderId = payment.OrderId,
                    CreatedAt = payment.CreatedAt,
                    UpdatedAt = payment.UpdatedAt
                };

                return Ok(paymentDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payment for order {OrderId}", orderId);
                return StatusCode(500, new { message = "An error occurred while retrieving the payment" });
            }
        }
    }
}
