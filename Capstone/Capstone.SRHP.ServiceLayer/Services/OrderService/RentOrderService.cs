using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
{
    public class RentOrderService : IRentOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEquipmentReturnService _equipmentReturnService;

        private readonly ILogger<RentOrderService> _logger;

        public RentOrderService(
            IUnitOfWork unitOfWork,
            IEquipmentReturnService equipmentReturnService,
            ILogger<RentOrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _equipmentReturnService = equipmentReturnService;
            _logger = logger;
        }

        public async Task<PagedResult<RentalListingDto>> GetPendingPickupsAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var today = DateTime.Today;

                // Query RentOrders directly
                var query = _unitOfWork.Repository<RentOrder>()
                    .AsQueryable(r => r.ExpectedReturnDate.Date == today && r.ActualReturnDate == null && !r.IsDelete)
                    .Include(r => r.Order)
                        .ThenInclude(o => o.User)
                    .Include(r => r.RentOrderDetails)
                        .ThenInclude(d => d.HotpotInventory)
                            .ThenInclude(hi => hi != null ? hi.Hotpot : null);

                // Get total count before applying pagination
                var totalCount = await query.CountAsync();

                // Apply pagination
                var rentOrders = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to DTOs with grouped equipment items
                var dtos = rentOrders.Select(rentOrder => MapToGroupedRentalListingDto(rentOrder)).ToList();

                return new PagedResult<RentalListingDto>
                {
                    Items = dtos,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving pending pickups");
                throw;
            }
        }

        public async Task<PagedResult<RentalListingDto>> GetOverdueRentalsAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var today = DateTime.Today;

                // Query RentOrders directly
                var query = _unitOfWork.Repository<RentOrder>()
                    .AsQueryable(r => r.ExpectedReturnDate.Date < today && r.ActualReturnDate == null && !r.IsDelete)
                    .Include(r => r.Order)
                        .ThenInclude(o => o.User)
                    .Include(r => r.RentOrderDetails)
                        .ThenInclude(d => d.HotpotInventory)
                            .ThenInclude(hi => hi != null ? hi.Hotpot : null);

                // Get total count before applying pagination
                var totalCount = await query.CountAsync();

                // Apply pagination
                var rentOrders = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to DTOs with grouped equipment items
                var dtos = rentOrders.Select(rentOrder => MapToGroupedRentalListingDto(rentOrder)).ToList();

                return new PagedResult<RentalListingDto>
                {
                    Items = dtos,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving overdue rentals");
                throw;
            }
        }
        public async Task<PagedResult<RentOrderDetailResponse>> GetUnassignedPickupsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var today = DateTime.Today;

            // Load orders with users first to filter by those with customer names
            var ordersWithUsers = await _unitOfWork.Repository<Order>()
                .AsQueryable(o => !o.IsDelete)
                .Include(o => o.User)
                .Where(o => o.User != null && !string.IsNullOrEmpty(o.User.Name) && o.Status == OrderStatus.Delivered)
                .Select(o => new { o.OrderId, o.User })
                .ToListAsync();

            var orderIdsWithCustomers = ordersWithUsers.Select(o => o.OrderId).ToList();
            var userDict = ordersWithUsers.ToDictionary(o => o.OrderId, o => o.User);

            // Create base query for unassigned rent orders with customer names
            var unassignedRentOrdersQuery = _unitOfWork.Repository<RentOrder>()
                .AsQueryable(r => r.ExpectedReturnDate.Date <= today &&
                                  r.ActualReturnDate == null &&
                                  !r.IsDelete &&
                                  orderIdsWithCustomers.Contains(r.OrderId))
                .OrderBy(r => r.OrderId);

            // Get total count for pagination
            var totalCount = await unassignedRentOrdersQuery.CountAsync();

            // Get the IDs for this page
            var unassignedOrderIds = await unassignedRentOrdersQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(r => r.OrderId)
                .ToListAsync();

            // If no orders found, return empty result
            if (!unassignedOrderIds.Any())
            {
                return new PagedResult<RentOrderDetailResponse>
                {
                    Items = new List<RentOrderDetailResponse>(),
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            // Load rent orders
            var rentOrders = await _unitOfWork.Repository<RentOrder>()
                .AsQueryable(r => unassignedOrderIds.Contains(r.OrderId))
                .ToListAsync();

            var rentOrderDict = rentOrders.ToDictionary(r => r.OrderId);

            // Load all details with hotpot information in a single query
            var details = await _unitOfWork.Repository<RentOrderDetail>()
                .AsQueryable(d => unassignedOrderIds.Contains(d.OrderId) && !d.IsDelete)
                .Include(d => d.HotpotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .ToListAsync();

            var detailsByOrderId = details.GroupBy(d => d.OrderId)
                                         .ToDictionary(g => g.Key, g => g.ToList());

            // Map to DTOs
            var dtoItems = new List<RentOrderDetailResponse>();

            foreach (var orderId in unassignedOrderIds)
            {
                // Get rent order
                if (!rentOrderDict.TryGetValue(orderId, out var rentOrder))
                    continue;

                // Get user (we already filtered for orders with users)
                userDict.TryGetValue(orderId, out var user);

                // Create response object for this order
                var response = new RentOrderDetailResponse
                {
                    OrderId = rentOrder.OrderId,
                    RentalStartDate = rentOrder.RentalStartDate.ToString("yyyy-MM-dd"),
                    ExpectedReturnDate = rentOrder.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                    ActualReturnDate = rentOrder.ActualReturnDate?.ToString("yyyy-MM-dd"),
                    Status = rentOrder.ActualReturnDate.HasValue ? "Returned" : "Pending",
                    CustomerName = user?.Name ?? "Unknown",
                    CustomerAddress = user?.Address ?? "Unknown",
                    CustomerPhone = user?.PhoneNumber ?? "Unknown",
                    Notes = rentOrder.RentalNotes,
                    EquipmentItems = new List<EquipmentItem>()
                };

                // Get details
                detailsByOrderId.TryGetValue(orderId, out var orderDetails);

                // If no details, add a placeholder equipment item
                if (orderDetails == null || !orderDetails.Any())
                {
                    response.EquipmentItems.Add(new EquipmentItem
                    {
                        DetailId = 0,
                        Type = "Unknown",
                        Id = 0,
                        Name = "No Equipment"
                    });
                }
                else
                {
                    // Add each equipment item
                    foreach (var detail in orderDetails)
                    {
                        response.EquipmentItems.Add(new EquipmentItem
                        {
                            DetailId = detail.RentOrderDetailId,
                            Type = detail.HotpotInventoryId.HasValue ? "Hotpot" : "Unknown",
                            Id = detail.HotpotInventoryId ?? 0,
                            Name = detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null
                                ? detail.HotpotInventory.Hotpot.Name
                                : "Unknown Equipment"
                        });
                    }
                }

                dtoItems.Add(response);
            }

            return new PagedResult<RentOrderDetailResponse>
            {
                Items = dtoItems,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<RentOrderDetailResponse> GetOrderDetailAsync(int rentOrderDetailId)
        {
            // Get the rent order detail with related entities
            var rentOrderDetail = await _unitOfWork.Repository<RentOrderDetail>()
                .AsQueryable(d => d.RentOrderDetailId == rentOrderDetailId && !d.IsDelete)
                .Include(d => d.HotpotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .FirstOrDefaultAsync();

            if (rentOrderDetail == null)
                throw new NotFoundException($"Rent order detail with ID {rentOrderDetailId} not found");

            // Get the associated rent order
            var rentOrder = await _unitOfWork.Repository<RentOrder>()
                .AsQueryable(r => r.OrderId == rentOrderDetail.OrderId && !r.IsDelete)
                .FirstOrDefaultAsync();

            if (rentOrder == null)
                throw new NotFoundException($"Rent order with ID {rentOrderDetail.OrderId} not found");

            // Get customer information
            var order = await _unitOfWork.Repository<Order>()
                .AsQueryable(o => o.OrderId == rentOrderDetail.OrderId && !o.IsDelete)
                .Include(o => o.User)
                .FirstOrDefaultAsync();

            // Get all equipment items for this order
            var allOrderDetails = await _unitOfWork.Repository<RentOrderDetail>()
                .AsQueryable(d => d.OrderId == rentOrderDetail.OrderId && !d.IsDelete)
                .Include(d => d.HotpotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .ToListAsync();

            // Map to response DTO
            var response = new RentOrderDetailResponse
            {
                OrderId = rentOrderDetail.OrderId,
                RentalStartDate = rentOrder.RentalStartDate.ToString("yyyy-MM-dd"),
                ExpectedReturnDate = rentOrder.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                ActualReturnDate = rentOrder.ActualReturnDate?.ToString("yyyy-MM-dd"),
                Status = rentOrder.ActualReturnDate.HasValue ? "Returned" : "Pending",
                CustomerName = order?.User?.Name ?? "Unknown",
                CustomerAddress = order?.Address ?? order?.User?.Address ?? "Unknown",
                CustomerPhone = order?.User?.PhoneNumber ?? "Unknown",
                Notes = rentOrder.RentalNotes,
                EquipmentItems = new List<EquipmentItem>()
            };

            // Add all equipment items for this order
            foreach (var detail in allOrderDetails)
            {
                response.EquipmentItems.Add(new EquipmentItem
                {
                    DetailId = detail.RentOrderDetailId,
                    Type = detail.HotpotInventoryId.HasValue ? "Hotpot" : "Unknown",
                    Id = detail.HotpotInventoryId ?? 0,
                    Name = detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null
                        ? detail.HotpotInventory.Hotpot.Name
                        : "Unknown Equipment"
                });
            }

            return response;
        }

        public async Task<List<RentOrderDetailDto>> GetPendingPickupsByUserAsync(int userId)
        {
            // Verify the user exists
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == userId && !u.IsDelete);

            if (user == null)
                throw new NotFoundException($"User with ID {userId} not found");

            // Get all rent orders for this user that are due for return
            var today = DateTime.Today;

            var pendingRentOrders = await _unitOfWork.Repository<RentOrder>()
                .AsQueryable(r => r.Order.UserId == userId &&
                                r.ExpectedReturnDate.Date <= today &&
                                r.ActualReturnDate == null &&
                                !r.IsDelete)
                .Include(r => r.Order)
                    .ThenInclude(o => o.User)
                .Include(r => r.RentOrderDetails)
                    .ThenInclude(d => d.HotpotInventory)
                        .ThenInclude(h => h != null ? h.Hotpot : null)
                .ToListAsync();

            // Map to DTOs
            var pendingPickupDtos = pendingRentOrders
                .SelectMany(rentOrder => rentOrder.RentOrderDetails
                    .Where(d => !d.IsDelete)
                    .Select(detail => new RentOrderDetailDto
                    {
                        RentOrderDetailId = detail.RentOrderDetailId,
                        OrderId = detail.OrderId,
                        HotpotInventoryId = detail.HotpotInventoryId,
                        Quantity = detail.Quantity,
                        RentalPrice = detail.RentalPrice,
                        ExpectedReturnDate = rentOrder.ExpectedReturnDate,
                        ActualReturnDate = rentOrder.ActualReturnDate,
                        LateFee = rentOrder.LateFee,
                        DamageFee = rentOrder.DamageFee,
                        CustomerName = rentOrder.Order?.User?.Name,
                        CustomerAddress = rentOrder.Order?.User?.Address,
                    }))
                .ToList();

            return pendingPickupDtos;
        }

        public async Task<IEnumerable<RentalHistoryItem>> GetRentalHistoryByUserAsync(int? userId = null)
        {
            try
            {
                // If userId has a value, check if user exists
                if (userId.HasValue)
                {
                    var user = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == userId.Value && !u.IsDelete);
                    if (user == null)
                        throw new NotFoundException($"User with ID {userId.Value} not found");
                }

                IQueryable<RentOrderDetail> query = _unitOfWork.Repository<RentOrderDetail>().AsQueryable();

                if (userId.HasValue)
                {
                    // Get all orders for this user
                    var orderIds = await _unitOfWork.Repository<Order>()
                        .AsQueryable(o => o.UserId == userId.Value && !o.IsDelete)
                        .Select(o => o.OrderId)
                        .ToListAsync();

                    // Filter rent order details for these orders
                    query = query.Where(r => orderIds.Contains(r.OrderId) && !r.IsDelete);
                }
                else
                {
                    // Get all non-deleted rent order details
                    query = query.Where(r => !r.IsDelete);
                }

                var rentOrderDetails = await query
                    .Include(r => r.RentOrder)
                        .ThenInclude(o => o.Order)
                        .ThenInclude(o => o.User)
                    .Include(r => r.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .OrderByDescending(r => r.RentOrder.RentalStartDate)
                    .ToListAsync();

                // Map to the DTO that matches the frontend interface
                return rentOrderDetails.Select(r => new RentalHistoryItem
                {
                    Id = r.RentOrderDetailId,
                    OrderId = r.OrderId,
                    CustomerName = r.RentOrder.Order?.User?.Name ?? "Unknown",
                    EquipmentName = r.HotpotInventory?.Hotpot?.Name ?? "Unknown",
                    RentalStartDate = r.RentOrder.RentalStartDate.ToString("yyyy-MM-dd"),
                    ExpectedReturnDate = r.RentOrder.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                    ActualReturnDate = r.RentOrder.ActualReturnDate?.ToString("yyyy-MM-dd"),
                    Status = DetermineRentalStatus(r)
                });
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rental history for user {UserId}", userId);
                throw;
            }
        }

        public async Task<bool> ExtendRentalPeriodAsync(int orderId, DateTime newExpectedReturnDate)
        {
            return await _unitOfWork.ExecuteInTransactionAsync<bool>(async () =>
            {
                var rentOrder = await _equipmentReturnService.GetRentOrderAsync(orderId);

                // Validate request
                if (rentOrder.ActualReturnDate.HasValue)
                    throw new ValidationException("Cannot extend a rental that has already been returned");

                if (newExpectedReturnDate <= rentOrder.ExpectedReturnDate)
                    throw new ValidationException("New expected return date must be after the current expected return date");

                // Calculate additional rental fee
                var additionalDays = (newExpectedReturnDate - rentOrder.ExpectedReturnDate).Days;

                // Calculate daily rate based on total rental price
                decimal totalRentalPrice = rentOrder.RentOrderDetails
                    .Where(d => !d.IsDelete)
                    .Sum(d => d.RentalPrice);

                var dailyRate = totalRentalPrice / (rentOrder.ExpectedReturnDate - rentOrder.RentalStartDate).Days;
                var additionalFee = additionalDays * dailyRate;

                // Update expected return date
                rentOrder.ExpectedReturnDate = newExpectedReturnDate;

                // Update rental notes
                rentOrder.RentalNotes = string.IsNullOrEmpty(rentOrder.RentalNotes)
                    ? $"Rental period extended by {additionalDays} days on {DateTime.UtcNow.AddHours(7)}"
                    : $"{rentOrder.RentalNotes}\nRental period extended by {additionalDays} days on {DateTime.UtcNow.AddHours(7)}";

                // Update subtotal
                rentOrder.SubTotal += additionalFee;

                rentOrder.SetUpdateDate();
                await _unitOfWork.Repository<RentOrder>().UpdateDetached(rentOrder);

                // Update order total price
                var order = await _unitOfWork.Repository<Order>().GetById(rentOrder.OrderId);
                if (order != null)
                {
                    order.TotalPrice += additionalFee;
                    order.SetUpdateDate();
                    await _unitOfWork.Repository<Order>().UpdateDetached(order);
                }

                await _unitOfWork.CommitAsync();

                return true;
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error extending rental period for rent order {OrderId}", orderId);
                }
            });
        }
        private RentalListingDto MapToGroupedRentalListingDto(RentOrder rentOrder)
        {
            var dto = new RentalListingDto
            {
                OrderId = rentOrder.OrderId,
                RentalStartDate = rentOrder.RentalStartDate,
                ExpectedReturnDate = rentOrder.ExpectedReturnDate,
                ActualReturnDate = rentOrder.ActualReturnDate,
                CustomerName = rentOrder.Order?.User?.Name ?? "Unknown",
                CustomerAddress = rentOrder.Order?.Address ?? rentOrder.Order?.User?.Address ?? "Unknown",
                CustomerPhone = rentOrder.Order?.User?.PhoneNumber ?? "Unknown",
                LateFee = rentOrder.LateFee,
                DamageFee = rentOrder.DamageFee,
                EquipmentItems = new List<RentalEquipmentItem>()
            };

            // Add equipment items
            if (rentOrder.RentOrderDetails != null)
            {
                foreach (var detail in rentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    dto.EquipmentItems.Add(new RentalEquipmentItem
                    {
                        RentOrderDetailId = detail.RentOrderDetailId,
                        EquipmentType = detail.HotpotInventoryId.HasValue ? "Hotpot" : "Unknown",
                        EquipmentName = detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null
                            ? detail.HotpotInventory.Hotpot.Name
                            : "Unknown Equipment",
                        Quantity = detail.Quantity,
                    });
                }
            }

            return dto;
        }
        private string DetermineRentalStatus(RentOrderDetail rentOrderDetail)
        {
            if (rentOrderDetail.RentOrder.ActualReturnDate.HasValue)
            {
                return "Returned";
            }
            else if (DateTime.UtcNow.AddHours(7) > rentOrderDetail.RentOrder.ExpectedReturnDate)
            {
                return "Overdue";
            }
            else if (rentOrderDetail.RentOrder.RentalStartDate > DateTime.UtcNow.AddHours(7))
            {
                return "Scheduled";
            }
            else
            {
                return "Active"; // Default case if none of the above conditions are met
            }
        }

    }
}

