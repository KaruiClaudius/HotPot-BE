using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ComboService
{
    public interface ISizeDiscountService : IBaseService<SizeDiscount>
    {
        Task<PagedResult<SizeDiscount>> GetSizeDiscountsAsync(
            int? minSize = null,
            int? maxSize = null,
            decimal? minDiscount = null,
            decimal? maxDiscount = null,
            DateTime? activeDate = null,
            bool? isActive = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "MinSize",
            bool ascending = true);
        Task<SizeDiscount> GetApplicableDiscountAsync(int size);
    }
}
