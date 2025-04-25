using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Customization;
using Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ComboService
{
    public interface ICustomizationService 
    {
        Task<PagedResult<Customization>> GetCustomizationsAsync(
        string searchTerm = null,
        int? userId = null,
        int? comboId = null,
        int? minSize = null,
        int? maxSize = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        int pageNumber = 1,
        int pageSize = 10,
        string sortBy = "CreatedAt",
        bool ascending = false);

        Task<Customization?> GetByIdAsync(int id);

        Task<Customization> CreateCustomizationAsync(
                 int? comboId,  // Accept nullable comboId
                 int userId,
                 string name,
                 string? note,
                 int size,
                 List<CustomizationIngredientsRequest> ingredients,
                 string[]? imageURLs = null);
        Task UpdateAsync(int id, Customization entity, List<CustomizationIngredientsRequest> ingredients);

        Task DeleteAsync(int id);

        Task<CustomizationPriceEstimate> CalculatePriceEstimateAsync(
            int? comboId,
            int size,
            List<CustomizationIngredientsRequest> ingredients);
    }
}
