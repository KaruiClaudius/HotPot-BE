using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Customization;
using Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
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
                    query = query.Where(c => c.UserId == userId.Value);
                }

                if (comboId.HasValue)
                {
                    query = query.Where(c => c.ComboId == comboId.Value);
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
                        .Where(ci => ci.CustomizationId == customization.CustomizationId && !ci.IsDelete)
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
                        .Where(ci => ci.CustomizationId == id && !ci.IsDelete)
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

            return await _unitOfWork.ExecuteInTransactionAsync<Customization>(async () =>
            {
                // Get applicable discount for this size
                var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(size);

                // Create new customization
                var customization = new Customization
                {
                    Name = name,
                    Note = note,
                    UserId = userId,
                    ComboId = comboId,
                    HotpotBrothId = brothId,
                    Size = size,
                    AppliedDiscountId = applicableDiscount?.SizeDiscountId,
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
                        var allowedType = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                            .FindAsync(ait => ait.ComboId == comboId &&
                                                 ait.IngredientTypeId == ingredient.IngredientTypeId &&
                                                 !ait.IsDelete);

                        if (allowedType == null)
                            throw new ValidationException($"Ingredient type of ingredient {ingredientDto.IngredientID} is not allowed for this combo");

                        // Validate minimum quantity requirement
                        if (ingredientDto.Quantity < allowedType.MinQuantity)
                            throw new ValidationException($"Ingredient {ingredient.Name} quantity must be at least {allowedType.MinQuantity}");

                    }

                    // Add ingredient to customization
                    var customizationIngredient = new CustomizationIngredient
                    {
                        CustomizationId = customization.CustomizationId,
                        IngredientId = ingredientDto.IngredientID,
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

                return await GetByIdAsync(customization.CustomizationId) ?? throw new InvalidOperationException("Customization creation failed");
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "tạo tùy chỉnh gặp trục trặc", ex);
                }
            });
        }



        public async Task UpdateAsync(int id, Customization entity, List<CustomizationIngredientDto> ingredients)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
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
                if (existingCustomization.HotpotBrothId != entity.HotpotBrothId)
                {
                    await ValidateHotpotBroth(entity.HotpotBrothId);
                }

                // Get applicable discount for this size if size changed
                if (existingCustomization.Size != entity.Size || !entity.AppliedDiscountId.HasValue)
                {
                    var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(entity.Size);
                    entity.AppliedDiscountId = applicableDiscount?.SizeDiscountId;
                }

                // Update customization basic info
                entity.SetUpdateDate();
                await _unitOfWork.Repository<Customization>().Update(entity, id);
                await _unitOfWork.CommitAsync();

                // Remove existing ingredients
                var existingIngredients = await _unitOfWork.Repository<CustomizationIngredient>()
                    .FindAll(ci => ci.CustomizationId == id)
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
                var brothPrice = await _ingredientService.GetCurrentPriceAsync(entity.HotpotBrothId);
                basePrice += brothPrice;

                // Get the combo for validation
                var combo = await _comboService.GetByIdAsync(entity.ComboId);

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
                    if (combo != null && combo.IsCustomizable)
                    {
                        // Check if ingredient type is allowed
                        var allowedType = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                            .FindAsync(ait => ait.ComboId == entity.ComboId &&
                                                ait.IngredientTypeId == ingredient.IngredientTypeId &&
                                                !ait.IsDelete);

                        if (allowedType == null)
                            throw new ValidationException($"Ingredient type of ingredient {ingredientDto.IngredientID} is not allowed for this combo");

                        // Validate minimum quantity requirement
                        if (ingredientDto.Quantity < allowedType.MinQuantity)
                            throw new ValidationException($"Ingredient {ingredient.Name} quantity must be at least {allowedType.MinQuantity}");
                    }

                    // Add ingredient to customization
                    var customizationIngredient = new CustomizationIngredient
                    {
                        CustomizationId = id,
                        IngredientId = ingredientDto.IngredientID,
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
                if (entity.AppliedDiscountId.HasValue)
                {
                    var discount = await _sizeDiscountService.GetByIdAsync(entity.AppliedDiscountId.Value);
                    if (discount != null)
                    {
                        totalPrice = basePrice * (1 - (discount.DiscountPercentage / 100m));
                    }
                }

                // Update total price
                entity.TotalPrice = totalPrice;
                await _unitOfWork.Repository<Customization>().Update(entity, id);
                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Cập nhật gặp trục trặc", ex);
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var customization = await GetByIdAsync(id);
                if (customization == null)
                    throw new NotFoundException($"Customization with ID {id} not found");

                // Check if this customization is used by any orders
                var isUsedByOrder = await _unitOfWork.Repository<SellOrderDetail>()
                    .AnyAsync(od => od.CustomizationId == id && !od.IsDelete);

                if (isUsedByOrder)
                    throw new ValidationException("Cannot delete this customization as it is used by existing orders");

                // Soft delete customization
                customization.SoftDelete();
                await _unitOfWork.CommitAsync();

                // Soft delete customization ingredients
                var customizationIngredients = await _unitOfWork.Repository<CustomizationIngredient>()
                    .FindAll(ci => ci.CustomizationId == id && !ci.IsDelete)
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


        public async Task<CustomizationPriceEstimate> CalculatePriceEstimateAsync(int comboId, int size, int brothId, List<CustomizationIngredientDto> ingredients)
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
                        var allowedType = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                            .FindAsync(ait => ait.ComboId == comboId &&
                                                 ait.IngredientTypeId == ingredient.IngredientTypeId &&
                                                 !ait.IsDelete);

                        if (allowedType == null)
                            throw new ValidationException($"Ingredient type of ingredient {ingredientDto.IngredientID} is not allowed for this combo");

                        // Validate minimum quantity requirement
                        if (ingredientDto.Quantity < allowedType.MinQuantity)
                            throw new ValidationException($"Ingredient {ingredient.Name} quantity must be at least {allowedType.MinQuantity}");

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

            if (broth.IngredientTypeId != BROTH_TYPE_ID)
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

        #region Measurement Unit Helpers

        // Helper method to standardize measurement unit format
        private string StandardizeMeasurementUnit(string unit)
        {
            if (string.IsNullOrWhiteSpace(unit))
                return "g"; // Default to grams for ingredients

            unit = unit.Trim().ToLower();

            // Map various forms to standard abbreviations
            return unit switch
            {
                "gram" or "grams" => "g",
                "kilogram" or "kilograms" => "kg",
                "milliliter" or "milliliters" => "ml",
                "liter" or "liters" => "l",
                "piece" or "pieces" => "pcs",
                "teaspoon" or "teaspoons" => "tsp",
                "tablespoon" or "tablespoons" => "tbsp",
                "cup" or "cups" => "cup",
                "ounce" or "ounces" => "oz",
                "pound" or "pounds" => "lb",
                _ => unit // Keep as is if it's already standardized
            };
        }

        // Helper method to convert between measurement units
        private decimal ConvertMeasurement(decimal quantity, string fromUnit, string toUnit)
        {
            // Standardize units
            fromUnit = StandardizeMeasurementUnit(fromUnit);
            toUnit = StandardizeMeasurementUnit(toUnit);

            // If units are the same, no conversion needed
            if (fromUnit == toUnit)
                return quantity;

            // Weight conversions
            if (IsWeightUnit(fromUnit) && IsWeightUnit(toUnit))
            {
                return ConvertWeight(quantity, fromUnit, toUnit);
            }

            // Volume conversions
            if (IsVolumeUnit(fromUnit) && IsVolumeUnit(toUnit))
            {
                return ConvertVolume(quantity, fromUnit, toUnit);
            }

            // Cannot convert between different types (weight to volume, etc.)
            throw new InvalidOperationException($"Cannot convert from {fromUnit} to {toUnit}");
        }

        private bool IsWeightUnit(string unit)
        {
            return unit is "g" or "kg" or "oz" or "lb";
        }

        private bool IsVolumeUnit(string unit)
        {
            return unit is "ml" or "l" or "tsp" or "tbsp" or "cup";
        }

        private decimal ConvertWeight(decimal quantity, string fromUnit, string toUnit)
        {
            // Convert to grams first
            decimal grams = fromUnit switch
            {
                "g" => quantity,
                "kg" => quantity * 1000,
                "oz" => quantity * 28.35m,
                "lb" => quantity * 453.592m,
                _ => throw new ArgumentException($"Unsupported weight unit: {fromUnit}")
            };

            // Convert from grams to target unit
            return toUnit switch
            {
                "g" => grams,
                "kg" => grams / 1000,
                "oz" => grams / 28.35m,
                "lb" => grams / 453.592m,
                _ => throw new ArgumentException($"Unsupported weight unit: {toUnit}")
            };
        }

        private decimal ConvertVolume(decimal quantity, string fromUnit, string toUnit)
        {
            // Convert to milliliters first
            decimal ml = fromUnit switch
            {
                "ml" => quantity,
                "l" => quantity * 1000,
                "tsp" => quantity * 4.929m,
                "tbsp" => quantity * 14.787m,
                "cup" => quantity * 236.588m,
                _ => throw new ArgumentException($"Unsupported volume unit: {fromUnit}")
            };

            // Convert from milliliters to target unit
            return toUnit switch
            {
                "ml" => ml,
                "l" => ml / 1000,
                "tsp" => ml / 4.929m,
                "tbsp" => ml / 14.787m,
                "cup" => ml / 236.588m,
                _ => throw new ArgumentException($"Unsupported volume unit: {toUnit}")
            };
        }

        #endregion
    }
}
