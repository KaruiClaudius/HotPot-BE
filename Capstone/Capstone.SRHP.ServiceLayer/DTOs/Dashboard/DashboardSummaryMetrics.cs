using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class DashboardSummaryMetrics
    {
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public int TotalCustomers { get; set; }
        public decimal AverageOrderValue { get; set; }
        public decimal HotpotDepositsTotal { get; set; }
        public RevenueByProductType RevenueByType { get; set; }
    }
}
