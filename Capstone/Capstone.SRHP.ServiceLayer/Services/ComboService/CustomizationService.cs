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
using System.Text.Json;
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
                        .Include(c => c.User)
                        .Include(c => c.Combo)
                        .Include(c => c.AppliedDiscount))
                    .Where(c => !c.IsDelete);

                // Apply filters
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(i =>
                        EF.Functions.Collate(i.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        i.Note != null && EF.Functions.Collate(i.Note.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        EF.Functions.Collate(i.Combo.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm));
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
                _logger.LogError(ex, "Lỗi khi lấy thông tin tùy chỉnh với ID {CustomizationId}", id);
                throw;
            }
        }

        public async Task<Customization> CreateCustomizationAsync(
            int? comboId,
            int userId,
            string name,
            string? note,
            int size,
            List<CustomizationIngredientsRequest> ingredients,
            string[]? imageURLs = null)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Tên tùy chỉnh không được để trống");

            if (size <= 0)
                throw new ValidationException("Kích thước phải lớn hơn 0");

            if (ingredients == null || !ingredients.Any())
                throw new ValidationException("Danh sách nguyên liệu không được để trống");

            // Validate user
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == userId && !u.IsDelete);

            if (user == null)
                throw new ValidationException($"Không tìm thấy người dùng với ID {userId}");

            // Validate image URLs if provided
            if (imageURLs != null && imageURLs.Length > 0)
            {
                foreach (var url in imageURLs)
                {
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        throw new ValidationException("URL hình ảnh không được để trống");
                    }

                    // Optional: Add URL format validation if needed
                    if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
                    {
                        throw new ValidationException($"Định dạng URL hình ảnh không hợp lệ: {url}");
                    }
                }
            }

            // Fetch all ingredients to validate
            var ingredientIds = ingredients.Select(i => i.IngredientID).Distinct().ToList();
            var existingIngredients = await _unitOfWork.Repository<Ingredient>()
                .FindAll(i => ingredientIds.Contains(i.IngredientId) && !i.IsDelete)
                .ToListAsync();


            var missingIngredientIds = ingredientIds.Except(existingIngredients.Select(i => i.IngredientId)).ToList();
            if (missingIngredientIds.Any())
            {
                throw new ValidationException($"Không tìm thấy nguyên liệu với ID: {string.Join(", ", missingIngredientIds)}");
            }

            await ValidateCustomizationRules(ingredients, existingIngredients, size);


            return await _unitOfWork.ExecuteInTransactionAsync<Customization>(async () =>
            {
                // Check for soft-deleted customization with the same name for this user
                var existingCustomization = await _unitOfWork.Repository<Customization>()
                    .FindAsync(c => c.Name == name && c.UserId == userId && c.IsDelete);

                if (existingCustomization != null)
                {
                    // Reactivate the soft-deleted customization
                    existingCustomization.IsDelete = false;
                    existingCustomization.Note = note;
                    existingCustomization.ComboId = comboId;
                    existingCustomization.Size = size;
                    existingCustomization.ImageURL = imageURLs != null ? JsonSerializer.Serialize(imageURLs) : null;
                    existingCustomization.SetUpdateDate();

                    // Get applicable discount for this size
                    var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(size);
                    existingCustomization.AppliedDiscountId = applicableDiscount?.SizeDiscountId;

                    await _unitOfWork.Repository<Customization>().Update(existingCustomization, existingCustomization.CustomizationId);
                    await _unitOfWork.CommitAsync();

                    // Update ingredients
                    await UpdateCustomizationIngredientsAsync(existingCustomization.CustomizationId, ingredients);

                    // Recalculate prices
                    await UpdatePricesAsync(existingCustomization.CustomizationId);

                    return await GetByIdAsync(existingCustomization.CustomizationId) ??
                        throw new InvalidOperationException("Tạo tùy chỉnh thất bại");
                }

                // Get applicable discount for this size
                var newDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(size);

                // Create new customization
                var customization = new Customization
                {
                    Name = name,
                    Note = note,
                    UserId = userId,
                    ComboId = comboId,
                    Size = size,
                    AppliedDiscountId = newDiscount?.SizeDiscountId,
                    BasePrice = 0,
                    TotalPrice = 0,
                    ImageURLs = imageURLs
                };

                _unitOfWork.Repository<Customization>().Insert(customization);
                await _unitOfWork.CommitAsync();

                // Add selected ingredients
                foreach (var ingredientDto in ingredients)
                {
                    // Get the ingredient (we already validated it exists)
                    var ingredient = existingIngredients.First(i => i.IngredientId == ingredientDto.IngredientID);

                    // Validate quantity
                    if (ingredientDto.Quantity <= 0)
                        throw new ValidationException("Số lượng nguyên liệu phải lớn hơn 0");

                    // Add ingredient to customization
                    var customizationIngredient = new CustomizationIngredient
                    {
                        CustomizationId = customization.CustomizationId,
                        IngredientId = ingredientDto.IngredientID,
                        Quantity = ingredientDto.Quantity
                    };

                    _unitOfWork.Repository<CustomizationIngredient>().Insert(customizationIngredient);
                }

                await _unitOfWork.CommitAsync();

                // Calculate prices
                await UpdatePricesAsync(customization.CustomizationId);

                return await GetByIdAsync(customization.CustomizationId) ??
                    throw new InvalidOperationException("Tạo tùy chỉnh thất bại");
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Lỗi khi tạo tùy chỉnh", ex);
                }
            });
        }

        #region Validate Customization Rules
        private async Task ValidateCustomizationRules(
            List<CustomizationIngredientsRequest> ingredients,
            List<Ingredient> existingIngredients,
            int size)
        {
            // Rule 1: At least one ingredient with type 1 (Base)
            var hasBaseIngredient = existingIngredients
                .Where(i => i.IngredientTypeId == 1)
                .Any(i => ingredients.Any(req => req.IngredientID == i.IngredientId));

            if (!hasBaseIngredient)
            {
                throw new ValidationException("Phải chọn ít nhất một nguyên liệu cơ bản (loại 1)");
            }

            // Rule 2: Limit on types 2 and 7 (Meat and Seafood)
            var meatAndSeafoodLimit = size + 2;

            var meatAndSeafoodIngredients = existingIngredients
                .Where(i => i.IngredientTypeId == 2 || i.IngredientTypeId == 7)
                .Where(i => ingredients.Any(req => req.IngredientID == i.IngredientId))
                .ToList();

            var totalMeatAndSeafoodQuantity = ingredients
                .Where(req => meatAndSeafoodIngredients.Any(i => i.IngredientId == req.IngredientID))
                .Sum(req => req.Quantity);

            if (totalMeatAndSeafoodQuantity > meatAndSeafoodLimit)
            {
                throw new ValidationException($"Tổng số lượng thịt và hải sản không được vượt quá {meatAndSeafoodLimit}");
            }

            // Rule 3: Quantity limits for each ingredient
            var lowerLimit = Math.Max(1, size / 2); // Ensure minimum is at least 1
            var upperLimit = Math.Max(4, Math.Ceiling(size * 1.5));

            foreach (var ingredient in ingredients)
            {
                if (ingredient.Quantity < lowerLimit)
                {
                    var ingredientName = existingIngredients
                        .First(i => i.IngredientId == ingredient.IngredientID).Name;

                    throw new ValidationException($"Số lượng của {ingredientName} phải ít nhất {lowerLimit}");
                }

                if (ingredient.Quantity > upperLimit)
                {
                    var ingredientName = existingIngredients
                        .First(i => i.IngredientId == ingredient.IngredientID).Name;

                    throw new ValidationException($"Số lượng của {ingredientName} không được vượt quá {upperLimit}");
                }
            }

            // Additional validation: Check total quantity (optional)
            var totalQuantity = ingredients.Sum(i => i.Quantity);
            var recommendedTotalQuantity = size * 3; // This is just an example, adjust as needed

            if (totalQuantity < recommendedTotalQuantity)
            {
                // This could be a warning rather than an error
                _logger.LogWarning($"Tổng số lượng nguyên liệu ({totalQuantity}) thấp hơn khuyến nghị ({recommendedTotalQuantity})");
            }
        }
        #endregion

        #region Create Customization Backup

        //public async Task<Customization> CreateCustomizationAsync(
        //    int? comboId,  // Accept nullable comboId
        //    int userId,
        //    string name,
        //    string? note,
        //    int size,
        //    List<CustomizationIngredientsRequest> ingredients,
        //    string[]? imageURLs = null)
        //{
        //    // Validate inputs
        //    if (string.IsNullOrWhiteSpace(name))
        //        throw new ValidationException("Tên tùy chỉnh không được để trống");

        //    if (size <= 0)
        //        throw new ValidationException("Kích thước phải lớn hơn 0");

        //    // Treat comboId = 0 as null (create from scratch)
        //    if (comboId == 0)
        //    {
        //        comboId = null;
        //    }

        //    // Validate user
        //    var user = await _unitOfWork.Repository<User>()
        //        .FindAsync(u => u.UserId == userId && !u.IsDelete);

        //    if (user == null)
        //        throw new ValidationException($"Không tìm thấy người dùng với ID {userId}");

        //    // Validate image URLs if provided
        //    if (imageURLs != null && imageURLs.Length > 0)
        //    {
        //        foreach (var url in imageURLs)
        //        {
        //            if (string.IsNullOrWhiteSpace(url))
        //            {
        //                throw new ValidationException("URL hình ảnh không được để trống");
        //            }

        //            // Optional: Add URL format validation if needed
        //            if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
        //            {
        //                throw new ValidationException($"Định dạng URL hình ảnh không hợp lệ: {url}");
        //            }
        //        }
        //    }

        //    // Different validation paths based on whether this is a combo-based customization or from scratch
        //    Combo combo = null;
        //    List<ComboAllowedIngredientType> allowedTypes = null;

        //    if (comboId.HasValue)
        //    {
        //        // Get the combo
        //        combo = await _comboService.GetByIdAsync(comboId.Value);
        //        if (combo == null)
        //            throw new NotFoundException($"Không tìm thấy combo với ID {comboId}");

        //        if (!combo.IsCustomizable)
        //            throw new ValidationException("Combo này không thể tùy chỉnh");

        //        // Get all allowed ingredient types for this combo
        //        allowedTypes = await _unitOfWork.Repository<ComboAllowedIngredientType>()
        //            .FindAll(ait => ait.ComboId == comboId.Value && !ait.IsDelete)
        //            .ToListAsync();
        //    }

        //    return await _unitOfWork.ExecuteInTransactionAsync<Customization>(async () =>
        //    {
        //        // Check for soft-deleted customization with the same name for this user
        //        var existingCustomization = await _unitOfWork.Repository<Customization>()
        //            .FindAsync(c => c.Name == name && c.UserId == userId && c.IsDelete);

        //        if (existingCustomization != null)
        //        {
        //            // Reactivate the soft-deleted customization
        //            existingCustomization.IsDelete = false;
        //            existingCustomization.Note = note;
        //            existingCustomization.ComboId = comboId;
        //            existingCustomization.Size = size;
        //            existingCustomization.ImageURL = imageURLs != null ? JsonSerializer.Serialize(imageURLs) : null;
        //            existingCustomization.SetUpdateDate();

        //            // Get applicable discount for this size
        //            var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(size);
        //            existingCustomization.AppliedDiscountId = applicableDiscount?.SizeDiscountId;

        //            await _unitOfWork.Repository<Customization>().Update(existingCustomization, existingCustomization.CustomizationId);
        //            await _unitOfWork.CommitAsync();

        //            // Update ingredients
        //            await UpdateCustomizationIngredientsAsync(existingCustomization.CustomizationId, ingredients);

        //            // Recalculate prices
        //            await UpdatePricesAsync(existingCustomization.CustomizationId);

        //            return await GetByIdAsync(existingCustomization.CustomizationId) ??
        //                throw new InvalidOperationException("Tạo tùy chỉnh thất bại");
        //        }

        //        // Get applicable discount for this size
        //        var newDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(size);

        //        // Create new customization
        //        var customization = new Customization
        //        {
        //            Name = name,
        //            Note = note,
        //            UserId = userId,
        //            ComboId = comboId,
        //            Size = size,
        //            AppliedDiscountId = newDiscount?.SizeDiscountId,
        //            BasePrice = 0,
        //            TotalPrice = 0,
        //            ImageURLs = imageURLs
        //        };

        //        _unitOfWork.Repository<Customization>().Insert(customization);
        //        await _unitOfWork.CommitAsync();

        //        // If this is a combo-based customization, validate ingredient types
        //        if (combo != null && allowedTypes != null && allowedTypes.Any())
        //        {
        //            await ValidateCustomizationIngredientsAsync(ingredients, allowedTypes);
        //        }

        //        // Add selected ingredients
        //        foreach (var ingredientDto in ingredients)
        //        {
        //            // Validate ingredient exists (we already did this for combo-based customizations)
        //            var ingredient = await _unitOfWork.Repository<Ingredient>()
        //                .FindAsync(i => i.IngredientId == ingredientDto.IngredientID && !i.IsDelete);

        //            if (ingredient == null)
        //                throw new ValidationException($"Không tìm thấy nguyên liệu với ID {ingredientDto.IngredientID}");

        //            // Validate quantity
        //            if (ingredientDto.Quantity <= 0)
        //                throw new ValidationException("Số lượng nguyên liệu phải lớn hơn 0");

        //            // Add ingredient to customization
        //            var customizationIngredient = new CustomizationIngredient
        //            {
        //                CustomizationId = customization.CustomizationId,
        //                IngredientId = ingredientDto.IngredientID,
        //                Quantity = ingredientDto.Quantity
        //            };

        //            _unitOfWork.Repository<CustomizationIngredient>().Insert(customizationIngredient);
        //        }

        //        await _unitOfWork.CommitAsync();

        //        // Calculate prices
        //        await UpdatePricesAsync(customization.CustomizationId);

        //        return await GetByIdAsync(customization.CustomizationId) ??
        //            throw new InvalidOperationException("Tạo tùy chỉnh thất bại");
        //    },
        //    ex =>
        //    {
        //        // Only log for exceptions that aren't validation or not found
        //        if (!(ex is NotFoundException || ex is ValidationException))
        //        {
        //            _logger.LogError(ex, "Lỗi khi tạo tùy chỉnh", ex);
        //        }
        //    });
        //}
        #endregion


        public async Task UpdateAsync(int id, Customization entity, List<CustomizationIngredientsRequest> ingredients)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var existingCustomization = await GetByIdAsync(id);
                if (existingCustomization == null)
                    throw new NotFoundException($"Không tìm thấy tùy chỉnh với ID {id}");

                // Validate basic properties
                if (string.IsNullOrWhiteSpace(entity.Name))
                    throw new ValidationException("Tên tùy chỉnh không được để trống");

                // Treat comboId = 0 as null (create from scratch)
                if (entity.ComboId == 0)
                {
                    entity.ComboId = null;
                }

                if (entity.Size <= 0)
                    throw new ValidationException("Kích thước phải lớn hơn 0");

                // Validate image URLs if provided
                if (entity.ImageURLs != null && entity.ImageURLs.Length > 0)
                {
                    foreach (var url in entity.ImageURLs)
                    {
                        if (string.IsNullOrWhiteSpace(url))
                        {
                            throw new ValidationException("URL hình ảnh không được để trống");
                        }

                        // Optional: Add URL format validation if needed
                        if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
                        {
                            throw new ValidationException($"Định dạng URL hình ảnh không hợp lệ: {url}");
                        }
                    }
                }

                // Get applicable discount for this size if size changed
                if (existingCustomization.Size != entity.Size || !entity.AppliedDiscountId.HasValue)
                {
                    var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(entity.Size);
                    entity.AppliedDiscountId = applicableDiscount?.SizeDiscountId;
                }

                // Fetch all ingredients to validate
                var ingredientIds = ingredients.Select(i => i.IngredientID).Distinct().ToList();
                var existingIngredients = await _unitOfWork.Repository<Ingredient>()
                    .FindAll(i => ingredientIds.Contains(i.IngredientId) && !i.IsDelete)
                    .ToListAsync();

                // Check if all ingredients exist
                var missingIngredientIds = ingredientIds.Except(existingIngredients.Select(i => i.IngredientId)).ToList();
                if (missingIngredientIds.Any())
                {
                    throw new ValidationException($"Không tìm thấy nguyên liệu với ID: {string.Join(", ", missingIngredientIds)}");
                }

                // Validate according to the new rules
                await ValidateCustomizationRules(ingredients, existingIngredients, entity.Size);

                // Update customization basic info
                entity.SetUpdateDate();
                await _unitOfWork.Repository<Customization>().Update(entity, id);
                await _unitOfWork.CommitAsync();

                // Update ingredients
                await UpdateCustomizationIngredientsAsync(id, ingredients);

                // Recalculate prices
                await UpdatePricesAsync(id);
            },
        ex =>
        {
            // Only log for exceptions that aren't validation or not found
            if (!(ex is NotFoundException || ex is ValidationException))
            {
                _logger.LogError(ex, "Lỗi khi cập nhật tùy chỉnh", ex);
            }
        });

            #region update backup

        //            public async Task UpdateAsync(int id, Customization entity, List<CustomizationIngredientsRequest> ingredients)
        //{
        //    await _unitOfWork.ExecuteInTransactionAsync(async () =>
        //    {
        //        var existingCustomization = await GetByIdAsync(id);
        //        if (existingCustomization == null)
        //            throw new NotFoundException($"Không tìm thấy tùy chỉnh với ID {id}");

        //        // Validate basic properties
        //        if (string.IsNullOrWhiteSpace(entity.Name))
        //            throw new ValidationException("Tên tùy chỉnh không được để trống");

        //        // Treat comboId = 0 as null (create from scratch)
        //        if (entity.ComboId == 0)
        //        {
        //            entity.ComboId = null;
        //        }

        //        if (entity.Size <= 0)
        //            throw new ValidationException("Kích thước phải lớn hơn 0");

        //        // Validate image URLs if provided
        //        if (entity.ImageURLs != null && entity.ImageURLs.Length > 0)
        //        {
        //            foreach (var url in entity.ImageURLs)
        //            {
        //                if (string.IsNullOrWhiteSpace(url))
        //                {
        //                    throw new ValidationException("URL hình ảnh không được để trống");
        //                }

        //                // Optional: Add URL format validation if needed
        //                if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
        //                {
        //                    throw new ValidationException($"Định dạng URL hình ảnh không hợp lệ: {url}");
        //                }
        //            }
        //        }

        //        // Get applicable discount for this size if size changed
        //        if (existingCustomization.Size != entity.Size || !entity.AppliedDiscountId.HasValue)
        //        {
        //            var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(entity.Size);
        //            entity.AppliedDiscountId = applicableDiscount?.SizeDiscountId;
        //        }

        //        // Update customization basic info
        //        entity.SetUpdateDate();
        //        await _unitOfWork.Repository<Customization>().Update(entity, id);
        //        await _unitOfWork.CommitAsync();

        //        // Get the combo for validation (if ComboId is not null)
        //        Combo combo = null;
        //        List<ComboAllowedIngredientType> allowedTypes = null;

        //        if (entity.ComboId.HasValue)
        //        {
        //            combo = await _comboService.GetByIdAsync(entity.ComboId.Value);
        //            if (combo == null)
        //                throw new NotFoundException($"Không tìm thấy combo với ID {entity.ComboId}");

        //            if (!combo.IsCustomizable)
        //                throw new ValidationException("Combo này không thể tùy chỉnh");

        //            // Get all allowed ingredient types for this combo
        //            allowedTypes = await _unitOfWork.Repository<ComboAllowedIngredientType>()
        //                .FindAll(ait => ait.ComboId == entity.ComboId.Value && !ait.IsDelete)
        //                .ToListAsync();
        //        }

        //        // If this is a combo-based customization, validate ingredient types
        //        if (combo != null && allowedTypes != null && allowedTypes.Any())
        //        {
        //            await ValidateCustomizationIngredientsAsync(ingredients, allowedTypes);
        //        }

        //        // Update ingredients
        //        await UpdateCustomizationIngredientsAsync(id, ingredients);

        //        // Recalculate prices
        //        await UpdatePricesAsync(id);
        //    },
        //ex =>
        //{
        //    // Only log for exceptions that aren't validation or not found
        //    if (!(ex is NotFoundException || ex is ValidationException))
        //    {
        //        _logger.LogError(ex, "Lỗi khi cập nhật tùy chỉnh", ex);
        //    }
        //});
            #endregion
        }
        private async Task UpdateCustomizationIngredientsAsync(int customizationId, List<CustomizationIngredientsRequest> ingredients)
        {
            // Get existing ingredients
            var existingIngredients = await _unitOfWork.Repository<CustomizationIngredient>()
                .FindAll(ci => ci.CustomizationId == customizationId)
                .ToListAsync();

            // Soft delete all existing ingredients
            foreach (var existingIngredient in existingIngredients)
            {
                existingIngredient.SoftDelete();
                existingIngredient.SetUpdateDate();
            }
            await _unitOfWork.CommitAsync();

            // Add new ingredients
            foreach (var ingredientDto in ingredients)
            {
                // Validate ingredient exists
                var ingredient = await _unitOfWork.Repository<Ingredient>()
                    .FindAsync(i => i.IngredientId == ingredientDto.IngredientID && !i.IsDelete);

                if (ingredient == null)
                    throw new ValidationException($"Không tìm thấy nguyên liệu với ID {ingredientDto.IngredientID}");

                // Validate quantity
                if (ingredientDto.Quantity <= 0)
                    throw new ValidationException("Số lượng nguyên liệu phải lớn hơn 0");

                // Check if this ingredient was previously soft-deleted
                var softDeletedIngredient = await _unitOfWork.Repository<CustomizationIngredient>()
                    .FindAsync(ci => ci.CustomizationId == customizationId &&
                                    ci.IngredientId == ingredientDto.IngredientID &&
                                    ci.IsDelete);

                if (softDeletedIngredient != null)
                {
                    // Reactivate the soft-deleted ingredient
                    softDeletedIngredient.IsDelete = false;
                    softDeletedIngredient.Quantity = ingredientDto.Quantity;
                    softDeletedIngredient.SetUpdateDate();
                    await _unitOfWork.Repository<CustomizationIngredient>().Update(
                        softDeletedIngredient, softDeletedIngredient.CustomizationIngredientId);
                }
                else
                {
                    // Add ingredient to customization
                    var customizationIngredient = new CustomizationIngredient
                    {
                        CustomizationId = customizationId,
                        IngredientId = ingredientDto.IngredientID,
                        Quantity = ingredientDto.Quantity
                    };

                    _unitOfWork.Repository<CustomizationIngredient>().Insert(customizationIngredient);
                }
            }

            await _unitOfWork.CommitAsync();
        }

        private async Task UpdatePricesAsync(int customizationId)
        {
            var customization = await _unitOfWork.Repository<Customization>()
                .IncludeNested(query =>
                    query.Include(c => c.CustomizationIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.AppliedDiscount))
                .FirstOrDefaultAsync(c => c.CustomizationId == customizationId && !c.IsDelete);

            if (customization == null)
                throw new NotFoundException($"Không tìm thấy tùy chỉnh với ID {customizationId}");

            // Calculate base price from ingredients
            decimal basePrice = 0;

            // Add prices of all ingredients
            foreach (var customizationIngredient in customization.CustomizationIngredients.Where(ci => !ci.IsDelete))
            {
                var ingredientPrice = await _ingredientService.GetCurrentPriceAsync(customizationIngredient.IngredientId);
                basePrice += ingredientPrice * customizationIngredient.Quantity;
            }

            // Update base price
            customization.BasePrice = basePrice;

            // Calculate total price with discount
            decimal totalPrice = basePrice;
            if (customization.AppliedDiscount != null)
            {
                decimal discountPercentage = customization.AppliedDiscount.DiscountPercentage;
                totalPrice = basePrice * (1 - (discountPercentage / 100m));
            }

            // Update total price
            customization.TotalPrice = totalPrice;

            // Update the customization
            customization.SetUpdateDate();
            await _unitOfWork.Repository<Customization>().Update(customization, customizationId);
            await _unitOfWork.CommitAsync();
        }


        public async Task DeleteAsync(int id)
        {
            try
            {
                var customization = await GetByIdAsync(id);
                if (customization == null)
                    throw new NotFoundException($"Không tìm thấy tùy chỉnh với ID {id}");

                // Check if this customization is used by any orders
                var isUsedByOrder = await _unitOfWork.Repository<SellOrderDetail>()
                    .AnyAsync(od => od.CustomizationId == id && !od.IsDelete);

                if (isUsedByOrder)
                    throw new ValidationException("Không thể xóa tùy chỉnh này vì nó đang được sử dụng bởi các đơn hàng hiện có");

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
                _logger.LogError(ex, "Lỗi khi xóa tùy chỉnh với ID {CustomizationId}", id);
                throw;
            }
        }


        public async Task<CustomizationPriceEstimate> CalculatePriceEstimateAsync(
            int? comboId, // Accept nullable comboId
            int size,
            List<CustomizationIngredientsRequest> ingredients)
        {
            try
            {
                // Treat comboId = 0 as null (create from scratch)
                if (comboId == 0)
                {
                    comboId = null;
                }

                // Validate combo if comboId is provided
                Combo combo = null;
                if (comboId.HasValue)
                {
                    combo = await _comboService.GetByIdAsync(comboId.Value);
                    if (combo == null)
                        throw new NotFoundException($"Không tìm thấy combo với ID {comboId}");

                    if (!combo.IsCustomizable)
                        throw new ValidationException("Combo này không thể tùy chỉnh");
                }

                // Validate size
                if (size <= 0)
                    throw new ValidationException("Kích thước phải lớn hơn 0");

                // Calculate base price
                decimal basePrice = 0;

                // Validate ingredients and add to price
                foreach (var ingredientDto in ingredients)
                {
                    // Validate ingredient exists
                    var ingredient = await _unitOfWork.Repository<Ingredient>()
                        .FindAsync(i => i.IngredientId == ingredientDto.IngredientID && !i.IsDelete);

                    if (ingredient == null)
                        throw new ValidationException($"Không tìm thấy nguyên liệu với ID {ingredientDto.IngredientID}");

                    // Validate quantity
                    if (ingredientDto.Quantity <= 0)
                        throw new ValidationException("Số lượng nguyên liệu phải lớn hơn 0");

                    // If this is a customizable combo, validate that the ingredient is allowed
                    if (combo != null && combo.IsCustomizable)
                    {
                        // Check if ingredient type is allowed
                        var allowedType = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                            .FindAsync(ait => ait.ComboId == comboId.Value &&
                                             ait.IngredientTypeId == ingredient.IngredientTypeId &&
                                             !ait.IsDelete);

                        if (allowedType == null)
                            throw new ValidationException($"Loại nguyên liệu của nguyên liệu {ingredientDto.IngredientID} không được phép cho combo này");

                        // Validate minimum quantity requirement
                        if (ingredientDto.Quantity < allowedType.MinQuantity)
                            throw new ValidationException($"Số lượng nguyên liệu {ingredient.Name} phải ít nhất {allowedType.MinQuantity}");
                    }
                    // For from-scratch customizations, no ingredient type validation is needed

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
                _logger.LogError(ex, "Lỗi khi tính giá ước tính");
                throw;
            }
        }

        private async Task ValidateCustomizationIngredientsAsync(
            List<CustomizationIngredientsRequest> ingredients,
            List<ComboAllowedIngredientType> allowedTypes)
        {
            // Group allowed types by IngredientTypeId.
            var allowedTypesByTypeId = allowedTypes
                .GroupBy(at => at.IngredientTypeId)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Group requested ingredients by IngredientTypeId.
            var ingredientsByType = new Dictionary<int, List<CustomizationIngredientsRequest>>();
            foreach (var ingredientDto in ingredients)
            {
                var ingredient = await _unitOfWork.Repository<Ingredient>()
                    .FindAsync(i => i.IngredientId == ingredientDto.IngredientID && !i.IsDelete);
                if (ingredient == null)
                    throw new ValidationException($"Không tìm thấy nguyên liệu với ID {ingredientDto.IngredientID}");

                int typeId = ingredient.IngredientTypeId;
                if (!ingredientsByType.ContainsKey(typeId))
                {
                    ingredientsByType[typeId] = new List<CustomizationIngredientsRequest>();
                }
                ingredientsByType[typeId].Add(ingredientDto);
            }

            // Loop through each allowed type (skip type 8)
            foreach (var kvp in allowedTypesByTypeId)
            {
                int typeId = kvp.Key;
                if (typeId == 8)
                    continue; // Free ingredients for type 8, no restrictions

                var allowedEntries = kvp.Value;
                // Check that the requested ingredients contain exactly allowed number for this type
                if (!ingredientsByType.ContainsKey(typeId))
                {
                    var typeName = await _unitOfWork.Repository<IngredientType>().GetById(typeId);
                    throw new ValidationException($"Combo yêu cầu {allowedEntries.Count} nguyên liệu khác nhau thuộc loại '{typeName?.Name ?? typeId.ToString()}', nhưng không có nguyên liệu nào được cung cấp");
                }

                var ingredientsOfType = ingredientsByType[typeId];

                // Check for duplicate ingredient IDs:
                var duplicateIds = ingredientsOfType
                    .GroupBy(x => x.IngredientID)
                    .Where(grp => grp.Count() > 1)
                    .Select(grp => grp.Key)
                    .ToList();
                if (duplicateIds.Any())
                {
                    var duplicates = string.Join(", ", duplicateIds);
                    throw new ValidationException($"Phát hiện nguyên liệu trùng lặp cho ID nguyên liệu: {duplicates}. Vui lòng thêm một mục cho mỗi nguyên liệu.");
                }

                // Check that the count is exactly what is allowed.
                if (ingredientsOfType.Count < allowedEntries.Count)
                {
                    var typeName = await _unitOfWork.Repository<IngredientType>().GetById(typeId);
                    throw new ValidationException($"Combo yêu cầu chính xác {allowedEntries.Count} nguyên liệu khác nhau thuộc loại '{typeName?.Name ?? typeId.ToString()}', nhưng chỉ có {ingredientsOfType.Count} được cung cấp");
                }
                else if (ingredientsOfType.Count > allowedEntries.Count)
                {
                    var typeName = await _unitOfWork.Repository<IngredientType>().GetById(typeId);
                    throw new ValidationException($"Combo chỉ cho phép {allowedEntries.Count} nguyên liệu khác nhau thuộc loại '{typeName?.Name ?? typeId.ToString()}', nhưng {ingredientsOfType.Count} đã được cung cấp");
                }

                // Validate that each ingredient meets the minimum
                for (int i = 0; i < allowedEntries.Count; i++)
                {
                    var allowedEntry = allowedEntries[i];
                    var ingredientDto = ingredientsOfType[i];

                    var ingredient = await _unitOfWork.Repository<Ingredient>()
                    .FindAsync(i => i.IngredientId == ingredientDto.IngredientID && !i.IsDelete);
                    if (ingredientDto.Quantity < allowedEntry.MinQuantity)
                    {
                        throw new ValidationException($"Số lượng nguyên liệu {ingredient?.Name ?? ingredientDto.IngredientID.ToString()} phải ít nhất {allowedEntry.MinQuantity}");
                    }
                }
            }

            // Also check if any provided ingredient types are not allowed (skip type 8)
            foreach (var typeId in ingredientsByType.Keys)
            {
                if (typeId == 8)
                    continue;
                if (!allowedTypesByTypeId.ContainsKey(typeId))
                {
                    var typeName = await _unitOfWork.Repository<IngredientType>().GetById(typeId);
                    throw new ValidationException($"Loại nguyên liệu '{typeName?.Name ?? typeId.ToString()}' không được phép cho combo này");
                }
            }
        }


    }
}
