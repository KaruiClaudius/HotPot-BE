using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<PagedResult<Order>> GetPagedAsync(int pageNumber, int pageSize);
        Task<Order> CreateAsync(CreateOrderRequest request, int userId);
        Task<Order> UpdateStatusAsync(int id, OrderStatus status);

        // User-specific operations
        Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
        Task<PagedResult<Order>> GetUserOrdersPagedAsync(int userId, int pageNumber, int pageSize);

        // Status-specific operations
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<PagedResult<Order>> GetOrdersByStatusPagedAsync(OrderStatus status, int pageNumber, int pageSize);

        // Deposit calculation
        Task<(decimal ingredientsDeposit, decimal hotpotDeposit)> CalculateDepositsAsync(List<OrderItemRequest> items);
    }
}
