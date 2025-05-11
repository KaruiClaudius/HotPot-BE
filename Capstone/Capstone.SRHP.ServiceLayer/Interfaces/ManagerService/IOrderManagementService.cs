using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IOrderManagementService
    {
        // Order allocation
        Task<StaffAssignmentResponse> AssignStaffToOrderAsync(string orderCode, int staffId, StaffTaskType taskType, int? vehicleId = null);
        Task<PagedResult<UnallocatedOrderDTO>> GetUnallocatedOrdersPaged(OrderQueryParams queryParams);
        Task<IEnumerable<StaffShippingOrderDTO>> GetOrdersByStaff(int staffId);

        // Order status tracking
        Task<OrderStatusUpdateDTO> UpdateOrderStatus(string orderCode, OrderStatus status);
        Task<OrderDetailDTO> GetOrderWithDetails(string orderCode);
        Task<PagedResult<OrderWithDetailsDTO>> GetOrdersByStatusPaged(OrderQueryParams queryParams);

        // Delivery progress monitoring
        Task<DeliveryStatusUpdateDTO> UpdateDeliveryStatus(int shippingOrderId, bool isDelivered, string notes = null);
        Task<DeliveryTimeUpdateDTO> UpdateDeliveryTime(int shippingOrderId, DateTime deliveryTime);
        Task<PagedResult<PendingDeliveryDTO>> GetPendingDeliveriesPaged(ShippingOrderQueryParams queryParams);

        // Vehicle related 
        Task<OrderSize> EstimateOrderSizeAsync(string orderCode);
        Task<VehicleType> SuggestVehicleTypeAsync(string orderCode);
    }
}