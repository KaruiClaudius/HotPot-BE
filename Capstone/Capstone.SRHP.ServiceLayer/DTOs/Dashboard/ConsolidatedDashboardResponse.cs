using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class ConsolidatedDashboardResponse
    {
        // Overall summary metrics
        public DashboardSummaryMetrics OverallMetrics { get; set; }

        // Monthly breakdown of orders and revenue
        public List<MonthlyMetrics> MonthlyData { get; set; }

        // Orders by status with counts and revenue
        public OrderStatusMetrics OrdersByStatus { get; set; }

        // Product consumption statistics
        public ProductConsumptionStats ProductConsumption { get; set; }
    }
}
