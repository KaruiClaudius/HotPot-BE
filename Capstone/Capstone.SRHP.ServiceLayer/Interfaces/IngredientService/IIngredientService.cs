using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.Utils;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.IngredientService
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

        // batch logic
        Task<IEnumerable<IngredientBatch>> GetIngredientBatchesAsync(int ingredientId);
        Task<IngredientBatch> GetBatchByIdAsync(int batchId);
        Task<IngredientBatch> AddBatchAsync(int ingredientId, int quantity, DateTime bestBeforeDate, bool isInitial = false);
        Task<List<IngredientBatch>> AddMultipleBatchesAsync(List<(int ingredientId, int quantity, DateTime bestBeforeDate)> batches);
        Task UpdateBatchAsync(int batchId, int quantity, DateTime bestBeforeDate, string batchNumber = null);
        Task DeleteBatchAsync(int batchId);
        Task<int> ConsumeIngredientAsync(int ingredientId, int quantity, int orderId, int? orderDetailId = null, int? comboId = null, int? customizationId = null);
        Task<IEnumerable<IngredientBatch>> GetExpiringBatchesAsync(int daysThreshold = 7);
        Task<IEnumerable<IngredientBatch>> GetExpiredBatchesAsync();

        // packaging logic
        Task<IEnumerable<IngredientPackaging>> GetPackagingOptionsAsync(int ingredientId);
        Task SetDefaultPackagingSizeAsync(int ingredientId, int packagingId);
        Task<IngredientPackaging> GetPackagingByIdAsync(int packagingId);
        Task<IngredientPackaging> AddPackagingAsync(IngredientPackaging packaging);
        Task DeletePackagingAsync(int packagingId);
    }
}
