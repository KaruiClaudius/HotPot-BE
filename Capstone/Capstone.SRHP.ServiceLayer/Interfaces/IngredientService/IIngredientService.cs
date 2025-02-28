using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.IngredientService
{
    public interface IIngredientService : IBaseService<Ingredient>
    {
        Task<PagedResult<Ingredient>> GetPagedAsync(int pageNumber, int pageSize);
        Task<Ingredient> CreateAsync(Ingredient entity, decimal initialPrice);
        Task<IEnumerable<Ingredient>> GetLowStockIngredientsAsync();
        Task<IEnumerable<Ingredient>> GetByTypeAsync(int typeId);
        Task<decimal> GetCurrentPriceAsync(int ingredientId);
        Task<IEnumerable<IngredientPrice>> GetPriceHistoryAsync(int ingredientId);
        Task<IngredientPrice> AddPriceAsync(IngredientPrice price);
        Task<Dictionary<int, decimal>> GetCurrentPricesAsync(IEnumerable<int> ingredientIds);
        Task<PagedResult<Ingredient>> SearchAsync(string searchTerm, int pageNumber, int pageSize);
    }
}
