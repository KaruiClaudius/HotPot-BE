using Capstone.HPTY.ModelLayer.Entities;
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
        Task<IEnumerable<CustomizationIngredient>> GetCustomizationIngredientsAsync(int customizationId);
        Task AddIngredientToCustomizationAsync(int customizationId, int ingredientId, int quantity);
        Task RemoveIngredientFromCustomizationAsync(int customizationId, int ingredientId);
        Task UpdateIngredientQuantityAsync(int customizationId, int ingredientId, int newQuantity);
        Task<decimal> CalculateTotalPriceAsync(int customizationId);
    }
}
