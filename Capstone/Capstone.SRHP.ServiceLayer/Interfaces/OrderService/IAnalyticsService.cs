using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.DTOs.Dashboard;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IAnalyticsService
    {
        Task<DashboardSummary> GetDashboardSummaryAsync(DateTime fromDate, DateTime toDate);
        Task<List<TopSellingItemDto>> GetTopSellingItemsAsync(string itemType, DateTime fromDate, DateTime toDate, int limit);
        Task<List<SalesTrendDto>> GetSalesTrendAsync(string period, DateTime fromDate, DateTime toDate);
        Task<OrdersByStatusDto> GetOrdersByStatusAsync(DateTime fromDate, DateTime toDate, int limit);
    }
}
