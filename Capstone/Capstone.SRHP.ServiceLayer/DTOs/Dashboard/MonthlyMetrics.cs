using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Dashboard
{
    public class MonthlyMetrics
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public decimal Revenue { get; set; }
        public int OrderCount { get; set; }
        public int CompletedOrderCount { get; set; }
        public Dictionary<string, int> OrdersByStatus { get; set; }
    }
}
