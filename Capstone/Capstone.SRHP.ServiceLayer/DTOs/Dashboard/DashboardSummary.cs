using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class DashboardSummary
    {
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public int TotalCustomers { get; set; }
        public decimal AverageOrderValue { get; set; }
        public OrderCountByStatus OrdersByStatus { get; set; }
        public RevenueByProductType RevenueByProductType { get; set; }
        public List<TopSellingItemDto> TopSellingItems { get; set; }
        public List<SalesTrendDto> SalesTrend { get; set; }
    }
}
