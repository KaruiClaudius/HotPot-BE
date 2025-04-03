using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Staff
{
    [Route("api/staff/payments")]
    [ApiController]
    //[Authorize(Roles = "Staff,Admin")]
    public class StaffPaymentController : ControllerBase
    {
        private readonly IStaffPaymentService _staffPaymentService;
        private readonly ILogger<StaffPaymentController> _logger;

        public StaffPaymentController(
            IStaffPaymentService staffPaymentService,
            ILogger<StaffPaymentController> logger)
        {
            _staffPaymentService = staffPaymentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<PaymentListItemDto>>> GetPayments(
             [FromQuery] PaymentFilterRequest filter,
             [FromQuery] int pageNumber = 1,
             [FromQuery] int pageSize = 20)
        {
            try
            {
                var pagedResult = await _staffPaymentService.GetPaymentsAsync(filter, pageNumber, pageSize);
                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payments");
                return StatusCode(500, "An error occurred while retrieving payments");
            }
        }

        [HttpPost("confirm-deposit")]
        public async Task<ActionResult<PaymentDetailDto>> ConfirmDeposit([FromBody] ConfirmDepositRequest request)
        {
            try
            {
                var payment = await _staffPaymentService.ConfirmDepositAsync(request);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error confirming deposit for payment {PaymentId}", request.PaymentId);
                return StatusCode(500, $"An error occurred while confirming deposit: {ex.Message}");
            }
        }

        [HttpPost("process")]
        public async Task<ActionResult<PaymentReceiptDto>> ProcessPayment([FromBody] ProcessPaymentRequest request)
        {
            try
            {
                var receipt = await _staffPaymentService.ProcessPaymentAsync(request);
                return Ok(receipt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payment {PaymentId}", request.PaymentId);
                return StatusCode(500, $"An error occurred while processing payment: {ex.Message}");
            }
        }

        [HttpGet("receipt/{paymentId}")]
        public async Task<ActionResult<PaymentReceiptDto>> GenerateReceipt(int paymentId)
        {
            try
            {
                var receipt = await _staffPaymentService.GenerateReceiptAsync(paymentId);
                return Ok(receipt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating receipt for payment {PaymentId}", paymentId);
                return StatusCode(500, $"An error occurred while generating receipt: {ex.Message}");
            }
        }
    }
}
