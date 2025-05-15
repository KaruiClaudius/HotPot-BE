using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class StaffAssignmentHistoryDto
    {
        public int StaffAssignmentId { get; set; }
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public int OrderId { get; set; }
        public string? OrderCode { get; set; }
        public string? CustomerName { get; set; }
        public StaffTaskType TaskType { get; set; }
        public string TaskTypeName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsActive { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderStatusName { get; set; }
    }

    public class StaffAssignmentHistoryFilterRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public StaffTaskType? TaskType { get; set; }
        public bool? IsActive { get; set; }
        public int? StaffId { get; set; }
        public string? StaffName { get; set; }
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }
}
