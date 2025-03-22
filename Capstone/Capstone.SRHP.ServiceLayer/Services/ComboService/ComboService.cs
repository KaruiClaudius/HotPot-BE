using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
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
    public class ComboService : IComboService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIngredientService _ingredientService;
        private readonly ISizeDiscountService _sizeDiscountService;
        private readonly ILogger<ComboService> _logger;
        private const int BROTH_TYPE_ID = 1; // Adjust this to match your broth type ID

        public ComboService(IUnitOfWork unitOfWork, IIngredientService ingredientService, ISizeDiscountService sizeDiscountService, ILogger<ComboService> logger)
        {
            _unitOfWork = unitOfWork;
            _ingredientService = ingredientService;
            _sizeDiscountService = sizeDiscountService;
            _logger = logger;
        }

        public async Task<PagedResult<Combo>> GetCombosAsync(
            string searchTerm = null,
            bool? isCustomizable = null,
            bool activeOnly = true,
            int? minSize = null,
            int? maxSize = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "Name",
            bool ascending = true)
        {
            // Validate pagination parameters
            if (pageNumber < 1)
                pageNumber = 1;

            if (pageSize < 1)
                pageSize = 10;

            // Start building the query with includes
            var query = _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.AppliedDiscount)
                         .Include(c => c.TurtorialVideo)
                         .Include(c => c.AllowedIngredientTypes)
                         .ThenInclude(ait => ait.IngredientType));

            // Apply active-only filter if requested
            if (activeOnly)
            {
                query = query.Where(c => !c.IsDelete);
            }

            // Apply search term filter if provided
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(c =>
                    c.Name.ToLower().Contains(searchTerm) ||
                    (c.Description != null && c.Description.ToLower().Contains(searchTerm)) ||
                    c.HotpotBroth.Name.ToLower().Contains(searchTerm));
            }

            // Apply customizable filter if provided
            if (isCustomizable.HasValue)
            {
                query = query.Where(c => c.IsCustomizable == isCustomizable.Value);
            }

            // Apply size range filters if provided
            if (minSize.HasValue)
            {
                query = query.Where(c => c.Size >= minSize.Value);
            }

            if (maxSize.HasValue)
            {
                query = query.Where(c => c.Size <= maxSize.Value);
            }

            // Apply price range filters if provided
            if (minPrice.HasValue)
            {
                query = query.Where(c => c.BasePrice >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(c => c.BasePrice <= maxPrice.Value);
            }

            // Count total results before applying pagination
            var totalCount = await query.CountAsync();

            // Apply sorting
            query = ApplySorting(query, sortBy, ascending);

            // Apply pagination
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return paged result
            return new PagedResult<Combo>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        // Helper method to apply sorting based on property name
        private IQueryable<Combo> ApplySorting(IQueryable<Combo> query, string sortBy, bool ascending)
        {
            // Default to sorting by Name if sortBy is invalid
            switch (sortBy.ToLower())
            {
                case "name":
                    return ascending
                        ? query.OrderBy(c => c.Name)
                        : query.OrderByDescending(c => c.Name);
                case "size":
                    return ascending
                        ? query.OrderBy(c => c.Size)
                        : query.OrderByDescending(c => c.Size);
                case "price":
                case "baseprice":
                    return ascending
                        ? query.OrderBy(c => c.BasePrice)
                        : query.OrderByDescending(c => c.BasePrice);
                case "totalprice":
                    return ascending
                        ? query.OrderBy(c => c.TotalPrice)
                        : query.OrderByDescending(c => c.TotalPrice);
                case "createdate":
                case "created":
                    return ascending
                        ? query.OrderBy(c => c.CreatedAt)
                        : query.OrderByDescending(c => c.CreatedAt);
                case "updatedate":
                case "updated":
                    return ascending
                        ? query.OrderBy(c => c.UpdatedAt)
                        : query.OrderByDescending(c => c.UpdatedAt);
                default:
                    return ascending
                        ? query.OrderBy(c => c.Name)
                        : query.OrderByDescending(c => c.Name);
            }
        }

        public async Task<Combo> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.AppliedDiscount)
                         .Include(c => c.TurtorialVideo)
                         .Include(c => c.AllowedIngredientTypes)
                         .ThenInclude(ait => ait.IngredientType))
                .FirstOrDefaultAsync(c => c.ComboId == id && !c.IsDelete);
        }


        public async Task<Combo> CreateComboWithVideoAsync(
        Combo combo,
        TurtorialVideo video,
        List<ComboIngredient> baseIngredients = null,
        List<ComboAllowedIngredientType> allowedTypes = null)
        {
            return await _unitOfWork.ExecuteInTransactionAsync<Combo>(async () =>
            {
                // Validate basic combo properties
                if (string.IsNullOrWhiteSpace(combo.Name))
                    throw new ValidationException("Combo name cannot be empty");

                if (combo.Size <= 0)
                    throw new ValidationException("Combo size must be greater than 0");

                // Validate video properties if provided
                if (video != null)
                {
                    if (string.IsNullOrWhiteSpace(video.Name))
                        throw new ValidationException("Video name cannot be empty");

                    if (string.IsNullOrWhiteSpace(video.VideoURL))
                        throw new ValidationException("Video URL cannot be empty");

                    // Validate URL format
                    if (!Uri.TryCreate(video.VideoURL, UriKind.Absolute, out _) && !video.VideoURL.StartsWith("/"))
                        throw new ValidationException($"Invalid video URL format: {video.VideoURL}");
                }

                // Validate image URLs if provided
                if (combo.ImageURLs != null && combo.ImageURLs.Length > 0)
                {
                    foreach (var url in combo.ImageURLs)
                    {
                        if (string.IsNullOrWhiteSpace(url))
                            throw new ValidationException("Image URLs cannot be empty");

                        if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
                            throw new ValidationException($"Invalid image URL format: {url}");
                    }
                }

                // Check if combo name exists
                var nameExists = await _unitOfWork.Repository<Combo>()
                    .AnyAsync(c => c.Name == combo.Name && !c.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Combo with name {combo.Name} already exists");

                // Validate HotpotBroth
                await ValidateHotpotBroth(combo.HotpotBrothId);

                // If combo is customizable, ensure allowed types are provided
                if (combo.IsCustomizable && (allowedTypes == null || allowedTypes.Count == 0))
                    throw new ValidationException("Customizable combos must have at least one allowed ingredient type");

                // First create the tutorial video if provided
                if (video != null)
                {
                    _unitOfWork.Repository<TurtorialVideo>().Insert(video);
                    await _unitOfWork.CommitAsync();

                    // Set the video ID on the combo
                    combo.TurtorialVideoId = video.TurtorialVideoId;
                }

                // Set initial base price (will be updated after ingredients are added)
                combo.BasePrice = 0;
                combo.TotalPrice = 0;

                // Get applicable discount for this size
                var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(combo.Size);
                combo.AppliedDiscountId = applicableDiscount?.SizeDiscountId;

                // Insert combo
                _unitOfWork.Repository<Combo>().Insert(combo);
                await _unitOfWork.CommitAsync();

                // Add base ingredients if provided
                if (baseIngredients != null && baseIngredients.Count > 0)
                {
                    foreach (var ingredient in baseIngredients)
                    {
                        // Validate ingredient exists
                        var ingredientExists = await _unitOfWork.Repository<Ingredient>()
                            .AnyAsync(i => i.IngredientId == ingredient.IngredientId && !i.IsDelete);

                        if (!ingredientExists)
                            throw new ValidationException($"Ingredient with ID {ingredient.IngredientId} not found");

                        // Validate quantity is positive
                        if (ingredient.Quantity <= 0)
                            throw new ValidationException("Ingredient quantity must be greater than 0");

                        ingredient.ComboId = combo.ComboId;
                        _unitOfWork.Repository<ComboIngredient>().Insert(ingredient);
                    }
                    await _unitOfWork.CommitAsync();
                }

                // Add allowed ingredient types if this is a customizable combo
                if (combo.IsCustomizable && allowedTypes != null && allowedTypes.Count > 0)
                {
                    foreach (var allowedType in allowedTypes)
                    {
                        // Validate ingredient type exists
                        var typeExists = await _unitOfWork.Repository<IngredientType>()
                            .AnyAsync(it => it.IngredientTypeId == allowedType.IngredientTypeId && !it.IsDelete);

                        if (!typeExists)
                            throw new ValidationException($"Ingredient type with ID {allowedType.IngredientTypeId} not found");

                        if (allowedType.MinQuantity <= 0)
                            throw new ValidationException($"Min quantity for ingredient type must be greater than 0");

                        allowedType.ComboId = combo.ComboId;
                        _unitOfWork.Repository<ComboAllowedIngredientType>().Insert(allowedType);
                    }
                    await _unitOfWork.CommitAsync();
                }

                // Calculate base price and total price
                await UpdatePricesAsync(combo.ComboId);

                // Return the complete combo with all relationships loaded
                return await GetByIdAsync(combo.ComboId);
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Tạo Combo gặp trục trặc", ex);
                }
            });
        }

        public async Task UpdateAsync(int id, Combo combo)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var existingCombo = await GetByIdAsync(id);
                if (existingCombo == null)
                    throw new NotFoundException($"Combo with ID {id} not found");

                // Validate basic properties
                if (string.IsNullOrWhiteSpace(combo.Name))
                    throw new ValidationException("Combo name cannot be empty");

                if (combo.Size <= 0)
                    throw new ValidationException("Combo size must be greater than 0");

                // Note: We don't validate BasePrice here since we'll calculate it

                // Validate image URLs if provided
                if (combo.ImageURLs != null && combo.ImageURLs.Length > 0)
                {
                    foreach (var url in combo.ImageURLs)
                    {
                        if (string.IsNullOrWhiteSpace(url))
                            throw new ValidationException("Image URLs cannot be empty");

                        if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
                            throw new ValidationException($"Invalid image URL format: {url}");
                    }
                }

                // Check if combo name exists (excluding this one)
                var nameExists = await _unitOfWork.Repository<Combo>()
                    .AnyAsync(c => c.Name == combo.Name && c.ComboId != id && !c.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Another combo with name {combo.Name} already exists");

                // Validate HotpotBroth if it's being changed
                if (existingCombo.HotpotBrothId != combo.HotpotBrothId)
                {
                    await ValidateHotpotBroth(combo.HotpotBrothId);
                }

                // Validate TurtorialVideo if it's being changed
                if (existingCombo.TurtorialVideoId != combo.TurtorialVideoId)
                {
                    await ValidateTurtorialVideo(combo.TurtorialVideoId);
                }

                // Get applicable discount for this size if size changed
                if (existingCombo.Size != combo.Size || !combo.AppliedDiscountId.HasValue)
                {
                    var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(combo.Size);
                    combo.AppliedDiscountId = applicableDiscount?.SizeDiscountId;
                }

                // Update combo
                combo.SetUpdateDate();
                await _unitOfWork.Repository<Combo>().Update(combo, id);
                await _unitOfWork.CommitAsync();

                // Recalculate prices
                await UpdatePricesAsync(id);
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
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
           {
               var combo = await GetByIdAsync(id);
               if (combo == null)
                   throw new NotFoundException($"Combo with ID {id} not found");

               // Check if this combo is used by any customizations or orders
               var isUsedByCustomization = await _unitOfWork.Repository<Customization>()
                     .AnyAsync(c => c.ComboId == id && !c.IsDelete);

               var isUsedByOrder = await _unitOfWork.Repository<SellOrderDetail>()
                     .AnyAsync(od => od.ComboId == id && !od.IsDelete);

               if (isUsedByCustomization || isUsedByOrder)
                   throw new ValidationException("Cannot delete this combo as it is used by existing customizations or orders");

               // Check if the tutorial video is used by other combos
               var videoId = combo.TurtorialVideoId;
               var videoUsedByOtherCombos = await _unitOfWork.Repository<Combo>()
                     .AnyAsync(c => c.TurtorialVideoId == videoId && c.ComboId != id && !c.IsDelete);

               // Soft delete combo and related entities
               combo.SoftDelete();

               // Soft delete combo ingredients
               var comboIngredients = await _unitOfWork.Repository<ComboIngredient>()
                     .FindAll(ci => ci.ComboId == id && !ci.IsDelete)
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

               // If the tutorial video is not used by other combos, soft delete it too
               if (!videoUsedByOtherCombos)
               {
                   var video = await _unitOfWork.Repository<TurtorialVideo>()
                         .FindAsync(tv => tv.TurtorialVideoId == videoId && !tv.IsDelete);

                   if (video != null)
                   {
                       video.SoftDelete();
                   }
               }

               await _unitOfWork.CommitAsync();
           },
       ex =>
       {
           // Only log for exceptions that aren't validation or not found
           if (!(ex is NotFoundException || ex is ValidationException))
           {
               _logger.LogError(ex, "Xoá gặp trục trặc", ex);
           }
       });
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
                .FindAll(i => i.IngredientTypeId == ingredientTypeId && i.Quantity > 0 && !i.IsDelete)
                .ToListAsync();
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


        public async Task<IEnumerable<ComboIngredient>> GetComboIngredientsAsync(int comboId)
        {
            return await _unitOfWork.Repository<ComboIngredient>()
                .Include(ci => ci.Ingredient)
                .Where(ci => ci.ComboId == comboId && !ci.IsDelete)
                .ToListAsync();
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


        private async Task ValidateTurtorialVideo(int turtorialVideoId)
        {
            var turtorialVideo = await _unitOfWork.Repository<TurtorialVideo>()
                .FindAsync(tv => tv.TurtorialVideoId == turtorialVideoId && !tv.IsDelete);

            if (turtorialVideo == null)
                throw new ValidationException($"Tutorial video with ID {turtorialVideoId} not found");
        }


        // Method to update prices when ingredients change
        public async Task UpdatePricesAsync(int comboId)
        {
            var combo = await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.HotpotBroth)
                         .Include(c => c.AppliedDiscount))
                .FirstOrDefaultAsync(c => c.ComboId == comboId && !c.IsDelete);

            if (combo == null)
                throw new NotFoundException($"Combo with ID {comboId} not found");

            // Calculate base price from ingredients
            decimal basePrice = 0;

            // Add hotpot broth price
            if (combo.HotpotBrothId > 0)
            {
                var brothPrice = await _ingredientService.GetCurrentPriceAsync(combo.HotpotBrothId);
                basePrice += brothPrice;
            }

            // Add prices of all ingredients
            foreach (var comboIngredient in combo.ComboIngredients.Where(ci => !ci.IsDelete))
            {
                var ingredientPrice = await _ingredientService.GetCurrentPriceAsync(comboIngredient.IngredientId);
                basePrice += ingredientPrice * comboIngredient.Quantity;
            }

            // Calculate per-person base price
            if (combo.Size > 0)
            {
                basePrice = basePrice / combo.Size;
            }

            // Update base price
            combo.BasePrice = basePrice;

            // Calculate total price (after discount)
            decimal totalPrice = basePrice;
            if (combo.AppliedDiscount != null)
            {
                decimal discountPercentage = combo.AppliedDiscount.DiscountPercentage;
                totalPrice = basePrice * (1 - (discountPercentage / 100m));
            }

            // Update total price
            combo.TotalPrice = totalPrice;

            // Update the combo
            combo.SetUpdateDate();
            await _unitOfWork.Repository<Combo>().Update(combo, comboId);
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Combo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Combo> CreateAsync(Combo entity)
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
