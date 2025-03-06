using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<PagedResult<Order>> GetAllPagedAsync(int pageNumber, int pageSize);
        Task<PagedResult<Order>> GetUserOrdersPagedAsync(int userId, int pageNumber, int pageSize);
        Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
        Task<Order> UpdateStatusAsync(int id, OrderStatus status);
        Task<decimal> CalculateTotalPriceAsync(ICollection<OrderDetail> orderDetails, int? discountId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<PagedResult<Order>> GetOrdersByStatusPagedAsync(OrderStatus status, int pageNumber, int pageSize);
        Task<OrderStatistics> GetOrderStatisticsAsync(DateTime? startDate = null, DateTime? endDate = null);
    }
}
