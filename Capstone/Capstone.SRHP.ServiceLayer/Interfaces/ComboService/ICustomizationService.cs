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
    public interface ICustomizationService : IBaseService<Customization>
    {
        Task<IEnumerable<Customization>> GetUserCustomizationsAsync(int userId);
        Task<PagedResult<Customization>> GetPagedAsync(int pageNumber, int pageSize);
        Task<IEnumerable<CustomizationIngredient>> GetCustomizationIngredientsAsync(int customizationId);
        Task AddIngredientToCustomizationAsync(int customizationId, int ingredientId, int quantity);
        Task RemoveIngredientFromCustomizationAsync(int customizationId, int ingredientId);
        Task UpdateIngredientQuantityAsync(int customizationId, int ingredientId, int newQuantity);
        Task UpdateAsync(int id, Customization entity, List<CustomizationIngredient> ingredients);
        Task<decimal> CalculateTotalPriceAsync(int customizationId);
        Task<PagedResult<Customization>> SearchAsync(string searchTerm, int pageNumber, int pageSize);

        Task<IEnumerable<Customization>> GetAllAsync();
        Task<Customization> GetByIdAsync(int id);

        Task<Customization> CreateCustomizationAsync(
            int comboId,
            int userId,
            string name,
            string? note,
            int size,
            int brothId,
            List<CustomizationIngredientDto> ingredients,
            string[]? imageURLs = null);
        Task UpdateAsync(int id, Customization customization);
        Task DeleteAsync(int id);
        Task<CustomizationPriceEstimate> CalculatePriceEstimateAsync(
            int comboId,
            int size,
            int brothId,
            List<CustomizationIngredientDto> ingredients);
        decimal GetTotalPrice(Customization customization);
    }
}
