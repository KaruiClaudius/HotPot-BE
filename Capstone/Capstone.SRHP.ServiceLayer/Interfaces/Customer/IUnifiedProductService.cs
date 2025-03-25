using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.DTOs.Customer;

namespace Capstone.HPTY.ServiceLayer.Interfaces.Customer
{
    public interface IUnifiedProductService
    {
        Task<PagedUnifiedProductResult> GetAllProductsAsync(
            string productType = null,
            string searchTerm = null,
            int? typeId = null,
            string material = null,
            string size = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            bool? onlyAvailable = true,
            int? minQuantity = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "Name",
            bool ascending = true);

        Task<UnifiedProductDto> GetProductByIdAsync(string productType, int id);

        Task<List<object>> GetProductTypesAsync(string productType);
    }
}
