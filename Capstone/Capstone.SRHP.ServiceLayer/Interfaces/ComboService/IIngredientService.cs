using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ComboService
{
    public interface IIngredientService
    {
        Task<PagedResult<Ingredient>> GetIngredientsAsync(
                   string searchTerm = null,
                   int? typeId = null,
                   bool? isLowStock = null,
                   decimal? minPrice = null,
                   decimal? maxPrice = null,
                   int pageNumber = 1,
                   int pageSize = 10,
                   string sortBy = "Name",
                   bool ascending = true);

        // Basic CRUD for ingredients
        Task<Ingredient> GetIngredientByIdAsync(int id);
        Task<Ingredient> CreateIngredientAsync(Ingredient entity, decimal initialPrice);
        Task UpdateIngredientAsync(int id, Ingredient entity);
        Task DeleteIngredientAsync(int id);
        Task UpdateIngredientQuantityAsync(int id, int quantityChange);


        // ingredient type operations
        Task<IEnumerable<IngredientType>> GetAllIngredientTypesAsync();
        Task<IngredientType> CreateIngredientTypeAsync(string name);
        Task DeleteIngredientTypeAsync(int id);

        // Essential price-related methods
        Task<decimal> GetCurrentPriceAsync(int ingredientId);
        Task<Dictionary<int, decimal>> GetCurrentPricesAsync(IEnumerable<int> ingredientIds);
        Task<IEnumerable<IngredientPrice>> GetPriceHistoryAsync(int ingredientId);
        Task<IngredientPrice> AddPriceAsync(int ingredientId, decimal price, DateTime effectiveDate);

        // Specialized methods
        Task<IEnumerable<Ingredient>> GetLowStockIngredientsAsync();


    }
}
