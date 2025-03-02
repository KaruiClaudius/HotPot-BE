using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class StaffWorkloadDto
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int ActiveDeliveries { get; set; }
        public int TotalDeliveriesToday { get; set; }
        public int TotalCompletedDeliveries { get; set; }
        public bool IsOverloaded => ActiveDeliveries >= 5; // Define threshold for overload
    }
    public class StaffAllocationStatsDto
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string Email { get; set; }

        // Current workload
        public int ActiveDeliveries { get; set; }

        // Historical allocations
        public int AllocationsToday { get; set; }
        public int AllocationsThisWeek { get; set; }
        public int AllocationsThisMonth { get; set; }
        public int TotalAllocations { get; set; }

        // Completed deliveries
        public int CompletedToday { get; set; }
        public int CompletedThisWeek { get; set; }
        public int CompletedThisMonth { get; set; }
        public int TotalCompleted { get; set; }

        // Performance metrics
        public double CompletionRate => TotalAllocations > 0 ? (double)TotalCompleted / TotalAllocations * 100 : 0;
        public bool IsOverloaded => ActiveDeliveries >= 5;
    }
    public class AutoAllocateOrderRequest
    {
        public int OrderId { get; set; }
    }
}
