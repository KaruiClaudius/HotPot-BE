using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;
using Capstone.HPTY.ServiceLayer.DTOs.Payments.Admin;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Capstone.HPTY.API.Controllers.Admin
{
    [Route("api/admin/payments")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminPaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdminPaymentController> _logger;

        public AdminPaymentController(
            IPaymentService paymentService,
            IUnitOfWork unitOfWork,
            ILogger<AdminPaymentController> logger)
        {
            _paymentService = paymentService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Get all payments with pagination, filtering, and sorting
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PagedResult<PaymentDetailResponse>>> GetPayments(
            [FromQuery] string searchTerm = null,
            [FromQuery] string paymentType = null,
            [FromQuery] string paymentStatus = null,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] decimal? minAmount = null,
            [FromQuery] decimal? maxAmount = null,
            [FromQuery] int? userId = null,
            [FromQuery] int? orderId = null,
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

                // Build the query
                var query = _unitOfWork.Repository<Payment>().AsQueryable();

                // Apply filters
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    // Search by transaction code or user name
                    query = query.Where(p =>
                        p.TransactionCode.ToString().Contains(searchTerm) ||
                        p.User.Name.Contains(searchTerm) ||
                        p.User.PhoneNumber.Contains(searchTerm) ||
                        p.User.Email.Contains(searchTerm));
                }

                if (!string.IsNullOrWhiteSpace(paymentType) && Enum.TryParse<PaymentType>(paymentType, true, out var type))
                {
                    query = query.Where(p => p.Type == type);
                }

                if (!string.IsNullOrWhiteSpace(paymentStatus) && Enum.TryParse<PaymentStatus>(paymentStatus, true, out var status))
                {
                    query = query.Where(p => p.Status == status);
                }

                if (fromDate.HasValue)
                {
                    query = query.Where(p => p.CreatedAt >= fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    // Include the entire day
                    var endDate = toDate.Value.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(p => p.CreatedAt <= endDate);
                }

                if (minAmount.HasValue)
                {
                    query = query.Where(p => p.Price >= minAmount.Value);
                }

                if (maxAmount.HasValue)
                {
                    query = query.Where(p => p.Price <= maxAmount.Value);
                }

                if (userId.HasValue)
                {
                    query = query.Where(p => p.UserId == userId.Value);
                }

                if (orderId.HasValue)
                {
                    query = query.Where(p => p.OrderId == orderId.Value);
                }

                // Only include non-deleted items
                query = query.Where(p => !p.IsDelete);

                // Include related entities
                query = query.Include(p => p.User)
                             .Include(p => p.Order);

                // Get total count
                var totalCount = await query.CountAsync();

                // Apply sorting
                if (!string.IsNullOrWhiteSpace(sortBy))
                {
                    switch (sortBy.ToLower())
                    {
                        case "paymentid":
                            query = ascending ? query.OrderBy(p => p.PaymentId) : query.OrderByDescending(p => p.PaymentId);
                            break;
                        case "transactioncode":
                            query = ascending ? query.OrderBy(p => p.TransactionCode) : query.OrderByDescending(p => p.TransactionCode);
                            break;
                        case "type":
                            query = ascending ? query.OrderBy(p => p.Type) : query.OrderByDescending(p => p.Type);
                            break;
                        case "status":
                            query = ascending ? query.OrderBy(p => p.Status) : query.OrderByDescending(p => p.Status);
                            break;
                        case "price":
                            query = ascending ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                            break;
                        case "username":
                            query = ascending ? query.OrderBy(p => p.User.Name) : query.OrderByDescending(p => p.User.Name);
                            break;
                        case "updatedat":
                            query = ascending ? query.OrderBy(p => p.UpdatedAt) : query.OrderByDescending(p => p.UpdatedAt);
                            break;
                        case "createdat":
                        default:
                            query = ascending ? query.OrderBy(p => p.CreatedAt) : query.OrderByDescending(p => p.CreatedAt);
                            break;
                    }
                }
                else
                {
                    // Default sorting
                    query = query.OrderByDescending(p => p.CreatedAt);
                }

                // Apply pagination
                var payments = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to response
                var paymentResponses = payments.Select(MapPaymentToResponse).ToList();

                return Ok(new PagedResult<PaymentDetailResponse>
                {
                    Items = paymentResponses,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payments");
                return StatusCode(500, new { message = "An error occurred while retrieving payments" });
            }
        }

        /// <summary>
        /// Get payment by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetailResponse>> GetPaymentById(int id)
        {
            try
            {
                var payment = await _unitOfWork.Repository<Payment>()
                    .AsQueryable()
                    .Include(p => p.User)
                    .Include(p => p.Order)
                    .FirstOrDefaultAsync(p => p.PaymentId == id && !p.IsDelete);

                if (payment == null)
                {
                    return NotFound(new { message = $"Payment with ID {id} not found" });
                }

                var paymentResponse = MapPaymentToResponse(payment);
                return Ok(paymentResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payment {PaymentId}", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the payment" });
            }
        }

        /// <summary>
        /// Get payments by order ID
        /// </summary>
        [HttpGet("by-order/{orderId}")]
        public async Task<ActionResult<List<PaymentDetailResponse>>> GetPaymentsByOrderId(int orderId)
        {
            try
            {
                var payments = await _unitOfWork.Repository<Payment>()
                    .AsQueryable()
                    .Include(p => p.User)
                    .Include(p => p.Order)
                    .Where(p => p.OrderId == orderId && !p.IsDelete)
                    .ToListAsync();

                if (payments == null || !payments.Any())
                {
                    return NotFound(new { message = $"No payments found for order ID {orderId}" });
                }

                var paymentResponses = payments.Select(MapPaymentToResponse).ToList();
                return Ok(paymentResponses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payments for order {OrderId}", orderId);
                return StatusCode(500, new { message = "An error occurred while retrieving the payments" });
            }
        }

        /// <summary>
        /// Get payments by user ID
        /// </summary>
        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<List<PaymentDetailResponse>>> GetPaymentsByUserId(int userId)
        {
            try
            {
                var payments = await _unitOfWork.Repository<Payment>()
                    .AsQueryable()
                    .Include(p => p.User)
                    .Include(p => p.Order)
                    .Where(p => p.UserId == userId && !p.IsDelete)
                    .ToListAsync();

                if (payments == null || !payments.Any())
                {
                    return NotFound(new { message = $"No payments found for user ID {userId}" });
                }

                var paymentResponses = payments.Select(MapPaymentToResponse).ToList();
                return Ok(paymentResponses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payments for user {UserId}", userId);
                return StatusCode(500, new { message = "An error occurred while retrieving the payments" });
            }
        }

        // Helper methods
        private PaymentDetailResponse MapPaymentToResponse(Payment payment)
        {
            if (payment == null) return null;

            var response = new PaymentDetailResponse
            {
                PaymentId = payment.PaymentId,
                TransactionCode = payment.TransactionCode,
                Type = payment.Type.ToString(),
                Status = payment.Status.ToString(),
                Price = payment.Price,
                CreatedAt = payment.CreatedAt,
                UpdatedAt = payment.UpdatedAt,
                User = payment.User != null ? new UserInfo
                {
                    UserId = payment.User.UserId,
                    Name = payment.User.Name,
                    PhoneNumber = payment.User.PhoneNumber,
                    Email = payment.User.Email
                } : null,
                Order = payment.Order != null ? new OrderBasicInfo
                {
                    OrderId = payment.Order.OrderId,
                    Status = payment.Order.Status.ToString(),
                    TotalPrice = payment.Order.TotalPrice,
                    CreatedAt = payment.Order.CreatedAt
                } : null
            };

            return response;
        }
    }
}
