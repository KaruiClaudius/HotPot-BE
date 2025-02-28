using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.IngredientService
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices)
                .Where(i => !i.IsDelete)
                .ToListAsync();
        }

        public async Task<PagedResult<Ingredient>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices)
                .Where(i => !i.IsDelete);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(i => i.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Ingredient>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices)
                .FirstOrDefaultAsync(i => i.IngredientId == id && !i.IsDelete);
        }

        public Task<Ingredient> CreateAsync(Ingredient entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Ingredient> CreateAsync(Ingredient entity, decimal initialPrice)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Ingredient name cannot be empty");

            if (entity.MinStockLevel < 0)
                throw new ValidationException("Minimum stock level cannot be negative");

            if (entity.Quantity < 0)
                throw new ValidationException("Quantity cannot be negative");

            if (initialPrice < 0)
                throw new ValidationException("Price cannot be negative");

            // Check if ingredient type exists
            var ingredientType = await _unitOfWork.Repository<IngredientType>()
                .FindAsync(t => t.IngredientTypeId == entity.IngredientTypeID && !t.IsDelete);

            if (ingredientType == null)
                throw new ValidationException($"Ingredient type with ID {entity.IngredientTypeID} not found");

            // Check if ingredient exists (including soft-deleted)
            var existingIngredient = await _unitOfWork.Repository<Ingredient>()
                .FindAsync(i => i.Name == entity.Name);

            if (existingIngredient != null)
            {
                if (!existingIngredient.IsDelete)
                {
                    throw new ValidationException($"Ingredient with name {entity.Name} already exists");
                }
                else
                {
                    // Reactivate and update the soft-deleted ingredient
                    existingIngredient.IsDelete = false;
                    existingIngredient.Description = entity.Description;
                    existingIngredient.ImageURL = entity.ImageURL;
                    existingIngredient.MinStockLevel = entity.MinStockLevel;
                    existingIngredient.Quantity = entity.Quantity;
                    existingIngredient.IngredientTypeID = entity.IngredientTypeID;
                    existingIngredient.SetUpdateDate();

                    // Add new price
                    var price = new IngredientPrice
                    {
                        IngredientID = existingIngredient.IngredientId,
                        Price = initialPrice,
                        EffectiveDate = DateTime.UtcNow
                    };

                    _unitOfWork.Repository<IngredientPrice>().Insert(price);
                    await _unitOfWork.CommitAsync();

                    return existingIngredient;
                }
            }

            // Create new ingredient
            _unitOfWork.Repository<Ingredient>().Insert(entity);
            await _unitOfWork.CommitAsync();

            // Add initial price
            var initialPriceEntity = new IngredientPrice
            {
                IngredientID = entity.IngredientId,
                Price = initialPrice,
                EffectiveDate = DateTime.UtcNow
            };

            _unitOfWork.Repository<IngredientPrice>().Insert(initialPriceEntity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task UpdateAsync(int id, Ingredient entity)
        {
            var existingIngredient = await GetByIdAsync(id);
            if (existingIngredient == null)
                throw new NotFoundException($"Ingredient with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Ingredient name cannot be empty");

            if (entity.MinStockLevel < 0)
                throw new ValidationException("Minimum stock level cannot be negative");

            if (entity.Quantity < 0)
                throw new ValidationException("Quantity cannot be negative");

            // Check if ingredient type exists
            var ingredientType = await _unitOfWork.Repository<IngredientType>()
                .FindAsync(t => t.IngredientTypeId == entity.IngredientTypeID && !t.IsDelete);

            if (ingredientType == null)
                throw new ValidationException($"Ingredient type with ID {entity.IngredientTypeID} not found");

            // Check for name uniqueness if name is changed
            if (entity.Name != existingIngredient.Name)
            {
                var nameExists = await _unitOfWork.Repository<Ingredient>()
                    .AnyAsync(i => i.Name == entity.Name && i.IngredientId != id && !i.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Ingredient with name {entity.Name} already exists");
            }

            entity.SetUpdateDate();
            await _unitOfWork.Repository<Ingredient>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ingredient = await GetByIdAsync(id);
            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {id} not found");

            // Check if ingredient is in use
            var isUsedInCustomization = await _unitOfWork.Repository<CustomizationIngredient>()
                .AnyAsync(ci => ci.IngredientID == id && !ci.IsDelete);

            var isUsedInCombo = await _unitOfWork.Repository<ComboIngredient>()
                .AnyAsync(ci => ci.IngredientID == id && !ci.IsDelete);

            var isUsedAsBrothInCombo = await _unitOfWork.Repository<Combo>()
                .AnyAsync(c => c.HotpotBrothID == id && !c.IsDelete);

            var isUsedAsBrothInCustomization = await _unitOfWork.Repository<Customization>()
                .AnyAsync(c => c.HotpotBrothID == id && !c.IsDelete);

            if (isUsedInCustomization || isUsedInCombo || isUsedAsBrothInCombo || isUsedAsBrothInCustomization)
                throw new ValidationException("Cannot delete ingredient that is in use");

            ingredient.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetLowStockIngredientsAsync()
        {
            return await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices)
                .Where(i => !i.IsDelete && i.Quantity <= i.MinStockLevel)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetByTypeAsync(int typeId)
        {
            return await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices)
                .Where(i => !i.IsDelete && i.IngredientTypeID == typeId)
                .ToListAsync();
        }

        public async Task<decimal> GetCurrentPriceAsync(int ingredientId)
        {
            var latestPrice = await _unitOfWork.Repository<IngredientPrice>()
                .FindAll(p => p.IngredientID == ingredientId && !p.IsDelete && p.EffectiveDate <= DateTime.UtcNow)
                .OrderByDescending(p => p.EffectiveDate)
                .FirstOrDefaultAsync();

            if (latestPrice == null)
                throw new NotFoundException($"No price found for ingredient with ID {ingredientId}");

            return latestPrice.Price;
        }

        public async Task<Dictionary<int, decimal>> GetCurrentPricesAsync(IEnumerable<int> ingredientIds)
        {
            var idList = ingredientIds.ToList();
            var now = DateTime.UtcNow;

            // Get all prices for the specified ingredients
            var allPrices = await _unitOfWork.Repository<IngredientPrice>()
                .FindAll(p => idList.Contains(p.IngredientID) && !p.IsDelete && p.EffectiveDate <= now)
                .ToListAsync();

            // Group by ingredient ID and get the latest price for each
            var result = new Dictionary<int, decimal>();

            foreach (var id in idList)
            {
                var latestPrice = allPrices
                    .Where(p => p.IngredientID == id)
                    .OrderByDescending(p => p.EffectiveDate)
                    .FirstOrDefault();

                if (latestPrice != null)
                {
                    result[id] = latestPrice.Price;
                }
            }

            return result;
        }

        public async Task<IEnumerable<IngredientPrice>> GetPriceHistoryAsync(int ingredientId)
        {
            return await _unitOfWork.Repository<IngredientPrice>()
                .Include(p => p.Ingredient)
                .Where(p => p.IngredientID == ingredientId && !p.IsDelete)
                .OrderByDescending(p => p.EffectiveDate)
                .ToListAsync();
        }

        public async Task<IngredientPrice> AddPriceAsync(IngredientPrice price)
        {
            // Validate
            if (price.Price < 0)
                throw new ValidationException("Price cannot be negative");

            var ingredient = await GetByIdAsync(price.IngredientID);
            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {price.IngredientID} not found");

            // Check if there's already a price with the same effective date
            var existingPrice = await _unitOfWork.Repository<IngredientPrice>()
                .FindAsync(p => p.IngredientID == price.IngredientID &&
                               p.EffectiveDate == price.EffectiveDate &&
                               !p.IsDelete);

            if (existingPrice != null)
                throw new ValidationException($"A price for this ingredient with effective date {price.EffectiveDate} already exists");

            _unitOfWork.Repository<IngredientPrice>().Insert(price);
            await _unitOfWork.CommitAsync();
            return price;
        }
        public async Task<PagedResult<Ingredient>> SearchAsync(string searchTerm, int pageNumber, int pageSize)
        {
            searchTerm = searchTerm?.ToLower() ?? "";

            var query = _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices)
                .Where(i => !i.IsDelete &&
                           (i.Name.ToLower().Contains(searchTerm) ||
                            (i.Description != null && i.Description.ToLower().Contains(searchTerm)) ||
                            i.IngredientType.Name.ToLower().Contains(searchTerm)));

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(i => i.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Ingredient>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }


    }
}