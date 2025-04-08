using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IRentOrderService
    {
        Task<IEnumerable<RentOrder>> GetByOrderIdAsync(int orderId);
        Task<PagedResult<RentalListingDto>> GetPendingPickupsAsync(int pageNumber = 1, int pageSize = 10);
        Task<List<RentOrderDetailDto>> GetPendingPickupsByUserAsync(int userId);
        Task<PagedResult<RentalListingDto>> GetOverdueRentalsAsync(int pageNumber = 1, int pageSize = 10);
        Task<bool> UpdateRentOrderDetailAsync(int rentOrderDetailId, UpdateRentOrderDetailRequest request);
        Task<decimal> CalculateLateFeeAsync(int rentOrderDetailId, DateTime actualReturnDate);
        Task<IEnumerable<RentalHistoryItem>> GetRentalHistoryByEquipmentAsync(int? hotpotInventoryId = null);
        Task<IEnumerable<RentalHistoryItem>> GetRentalHistoryByUserAsync(int? userId = null);
        Task<bool> ExtendRentalPeriodAsync(int rentOrderDetailId, DateTime newExpectedReturnDate);
        Task<PagedResult<RentOrderDetailResponse>> GetUnassignedPickupsAsync(int pageNumber = 1, int pageSize = 10);

    }
}
