using Capstone.HPTY.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces
{
    public interface IIngredientService : IBaseService<Ingredient>
    {
        Task<IEnumerable<Ingredient>> GetByTypeAsync(int typeId);
        Task<bool> UpdateStockAsync(int id, int quantity);
        Task<IEnumerable<Ingredient>> GetLowStockIngredientsAsync();
        Task<decimal> GetCurrentPriceAsync(int id);
        Task UpdatePriceAsync(int id, decimal newPrice);
    }
}
