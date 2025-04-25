using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Management;

namespace Capstone.HPTY.ServiceLayer.DTOs.Orders
{
    public class StaffOrderDto
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();

        // Add vehicle information
        public VehicleInfoDto Vehicle { get; set; }
        public OrderSize OrderSize { get; set; }
    }
}
