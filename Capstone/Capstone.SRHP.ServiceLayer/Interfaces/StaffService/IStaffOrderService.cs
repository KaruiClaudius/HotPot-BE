using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.StaffService
{
    public interface IStaffOrderService
    {
        //    Task<IEnumerable<StaffAssignedOrderBaseDto>> GetAssignedOrdersAsync(
        //int staffId, StaffTaskType staffTaskType, OrderStatus? statusFilter = null);
        Task<IEnumerable<StaffAssignedOrderBaseDto>> GetAssignedOrdersAsync(int staffId, StaffTaskType staffTaskType);

        //Task<IEnumerable<StaffOrderDto>> GetOrdersByStatusAsync(OrderStatus status, int staffId);
        Task<StaffOrderDto> GetOrderWithDetailsAsync(int orderId);
        Task<StaffOrderDto> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, int staffId);
        Task<StaffOrderDto> CancelOrderAsync(int orderId, string cancellationReason);
        Task<PagedResult<StaffOrderDto>> GetOrderHistoryAsync(
            int pageNumber,
            int pageSize,
            OrderStatus? status = null,
            DateTime? startDate = null,
            DateTime? endDate = null);
        Task<VehicleInfoDto> GetVehicleInfoAsync(int orderId);
    }

}
