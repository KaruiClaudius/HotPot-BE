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

        public async Task<PagedResult<PaymentListItemDto>> GetPaymentsAsync(PaymentFilterRequest filter, int pageNumber, int pageSize)
        {
            try
            {
                // Start with base query - filter out deleted payments
                var query = _unitOfWork.Repository<Payment>()
                    .AsQueryable()
                    .Where(p => !p.IsDelete);

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

                query = query.Where(p => p.Order != null && !p.Order.IsDelete && !string.IsNullOrEmpty(p.Order.OrderCode));

                // Include related entities - ensure we filter out deleted orders
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
                        OrderCode = p.Order != null ? p.Order.OrderCode : string.Empty,
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

        public async Task<PaymentReceiptDto> GenerateDetailedReceiptAsync(int paymentId)
        {
            // Get the payment with related data
            var payment = await _unitOfWork.Repository<Payment>()
                .AsQueryable()
                .Include(p => p.User)
                .Include(p => p.Order)
                    .ThenInclude(o => o.Discount)
                .Include(p => p.Order)
                    .ThenInclude(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                .Include(p => p.Order)
                    .ThenInclude(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails)
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);

            if (payment == null)
                throw new NotFoundException($"Payment with ID {paymentId} not found");

            // Validate payment status is Success
            if (payment.Status != PaymentStatus.Success)
                throw new ValidationException($"Cannot generate receipt for payment with status '{payment.Status}'. Only successful payments can have receipts generated.");

            var order = payment.Order;
            if (order == null)
                throw new NotFoundException($"Order associated with payment ID {paymentId} not found");

            // Load all necessary details for the receipt
            await LoadOrderDetailsAsync(order);

            // Build sold items list
            var soldItems = new List<ReceiptItemDto>();
            if (order.SellOrder != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    soldItems.Add(new ReceiptItemDto
                    {
                        ItemType = GetItemType(detail),
                        Name = GetItemName(detail),
                        Quantity = detail.Quantity,
                        UnitPrice = detail.UnitPrice,
                        TotalPrice = detail.UnitPrice * detail.Quantity
                    });
                }
            }

            // Build rented items list
            var rentedItems = new List<ReceiptRentalItemDto>();
            if (order.RentOrder != null)
            {
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.HotpotInventory?.Hotpot != null)
                    {
                        rentedItems.Add(new ReceiptRentalItemDto
                        {
                            Name = detail.HotpotInventory.Hotpot.Name,
                            Quantity = 1,
                            RentalPrice = detail.RentalPrice,
                            RentalStartDate = order.RentOrder.RentalStartDate,
                            ExpectedReturnDate = order.RentOrder.ExpectedReturnDate,
                            ActualReturnDate = order.RentOrder.ActualReturnDate
                        });
                    }
                }
            }

            // Create the receipt
            return new PaymentReceiptDto
            {
                ReceiptId = payment.PaymentId, // Using payment ID as receipt ID
                OrderId = order.OrderId,
                OrderCode = order.OrderCode,
                PaymentId = payment.PaymentId,
                TransactionCode = payment.TransactionCode.ToString(),
                Amount = payment.Price,
                PaymentDate = payment.CreatedAt,
                CustomerName = payment.User?.Name ?? "Unknown",
                CustomerPhone = payment.User?.PhoneNumber ?? "Unknown",
                PaymentMethod = payment.Type.ToString(),
                OrderStatus = order.Status.ToString(),
                DeliveryAddress = order.Address,
                SoldItems = soldItems,
                RentedItems = rentedItems,
                //DiscountAmount = discountAmount,
                TotalAmount = order.TotalPrice,
                LateFee = order.RentOrder?.LateFee,
                DamageFee = order.RentOrder?.DamageFee,
                Notes = order.Notes
            };
        }

        private async Task LoadOrderDetailsAsync(Order order)
        {
            // Load all the necessary details for ingredients, utensils, combos, and customizations
            if (order.SellOrder != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.IngredientId.HasValue && detail.Ingredient == null)
                    {
                        detail.Ingredient = await _unitOfWork.Repository<Ingredient>().GetById(detail.IngredientId.Value);
                    }
                    else if (detail.UtensilId.HasValue && detail.Utensil == null)
                    {
                        detail.Utensil = await _unitOfWork.Repository<Utensil>().GetById(detail.UtensilId.Value);
                    }
                    else if (detail.ComboId.HasValue && detail.Combo == null)
                    {
                        detail.Combo = await _unitOfWork.Repository<Combo>().GetById(detail.ComboId.Value);
                    }
                    else if (detail.CustomizationId.HasValue && detail.Customization == null)
                    {
                        detail.Customization = await _unitOfWork.Repository<Customization>().GetById(detail.CustomizationId.Value);
                    }
                }
            }

            // Load hotpot details
            if (order.RentOrder != null)
            {
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.HotpotInventoryId.HasValue && detail.HotpotInventory == null)
                    {
                        detail.HotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                            .IncludeNested(query => query.Include(h => h.Hotpot))
                            .FirstOrDefaultAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId);
                    }
                }
            }
        }

        private string GetItemType(SellOrderDetail detail)
        {
            if (detail.IngredientId.HasValue) return "Nguyên liệu";
            if (detail.UtensilId.HasValue) return "Dụng cụ ăn";
            if (detail.ComboId.HasValue) return "Combo";
            if (detail.CustomizationId.HasValue) return " Combo Tùy chỉnh";
            return "Unknown";
        }

        private string GetItemName(SellOrderDetail detail)
        {
            if (detail.Ingredient != null) return detail.Ingredient.Name;
            if (detail.Utensil != null) return detail.Utensil.Name;
            if (detail.Combo != null) return detail.Combo.Name;
            if (detail.Customization != null) return detail.Customization.Name;
            return "Unknown Item";
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