using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ComboService
{
    public interface IComboService : IBaseService<Combo>
    {
        Task<PagedResult<Combo>> GetPagedAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Combo>> GetCustomizableCombosAsync();
        Task<Combo> CreateAsync(Combo combo, List<ComboIngredient> ingredients);
        Task<Combo> CreateCustomizableComboAsync(Combo combo, List<ComboAllowedIngredientType> allowedTypes);
        Task<IEnumerable<ComboAllowedIngredientType>> GetAllowedIngredientTypesAsync(int comboId);
        Task<IEnumerable<Ingredient>> GetAvailableIngredientsForTypeAsync(int comboId, int ingredientTypeId);
        Task<decimal> CalculateTotalPriceAsync(int comboId, int size);
        Task<IEnumerable<Combo>> GetActiveAsync();
        Task<IEnumerable<ComboIngredient>> GetComboIngredientsAsync(int comboId);
        Task AddIngredientToComboAsync(int comboId, int ingredientId, int quantity);
        Task RemoveIngredientFromComboAsync(int comboId, int ingredientId);
        Task UpdateIngredientQuantityAsync(int comboId, int ingredientId, int newQuantity);
        Task<PagedResult<Combo>> SearchAsync(string searchTerm, int pageNumber, int pageSize);
    }
}
