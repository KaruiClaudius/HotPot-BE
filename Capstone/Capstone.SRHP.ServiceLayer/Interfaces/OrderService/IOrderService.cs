using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<PagedResult<Order>> GetOrdersAsync(
             string searchTerm = null,
             int? userId = null,
             string status = null,
             DateTime? fromDate = null,
             DateTime? toDate = null,
             decimal? minPrice = null,
             decimal? maxPrice = null,
             bool? hasHotpot = null,
             string paymentStatus = null,
             int pageNumber = 1,
             int pageSize = 10,
             string sortBy = "CreatedAt",
             bool ascending = false);
        Task<Order> CreateAsync(CreateOrderRequest request, int userId);
        Task<Order> UpdateAsync(int id, UpdateOrderRequest request);
        Task<Order> UpdateStatusAsync(int id, OrderStatus status);
        Task<Order> UpdateCartItemsQuantityAsync(int userId, CartItemUpdate[] itemUpdates);
    }
}
