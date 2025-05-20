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
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
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
        private readonly ILogger<RentOrderService> _logger;

        public RentOrderService(
            IUnitOfWork unitOfWork,
            ILogger<RentOrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PagedResult<RentalListingDto>> GetPendingPickupsAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var today = DateTime.Today;

                // Query RentOrders directly instead of RentOrderDetails
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
                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to DTOs
                var dtos = items.SelectMany(rentOrder =>
                    rentOrder.RentOrderDetails.Where(d => !d.IsDelete).Select(detail =>
                        MapToRentalListingDto(detail, rentOrder)
                    )
                ).ToList();

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

                // Get details
                detailsByOrderId.TryGetValue(orderId, out var orderDetails);

                // If no details, create one response with order info
                if (orderDetails == null || !orderDetails.Any())
                {
                    dtoItems.Add(new RentOrderDetailResponse
                    {
                        Id = 0,
                        OrderId = rentOrder.OrderId,
                        EquipmentType = "Unknown",
                        EquipmentId = 0,
                        EquipmentName = "No Equipment",
                        RentalStartDate = rentOrder.RentalStartDate.ToString("yyyy-MM-dd"),
                        ExpectedReturnDate = rentOrder.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                        ActualReturnDate = rentOrder.ActualReturnDate?.ToString("yyyy-MM-dd"),
                        Status = rentOrder.ActualReturnDate.HasValue ? "Returned" : "Pending",
                        CustomerName = user?.Name ?? "Unknown",
                        CustomerAddress = user?.Address ?? "Unknown",
                        CustomerPhone = user?.PhoneNumber ?? "Unknown",
                        Notes = rentOrder.RentalNotes
                    });
                    continue;
                }

                // Map each detail
                foreach (var detail in orderDetails)
                {
                    dtoItems.Add(new RentOrderDetailResponse
                    {
                        Id = detail.RentOrderDetailId,
                        OrderId = detail.OrderId,
                        EquipmentType = detail.HotpotInventoryId.HasValue ? "Hotpot" : "Unknown",
                        EquipmentId = detail.HotpotInventoryId ?? 0,
                        EquipmentName = detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null
                            ? detail.HotpotInventory.Hotpot.Name
                            : "Unknown Equipment",
                        RentalStartDate = rentOrder.RentalStartDate.ToString("yyyy-MM-dd"),
                        ExpectedReturnDate = rentOrder.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                        ActualReturnDate = rentOrder.ActualReturnDate?.ToString("yyyy-MM-dd"),
                        Status = rentOrder.ActualReturnDate.HasValue ? "Returned" : "Pending",
                        CustomerName = user?.Name ?? "Unknown",
                        CustomerAddress = user?.Address ?? "Unknown",
                        CustomerPhone = user?.PhoneNumber ?? "Unknown",
                        Notes = rentOrder.RentalNotes
                    });
                }
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

            // Map to response DTO
            var response = new RentOrderDetailResponse
            {
                Id = rentOrderDetail.RentOrderDetailId,
                OrderId = rentOrderDetail.OrderId,
                EquipmentType = rentOrderDetail.HotpotInventoryId.HasValue ? "Hotpot" : "Unknown",
                EquipmentId = rentOrderDetail.HotpotInventoryId ?? 0,
                EquipmentName = rentOrderDetail.HotpotInventoryId.HasValue && rentOrderDetail.HotpotInventory?.Hotpot != null
                    ? rentOrderDetail.HotpotInventory.Hotpot.Name
                    : "Unknown Equipment",
                RentalStartDate = rentOrder.RentalStartDate.ToString("yyyy-MM-dd"),
                ExpectedReturnDate = rentOrder.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                ActualReturnDate = rentOrder.ActualReturnDate?.ToString("yyyy-MM-dd"),
                Status = rentOrder.ActualReturnDate.HasValue ? "Returned" : "Pending",
                CustomerName = order?.User?.Name ?? "Unknown",
                CustomerAddress = order?.Address ?? order?.User?.Address ?? "Unknown",
                CustomerPhone = order?.User?.PhoneNumber ?? "Unknown",
                Notes = rentOrder.RentalNotes
            };

            return response;
        }

        public async Task<PagedResult<RentalListingDto>> GetOverdueRentalsAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var today = DateTime.Today;

                // Query RentOrders directly instead of RentOrderDetails
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
                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to DTOs
                var dtos = items.SelectMany(rentOrder =>
                    rentOrder.RentOrderDetails.Where(d => !d.IsDelete).Select(detail =>
                        MapToRentalListingDto(detail, rentOrder)
                    )
                ).ToList();

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

        private RentalListingDto MapToRentalListingDto(RentOrderDetail detail, RentOrder rentOrder)
        {
            return new RentalListingDto
            {
                RentOrderDetailId = detail.RentOrderDetailId,
                OrderId = detail.OrderId,
                EquipmentType = "Hotpot",
                EquipmentName = detail.HotpotInventory?.Hotpot?.Name,
                Quantity = detail.Quantity,
                RentalPrice = detail.RentalPrice,
                RentalStartDate = rentOrder.RentalStartDate,
                ExpectedReturnDate = rentOrder.ExpectedReturnDate,
                ActualReturnDate = rentOrder.ActualReturnDate,
                CustomerName = rentOrder.Order?.User?.Name,
                CustomerAddress = rentOrder.Order?.User?.Address,
                CustomerPhone = rentOrder.Order?.User?.PhoneNumber,
                LateFee = rentOrder.LateFee,
                DamageFee = rentOrder.DamageFee
            };
        }
    }
}
