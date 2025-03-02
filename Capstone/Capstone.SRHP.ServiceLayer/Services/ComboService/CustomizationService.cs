using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Customization;
using Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount;
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
    public class CustomizationService : ICustomizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIngredientService _ingredientService;
        private readonly IComboService _comboService;
        private readonly ISizeDiscountService _sizeDiscountService;
        private const int BROTH_TYPE_ID = 1;

        public CustomizationService(
            IUnitOfWork unitOfWork,
            IIngredientService ingredientService,
            IComboService comboService,
            ISizeDiscountService sizeDiscountService)
        {
            _unitOfWork = unitOfWork;
            _ingredientService = ingredientService;
            _comboService = comboService;
            _sizeDiscountService = sizeDiscountService;
        }

        public async Task<IEnumerable<Customization>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Customization>()
                .IncludeNested(query =>
                    query.Include(c => c.CustomizationIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.User)
                         .Include(c => c.Combo)
                         .Include(c => c.AppliedDiscount))
                .Where(c => !c.IsDelete)
                .ToListAsync();
        }


        public async Task<PagedResult<Customization>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<Customization>()
                .IncludeNested(query =>
                    query.Include(c => c.CustomizationIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.User)
                         .Include(c => c.Combo))
                .Where(c => !c.IsDelete);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Customization>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Customization?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Customization>()
                .IncludeNested(query =>
                    query.Include(c => c.CustomizationIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.User)
                         .Include(c => c.Combo)
                         .Include(c => c.AppliedDiscount))
                .FirstOrDefaultAsync(c => c.CustomizationId == id && !c.IsDelete);
        }

        public async Task<IEnumerable<Customization>> GetUserCustomizationsAsync(int userId)
        {
            return await _unitOfWork.Repository<Customization>()
                .IncludeNested(query =>
                    query.Include(c => c.CustomizationIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.Combo)
                         .Include(c => c.AppliedDiscount))
                .Where(c => c.UserID == userId && !c.IsDelete)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<Customization> CreateAsync(Customization entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Customization name cannot be empty");

            // Validate user exists
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == entity.UserID && !u.IsDelete);

            if (user == null)
                throw new ValidationException("Invalid user");

            // Validate HotpotBroth
            await ValidateHotpotBroth(entity.HotpotBrothID);

            // Calculate initial total price
            entity.BasePrice = await CalculateTotalPriceAsync(entity);

            _unitOfWork.Repository<Customization>().Insert(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<Customization> CreateCustomizationAsync(
    int comboId,
    int userId,
    string name,
    string? note,
    int size,
    int brothId,
    List<CustomizationIngredientDto> ingredients)
        {
            // Validation logic...

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Get applicable discount for this size
                var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(size);

                // Create new customization
                var customization = new Customization
                {
                    Name = name,
                    Note = note,
                    UserID = userId,
                    ComboID = comboId,
                    HotpotBrothID = brothId,
                    Size = size,
                    AppliedDiscountID = applicableDiscount?.SizeDiscountId,
                    BasePrice = 0 // Will calculate this below
                };

                _unitOfWork.Repository<Customization>().Insert(customization);
                await _unitOfWork.CommitAsync();

                // Calculate and update base price
                decimal basePrice = await CalculateBasePriceAsync(customization, ingredients);
                customization.BasePrice = basePrice;

                await _unitOfWork.Repository<Customization>().Update(customization, customization.CustomizationId);
                await _unitOfWork.CommitAsync();

                await transaction.CommitAsync();

                return await GetByIdAsync(customization.CustomizationId);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        // Helper method to calculate base price
        private async Task<decimal> CalculateBasePriceAsync(Customization customization, List<CustomizationIngredientDto> ingredients)
        {
            decimal basePrice = 0;

            // Add broth price
            var brothPrice = await _ingredientService.GetCurrentPriceAsync(customization.HotpotBrothID);
            basePrice += brothPrice;

            // Add ingredients prices
            foreach (var ingredientDto in ingredients)
            {
                var ingredientPrice = await _ingredientService.GetCurrentPriceAsync(ingredientDto.IngredientID);
                basePrice += ingredientPrice * ingredientDto.Quantity;

                // Also add the ingredient to the customization
                var customizationIngredient = new CustomizationIngredient
                {
                    CustomizationID = customization.CustomizationId,
                    IngredientID = ingredientDto.IngredientID,
                    Quantity = ingredientDto.Quantity
                };

                _unitOfWork.Repository<CustomizationIngredient>().Insert(customizationIngredient);
            }

            await _unitOfWork.CommitAsync();

            return basePrice;
        }

        public async Task UpdateAsync(int id, Customization customization)
        {
            var existingCustomization = await GetByIdAsync(id);
            if (existingCustomization == null)
                throw new NotFoundException($"Customization with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(customization.Name))
                throw new ValidationException("Customization name cannot be empty");

            if (customization.Size <= 0)
                throw new ValidationException("Size must be greater than 0");

            // Validate HotpotBroth if it's being changed
            if (existingCustomization.HotpotBrothID != customization.HotpotBrothID)
            {
                await ValidateHotpotBroth(customization.HotpotBrothID);
            }

            // Get applicable discount for this size if size changed
            if (existingCustomization.Size != customization.Size || !customization.AppliedDiscountID.HasValue)
            {
                var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(customization.Size);
                customization.AppliedDiscountID = applicableDiscount?.SizeDiscountId;

                // Recalculate total price with new discount
                if (applicableDiscount != null)
                {
                    customization.BasePrice = customization.BasePrice * (1 - (applicableDiscount.DiscountPercentage / 100m));
                }
                else
                {
                    customization.BasePrice = customization.BasePrice;
                }
            }

            // Update customization
            customization.SetUpdateDate();
            await _unitOfWork.Repository<Customization>().Update(customization, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, Customization entity, List<CustomizationIngredient> ingredients)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var existingCustomization = await GetByIdAsync(id);
                if (existingCustomization == null)
                    throw new NotFoundException($"Customization with ID {id} not found");

                // Validate basic properties
                if (string.IsNullOrWhiteSpace(entity.Name))
                    throw new ValidationException("Customization name cannot be empty");

                // Validate HotpotBroth if it's being changed
                if (existingCustomization.HotpotBrothID != entity.HotpotBrothID)
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

                // Update customization basic info
                entity.SetUpdateDate();
                await _unitOfWork.Repository<Customization>().Update(entity, id);
                await _unitOfWork.CommitAsync();

                // Remove existing ingredients
                var existingIngredients = await _unitOfWork.Repository<CustomizationIngredient>()
                    .FindAll(ci => ci.CustomizationID == id)
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
                    ingredient.CustomizationID = id;
                    _unitOfWork.Repository<CustomizationIngredient>().Insert(ingredient);
                }
                await _unitOfWork.CommitAsync();

                // Calculate and update total price
                entity.BasePrice = await CalculateTotalPriceAsync(id);
                await _unitOfWork.Repository<Customization>().Update(entity, id);
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
            var customization = await GetByIdAsync(id);
            if (customization == null)
                throw new NotFoundException($"Customization with ID {id} not found");

            // Check if this customization is used by any orders
            var isUsedByOrder = await _unitOfWork.Repository<OrderDetail>()
                .AnyAsync(od => od.CustomizationID == id && !od.IsDelete);

            if (isUsedByOrder)
                throw new ValidationException("Cannot delete this customization as it is used by existing orders");

            // Soft delete customization and related entities
            customization.SoftDelete();

            // Soft delete customization ingredients
            var customizationIngredients = await _unitOfWork.Repository<CustomizationIngredient>()
                .FindAll(ci => ci.CustomizationID == id && !ci.IsDelete)
                .ToListAsync();

            foreach (var ingredient in customizationIngredients)
            {
                ingredient.SoftDelete();
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task<CustomizationPriceEstimate> CalculatePriceEstimateAsync(
    int comboId,
    int size,
    int brothId,
    List<CustomizationIngredientDto> ingredients)
        {
            // Validation logic...

            // Calculate base price
            decimal basePrice = 0;

            // Add broth price
            var brothPrice = await _ingredientService.GetCurrentPriceAsync(brothId);
            basePrice += brothPrice;

            // Add ingredients prices
            var ingredientIds = ingredients.Select(i => i.IngredientID).ToList();
            var prices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

            foreach (var ingredient in ingredients)
            {
                if (prices.TryGetValue(ingredient.IngredientID, out decimal price))
                {
                    basePrice += price * ingredient.Quantity;
                }
                else
                {
                    throw new ValidationException($"Price not found for ingredient with ID {ingredient.IngredientID}");
                }
            }

            // Get applicable discount
            var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(size);
            decimal discountPercentage = applicableDiscount?.DiscountPercentage ?? 0;
            decimal discountAmount = basePrice * (discountPercentage / 100m);
            decimal totalPrice = basePrice - discountAmount;

            return new CustomizationPriceEstimate
            {
                BasePrice = basePrice,
                DiscountPercentage = discountPercentage,
                DiscountAmount = discountAmount,
                Total = totalPrice,
                Size = size
            };
        }


        public async Task<IEnumerable<CustomizationIngredient>> GetCustomizationIngredientsAsync(int customizationId)
        {
            return await _unitOfWork.Repository<CustomizationIngredient>()
                .Include(ci => ci.Ingredient)
                .Where(ci => ci.CustomizationID == customizationId && !ci.IsDelete)
                .ToListAsync();
        }

        public async Task AddIngredientToCustomizationAsync(int customizationId, int ingredientId, int quantity)
        {
            var customization = await GetByIdAsync(customizationId);
            if (customization == null)
                throw new NotFoundException($"Customization with ID {customizationId} not found");

            var ingredient = await _unitOfWork.Repository<Ingredient>()
                .IncludeNested(query => query.Include(i => i.IngredientType))
                .FirstOrDefaultAsync(i => i.IngredientId == ingredientId && !i.IsDelete);

            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {ingredientId} not found");

            // Don't allow adding broth as a regular ingredient
            if (ingredient.IngredientTypeID == BROTH_TYPE_ID)
                throw new ValidationException("Cannot add broth as a regular ingredient. Use HotpotBroth property instead.");

            // Check if ingredient already exists
            var existingIngredient = await _unitOfWork.Repository<CustomizationIngredient>()
                .FindAsync(ci => ci.CustomizationID == customizationId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (existingIngredient != null)
                throw new ValidationException("Ingredient already exists in customization");

            var customizationIngredient = new CustomizationIngredient
            {
                CustomizationID = customizationId,
                IngredientID = ingredientId,
                Quantity = quantity
            };

            _unitOfWork.Repository<CustomizationIngredient>().Insert(customizationIngredient);

            // Update total price
            customization.BasePrice = await CalculateTotalPriceAsync(customization);
            customization.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveIngredientFromCustomizationAsync(int customizationId, int ingredientId)
        {
            var customizationIngredient = await _unitOfWork.Repository<CustomizationIngredient>()
                .FindAsync(ci => ci.CustomizationID == customizationId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (customizationIngredient == null)
                throw new NotFoundException("Ingredient not found in customization");

            customizationIngredient.SoftDelete();

            // Update total price
            var customization = await GetByIdAsync(customizationId);
            if (customization != null)
            {
                customization.BasePrice = await CalculateTotalPriceAsync(customization);
                customization.SetUpdateDate();
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateIngredientQuantityAsync(int customizationId, int ingredientId, int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ValidationException("Quantity must be greater than 0");

            var customizationIngredient = await _unitOfWork.Repository<CustomizationIngredient>()
                .FindAsync(ci => ci.CustomizationID == customizationId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (customizationIngredient == null)
                throw new NotFoundException("Ingredient not found in customization");

            customizationIngredient.Quantity = newQuantity;
            customizationIngredient.SetUpdateDate();

            // Update total price
            var customization = await GetByIdAsync(customizationId);
            if (customization != null)
            {
                customization.BasePrice = await CalculateTotalPriceAsync(customization);
                customization.SetUpdateDate();
            }

            await _unitOfWork.CommitAsync();
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

        public async Task<decimal> CalculateTotalPriceAsync(int customizationId)
        {
            var customization = await GetByIdAsync(customizationId);
            if (customization == null)
                throw new NotFoundException($"Customization with ID {customizationId} not found");

            return await CalculateTotalPriceAsync(customization);
        }
        private async Task<decimal> CalculateTotalPriceAsync(Customization customization)
        {
            decimal totalPrice = 0;

            // Add hotpot broth price
            if (customization.HotpotBrothID > 0)
            {
                try
                {
                    var brothPrice = await _ingredientService.GetCurrentPriceAsync(customization.HotpotBrothID);
                    totalPrice += brothPrice;
                }
                catch (NotFoundException)
                {
                    // Handle case where broth price is not found
                    throw new ValidationException($"Price not found for broth with ID {customization.HotpotBrothID}");
                }
            }

            // Add ingredients prices
            var customizationIngredients = await _unitOfWork.Repository<CustomizationIngredient>()
                .IncludeNested(query => query.Include(ci => ci.Ingredient))
                .Where(ci => ci.CustomizationID == customization.CustomizationId && !ci.IsDelete)
                .ToListAsync();

            // Get all ingredient IDs
            var ingredientIds = customizationIngredients.Select(ci => ci.IngredientID).ToList();

            // Get all current prices in a single query
            var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

            foreach (var customizationIngredient in customizationIngredients)
            {
                if (currentPrices.TryGetValue(customizationIngredient.IngredientID, out decimal price))
                {
                    totalPrice += price * customizationIngredient.Quantity;
                }
                else
                {
                    throw new ValidationException($"Price not found for ingredient with ID {customizationIngredient.IngredientID}");
                }
            }

            return totalPrice;
        }

        public async Task<PagedResult<Customization>> SearchAsync(string searchTerm, int pageNumber, int pageSize)
        {
            searchTerm = searchTerm?.ToLower() ?? "";

            var query = _unitOfWork.Repository<Customization>()
                .IncludeNested(q =>
                    q.Include(c => c.CustomizationIngredients)
                     .ThenInclude(ci => ci.Ingredient)
                     .Include(c => c.HotpotBroth)
                     .Include(c => c.User)
                     .Include(c => c.Combo))
                .Where(c => !c.IsDelete &&
                           (c.Name.ToLower().Contains(searchTerm) ||
                            c.HotpotBroth.Name.ToLower().Contains(searchTerm) ||
                            c.User.Name.ToLower().Contains(searchTerm)));

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Customization>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public decimal GetTotalPrice(Customization customization)
        {
            if (customization.AppliedDiscount == null)
                return customization.BasePrice;

            return customization.BasePrice * (1 - (customization.AppliedDiscount.DiscountPercentage / 100m));
        }
    }
}
