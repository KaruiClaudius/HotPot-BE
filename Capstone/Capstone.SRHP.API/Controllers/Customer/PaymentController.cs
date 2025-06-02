using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.BackgroundService;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
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
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger, IOrderService orderService, IServiceProvider serviceProvider)
        {
            _paymentService = paymentService;
            _logger = logger;
            _orderService = orderService;
            _serviceProvider = serviceProvider;
        }

        [HttpPost("process-online-payment")]
        [Authorize]
        public async Task<IActionResult> ProcessOnlinePayment([FromBody] ProcessOnlinePaymentRequest request)
        {
            try
            {
                var currentUserPhone = User.FindFirstValue("phone");
                var currentUserName = User.FindFirstValue("name");
                var userIdValue = User.FindFirstValue("id");
                if (request.DiscountId <= 0)
                {
                    request.DiscountId = null;
                }

                if (userIdValue == null)
                {
                    return BadRequest(new { message = "Không tìm thấy ID người dùng" });
                }
                var userId = int.Parse(userIdValue);
                var isCustomer = User.IsInRole("Customer");
                if (!isCustomer)
                {
                    return Forbid();
                }

                // Verify cart items availability before processing payment
                var verifyResponse = await _paymentService.VerifyCartBeforePaymentAsync(request.OrderId);
                if (verifyResponse.error != 0)
                {
                    return BadRequest(new { message = verifyResponse.message, details = verifyResponse.data });
                }

                string productName = "Order " + request.OrderId;
                var order = await _orderService.GetByIdAsync(request.OrderId);
                if (order == null)
                {
                    return NotFound(new { message = "Không tìm thấy đơn hàng" });
                }

                int price = (int)order.TotalPrice;

                // Create payment link request
                var paymentLinkRequest = new CreatePaymentLinkRequest(
                    productName: productName,
                    description: request.Description,
                    price: price,
                    returnUrl: request.ReturnUrl,
                    cancelUrl: request.CancelUrl,
                    buyerName: currentUserName,
                    buyerPhone: currentUserPhone
                );

                // Process the payment with expected return date
                var response = await _paymentService.ProcessOnlinePayment(
                    request.OrderId,
                    request.Address,
                    request.Notes,
                    request.DiscountId,
                    request.ExpectedReturnDate,
                    request.DeliveryTime,
                    paymentLinkRequest,
                    userId);

                if (response.error == 0)
                {
                    return Ok(response);
                }

                _logger.LogError("Failed to process online payment for order {OrderId}: {Message}", request.OrderId, response.message);
                return BadRequest(new { response.message });
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
                _logger.LogError(ex, "Error processing online payment");
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi xử lý thanh toán trực tuyến" });
            }
        }


        [HttpPost("process-cash-payment")]
        [Authorize]
        public async Task<IActionResult> ProcessCashPayment([FromBody] ProcessCashPaymentRequest request)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue("id"));

                // Verify cart items availability before processing payment
                var verifyResponse = await _paymentService.VerifyCartBeforePaymentAsync(request.OrderId);
                if (verifyResponse.error != 0)
                {
                    return BadRequest(new { message = verifyResponse.message, details = verifyResponse.data });
                }

                // Process the cash payment with expected return date
                var payment = await _paymentService.ProcessCashPayment(
                    request.OrderId,
                    request.Address,
                    request.Notes,
                    request.DiscountId,
                    request.ExpectedReturnDate,
                    request.DeliveryTime,
                    userId);

                return Ok(new
                {
                    message = "Tạo thanh toán tiền mặt thành công",
                    paymentId = payment.PaymentId,
                    status = payment.Status.ToString()
                });
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
                _logger.LogError(ex, "Error processing cash payment");
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi xử lý thanh toán tiền mặt" });
            }
        }


        [HttpPost("cancel-order/{orderCode}")]
        [Authorize]
        public async Task<IActionResult> CancelOrder(int orderCode, [FromQuery] string reason)
        {
            try
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
                                var currentUserId = int.Parse(User.FindFirstValue("id"));
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
                return BadRequest(new { message = response.message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling order {OrderCode}", orderCode);
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi hủy đơn hàng" });
            }
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
        public async Task<IActionResult> CheckOrder([FromBody] CheckOrderRequest request)
        {
            var correlationId = Guid.NewGuid().ToString();
            _logger.LogInformation("[{CorrelationId}] Received check-order request for {TransactionCode}",
                correlationId, request.OrderCode);

            try
            {
                // Check if the payment is being processed by the background service

                // Use a read-only transaction with a very short timeout
                using var scope = _serviceProvider.CreateScope();
                var lockService = scope.ServiceProvider.GetRequiredService<ILockService>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var payOS = scope.ServiceProvider.GetRequiredService<PayOS>();

                string processLockKey = $"process_payment_{request.OrderCode}";
                if (lockService.IsLocked(processLockKey))
                {
                    _logger.LogInformation("[{CorrelationId}] Payment {TransactionCode} is currently being processed by background service",
                        correlationId, request.OrderCode);
                    return Ok(new Response(0, "Đơn hàng đang được xử lý, vui lòng đợi trong giây lát", null));
                }

                // Get payment status from database
                var currentUserPhone = User.FindFirstValue("phone");



                // Get payment transaction
                var paymentTransaction = await unitOfWork.Repository<Payment>()
                    .FindAsync(pt => pt.TransactionCode == request.OrderCode);

                if (paymentTransaction == null)
                {
                    return Ok(new Response(-1, "Không tìm thấy giao dịch", null));
                }

                // Get payment info from PayOS
                var paymentInfo = await payOS.getPaymentLinkInformation(request.OrderCode);
                if (paymentInfo == null)
                {
                    return Ok(new Response(-1, "Thông tin thanh toán không tìm thấy", null));
                }

                // Get user
                var user = await unitOfWork.Repository<User>().FindAsync(u => u.PhoneNumber == currentUserPhone);
                if (user == null)
                {
                    return Ok(new Response(-1, "Không tìm thấy người dùng", null));
                }

                // Prepare user info for response
                var userInfo = new
                {
                    user.UserId,
                    user.Name,
                    user.PhoneNumber,
                };

                // If payment is pending in our system but PAID/CANCELLED in PayOS,
                // let the user know it's being processed and trigger background service
                if (paymentTransaction.Status == PaymentStatus.Pending &&
                    (paymentInfo.status == "PAID" || paymentInfo.status == "CANCELLED"))
                {
                    string message = paymentInfo.status == "PAID"
                        ? "Thanh toán đang được xử lý, vui lòng đợi trong giây lát"
                        : "Giao dịch đang được hủy, vui lòng đợi trong giây lát";

                    _logger.LogInformation("[{CorrelationId}] Payment {TransactionCode} is {Status} in PayOS but PENDING in our system",
                        correlationId, request.OrderCode, paymentInfo.status);

                    return Ok(new Response(0, message, new { paymentInfo, userInfo }));
                }

                // For other statuses, just return the current status
                string statusMessage;
                switch (paymentTransaction.Status)
                {
                    case PaymentStatus.Success:
                        statusMessage = "Hoàn thành giao dịch";
                        break;
                    case PaymentStatus.Cancelled:
                        statusMessage = "Huỷ giao dịch";
                        break;
                    case PaymentStatus.Pending:
                        statusMessage = "Giao dịch chưa hoàn thành";
                        break;
                    default:
                        statusMessage = $"Trạng thái giao dịch: {paymentTransaction.Status}";
                        break;
                }

                return Ok(new Response(0, statusMessage, new { paymentInfo, userInfo }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{CorrelationId}] Error checking order status for {TransactionCode}",
                    correlationId, request.OrderCode);
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi kiểm tra trạng thái đơn hàng" });
            }
        }
    }
}
