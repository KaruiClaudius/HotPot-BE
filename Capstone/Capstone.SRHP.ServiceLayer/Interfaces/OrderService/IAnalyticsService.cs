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
        Task<ConsolidatedDashboardResponse> GetConsolidatedDashboardDataAsync(
            DateTime fromDate,
            DateTime toDate,
            string status = null,
            string productType = null,
            bool? hasHotpot = null,
            string paymentStatus = null,
            int topProductsLimit = 5,
            int? year = null);
    }
}
