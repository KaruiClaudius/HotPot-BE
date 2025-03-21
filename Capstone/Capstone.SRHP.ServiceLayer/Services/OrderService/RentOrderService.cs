using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
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

        public async Task<IEnumerable<RentOrderDetail>> GetByOrderIdAsync(int orderId)
        {
            try
            {
                // Check if order exists
                var order = await _unitOfWork.Repository<Order>()
                    .FindAsync(o => o.OrderId == orderId && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                return await _unitOfWork.Repository<RentOrderDetail>()
                    .AsQueryable(r => r.OrderId == orderId && !r.IsDelete)
                    .Include(r => r.Utensil)
                    .Include(r => r.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .ToListAsync();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rent order details for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<PagedResult<RentalListingDto>> GetPendingPickupsAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var today = DateTime.Today;

                var query = _unitOfWork.Repository<RentOrderDetail>()
                    .AsQueryable(r => r.ExpectedReturnDate.Date == today && r.ActualReturnDate == null && !r.IsDelete)
                    .Include(r => r.Order)
                        .ThenInclude(o => o.User)
                    .Include(r => r.Utensil)
                    .Include(r => r.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null);

                // Get total count before applying pagination
                var totalCount = await query.CountAsync();

                // Apply pagination
                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to DTOs
                var dtos = items.Select(MapToRentalListingDto).ToList();

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

                var query = _unitOfWork.Repository<RentOrderDetail>()
                    .AsQueryable(r => r.ExpectedReturnDate.Date < today && r.ActualReturnDate == null && !r.IsDelete)
                    .Include(r => r.Order)
                        .ThenInclude(o => o.User)
                    .Include(r => r.Utensil)
                    .Include(r => r.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null);

                // Get total count before applying pagination
                var totalCount = await query.CountAsync();

                // Apply pagination
                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to DTOs
                var dtos = items.Select(MapToRentalListingDto).ToList();

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

        // Helper method to map RentOrderDetail to DTO

        public async Task<List<RentOrderDetailDto>> GetPendingPickupsByUserAsync(int userId)
        {
            // Verify the user exists
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == userId && !u.IsDelete);

            if (user == null)
                throw new NotFoundException($"User with ID {userId} not found");

            // Get all rent order details for this user that are due for return
            var today = DateTime.Today;

            var pendingPickups = await _unitOfWork.Repository<RentOrderDetail>()
                .AsQueryable(r => r.Order.UserId == userId &&
                                 r.ExpectedReturnDate.Date <= today &&
                                 r.ActualReturnDate == null &&
                                 !r.IsDelete)
                .Include(r => r.Order)
                    .ThenInclude(o => o.User)
                .Include(r => r.Utensil)
                .Include(r => r.HotpotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .ToListAsync();

            // Map to DTOs
            var pendingPickupDtos = pendingPickups.Select(p => new RentOrderDetailDto
            {
                RentOrderDetailId = p.RentOrderDetailId,
                OrderId = p.OrderId,
                UtensilId = p.UtensilId,
                HotpotInventoryId = p.HotpotInventoryId,
                Quantity = p.Quantity,
                RentalPrice = p.RentalPrice,
                ExpectedReturnDate = p.ExpectedReturnDate,
                ActualReturnDate = p.ActualReturnDate,
                LateFee = p.LateFee,
                DamageFee = p.DamageFee,
                CustomerName = p.Order?.User?.Name,
                CustomerAddress = p.Order?.User?.Address,
                // Check if there's an active pickup assignment              
            }).ToList();

            return pendingPickupDtos;
        }

        public async Task<bool> UpdateRentOrderDetailAsync(int rentOrderDetailId, UpdateRentOrderDetailRequest request)
        {
            return await _unitOfWork.ExecuteInTransactionAsync<bool>(async () =>
            {
                var rentOrderDetail = await _equipmentReturnService.GetRentOrderDetailAsync(rentOrderDetailId);

                // Validate request
                if (rentOrderDetail.ActualReturnDate.HasValue)
                    throw new ValidationException("Cannot update a rental that has already been returned");

                // Update expected return date if provided
                if (!string.IsNullOrEmpty(request.ExpectedReturnDate))
                {
                    if (DateTime.TryParse(request.ExpectedReturnDate, out DateTime parsedDate))
                    {
                        // Ensure expected return date is not before rental start date
                        if (parsedDate < rentOrderDetail.RentalStartDate)
                            throw new ValidationException("Expected return date cannot be before rental start date");

                        rentOrderDetail.ExpectedReturnDate = parsedDate;
                    }
                    else
                    {
                        throw new ValidationException("Invalid date format for expected return date");
                    }
                }

                // Update notes if provided
                if (request.Notes != null)  // Allow empty string to clear notes
                {
                    rentOrderDetail.RentalNotes = request.Notes;
                }

                rentOrderDetail.SetUpdateDate();
                await _unitOfWork.Repository<RentOrderDetail>().UpdateDetached(rentOrderDetail);


                await _unitOfWork.CommitAsync();
                return true;
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error updating rent order detail {RentOrderDetailId}", rentOrderDetailId);
                }
            });
        }
        
        public async Task<decimal> CalculateLateFeeAsync(int rentOrderDetailId, DateTime actualReturnDate)
        {
            try
            {
                var rentOrderDetail = await _equipmentReturnService.GetRentOrderDetailAsync(rentOrderDetailId);

                if (actualReturnDate <= rentOrderDetail.ExpectedReturnDate)
                    return 0; // No late fee

                var daysLate = (actualReturnDate - rentOrderDetail.ExpectedReturnDate).Days;

                // Calculate late fee as 10% of rental price per day late
                return daysLate * (rentOrderDetail.RentalPrice * 0.1m);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating late fee for rent order detail {RentOrderDetailId}", rentOrderDetailId);
                throw;
            }
        }

        public async Task<IEnumerable<RentalHistoryItem>> GetRentalHistoryByEquipmentAsync(int? utensilId = null, int? hotpotInventoryId = null)
        {
            try
            {
                if (!utensilId.HasValue && !hotpotInventoryId.HasValue)
                    throw new ValidationException("Either utensilId or hotpotInventoryId must be provided");

                IQueryable<RentOrderDetail> query = _unitOfWork.Repository<RentOrderDetail>().AsQueryable();

                if (utensilId.HasValue)
                {
                    query = query.Where(r => r.UtensilId == utensilId.Value && !r.IsDelete);
                }
                else if (hotpotInventoryId.HasValue)
                {
                    query = query.Where(r => r.HotpotInventoryId == hotpotInventoryId.Value && !r.IsDelete);
                }

                var rentOrderDetails = await query
                    .Include(r => r.Order)
                        .ThenInclude(o => o.User)
                    .Include(r => r.Utensil)
                    .Include(r => r.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .OrderByDescending(r => r.RentalStartDate)
                    .ToListAsync();

                // Map to the DTO that matches the frontend interface
                return rentOrderDetails.Select(r => new RentalHistoryItem
                {
                    Id = r.RentOrderDetailId,
                    OrderId = r.OrderId,
                    CustomerName = r.Order?.User?.Name ?? "Unknown",
                    EquipmentName = r.Utensil?.Name ?? r.HotpotInventory?.Hotpot?.Name ?? "Unknown",
                    RentalStartDate = r.RentalStartDate.ToString("yyyy-MM-dd"),
                    ExpectedReturnDate = r.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                    ActualReturnDate = r.ActualReturnDate?.ToString("yyyy-MM-dd"),
                    Status = DetermineRentalStatus(r)
                });
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rental history for equipment");
                throw;
            }
        }

        public async Task<IEnumerable<RentalHistoryItem>> GetRentalHistoryByUserAsync(int userId)
        {
            try
            {
                // Check if user exists
                var user = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == userId && !u.IsDelete);
                if (user == null)
                    throw new NotFoundException($"User with ID {userId} not found");

                // Get all orders for this user
                var orderIds = await _unitOfWork.Repository<Order>()
                    .AsQueryable(o => o.UserId == userId && !o.IsDelete)
                    .Select(o => o.OrderId)
                    .ToListAsync();

                // Get all rent order details for these orders
                var rentOrderDetails = await _unitOfWork.Repository<RentOrderDetail>()
                    .AsQueryable(r => orderIds.Contains(r.OrderId) && !r.IsDelete)
                    .Include(r => r.Order)
                        .ThenInclude(o => o.User)
                    .Include(r => r.Utensil)
                    .Include(r => r.HotpotInventory)
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .OrderByDescending(r => r.RentalStartDate)
                    .ToListAsync();

                // Map to the DTO that matches the frontend interface
                return rentOrderDetails.Select(r => new RentalHistoryItem
                {
                    Id = r.RentOrderDetailId,
                    OrderId = r.OrderId,
                    CustomerName = r.Order?.User?.Name ?? "Unknown",
                    EquipmentName = r.Utensil?.Name ?? r.HotpotInventory?.Hotpot?.Name ?? "Unknown",
                    RentalStartDate = r.RentalStartDate.ToString("yyyy-MM-dd"),
                    ExpectedReturnDate = r.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                    ActualReturnDate = r.ActualReturnDate?.ToString("yyyy-MM-dd"),
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

        public async Task<bool> ExtendRentalPeriodAsync(int rentOrderDetailId, DateTime newExpectedReturnDate)
        {
            return await _unitOfWork.ExecuteInTransactionAsync<bool>(async () =>
            {
                var rentOrderDetail = await _equipmentReturnService.GetRentOrderDetailAsync(rentOrderDetailId);

                // Validate request
                if (rentOrderDetail.ActualReturnDate.HasValue)
                    throw new ValidationException("Cannot extend a rental that has already been returned");

                if (newExpectedReturnDate <= rentOrderDetail.ExpectedReturnDate)
                    throw new ValidationException("New expected return date must be after the current expected return date");

                // Calculate additional rental fee
                var additionalDays = (newExpectedReturnDate - rentOrderDetail.ExpectedReturnDate).Days;
                var dailyRate = rentOrderDetail.RentalPrice / (rentOrderDetail.ExpectedReturnDate - rentOrderDetail.RentalStartDate).Days;
                var additionalFee = additionalDays * dailyRate;

                // Update expected return date
                rentOrderDetail.ExpectedReturnDate = newExpectedReturnDate;
                rentOrderDetail.RentalPrice += additionalFee; // Add additional fee to rental price
                rentOrderDetail.RentalNotes = string.IsNullOrEmpty(rentOrderDetail.RentalNotes)
                    ? $"Rental period extended by {additionalDays} days on {DateTime.Now}"
                    : $"{rentOrderDetail.RentalNotes}\nRental period extended by {additionalDays} days on {DateTime.Now}";

                rentOrderDetail.SetUpdateDate();
                await _unitOfWork.Repository<RentOrderDetail>().UpdateDetached(rentOrderDetail);

                // Update order total price
                var order = await _unitOfWork.Repository<Order>().GetById(rentOrderDetail.OrderId);
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
                _logger.LogError(ex, "Error extending rental period for rent order detail {RentOrderDetailId}", rentOrderDetailId);
            }
        });
        }

        public async Task<PagedResult<RentOrderDetailResponse>> GetUnassignedPickupsAsync(int pageNumber = 1, int pageSize = 10)
        {
            var today = DateTime.Today;

            // Get all rent order details that are due for pickup today or overdue
            var pendingPickupsQuery = _unitOfWork.Repository<RentOrderDetail>()
                .AsQueryable(r => r.ExpectedReturnDate.Date <= today && r.ActualReturnDate == null && !r.IsDelete)
                .Include(r => r.Order)
                    .ThenInclude(o => o.User)
                .Include(r => r.Utensil)
                .Include(r => r.HotpotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null);

            // Get all rent order details that are already assigned
            var assignedPickupIds = await _unitOfWork.Repository<StaffPickupAssignment>()
                .AsQueryable(a => a.CompletedDate == null)
                .Select(a => a.RentOrderDetailId)
                .ToListAsync();

            // Filter out the assigned pickups
            var unassignedPickupsQuery = pendingPickupsQuery.Where(p => !assignedPickupIds.Contains(p.RentOrderDetailId));

            // Get total count before applying pagination
            var totalCount = await unassignedPickupsQuery.CountAsync();

            // Apply pagination
            var items = await unassignedPickupsQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to DTOs
            var dtoItems = items.Select(item => new RentOrderDetailResponse
            {
                Id = item.RentOrderDetailId,
                OrderId = item.OrderId,
                EquipmentType = item.HotpotInventoryId.HasValue ? "Hotpot" : "Utensil",
                EquipmentId = item.HotpotInventoryId ?? item.UtensilId ?? 0,
                EquipmentName = item.HotpotInventoryId.HasValue
                    ? item.HotpotInventory?.Hotpot?.Name
                    : item.Utensil?.Name,
                RentalStartDate = item.RentalStartDate.ToString("yyyy-MM-dd"),
                ExpectedReturnDate = item.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                ActualReturnDate = item.ActualReturnDate?.ToString("yyyy-MM-dd"),
                Status = item.ActualReturnDate.HasValue ? "Returned" : "Pending",
                CustomerName = item.Order?.User?.Name,
                CustomerAddress = item.Order?.Address,
                CustomerPhone = item.Order?.User?.PhoneNumber,
                Notes = item.RentalNotes
            }).ToList();

            return new PagedResult<RentOrderDetailResponse>
            {
                Items = dtoItems,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }      

        private string DetermineRentalStatus(RentOrderDetail rentOrderDetail)
        {
            // This is a simple example - you may need to adjust based on your business logic
            if (rentOrderDetail.ActualReturnDate.HasValue)
            {
                return "Returned";
            }
            else if (DateTime.Now > rentOrderDetail.ExpectedReturnDate)
            {
                return "Overdue";
            }
            else if (rentOrderDetail.RentalStartDate > DateTime.Now)
            {
                return "Scheduled";
            }
            else
            {
                return "Active";
            }
        }
        private RentalListingDto MapToRentalListingDto(RentOrderDetail detail)
        {
            return new RentalListingDto
            {
                RentOrderDetailId = detail.RentOrderDetailId,
                OrderId = detail.OrderId,
                EquipmentType = detail.UtensilId.HasValue ? "Utensil" : "Hotpot",
                EquipmentName = detail.UtensilId.HasValue
                    ? detail.Utensil?.Name
                    : detail.HotpotInventory?.Hotpot?.Name,
                Quantity = detail.Quantity,
                RentalPrice = detail.RentalPrice,
                RentalStartDate = detail.RentalStartDate,
                ExpectedReturnDate = detail.ExpectedReturnDate,
                ActualReturnDate = detail.ActualReturnDate,
                CustomerName = detail.Order?.User?.Name,
                CustomerAddress = detail.Order?.User?.Address,
                CustomerPhone = detail.Order?.User?.PhoneNumber,
                LateFee = detail.LateFee,
                DamageFee = detail.DamageFee
            };
        }

    }
}
