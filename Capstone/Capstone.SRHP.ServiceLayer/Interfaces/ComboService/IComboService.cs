using Capstone.HPTY.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ComboService
{
    public interface IComboService : IBaseService<Combo>
    {
        Task<IEnumerable<Combo>> GetActiveAsync();
        Task<IEnumerable<ComboIngredient>> GetComboIngredientsAsync(int comboId);
        Task AddIngredientToComboAsync(int comboId, int ingredientId, int quantity);
        Task RemoveIngredientFromComboAsync(int comboId, int ingredientId);
        Task UpdateIngredientQuantityAsync(int comboId, int ingredientId, int newQuantity);
        Task<decimal> CalculateTotalPriceAsync(int comboId);
    }
}
