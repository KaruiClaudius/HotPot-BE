using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IOrderHistoryService
    {
        /// Gets order history with optional filtering
        Task<PagedResult<OrderHistoryDto>> GetOrderHistoryAsync(OrderHistoryFilterRequest filter);

        /// Gets details of a specific order
        Task<OrderHistoryDto> GetOrderDetailsAsync(int orderId);

        /// Gets orders by status
        Task<PagedResult<OrderHistoryDto>> GetOrdersByStatusAsync(OrderStatus status, int pageNumber = 1, int pageSize = 10);

        /// Gets orders by date range
        Task<PagedResult<OrderHistoryDto>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate, int pageNumber = 1, int pageSize = 10);
    }
}
