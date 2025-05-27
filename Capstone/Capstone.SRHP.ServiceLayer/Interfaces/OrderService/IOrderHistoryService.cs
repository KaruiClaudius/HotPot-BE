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
    public interface IOrderHistoryService
    {
        /// Gets order history with optional filtering
        Task<PagedResult<OrderHistoryDto>> GetOrderHistoryAsync(OrderHistoryFilterRequest filter);

    }
}
