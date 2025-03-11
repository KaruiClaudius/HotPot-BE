using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Customization;
using Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CustomizationService> _logger;
        private const int BROTH_TYPE_ID = 1;

        public CustomizationService(
            IUnitOfWork unitOfWork,
            IIngredientService ingredientService,
            IComboService comboService,
            ISizeDiscountService sizeDiscountService,
            ILogger<CustomizationService> logger)
        {
            _unitOfWork = unitOfWork;
            _ingredientService = ingredientService;
            _comboService = comboService;
            _sizeDiscountService = sizeDiscountService;
            _logger = logger;
        }

        public async Task<PagedResult<Customization>> GetCustomizationsAsync(
                string searchTerm = null,
                int? userId = null,
                int? comboId = null,
                int? minSize = null,
                int? maxSize = null,
                decimal? minPrice = null,
                decimal? maxPrice = null,
                int pageNumber = 1,
                int pageSize = 10,
                string sortBy = "CreatedAt",
                bool ascending = false)
        {
            try
            {
                // Start with base query
                var query = _unitOfWork.Repository<Customization>()
                    .IncludeNested(q => q
                        .Include(c => c.HotpotBroth)
                        .Include(c => c.User)
                        .Include(c => c.Combo)
                        .Include(c => c.AppliedDiscount))
                    .Where(c => !c.IsDelete);

                // Apply filters
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(c =>
                        c.Name.ToLower().Contains(searchTerm) ||
                        (c.Note != null && c.Note.ToLower().Contains(searchTerm)) ||
                        c.HotpotBroth.Name.ToLower().Contains(searchTerm) ||
                        c.Combo.Name.ToLower().Contains(searchTerm));
                }

                if (userId.HasValue)
                {
                    query = query.Where(c => c.UserID == userId.Value);
                }

                if (comboId.HasValue)
                {
                    query = query.Where(c => c.ComboID == comboId.Value);
                }

                if (minSize.HasValue)
                {
                    query = query.Where(c => c.Size >= minSize.Value);
                }

                if (maxSize.HasValue)
                {
                    query = query.Where(c => c.Size <= maxSize.Value);
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(c => c.TotalPrice >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(c => c.TotalPrice <= maxPrice.Value);
                }

                // Get total count before applying pagination
                var totalCount = await query.CountAsync();

                // Apply sorting
                IOrderedQueryable<Customization> orderedQuery;

                switch (sortBy?.ToLower())
                {
                    case "name":
                        orderedQuery = ascending ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name);
                        break;
                    case "price":
                        orderedQuery = ascending ? query.OrderBy(c => c.TotalPrice) : query.OrderByDescending(c => c.TotalPrice);
                        break;
                    case "size":
                        orderedQuery = ascending ? query.OrderBy(c => c.Size) : query.OrderByDescending(c => c.Size);
                        break;
                    case "combo":
                        orderedQuery = ascending ? query.OrderBy(c => c.Combo.Name) : query.OrderByDescending(c => c.Combo.Name);
                        break;
                    case "updatedat":
                        orderedQuery = ascending ? query.OrderBy(c => c.UpdatedAt) : query.OrderByDescending(c => c.UpdatedAt);
                        break;
                    default: // Default to CreatedAt
                        orderedQuery = ascending ? query.OrderBy(c => c.CreatedAt) : query.OrderByDescending(c => c.CreatedAt);
                        break;
                }

                // Apply pagination
                var items = await orderedQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Load ingredients for each customization
                foreach (var customization in items)
                {
                    customization.CustomizationIngredients = await _unitOfWork.Repository<CustomizationIngredient>()
                        .Include(ci => ci.Ingredient)
                        .Where(ci => ci.CustomizationID == customization.CustomizationId && !ci.IsDelete)
                        .ToListAsync();
                }

                return new PagedResult<Customization>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving customizations with filters");
                throw;
            }
        }

        public async Task<Customization?> GetByIdAsync(int id)
        {
            try
            {
                var customization = await _unitOfWork.Repository<Customization>()
                    .IncludeNested(q => q
                        .Include(c => c.HotpotBroth)
                        .Include(c => c.User)
                        .Include(c => c.Combo)
                        .Include(c => c.AppliedDiscount))
                    .FirstOrDefaultAsync(c => c.CustomizationId == id && !c.IsDelete);

                if (customization != null)
                {
                    // Load ingredients
                    customization.CustomizationIngredients = await _unitOfWork.Repository<CustomizationIngredient>()
                        .Include(ci => ci.Ingredient)
                        .Where(ci => ci.CustomizationID == id && !ci.IsDelete)
                        .ToListAsync();
                }

                return customization;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving customization with ID {CustomizationId}", id);
                throw;
            }
        }

        public async Task<Customization> CreateCustomizationAsync(
        int comboId,
        int userId,
        string name,
        string? note,
        int size,
        int brothId,
        List<CustomizationIngredientDto> ingredients,
        string[]? imageURLs = null)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Customization name cannot be empty");

            if (size <= 0)
                throw new ValidationException("Size must be greater than 0");

            // Get the combo
            var combo = await _comboService.GetByIdAsync(comboId);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {comboId} not found");

            if (!combo.IsCustomizable)
                throw new ValidationException("This combo is not customizable");

            // Validate user
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == userId && !u.IsDelete);

            if (user == null)
                throw new ValidationException($"User with ID {userId} not found");

            // Validate broth
            await ValidateHotpotBroth(brothId);

            // Validate image URLs if provided
            if (imageURLs != null && imageURLs.Length > 0)
            {
                foreach (var url in imageURLs)
                {
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        throw new ValidationException("Image URLs cannot be empty");
                    }

                    // Optional: Add URL format validation if needed
                    if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
                    {
                        throw new ValidationException($"Invalid image URL format: {url}");
                    }
                }
            }

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
                    BasePrice = 0,
                    TotalPrice = 0,
                    ImageURLs = imageURLs
                };

                _unitOfWork.Repository<Customization>().Insert(customization);
                await _unitOfWork.CommitAsync();

                // Add ingredients and calculate base price
                decimal basePrice = 0;

                // Add broth price
                var brothPrice = await _ingredientService.GetCurrentPriceAsync(brothId);
                basePrice += brothPrice;

                // Add selected ingredients
                foreach (var ingredientDto in ingredients)
                {
                    // Validate ingredient exists
                    var ingredient = await _unitOfWork.Repository<Ingredient>()
                        .FindAsync(i => i.IngredientId == ingredientDto.IngredientID && !i.IsDelete);

                    if (ingredient == null)
                        throw new ValidationException($"Ingredient with ID {ingredientDto.IngredientID} not found");

                    // Validate quantity
                    if (ingredientDto.Quantity <= 0)
                        throw new ValidationException("Ingredient quantity must be greater than 0");

                    // If this is a customizable combo, validate that the ingredient is allowed
                    if (combo.IsCustomizable)
                    {
                        // Check if ingredient type is allowed
                        var isTypeAllowed = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                            .AnyAsync(ait => ait.ComboId == comboId && ait.IngredientTypeId == ingredient.IngredientTypeID && !ait.IsDelete);

                        if (!isTypeAllowed)
                            throw new ValidationException($"Ingredient type of ingredient {ingredientDto.IngredientID} is not allowed for this combo");
                    }

                    // Add ingredient to customization
                    var customizationIngredient = new CustomizationIngredient
                    {
                        CustomizationID = customization.CustomizationId,
                        IngredientID = ingredientDto.IngredientID,
                        Quantity = ingredientDto.Quantity
                    };

                    _unitOfWork.Repository<CustomizationIngredient>().Insert(customizationIngredient);

                    // Add to base price
                    var ingredientPrice = await _ingredientService.GetCurrentPriceAsync(ingredientDto.IngredientID);
                    basePrice += ingredientPrice * ingredientDto.Quantity;
                }

                // Update base price
                customization.BasePrice = basePrice;

                // Calculate total price with discount
                decimal totalPrice = basePrice;
                if (applicableDiscount != null)
                {
                    totalPrice = basePrice * (1 - (applicableDiscount.DiscountPercentage / 100m));
                }

                // Update total price
                customization.TotalPrice = totalPrice;
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

       

        public async Task UpdateAsync(int id, Customization entity, List<CustomizationIngredientDto> ingredients)
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

                if (entity.Size <= 0)
                    throw new ValidationException("Size must be greater than 0");

                // Validate image URLs if provided
                if (entity.ImageURLs != null && entity.ImageURLs.Length > 0)
                {
                    foreach (var url in entity.ImageURLs)
                    {
                        if (string.IsNullOrWhiteSpace(url))
                        {
                            throw new ValidationException("Image URLs cannot be empty");
                        }

                        // Optional: Add URL format validation if needed
                        if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
                        {
                            throw new ValidationException($"Invalid image URL format: {url}");
                        }
                    }
                }

                // Validate HotpotBroth if it's being changed
                if (existingCustomization.HotpotBrothID != entity.HotpotBrothID)
                {
                    await ValidateHotpotBroth(entity.HotpotBrothID);
                }

                // Get applicable discount for this size if size changed
                if (existingCustomization.Size != entity.Size || !entity.AppliedDiscountID.HasValue)
                {
                    var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(entity.Size);
                    entity.AppliedDiscountID = applicableDiscount?.SizeDiscountId;
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
                decimal basePrice = 0;

                // Add broth price
                var brothPrice = await _ingredientService.GetCurrentPriceAsync(entity.HotpotBrothID);
                basePrice += brothPrice;

                // Add ingredients
                foreach (var ingredientDto in ingredients)
                {
                    // Validate ingredient exists
                    var ingredient = await _unitOfWork.Repository<Ingredient>()
                        .FindAsync(i => i.IngredientId == ingredientDto.IngredientID && !i.IsDelete);

                    if (ingredient == null)
                        throw new ValidationException($"Ingredient with ID {ingredientDto.IngredientID} not found");

                    // Validate quantity
                    if (ingredientDto.Quantity <= 0)
                        throw new ValidationException("Ingredient quantity must be greater than 0");

                    // If this is a customizable combo, validate that the ingredient is allowed
                    var combo = await _comboService.GetByIdAsync(entity.ComboID);
                    if (combo != null && combo.IsCustomizable)
                    {
                        // Check if ingredient type is allowed
                        var isTypeAllowed = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                            .AnyAsync(ait => ait.ComboId == entity.ComboID && ait.IngredientTypeId == ingredient.IngredientTypeID && !ait.IsDelete);

                        if (!isTypeAllowed)
                            throw new ValidationException($"Ingredient type of ingredient {ingredientDto.IngredientID} is not allowed for this combo");
                    }

                    // Add ingredient to customization
                    var customizationIngredient = new CustomizationIngredient
                    {
                        CustomizationID = id,
                        IngredientID = ingredientDto.IngredientID,
                        Quantity = ingredientDto.Quantity
                    };

                    _unitOfWork.Repository<CustomizationIngredient>().Insert(customizationIngredient);

                    // Add to base price
                    var ingredientPrice = await _ingredientService.GetCurrentPriceAsync(ingredientDto.IngredientID);
                    basePrice += ingredientPrice * ingredientDto.Quantity;
                }

                // Update base price
                entity.BasePrice = basePrice;

                // Calculate total price with discount
                decimal totalPrice = basePrice;
                if (entity.AppliedDiscountID.HasValue)
                {
                    var discount = await _sizeDiscountService.GetByIdAsync(entity.AppliedDiscountID.Value);
                    if (discount != null)
                    {
                        totalPrice = basePrice * (1 - (discount.DiscountPercentage / 100m));
                    }
                }

                // Update total price
                entity.TotalPrice = totalPrice;
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
            try
            {
                var customization = await GetByIdAsync(id);
                if (customization == null)
                    throw new NotFoundException($"Customization with ID {id} not found");

                // Check if this customization is used by any orders
                var isUsedByOrder = await _unitOfWork.Repository<OrderDetail>()
                    .AnyAsync(od => od.CustomizationID == id && !od.IsDelete);

                if (isUsedByOrder)
                    throw new ValidationException("Cannot delete this customization as it is used by existing orders");

                // Soft delete customization
                customization.SoftDelete();
                await _unitOfWork.CommitAsync();

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting customization with ID {CustomizationId}", id);
                throw;
            }
        }


        public async Task<CustomizationPriceEstimate> CalculatePriceEstimateAsync(
    int comboId,
    int size,
    int brothId,
    List<CustomizationIngredientDto> ingredients)
        {
            try
            {
                // Validate combo
                var combo = await _comboService.GetByIdAsync(comboId);
                if (combo == null)
                    throw new NotFoundException($"Combo with ID {comboId} not found");

                if (!combo.IsCustomizable)
                    throw new ValidationException("This combo is not customizable");

                // Validate broth
                await ValidateHotpotBroth(brothId);

                // Validate size
                if (size <= 0)
                    throw new ValidationException("Size must be greater than 0");

                // Calculate base price
                decimal basePrice = 0;

                // Add broth price
                var brothPrice = await _ingredientService.GetCurrentPriceAsync(brothId);
                basePrice += brothPrice;

                // Validate ingredients and add to price
                foreach (var ingredientDto in ingredients)
                {
                    // Validate ingredient exists
                    var ingredient = await _unitOfWork.Repository<Ingredient>()
                        .FindAsync(i => i.IngredientId == ingredientDto.IngredientID && !i.IsDelete);

                    if (ingredient == null)
                        throw new ValidationException($"Ingredient with ID {ingredientDto.IngredientID} not found");

                    // Validate quantity
                    if (ingredientDto.Quantity <= 0)
                        throw new ValidationException("Ingredient quantity must be greater than 0");

                    // If this is a customizable combo, validate that the ingredient is allowed
                    if (combo.IsCustomizable)
                    {
                        // Check if ingredient type is allowed
                        var isTypeAllowed = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                            .AnyAsync(ait => ait.ComboId == comboId && ait.IngredientTypeId == ingredient.IngredientTypeID && !ait.IsDelete);

                        if (!isTypeAllowed)
                            throw new ValidationException($"Ingredient type of ingredient {ingredientDto.IngredientID} is not allowed for this combo");
                    }

                    // Add to base price
                    var ingredientPrice = await _ingredientService.GetCurrentPriceAsync(ingredientDto.IngredientID);
                    basePrice += ingredientPrice * ingredientDto.Quantity;
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating price estimate");
                throw;
            }
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

        public Task<IEnumerable<Customization>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customization> CreateAsync(Customization entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Customization entity)
        {
            throw new NotImplementedException();
        }
    }
}
