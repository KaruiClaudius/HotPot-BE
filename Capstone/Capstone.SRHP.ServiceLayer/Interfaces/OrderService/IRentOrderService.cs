using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IRentOrderService
    {
        Task<RentOrderDetail> GetByIdAsync(int rentOrderDetailId);
        Task<IEnumerable<RentOrderDetail>> GetByOrderIdAsync(int orderId);
        Task<PagedResult<RentOrderDetail>> GetPendingPickupsAsync(int pageNumber = 1, int pageSize = 10);
        Task<List<RentOrderDetailDto>> GetPendingPickupsByUserAsync(int userId);
        Task<PagedResult<RentOrderDetail>> GetOverdueRentalsAsync(int pageNumber = 1, int pageSize = 10);
        Task<bool> RecordEquipmentReturnAsync(int rentOrderDetailId, RecordReturnRequest request);
        Task<bool> UpdateRentOrderDetailAsync(int rentOrderDetailId, UpdateRentOrderDetailRequest request);
        Task<bool> CancelRentOrderDetailAsync(int rentOrderDetailId);
        Task<decimal> CalculateLateFeeAsync(int rentOrderDetailId, DateTime actualReturnDate);
        Task<IEnumerable<RentOrderDetail>> GetRentalHistoryByEquipmentAsync(int? utensilId = null, int? hotpotInventoryId = null);
        Task<IEnumerable<RentOrderDetail>> GetRentalHistoryByUserAsync(int userId);
        Task<bool> ExtendRentalPeriodAsync(int rentOrderDetailId, DateTime newExpectedReturnDate);
        Task<PagedResult<RentOrderDetailResponse>> GetUnassignedPickupsAsync(int pageNumber = 1, int pageSize = 10);

    }
}
