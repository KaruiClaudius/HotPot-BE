// Capstone.HPTY.ServiceLayer.Services.OrderService
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffPaymentService : IStaffPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StaffPaymentService> _logger;

        public StaffPaymentService(
            IUnitOfWork unitOfWork,
            ILogger<StaffPaymentService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PaymentDetailDto> ConfirmDepositAsync(ConfirmDepositRequest request)
        {
            try
            {
                // Get the payment
                var payment = await _unitOfWork.Repository<Payment>()
                    .AsQueryable(p => p.PaymentId == request.PaymentId && p.OrderId == request.OrderId)
                    .Include(p => p.Order)
                    .Include(p => p.User)
                    .Include(p => p.Receipt)
                    .FirstOrDefaultAsync();

                if (payment == null)
                {
                    throw new NotFoundException($"Payment with ID {request.PaymentId} not found");
                }

                // Validate payment status
                if (payment.Status != PaymentStatus.Pending)
                {
                    throw new ValidationException($"Cannot confirm deposit for payment with status {payment.Status}");
                }

                // Keep payment status as Pending but update the timestamp
                payment.UpdatedAt = DateTime.UtcNow.AddHours(7);

                // Update order status to show payment is being processed
                var order = payment.Order;
                if (order != null)
                {
                    order.Status = OrderStatus.Processing;
                    order.SetUpdateDate();
                    await _unitOfWork.Repository<Order>().Update(order, order.OrderId);
                }

                // Save changes
                await _unitOfWork.Repository<Payment>().Update(payment, payment.PaymentId);
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Deposit confirmed for payment {PaymentId}, order {OrderId}",
                    payment.PaymentId, payment.OrderId);

                // Map to DTO
                return new PaymentDetailDto
                {
                    PaymentId = payment.PaymentId,
                    TransactionCode = payment.TransactionCode,
                    PaymentType = payment.Type.ToString(),
                    Status = payment.Status.ToString(),
                    Price = payment.Price,
                    CreatedAt = payment.CreatedAt,
                    UpdatedAt = payment.UpdatedAt,
                    Order = payment.Order != null ? new OrderInfoDto
                    {
                        OrderId = payment.Order.OrderId,
                        Status = payment.Order.Status.ToString(),
                        TotalPrice = payment.Order.TotalPrice,
                        Address = payment.Order.Address,
                        Notes = payment.Order.Notes
                    } : null,
                    User = new UserInfoDto
                    {
                        UserId = payment.User.UserId,
                        Name = payment.User.Name,
                        Email = payment.User.Email,
                        PhoneNumber = payment.User.PhoneNumber
                    },
                    Receipt = payment.Receipt != null ? new ReceiptInfoDto
                    {
                        ReceiptId = payment.Receipt.ReceiptId,
                        ReceiptNumber = payment.Receipt.ReceiptNumber,
                        GeneratedAt = payment.Receipt.GeneratedAt
                    } : null
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error confirming deposit for payment {PaymentId}, order {OrderId}",
                    request.PaymentId, request.OrderId);
                throw;
            }
        }

        public async Task<PaymentReceiptDto> ProcessPaymentAsync(ProcessPaymentRequest request)
        {
            try
            {
                // Get the payment
                var payment = await _unitOfWork.Repository<Payment>()
                    .AsQueryable(p => p.PaymentId == request.PaymentId && p.OrderId == request.OrderId)
                    .Include(p => p.Order)
                    .Include(p => p.User)
                    .FirstOrDefaultAsync();

                if (payment == null)
                {
                    throw new NotFoundException($"Payment with ID {request.PaymentId} not found");
                }

                // Validate payment status transition
                if (!IsValidPaymentStatusTransition(payment.Status, request.NewStatus))
                {
                    throw new ValidationException($"Invalid payment status transition from {payment.Status} to {request.NewStatus}");
                }

                // Update payment status
                payment.Status = request.NewStatus;
                payment.UpdatedAt = DateTime.UtcNow.AddHours(7);

                // Update order status based on payment status
                var order = payment.Order;
                if (order != null)
                {
                    if (request.NewStatus == PaymentStatus.Success)
                    {
                        // Payment successful, update order status accordingly
                        if (order.Status == OrderStatus.Processing)
                        {
                            // Move to confirmed if currently processing
                            order.Status = OrderStatus.Shipping;
                        }
                        else if (order.Status == OrderStatus.Shipping ||
                                 order.Status == OrderStatus.Delivered)
                        {
                            // Keep shipping/delivered status if already in those states
                            // No change needed
                        }
                        else
                        {
                            // For any other status, move to confirmed
                            order.Status = OrderStatus.Completed;
                        }
                    }
                    else if (request.NewStatus == PaymentStatus.Cancelled)
                    {
                        order.Status = OrderStatus.Cancelled;
                    }
                    else if (request.NewStatus == PaymentStatus.Refunded)
                    {
                        order.Status = OrderStatus.Returning;
                    }

                    order.SetUpdateDate();
                    await _unitOfWork.Repository<Order>().Update(order, order.OrderId);
                }

                // Save changes
                await _unitOfWork.Repository<Payment>().Update(payment, payment.PaymentId);
                await _unitOfWork.CommitAsync();

                _logger.LogInformation("Payment {PaymentId} processed with status {Status}",
                    payment.PaymentId, payment.Status);

                // Generate receipt if requested
                PaymentReceiptDto receipt = null;
                if (request.GenerateReceipt && request.NewStatus == PaymentStatus.Success)
                {
                    receipt = await GenerateReceiptAsync(payment.PaymentId);
                }

                return receipt;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payment {PaymentId}, order {OrderId}",
                    request.PaymentId, request.OrderId);
                throw;
            }
        }

        public async Task<PagedResult<PaymentListItemDto>> GetPaymentsAsync(PaymentFilterRequest filter, int pageNumber, int pageSize)
        {
            try
            {
                // Start with base query
                var query = _unitOfWork.Repository<Payment>().AsQueryable();

                // Apply filters
                if (filter.Status.HasValue)
                {
                    query = query.Where(p => p.Status == filter.Status.Value);
                }

                if (filter.FromDate.HasValue)
                {
                    query = query.Where(p => p.CreatedAt >= filter.FromDate.Value);
                }

                if (filter.ToDate.HasValue)
                {
                    query = query.Where(p => p.CreatedAt <= filter.ToDate.Value);
                }

                // Include related entities
                query = query.Include(p => p.Order)
                             .Include(p => p.User);

                // Get total count for pagination
                var totalCount = await query.CountAsync();

                // Apply sorting using dynamic ordering
                query = ApplySorting(query, filter.SortBy, filter.SortDescending);

                // Apply pagination and project to DTO
                var payments = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(p => new PaymentListItemDto
                    {
                        PaymentId = p.PaymentId,
                        TransactionCode = p.TransactionCode,
                        PaymentType = p.Type.ToString(),
                        Status = p.Status.ToString(),
                        Price = p.Price,
                        CreatedAt = p.CreatedAt,
                        UpdatedAt = p.UpdatedAt,
                        OrderId = p.OrderId,
                        OrderStatus = p.Order != null ? p.Order.Status.ToString() : string.Empty,
                        UserId = p.UserId,
                        CustomerName = p.User != null ? p.User.Name : string.Empty,
                        CustomerPhone = p.User != null ? p.User.PhoneNumber : string.Empty
                    })
                    .ToListAsync();

                // Create paged result
                return new PagedResult<PaymentListItemDto>
                {
                    Items = payments,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting payments with filter");
                throw;
            }
        }

        public async Task<PaymentReceiptDto> GenerateReceiptAsync(int paymentId)
        {
            try
            {
                var payment = await _unitOfWork.Repository<Payment>()
                    .AsQueryable(p => p.PaymentId == paymentId)
                    .Include(p => p.Order)
                    .Include(p => p.User)
                    .FirstOrDefaultAsync();

                if (payment == null)
                {
                    throw new NotFoundException($"Payment with ID {paymentId} not found");
                }

                // Try to get existing receipt
                var receipt = await _unitOfWork.Repository<PaymentReceipt>()
                    .AsQueryable(r => r.PaymentId == paymentId)
                    .FirstOrDefaultAsync();

                // If no receipt exists, create one
                if (receipt == null)
                {
                    receipt = new PaymentReceipt
                    {
                        PaymentId = payment.PaymentId,
                        OrderId = payment.OrderId ?? 0,
                        Amount = payment.Price,
                        GeneratedAt = DateTime.UtcNow.AddHours(7),
                        ReceiptNumber = $"REC-{DateTime.UtcNow.AddHours(7):yyyyMMdd}-{payment.TransactionCode}",
                    };

                    await _unitOfWork.Repository<PaymentReceipt>().InsertAsync(receipt);
                    await _unitOfWork.CommitAsync();
                }

                // Return receipt DTO
                return new PaymentReceiptDto
                {
                    ReceiptId = receipt.ReceiptId,
                    OrderId = payment.OrderId ?? 0,
                    OrderCode = payment.Order?.OrderCode ?? "Unknown",
                    PaymentId = payment.PaymentId,
                    TransactionCode = payment.TransactionCode.ToString() ?? "Unknown",
                    Amount = payment.Price,
                    PaymentDate = payment.UpdatedAt ?? payment.CreatedAt,
                    CustomerName = payment.User?.Name ?? "Unknown",
                    CustomerPhone = payment.User.PhoneNumber ?? "Unknown",
                    PaymentMethod = payment.Type.ToString() ?? "Unknown",
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating receipt for payment {PaymentId}", paymentId);
                throw;
            }
        }

        private bool IsValidPaymentStatusTransition(PaymentStatus currentStatus, PaymentStatus newStatus)
        {
            // Only allow transitions from Pending to Success/Cancelled/Refunded
            if (currentStatus == PaymentStatus.Pending)
            {
                return newStatus == PaymentStatus.Success ||
                       newStatus == PaymentStatus.Cancelled ||
                       newStatus == PaymentStatus.Refunded;
            }

            // Don't allow changing status once it's finalized
            return false;
        }

        private IQueryable<Payment> ApplySorting(IQueryable<Payment> query, string sortBy, bool sortDescending)
        {
            // Define a dictionary mapping sort property names to expressions
            var sortExpressions = new Dictionary<string, Expression<Func<Payment, object>>>
            {
                { "PaymentId", p => p.PaymentId },
                { "TransactionCode", p => p.TransactionCode },
                { "Price", p => p.Price },
                { "Status", p => p.Status },
                { "CreatedAt", p => p.CreatedAt },
                { "UpdatedAt", p => p.UpdatedAt ?? DateTime.MinValue },
                { "CustomerName", p => p.User.Name },
                { "OrderId", p => p.OrderId ?? 0 }
            };

            // Default to CreatedAt if sortBy is not in the dictionary
            if (!sortExpressions.TryGetValue(sortBy, out var sortExpression))
            {
                sortExpression = sortExpressions["CreatedAt"];
            }

            // Apply sorting
            return sortDescending
                ? query.OrderByDescending(sortExpression)
                : query.OrderBy(sortExpression);
        }
    }
}