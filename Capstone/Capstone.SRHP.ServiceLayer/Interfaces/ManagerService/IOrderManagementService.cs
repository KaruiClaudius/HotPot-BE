using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IOrderManagementService
    {
        // Order allocation
        Task<ShippingOrder> AllocateOrderToStaff(int orderId, int staffId);
        Task<PagedResult<Order>> GetUnallocatedOrdersPaged(OrderQueryParams queryParams);
        Task<IEnumerable<ShippingOrder>> GetOrdersByStaff(int staffId);

        // Order status tracking
        Task<Order> UpdateOrderStatus(int orderId, OrderStatus status);
        Task<Order> GetOrderWithDetails(int orderId);
        Task<PagedResult<Order>> GetOrdersByStatusPaged(OrderQueryParams queryParams);

        // Delivery progress monitoring
        Task<ShippingOrder> UpdateDeliveryStatus(int shippingOrderId, bool isDelivered, string notes = null);
        Task<ShippingOrder> UpdateDeliveryTime(int shippingOrderId, DateTime deliveryTime);
        Task<PagedResult<ShippingOrder>> GetPendingDeliveriesPaged(ShippingOrderQueryParams queryParams);

        // Reporting
        Task<IEnumerable<Order>> GetOrdersWithAllDetails(DateTime startDate, DateTime endDate, OrderStatus? status = null);

        // Reassignment
        Task<ShippingOrder> ReassignShippingOrder(int shippingOrderId, int newStaffId);
    }
}