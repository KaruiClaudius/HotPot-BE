using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.OrderService
{
    public interface IDiscountService : IBaseService<Discount>
    {
        Task<PagedResult<Discount>> GetDiscountsAsync(
            string searchTerm = null,
            decimal? minDiscountPercentage = null,
            decimal? maxDiscountPercentage = null,
            double? minPointCost = null,
            double? maxPointCost = null,
            DateTime? startDateFrom = null,
            DateTime? startDateTo = null,
            DateTime? endDateFrom = null,
            DateTime? endDateTo = null,
            bool? isActive = null,
            bool? isUpcoming = null,
            bool? isExpired = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "CreatedAt",
            bool ascending = false);
        Task<IEnumerable<Discount>> GetActiveDiscountsAsync();
        Task<IEnumerable<Discount>> GetUpcomingDiscountsAsync();
        Task<IEnumerable<Discount>> GetExpiredDiscountsAsync();
        Task<bool> IsDiscountValidAsync(int discountId);
        Task<decimal> CalculateDiscountAmountAsync(int discountId, decimal originalPrice);
        Task<bool> HasSufficientPointsAsync(int discountId, double? userPoints);
        Task<int> GetOrderCountByDiscountAsync(int discountId);
        Task<Dictionary<int, int>> GetOrderCountsByDiscountsAsync(IEnumerable<int> discountIds);
    }
}
