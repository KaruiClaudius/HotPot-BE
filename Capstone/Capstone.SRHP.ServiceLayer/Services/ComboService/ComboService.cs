using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.ComboService
{
    public class ComboService : IComboService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIngredientService _ingredientService;
        private const int BROTH_TYPE_ID = 1; // Adjust this to match your broth type ID

        public ComboService(IUnitOfWork unitOfWork, IIngredientService ingredientService)
        {
            _unitOfWork = unitOfWork;
            _ingredientService = ingredientService;
        }

        public async Task<IEnumerable<Combo>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth))
                .Where(c => !c.IsDelete)
                .ToListAsync();
        }

        public async Task<PagedResult<Combo>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth))
                .Where(c => !c.IsDelete);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Combo>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Combo?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth))
                .FirstOrDefaultAsync(c => c.ComboId == id && !c.IsDelete);
        }

        public async Task<Combo> CreateAsync(Combo entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Combo name cannot be empty");

            if (entity.Size <= 0)
                throw new ValidationException("Combo size must be greater than 0");

            if (entity.Discount < 0 || entity.Discount > 100)
                throw new ValidationException("Discount must be between 0 and 100");

            // Check if combo name exists
            var nameExists = await _unitOfWork.Repository<Combo>()
                .AnyAsync(c => c.Name == entity.Name && !c.IsDelete);

            if (nameExists)
                throw new ValidationException($"Combo with name {entity.Name} already exists");

            // Validate HotpotBroth
            await ValidateHotpotBroth(entity.HotpotBrothID);

            // Calculate initial total price
            entity.TotalPrice = await CalculateTotalPriceAsync(entity);

            _unitOfWork.Repository<Combo>().Insert(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<Combo> CreateAsync(Combo entity, List<ComboIngredient> ingredients)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Validate basic properties
                if (string.IsNullOrWhiteSpace(entity.Name))
                    throw new ValidationException("Combo name cannot be empty");

                if (entity.Size <= 0)
                    throw new ValidationException("Combo size must be greater than 0");

                if (entity.Discount < 0 || entity.Discount > 100)
                    throw new ValidationException("Discount must be between 0 and 100");

                // Check if combo name exists
                var nameExists = await _unitOfWork.Repository<Combo>()
                    .AnyAsync(c => c.Name == entity.Name && !c.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Combo with name {entity.Name} already exists");

                // Validate HotpotBroth
                await ValidateHotpotBroth(entity.HotpotBrothID);

                // Validate all ingredients
                foreach (var ingredient in ingredients)
                {
                    var ingredientExists = await _unitOfWork.Repository<Ingredient>()
                        .AnyAsync(i => i.IngredientId == ingredient.IngredientID && !i.IsDelete);

                    if (!ingredientExists)
                        throw new ValidationException($"Ingredient with ID {ingredient.IngredientID} not found");

                    if (ingredient.Quantity <= 0)
                        throw new ValidationException("Ingredient quantity must be greater than 0");
                }

                // Insert combo first
                _unitOfWork.Repository<Combo>().Insert(entity);
                await _unitOfWork.CommitAsync();

                // Add ingredients
                foreach (var ingredient in ingredients)
                {
                    ingredient.ComboID = entity.ComboId;
                    _unitOfWork.Repository<ComboIngredient>().Insert(ingredient);
                }
                await _unitOfWork.CommitAsync();

                // Calculate and update total price
                var combo = await GetByIdAsync(entity.ComboId);
                if (combo != null)
                {
                    combo.TotalPrice = await CalculateTotalPriceAsync(combo);
                    await _unitOfWork.Repository<Combo>().Update(combo, combo.ComboId);
                    await _unitOfWork.CommitAsync();
                }

                await transaction.CommitAsync();
                return await GetByIdAsync(entity.ComboId);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateAsync(int id, Combo entity)
        {
            var existingCombo = await GetByIdAsync(id);
            if (existingCombo == null)
                throw new NotFoundException($"Combo with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Combo name cannot be empty");

            if (entity.Size <= 0)
                throw new ValidationException("Combo size must be greater than 0");

            if (entity.Discount < 0 || entity.Discount > 100)
                throw new ValidationException("Discount must be between 0 and 100");

            // Check for name uniqueness if name is changed
            if (entity.Name != existingCombo.Name)
            {
                var nameExists = await _unitOfWork.Repository<Combo>()
                    .AnyAsync(c => c.Name == entity.Name && c.ComboId != id && !c.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Combo with name {entity.Name} already exists");
            }

            // Validate HotpotBroth if it's being changed
            if (existingCombo.HotpotBrothID != entity.HotpotBrothID)
            {
                await ValidateHotpotBroth(entity.HotpotBrothID);
            }

            // Update total price
            entity.TotalPrice = await CalculateTotalPriceAsync(entity);
            entity.SetUpdateDate();

            await _unitOfWork.Repository<Combo>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, Combo entity, List<ComboIngredient> ingredients)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var existingCombo = await GetByIdAsync(id);
                if (existingCombo == null)
                    throw new NotFoundException($"Combo with ID {id} not found");

                // Validate basic properties
                if (string.IsNullOrWhiteSpace(entity.Name))
                    throw new ValidationException("Combo name cannot be empty");

                if (entity.Size <= 0)
                    throw new ValidationException("Combo size must be greater than 0");

                if (entity.Discount < 0 || entity.Discount > 100)
                    throw new ValidationException("Discount must be between 0 and 100");

                // Check for name uniqueness if name is changed
                if (entity.Name != existingCombo.Name)
                {
                    var nameExists = await _unitOfWork.Repository<Combo>()
                        .AnyAsync(c => c.Name == entity.Name && c.ComboId != id && !c.IsDelete);

                    if (nameExists)
                        throw new ValidationException($"Combo with name {entity.Name} already exists");
                }

                // Validate HotpotBroth if it's being changed
                if (existingCombo.HotpotBrothID != entity.HotpotBrothID)
                {
                    await ValidateHotpotBroth(entity.HotpotBrothID);
                }

                // Validate all ingredients
                foreach (var ingredient in ingredients)
                {
                    var ingredientExists = await _unitOfWork.Repository<Ingredient>()
                        .AnyAsync(i => i.IngredientId == ingredient.IngredientID && !i.IsDelete);

                    if (!ingredientExists)
                        throw new ValidationException($"Ingredient with ID {ingredient.IngredientID} not found");

                    if (ingredient.Quantity <= 0)
                        throw new ValidationException("Ingredient quantity must be greater than 0");
                }

                // Update combo basic info
                entity.SetUpdateDate();
                await _unitOfWork.Repository<Combo>().Update(entity, id);
                await _unitOfWork.CommitAsync();

                // Remove existing ingredients
                var existingIngredients = await _unitOfWork.Repository<ComboIngredient>()
                    .FindAll(ci => ci.ComboID == id)
                    .ToListAsync();

                foreach (var existingIngredient in existingIngredients)
                {
                    existingIngredient.SoftDelete();
                    existingIngredient.SetUpdateDate();
                }
                await _unitOfWork.CommitAsync();

                // Add new ingredients
                foreach (var ingredient in ingredients)
                {
                    ingredient.ComboID = id;
                    _unitOfWork.Repository<ComboIngredient>().Insert(ingredient);
                }
                await _unitOfWork.CommitAsync();

                // Calculate and update total price
                entity.TotalPrice = await CalculateTotalPriceAsync(id);
                await _unitOfWork.Repository<Combo>().Update(entity, id);
                await _unitOfWork.CommitAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var combo = await GetByIdAsync(id);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {id} not found");

            // Check if combo is in use in customizations
            var isUsedInCustomization = await _unitOfWork.Repository<Customization>()
                .AnyAsync(c => c.ComboID == id && !c.IsDelete);

            if (isUsedInCustomization)
                throw new ValidationException("Cannot delete combo that is used in customizations");

            combo.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Combo>> GetActiveAsync()
        {
            return await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth))
                .Where(c => !c.IsDelete)
                .ToListAsync();
        }

        public async Task<IEnumerable<ComboIngredient>> GetComboIngredientsAsync(int comboId)
        {
            return await _unitOfWork.Repository<ComboIngredient>()
                .Include(ci => ci.Ingredient)
                .Where(ci => ci.ComboID == comboId && !ci.IsDelete)
                .ToListAsync();
        }

        public async Task AddIngredientToComboAsync(int comboId, int ingredientId, int quantity)
        {
            var combo = await GetByIdAsync(comboId);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {comboId} not found");

            var ingredient = await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .FirstOrDefaultAsync(i => i.IngredientId == ingredientId && !i.IsDelete);

            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {ingredientId} not found");

            // Don't allow adding broth as a regular ingredient
            if (ingredient.IngredientTypeID == BROTH_TYPE_ID)
                throw new ValidationException("Cannot add broth as a regular ingredient. Use HotpotBroth property instead.");

            // Check if ingredient already exists in combo
            var existingIngredient = await _unitOfWork.Repository<ComboIngredient>()
                .FindAsync(ci => ci.ComboID == comboId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (existingIngredient != null)
                throw new ValidationException("Ingredient already exists in combo");

            var comboIngredient = new ComboIngredient
            {
                ComboID = comboId,
                IngredientID = ingredientId,
                Quantity = quantity
            };

            _unitOfWork.Repository<ComboIngredient>().Insert(comboIngredient);

            // Update combo total price
            combo.TotalPrice = await CalculateTotalPriceAsync(combo);
            combo.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveIngredientFromComboAsync(int comboId, int ingredientId)
        {
            var comboIngredient = await _unitOfWork.Repository<ComboIngredient>()
                .FindAsync(ci => ci.ComboID == comboId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (comboIngredient == null)
                throw new NotFoundException("Ingredient not found in combo");

            comboIngredient.SoftDelete();

            // Update combo total price
            var combo = await GetByIdAsync(comboId);
            if (combo != null)
            {
                combo.TotalPrice = await CalculateTotalPriceAsync(combo);
                combo.SetUpdateDate();
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateIngredientQuantityAsync(int comboId, int ingredientId, int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ValidationException("Quantity must be greater than 0");

            var comboIngredient = await _unitOfWork.Repository<ComboIngredient>()
                .FindAsync(ci => ci.ComboID == comboId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (comboIngredient == null)
                throw new NotFoundException("Ingredient not found in combo");

            comboIngredient.Quantity = newQuantity;
            comboIngredient.SetUpdateDate();

            // Update combo total price
            var combo = await GetByIdAsync(comboId);
            if (combo != null)
            {
                combo.TotalPrice = await CalculateTotalPriceAsync(combo);
                combo.SetUpdateDate();
            }

            await _unitOfWork.CommitAsync();
        }
        private async Task ValidateHotpotBroth(int brothId)
        {
            var broth = await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .FirstOrDefaultAsync(i => i.IngredientId == brothId && !i.IsDelete);

            if (broth == null)
                throw new ValidationException("Invalid hotpot broth selected");

            if (broth.IngredientTypeID != BROTH_TYPE_ID)
                throw new ValidationException("Selected ingredient is not a broth type");

            if (broth.Quantity <= 0)
                throw new ValidationException("Selected broth is out of stock");
        }

        public async Task<PagedResult<Combo>> SearchAsync(string searchTerm, int pageNumber, int pageSize)
        {
            searchTerm = searchTerm?.ToLower() ?? "";

            var query = _unitOfWork.Repository<Combo>()
                .Include(c => c.ComboIngredients, c => c.HotpotBroth)
                .Where(c => !c.IsDelete &&
                           (c.Name.ToLower().Contains(searchTerm) ||
                            (c.Description != null && c.Description.ToLower().Contains(searchTerm)) ||
                            c.HotpotBroth.Name.ToLower().Contains(searchTerm)));

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Combo>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<decimal> CalculateTotalPriceAsync(int comboId)
        {
            var combo = await GetByIdAsync(comboId);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {comboId} not found");

            return await CalculateTotalPriceAsync(combo);
        }

        private async Task<decimal> CalculateTotalPriceAsync(Combo combo)
        {
            decimal totalPrice = 0;

            // Add hotpot broth price
            if (combo.HotpotBrothID > 0)
            {
                try
                {
                    var brothPrice = await _ingredientService.GetCurrentPriceAsync(combo.HotpotBrothID);
                    totalPrice += brothPrice;
                }
                catch (NotFoundException)
                {
                    // Handle case where broth price is not found
                    throw new ValidationException($"Price not found for broth with ID {combo.HotpotBrothID}");
                }
            }

            // Add ingredients prices
            var comboIngredients = await _unitOfWork.Repository<ComboIngredient>()
                .Include(ci => ci.Ingredient)
                .Where(ci => ci.ComboID == combo.ComboId && !ci.IsDelete)
                .ToListAsync();

            // Get all ingredient IDs
            var ingredientIds = comboIngredients.Select(ci => ci.IngredientID).ToList();

            // Get all current prices in a single query
            var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

            foreach (var comboIngredient in comboIngredients)
            {
                if (currentPrices.TryGetValue(comboIngredient.IngredientID, out decimal price))
                {
                    totalPrice += price * comboIngredient.Quantity;
                }
                else
                {
                    throw new ValidationException($"Price not found for ingredient with ID {comboIngredient.IngredientID}");
                }
            }


            // Apply discount if any
            if (combo.Discount > 0)
            {
                totalPrice = totalPrice * (1 - ((decimal)combo.Discount / 100m));
            }

            return totalPrice;
        }


        private async Task LoadIngredientsForCombo(Combo combo)
        {
            if (combo == null || combo.ComboIngredients == null)
                return;

            // Get all ingredient IDs
            var ingredientIds = combo.ComboIngredients.Select(ci => ci.IngredientID).ToList();

            // Load all ingredients in a single query
            var ingredients = await _unitOfWork.Repository<Ingredient>()
                .GetWhere(i => ingredientIds.Contains(i.IngredientId) && !i.IsDelete);

            // Assign ingredients to combo ingredients
            foreach (var comboIngredient in combo.ComboIngredients)
            {
                comboIngredient.Ingredient = ingredients.FirstOrDefault(i => i.IngredientId == comboIngredient.IngredientID);
            }
        }

        // Helper method to load ingredients for multiple combos
        private async Task LoadIngredientsForCombos(IEnumerable<Combo> combos)
        {
            if (combos == null)
                return;

            // Get all combo ingredients IDs
            var allIngredientIds = new HashSet<int>();
            foreach (var combo in combos)
            {
                if (combo.ComboIngredients != null)
                {
                    foreach (var ci in combo.ComboIngredients)
                    {
                        allIngredientIds.Add(ci.IngredientID);
                    }
                }
            }

            // Load all ingredients in a single query
            var ingredients = await _unitOfWork.Repository<Ingredient>()
                .GetWhere(i => allIngredientIds.Contains(i.IngredientId) && !i.IsDelete);

            // Create a lookup dictionary for quick access
            var ingredientLookup = ingredients.ToDictionary(i => i.IngredientId);

            // Assign ingredients to combo ingredients
            foreach (var combo in combos)
            {
                if (combo.ComboIngredients != null)
                {
                    foreach (var comboIngredient in combo.ComboIngredients)
                    {
                        if (ingredientLookup.TryGetValue(comboIngredient.IngredientID, out var ingredient))
                        {
                            comboIngredient.Ingredient = ingredient;
                        }
                    }
                }
            }
        }
    }
}
