using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface ICustomerOrderHistoryService
    {
        /// Gets order history for a specific customer with optional filtering
        Task<PagedResult<OrderHistoryDto>> GetCustomerOrderHistoryAsync(int userId, OrderHistoryFilterRequest filter);

        /// Gets details of a specific order for a customer
        Task<OrderHistoryDto> GetCustomerOrderDetailsAsync(int userId, int orderId);

        /// Gets customer orders by status
        Task<PagedResult<OrderHistoryDto>> GetCustomerOrdersByStatusAsync(int userId, OrderStatus status, int pageNumber = 1, int pageSize = 10);

        /// Gets customer orders by date range
        Task<PagedResult<OrderHistoryDto>> GetCustomerOrdersByDateRangeAsync(int userId, DateTime startDate, DateTime endDate, int pageNumber = 1, int pageSize = 10);
    }
}
