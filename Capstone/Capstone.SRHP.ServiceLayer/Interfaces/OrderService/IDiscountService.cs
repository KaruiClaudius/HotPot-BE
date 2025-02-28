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
        Task<PagedResult<Discount>> GetPagedAsync(int pageNumber, int pageSize);
        Task<PagedResult<Discount>> SearchAsync(string searchTerm, int pageNumber, int pageSize);
        Task<IEnumerable<Discount>> GetActiveDiscountsAsync();
        Task<IEnumerable<Discount>> GetUpcomingDiscountsAsync();
        Task<IEnumerable<Discount>> GetExpiredDiscountsAsync();
        Task<bool> IsDiscountValidAsync(int discountId);
        Task<double> CalculateDiscountAmountAsync(int discountId, double originalPrice);
        Task<bool> HasSufficientPointsAsync(int discountId, double userPoints);
        Task<int> GetOrderCountByDiscountAsync(int discountId);
        Task<Dictionary<int, int>> GetOrderCountsByDiscountsAsync(IEnumerable<int> discountIds);
    }
}
