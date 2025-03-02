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
        private readonly ISizeDiscountService _sizeDiscountService;
        private const int BROTH_TYPE_ID = 1; // Adjust this to match your broth type ID

        public ComboService(IUnitOfWork unitOfWork, IIngredientService ingredientService, ISizeDiscountService sizeDiscountService)
        {
            _unitOfWork = unitOfWork;
            _ingredientService = ingredientService;
            _sizeDiscountService = sizeDiscountService;
        }

        public async Task<IEnumerable<Combo>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.AppliedDiscount))
                .Where(c => !c.IsDelete)
                .ToListAsync();
        }

        public async Task<PagedResult<Combo>> GetPagedAsync(int pageNumber, int pageSize)
        {
            // Validate input parameters
            if (pageNumber < 1)
                pageNumber = 1;

            if (pageSize < 1)
                pageSize = 10;

            var query = _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.AppliedDiscount))
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

        public async Task<Combo> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.AppliedDiscount)
                         .Include(c => c.AllowedIngredientTypes)
                         .ThenInclude(ait => ait.IngredientType))
                .FirstOrDefaultAsync(c => c.ComboId == id && !c.IsDelete);
        }
        public async Task<IEnumerable<Combo>> GetCustomizableCombosAsync()
        {
            return await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.AllowedIngredientTypes)
                         .ThenInclude(ait => ait.IngredientType)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.AppliedDiscount))
                .Where(c => c.IsCustomizable && !c.IsDelete)
                .ToListAsync();
        }

        public async Task<Combo> CreateAsync(Combo entity)
        {
            //// Validate basic properties
            //if (string.IsNullOrWhiteSpace(entity.Name))
            //    throw new ValidationException("Combo name cannot be empty");

            //if (entity.Size <= 0)
            //    throw new ValidationException("Combo size must be greater than 0");

            //if (entity.Discount < 0 || entity.Discount > 100)
            //    throw new ValidationException("Discount must be between 0 and 100");

            //// Check if combo name exists
            //var nameExists = await _unitOfWork.Repository<Combo>()
            //    .AnyAsync(c => c.Name == entity.Name && !c.IsDelete);

            //if (nameExists)
            //    throw new ValidationException($"Combo with name {entity.Name} already exists");

            //// Validate HotpotBroth
            //await ValidateHotpotBroth(entity.HotpotBrothID);

            //// Calculate initial total price
            //entity.BasePrice  = await CalculateTotalPriceAsync(entity);

            //_unitOfWork.Repository<Combo>().Insert(entity);
            //await _unitOfWork.CommitAsync();

            //return entity;

            throw new NotImplementedException();
        }

        public async Task<Combo> CreateAsync(Combo combo, List<ComboIngredient> ingredients)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Validate basic properties
                if (string.IsNullOrWhiteSpace(combo.Name))
                    throw new ValidationException("Combo name cannot be empty");

                if (combo.Size <= 0)
                    throw new ValidationException("Combo size must be greater than 0");

                if (combo.BasePrice <= 0)
                    throw new ValidationException("Combo base price must be greater than 0");

                // Check if combo name exists
                var nameExists = await _unitOfWork.Repository<Combo>()
                    .AnyAsync(c => c.Name == combo.Name && !c.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Combo with name {combo.Name} already exists");

                // Validate HotpotBroth
                await ValidateHotpotBroth(combo.HotpotBrothID);

                // Get applicable discount for this size
                var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(combo.Size);
                combo.AppliedDiscountID = applicableDiscount?.SizeDiscountId;

                // Insert combo
                _unitOfWork.Repository<Combo>().Insert(combo);
                await _unitOfWork.CommitAsync();

                // Add ingredients
                foreach (var ingredient in ingredients)
                {
                    // Validate ingredient exists
                    var ingredientExists = await _unitOfWork.Repository<Ingredient>()
                        .AnyAsync(i => i.IngredientId == ingredient.IngredientID && !i.IsDelete);

                    if (!ingredientExists)
                        throw new ValidationException($"Ingredient with ID {ingredient.IngredientID} not found");

                    ingredient.ComboID = combo.ComboId;
                    _unitOfWork.Repository<ComboIngredient>().Insert(ingredient);
                }

                await _unitOfWork.CommitAsync();
                await transaction.CommitAsync();

                return await GetByIdAsync(combo.ComboId);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Combo> CreateCustomizableComboAsync(Combo combo, List<ComboAllowedIngredientType> allowedTypes)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Validate basic properties
                if (string.IsNullOrWhiteSpace(combo.Name))
                    throw new ValidationException("Combo name cannot be empty");

                if (combo.Size <= 0)
                    throw new ValidationException("Combo size must be greater than 0");

                if (combo.BasePrice <= 0)
                    throw new ValidationException("Combo base price must be greater than 0");

                // Set as customizable
                combo.IsCustomizable = true;

                // Check if combo name exists
                var nameExists = await _unitOfWork.Repository<Combo>()
                    .AnyAsync(c => c.Name == combo.Name && !c.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Combo with name {combo.Name} already exists");

                // Validate HotpotBroth
                await ValidateHotpotBroth(combo.HotpotBrothID);

                // Get applicable discount for this size
                var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(combo.Size);
                combo.AppliedDiscountID = applicableDiscount?.SizeDiscountId;

                // Insert combo
                _unitOfWork.Repository<Combo>().Insert(combo);
                await _unitOfWork.CommitAsync();

                // Add allowed ingredient types
                foreach (var allowedType in allowedTypes)
                {
                    // Validate ingredient type exists
                    var typeExists = await _unitOfWork.Repository<IngredientType>()
                        .AnyAsync(it => it.IngredientTypeId == allowedType.IngredientTypeId && !it.IsDelete);

                    if (!typeExists)
                        throw new ValidationException($"Ingredient type with ID {allowedType.IngredientTypeId} not found");

                    allowedType.ComboId = combo.ComboId;
                    _unitOfWork.Repository<ComboAllowedIngredientType>().Insert(allowedType);
                }

                await _unitOfWork.CommitAsync();
                await transaction.CommitAsync();

                return await GetByIdAsync(combo.ComboId);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateAsync(int id, Combo combo)
        {
            var existingCombo = await GetByIdAsync(id);
            if (existingCombo == null)
                throw new NotFoundException($"Combo with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(combo.Name))
                throw new ValidationException("Combo name cannot be empty");

            if (combo.Size <= 0)
                throw new ValidationException("Combo size must be greater than 0");

            if (combo.BasePrice <= 0)
                throw new ValidationException("Combo base price must be greater than 0");

            // Check if combo name exists (excluding this one)
            var nameExists = await _unitOfWork.Repository<Combo>()
                .AnyAsync(c => c.Name == combo.Name && c.ComboId != id && !c.IsDelete);

            if (nameExists)
                throw new ValidationException($"Another combo with name {combo.Name} already exists");

            // Validate HotpotBroth if it's being changed
            if (existingCombo.HotpotBrothID != combo.HotpotBrothID)
            {
                await ValidateHotpotBroth(combo.HotpotBrothID);
            }

            // Get applicable discount for this size if size changed
            if (existingCombo.Size != combo.Size || !combo.AppliedDiscountID.HasValue)
            {
                var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(combo.Size);
                combo.AppliedDiscountID = applicableDiscount?.SizeDiscountId;
            }

            // Update combo
            combo.SetUpdateDate();
            await _unitOfWork.Repository<Combo>().Update(combo, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var combo = await GetByIdAsync(id);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {id} not found");

            // Check if this combo is used by any customizations or orders
            var isUsedByCustomization = await _unitOfWork.Repository<Customization>()
                .AnyAsync(c => c.ComboID == id && !c.IsDelete);

            var isUsedByOrder = await _unitOfWork.Repository<OrderDetail>()
                .AnyAsync(od => od.ComboID == id && !od.IsDelete);

            if (isUsedByCustomization || isUsedByOrder)
                throw new ValidationException("Cannot delete this combo as it is used by existing customizations or orders");

            // Soft delete combo and related entities
            combo.SoftDelete();

            // Soft delete combo ingredients
            var comboIngredients = await _unitOfWork.Repository<ComboIngredient>()
                .FindAll(ci => ci.ComboID == id && !ci.IsDelete)
                .ToListAsync();

            foreach (var ingredient in comboIngredients)
            {
                ingredient.SoftDelete();
            }

            // Soft delete allowed ingredient types if this is a customizable combo
            if (combo.IsCustomizable)
            {
                var allowedTypes = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                    .FindAll(ait => ait.ComboId == id && !ait.IsDelete)
                    .ToListAsync();

                foreach (var type in allowedTypes)
                {
                    type.SoftDelete();
                }
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ComboAllowedIngredientType>> GetAllowedIngredientTypesAsync(int comboId)
        {
            var combo = await GetByIdAsync(comboId);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {comboId} not found");

            if (!combo.IsCustomizable)
                throw new ValidationException($"Combo with ID {comboId} is not customizable");

            return await _unitOfWork.Repository<ComboAllowedIngredientType>()
                .IncludeNested(q => q.Include(ait => ait.IngredientType))
                .Where(ait => ait.ComboId == comboId && !ait.IsDelete)
                .ToListAsync();
        }



        public async Task<IEnumerable<Ingredient>> GetAvailableIngredientsForTypeAsync(int comboId, int ingredientTypeId)
        {
            var combo = await GetByIdAsync(comboId);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {comboId} not found");

            if (!combo.IsCustomizable)
                throw new ValidationException($"Combo with ID {comboId} is not customizable");

            // Check if this ingredient type is allowed for this combo
            var isAllowed = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                .AnyAsync(ait => ait.ComboId == comboId && ait.IngredientTypeId == ingredientTypeId && !ait.IsDelete);

            if (!isAllowed)
                throw new ValidationException($"Ingredient type with ID {ingredientTypeId} is not allowed for this combo");

            // Get all available ingredients of this type
            return await _unitOfWork.Repository<Ingredient>()
                .FindAll(i => i.IngredientTypeID == ingredientTypeId && i.Quantity > 0 && !i.IsDelete)
                .ToListAsync();
        }

        private async Task ValidateHotpotBroth(int brothId)
        {
            var broth = await _unitOfWork.Repository<Ingredient>()
                .IncludeNested(query => query.Include(i => i.IngredientType))
                .FirstOrDefaultAsync(i => i.IngredientId == brothId && !i.IsDelete);

            if (broth == null)
                throw new ValidationException("Invalid hotpot broth selected");

            if (broth.IngredientTypeID != BROTH_TYPE_ID)
                throw new ValidationException("Selected ingredient is not a broth type");

            if (broth.Quantity <= 0)
                throw new ValidationException("Selected broth is out of stock");
        }

        public async Task<IEnumerable<Combo>> GetActiveAsync()
        {
            return await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.AppliedDiscount))
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

            // Update combo base price
            combo.BasePrice = await CalculateBasePriceAsync(combo);
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

            // Update combo base price
            var combo = await GetByIdAsync(comboId);
            if (combo != null)
            {
                combo.BasePrice = await CalculateBasePriceAsync(combo);
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

            // Update combo base price
            var combo = await GetByIdAsync(comboId);
            if (combo != null)
            {
                combo.BasePrice = await CalculateBasePriceAsync(combo);
                combo.SetUpdateDate();
            }

            await _unitOfWork.CommitAsync();
        }


        public async Task<PagedResult<Combo>> SearchAsync(string searchTerm, int pageNumber, int pageSize)
        {
            searchTerm = searchTerm?.ToLower() ?? "";

            var query = _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.AppliedDiscount))
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

        public async Task<decimal> CalculateTotalPriceAsync(int comboId, int size)
        {
            var combo = await GetByIdAsync(comboId);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {comboId} not found");

            // Calculate base price (scaled by size)
            decimal basePrice = combo.BasePrice * size;

            // Get applicable discount
            decimal discountPercentage = 0;
            if (combo.AppliedDiscount != null)
            {
                discountPercentage = combo.AppliedDiscount.DiscountPercentage;
            }
            else
            {
                var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(size);
                if (applicableDiscount != null)
                {
                    discountPercentage = applicableDiscount.DiscountPercentage;
                }
            }

            decimal finalPrice = basePrice;
            if (discountPercentage > 0)
            {
                finalPrice = basePrice * (1 - (discountPercentage / 100m));
            }

            return finalPrice;
        }

        // This method calculates the base price for a single serving
        private async Task<decimal> CalculateBasePriceAsync(Combo combo)
        {
            decimal basePrice = 0;

            // Add hotpot broth price
            if (combo.HotpotBrothID > 0)
            {
                try
                {
                    var brothPrice = await _ingredientService.GetCurrentPriceAsync(combo.HotpotBrothID);
                    basePrice += brothPrice;
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
                    basePrice += price * comboIngredient.Quantity;
                }
                else
                {
                    throw new ValidationException($"Price not found for ingredient with ID {comboIngredient.IngredientID}");
                }
            }

            // Calculate per-person base price
            basePrice = basePrice / combo.Size;

            return basePrice;
        }
    }
}
