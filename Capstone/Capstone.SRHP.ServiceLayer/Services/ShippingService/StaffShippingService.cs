using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.ShippingService
{
    public class StaffShippingService : IStaffShippingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StaffShippingService> _logger;

        public StaffShippingService(
            IUnitOfWork unitOfWork,
            ILogger<StaffShippingService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<ShippingListDto>> GetShippingListAsync(int staffId)
        {
            try
            {
                _logger.LogInformation("Getting shipping list for staff ID: {StaffId}", staffId);

                // Use the generic repository through unit of work to query shipping orders
                var shippingOrdersQuery = _unitOfWork.Repository<ShippingOrder>()
                    .AsQueryable()
                    .Where(so => so.StaffID == staffId)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.User)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.OrderDetails);

                var shippingOrders = await shippingOrdersQuery.ToListAsync();
                return shippingOrders.Select(MapToShippingListDto).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving shipping list for staff ID: {StaffId}", staffId);
                throw;
            }
        }

        public async Task<ShippingListDto> GetShippingDetailAsync(int shippingOrderId)
        {
            try
            {
                _logger.LogInformation("Getting shipping detail for ID: {ShippingOrderId}", shippingOrderId);

                // Use the generic repository through unit of work to query a specific shipping order with details
                var shippingOrderQuery = _unitOfWork.Repository<ShippingOrder>()
                    .AsQueryable()
                    .Where(so => so.ShippingOrderId == shippingOrderId)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.User)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.OrderDetails)
                            .ThenInclude(od => od.Utensil)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.OrderDetails)
                            .ThenInclude(od => od.Ingredient)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.OrderDetails)
                        .ThenInclude(od => od.HotpotInventory)
                        .ThenInclude(hi => hi.Hotpot)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.OrderDetails)
                            .ThenInclude(od => od.Customization)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.OrderDetails)
                            .ThenInclude(od => od.Combo);

                var shippingOrder = await shippingOrderQuery.FirstOrDefaultAsync();

                if (shippingOrder == null)
                {
                    throw new NotFoundException($"Shipping order with ID {shippingOrderId} not found");
                }

                return MapToShippingListDto(shippingOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving shipping detail for ID: {ShippingOrderId}", shippingOrderId);
                throw;
            }
        }

        public async Task<IEnumerable<ShippingListDto>> GetPendingShippingListAsync(int staffId)
        {
            try
            {
                _logger.LogInformation("Getting pending shipping list for staff ID: {StaffId}", staffId);

                // Use the generic repository through unit of work to query pending shipping orders
                var pendingShippingOrdersQuery = _unitOfWork.Repository<ShippingOrder>()
                    .AsQueryable()
                    .Where(so => so.StaffID == staffId && !so.IsDelivered)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.User)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.OrderDetails)
                    .OrderBy(so => so.DeliveryTime);

                var pendingShippingOrders = await pendingShippingOrdersQuery.ToListAsync();
                return pendingShippingOrders.Select(MapToShippingListDto).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving pending shipping list for staff ID: {StaffId}", staffId);
                throw;
            }
        }

        public async Task<ShippingListDto> UpdateDeliveryNotesAsync(int shippingOrderId, string notes)
        {
            try
            {
                _logger.LogInformation("Updating delivery notes for shipping order ID: {ShippingOrderId}", shippingOrderId);

                // Find the shipping order
                var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .FindAsync(so => so.ShippingOrderId == shippingOrderId);

                if (shippingOrder == null)
                {
                    throw new NotFoundException($"Shipping order with ID {shippingOrderId} not found");
                }

                // Update the notes
                shippingOrder.DeliveryNotes = notes;

                // Save changes
                await _unitOfWork.CommitAsync();

                // Fetch the updated shipping order with all details
                return await GetShippingDetailAsync(shippingOrderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating delivery notes for shipping order ID: {ShippingOrderId}", shippingOrderId);
                throw;
            }
        }

        // Helper method to map ShippingOrder entity to ShippingListDto
        private ShippingListDto MapToShippingListDto(ShippingOrder shippingOrder)
        {
            if (shippingOrder == null) return null;

            var dto = new ShippingListDto
            {
                ShippingOrderId = shippingOrder.ShippingOrderId,
                OrderID = shippingOrder.OrderID,
                DeliveryTime = shippingOrder.DeliveryTime,
                DeliveryNotes = shippingOrder.DeliveryNotes ?? string.Empty,
                IsDelivered = shippingOrder.IsDelivered,
                DeliveryAddress = shippingOrder.Order?.Address ?? string.Empty,
                CustomerName = shippingOrder.Order?.User?.Name ?? "Unknown",
                CustomerPhone = shippingOrder.Order?.User?.PhoneNumber ?? "Unknown",
                OrderStatus = shippingOrder.Order?.Status.ToString() ?? "Unknown",
                TotalPrice = shippingOrder.Order?.TotalPrice ?? 0,
                Items = new List<ShippingItemDto>()
            };

            // Map order details to shipping items
            if (shippingOrder.Order?.OrderDetails != null)
            {
                foreach (var detail in shippingOrder.Order.OrderDetails)
                {
                    string itemName = "Unknown";
                    string itemType = "Unknown";

                    if (detail.Utensil != null)
                    {
                        itemName = detail.Utensil.Name;
                        itemType = "Utensil";
                    }
                    else if (detail.Ingredient != null)
                    {
                        itemName = detail.Ingredient.Name;
                        itemType = "Ingredient";
                    }
                    else if (detail.HotpotInventory != null)
                    {
                        itemName = detail.HotpotInventory.Hotpot.Name;
                        itemType = "Hotpot";
                    }
                    else if (detail.Customization != null)
                    {
                        itemName = detail.Customization.Name;
                        itemType = "Customization";
                    }
                    else if (detail.Combo != null)
                    {
                        itemName = detail.Combo.Name;
                        itemType = "Combo";
                    }

                    dto.Items.Add(new ShippingItemDto
                    {
                        OrderDetailId = detail.OrderDetailId,
                        ItemName = itemName,
                        ItemType = itemType,
                        Quantity = detail.Quantity
                    });
                }
            }

            return dto;
        }

        public async Task<ProofOfDeliveryResponse> SaveProofOfDeliveryAsync(int shippingOrderId, ProofOfDeliveryRequest request)
        {
            try
            {
                _logger.LogInformation("Saving proof of delivery for shipping order ID: {ShippingOrderId}", shippingOrderId);

                // Find the shipping order
                var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .FindAsync(so => so.ShippingOrderId == shippingOrderId);

                if (shippingOrder == null)
                {
                    throw new NotFoundException($"Shipping order with ID {shippingOrderId} not found");
                }

                // Update the shipping order with proof of delivery data
                if (!string.IsNullOrEmpty(request.Base64Image))
                {
                    shippingOrder.ProofImage = Convert.FromBase64String(request.Base64Image);
                    shippingOrder.ProofImageType = request.ImageType ?? "image/jpeg";
                }

                if (!string.IsNullOrEmpty(request.Base64Signature))
                {
                    shippingOrder.SignatureData = Convert.FromBase64String(request.Base64Signature);
                }

                if (!string.IsNullOrEmpty(request.DeliveryNotes))
                {
                    shippingOrder.DeliveryNotes = request.DeliveryNotes;
                }

                // Mark as delivered and set timestamps
                shippingOrder.IsDelivered = true;
                shippingOrder.ProofTimestamp = DateTime.UtcNow;

                if (shippingOrder.DeliveryTime == null)
                {
                    shippingOrder.DeliveryTime = DateTime.UtcNow;
                }

                // Save changes
                await _unitOfWork.CommitAsync();

                // Return response
                return new ProofOfDeliveryResponse
                {
                    ShippingOrderId = shippingOrder.ShippingOrderId,
                    IsDelivered = shippingOrder.IsDelivered,
                    DeliveryTime = shippingOrder.DeliveryTime,
                    ProofTimestamp = shippingOrder.ProofTimestamp,
                    DeliveryNotes = shippingOrder.DeliveryNotes,
                    HasProofImage = shippingOrder.ProofImage != null && shippingOrder.ProofImage.Length > 0,
                    HasSignature = shippingOrder.SignatureData != null && shippingOrder.SignatureData.Length > 0
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving proof of delivery for shipping order ID: {ShippingOrderId}", shippingOrderId);
                throw;
            }
        }

        public async Task<ProofOfDeliveryDto> GetProofOfDeliveryAsync(int shippingOrderId)
        {
            try
            {
                _logger.LogInformation("Getting proof of delivery for shipping order ID: {ShippingOrderId}", shippingOrderId);

                // Find the shipping order
                var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .FindAsync(so => so.ShippingOrderId == shippingOrderId);

                if (shippingOrder == null)
                {
                    throw new NotFoundException($"Shipping order with ID {shippingOrderId} not found");
                }

                // Check if proof of delivery exists
                if (shippingOrder.ProofImage == null && shippingOrder.SignatureData == null)
                {
                    throw new NotFoundException($"No proof of delivery found for shipping order with ID {shippingOrderId}");
                }

                // Convert binary data to base64 strings
                string? base64Image = null;
                string? base64Signature = null;

                if (shippingOrder.ProofImage != null && shippingOrder.ProofImage.Length > 0)
                {
                    base64Image = Convert.ToBase64String(shippingOrder.ProofImage);
                }

                if (shippingOrder.SignatureData != null && shippingOrder.SignatureData.Length > 0)
                {
                    base64Signature = Convert.ToBase64String(shippingOrder.SignatureData);
                }

                // Return DTO
                return new ProofOfDeliveryDto
                {
                    ShippingOrderId = shippingOrder.ShippingOrderId,
                    Base64Image = base64Image,
                    ImageType = shippingOrder.ProofImageType,
                    Base64Signature = base64Signature,
                    DeliveryNotes = shippingOrder.DeliveryNotes,
                    ProofTimestamp = shippingOrder.ProofTimestamp
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting proof of delivery for shipping order ID: {ShippingOrderId}", shippingOrderId);
                throw;
            }
        }

    }
}
