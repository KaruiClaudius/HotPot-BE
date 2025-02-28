using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.StaffService
{
    public interface IStaffOrderService
    {
        Task<IEnumerable<Order>> GetAssignedOrdersAsync(int staffId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<Order> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, string notes);
        Task<Order> CancelOrderAsync(int orderId, string cancellationReason);
        Task<PagedResult<Order>> GetOrderHistoryAsync(int pageNumber, int pageSize, OrderStatus? status = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<Order> GetOrderWithDetailsAsync(int orderId);
    }

}
