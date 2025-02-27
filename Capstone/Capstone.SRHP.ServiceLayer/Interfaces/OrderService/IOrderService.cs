using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
        Task<Order> UpdateStatusAsync(int id, OrderStatus status);
        Task<decimal> CalculateTotalPriceAsync(ICollection<OrderDetail> orderDetails, int? discountId);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
    }
}
