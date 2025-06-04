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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.IngredientService
{
    public class ComboService : IComboService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIngredientService _ingredientService;
        private readonly ISizeDiscountService _sizeDiscountService;
        private readonly ILogger<ComboService> _logger;

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
                    EF.Functions.Collate(c.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    c.Description != null && EF.Functions.Collate(c.Description.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm));
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
            try
            {
                var combo = await _unitOfWork.Repository<Combo>()
                    .IncludeNested(query =>
                        query.Include(c => c.ComboIngredients)
                             .ThenInclude(ci => ci.Ingredient)
                             .Include(c => c.AppliedDiscount)
                             .Include(c => c.TurtorialVideo)
                             .Include(c => c.AllowedIngredientTypes)
                             .ThenInclude(ait => ait.IngredientType))
                    .FirstOrDefaultAsync(c => c.ComboId == id && !c.IsDelete);

                if (combo == null)
                    throw new NotFoundException($"Không tìm thấy combo với ID {id}");

                return combo;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy thông tin combo với ID {ComboId}", id);
                throw;
            }
        }


        public async Task<Combo> CreateComboWithVideoAsync(
            Combo combo,
            TurtorialVideo video,
            List<ComboIngredient> baseIngredients = null,
            List<ComboAllowedIngredientType> allowedTypes = null)
        {
            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // Check for soft-deleted combo with the same name
                var existingCombo = await _unitOfWork.Repository<Combo>()
                    .FindAsync(c => c.Name == combo.Name);

                if (existingCombo != null)
                {
                    if (!existingCombo.IsDelete)
                    {
                        throw new ValidationException($"Combo với tên '{combo.Name}' đã tồn tại");
                    }
                    else
                    {
                        // Reactivate the soft-deleted combo
                        existingCombo.IsDelete = false;
                        existingCombo.Size = combo.Size;
                        existingCombo.Description = combo.Description;
                        existingCombo.ImageURL = combo.ImageURL;
                        existingCombo.IsCustomizable = combo.IsCustomizable;
                        existingCombo.SetUpdateDate();

                        // Update tutorial video if provided
                        if (video != null)
                        {
                            // Check if the existing video can be reused
                            var existingVideo = await _unitOfWork.Repository<TurtorialVideo>()
                                .FindAsync(v => v.TurtorialVideoId == existingCombo.TurtorialVideoId);

                            if (existingVideo != null)
                            {
                                existingVideo.Name = video.Name;
                                existingVideo.VideoURL = video.VideoURL;
                                existingVideo.Description = video.Description;
                                existingVideo.SetUpdateDate();
                                await _unitOfWork.Repository<TurtorialVideo>().Update(existingVideo, existingVideo.TurtorialVideoId);
                            }
                            else
                            {
                                // Create new video
                                _unitOfWork.Repository<TurtorialVideo>().Insert(video);
                                await _unitOfWork.CommitAsync();
                                existingCombo.TurtorialVideoId = video.TurtorialVideoId;
                            }
                        }

                        // Get applicable discount for this size
                        if (combo.Size > 0)
                        {
                            var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(combo.Size);
                            existingCombo.AppliedDiscountId = applicableDiscount?.SizeDiscountId;
                        }
                        else
                        {
                            existingCombo.AppliedDiscountId = null;
                        }

                        await _unitOfWork.CommitAsync();

                        // Handle ingredients and allowed types
                        await ReactivateOrCreateComboIngredients(existingCombo.ComboId, baseIngredients);

                        if (existingCombo.IsCustomizable)
                        {
                            await ReactivateOrCreateAllowedTypes(existingCombo.ComboId, allowedTypes);
                        }

                        // Recalculate prices
                        await UpdatePricesAsync(existingCombo.ComboId);

                        // Return the reactivated combo
                        return await GetByIdAsync(existingCombo.ComboId);
                    }
                }

                // Validate basic combo properties
                if (string.IsNullOrWhiteSpace(combo.Name))
                    throw new ValidationException("Tên combo không được để trống");

                if (combo.Size <= 0)
                    throw new ValidationException("Kích thước combo phải lớn hơn 0");

                // Validate video properties if provided
                if (video != null)
                {
                    if (string.IsNullOrWhiteSpace(video.Name))
                        throw new ValidationException("Tên video không được để trống");

                    if (string.IsNullOrWhiteSpace(video.VideoURL))
                        throw new ValidationException("URL video không được để trống");

                    // Validate URL format
                    if (!Uri.TryCreate(video.VideoURL, UriKind.Absolute, out _) && !video.VideoURL.StartsWith("/"))
                        throw new ValidationException($"Định dạng URL video không hợp lệ: {video.VideoURL}");
                }

                // Validate image URLs if provided
                if (combo.ImageURLs != null && combo.ImageURLs.Length > 0)
                {
                    foreach (var url in combo.ImageURLs)
                    {
                        if (string.IsNullOrWhiteSpace(url))
                            throw new ValidationException("URL hình ảnh không được để trống");

                        if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
                            throw new ValidationException($"Định dạng URL hình ảnh không hợp lệ: {url}");
                    }
                }

                //validate types of ingredient given
                if (!combo.IsCustomizable && baseIngredients != null && baseIngredients.Count > 0)
                {
                    var ingredientIds = baseIngredients.Select(i => i.IngredientId).ToList();
                    await ValidateComboIngredientsAsync(ingredientIds);
                }

                if (combo.IsCustomizable && allowedTypes != null && allowedTypes.Count > 0)
                {
                    var allowedTypeIds = allowedTypes.Select(t => t.IngredientTypeId).ToList();
                    await ValidateAllowedIngredientTypesAsync(allowedTypeIds);
                }

                // If combo is customizable, ensure allowed types are provided
                if (combo.IsCustomizable && (allowedTypes == null || allowedTypes.Count == 0))
                    throw new ValidationException("Combo tùy chỉnh phải có ít nhất một loại nguyên liệu được phép");

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

                // Get applicable discount for this size if size is greater than 0
                if (combo.Size > 0)
                {
                    var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(combo.Size);
                    combo.AppliedDiscountId = applicableDiscount?.SizeDiscountId;
                }
                else
                {
                    combo.AppliedDiscountId = null;
                }

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
                            throw new ValidationException($"Không tìm thấy nguyên liệu với ID {ingredient.IngredientId}");

                        // Validate quantity is positive
                        if (ingredient.Quantity <= 0)
                            throw new ValidationException("Số lượng nguyên liệu phải lớn hơn 0");

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
                            throw new ValidationException($"Không tìm thấy loại nguyên liệu với ID {allowedType.IngredientTypeId}");

                        if (allowedType.MinQuantity <= 0)
                            throw new ValidationException($"Số lượng tối thiểu cho loại nguyên liệu phải lớn hơn 0");

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
                    _logger.LogError(ex, "Lỗi khi tạo combo", ex);
                }
            });
        }

        public async Task<string> GenerateGroupIdentifierAsync(string comboName)
        {
            // Create a base identifier from the combo name (remove spaces, special chars)
            string baseIdentifier = Regex.Replace(comboName, @"[^a-zA-Z0-9]", "").ToLower();

            // Add a timestamp or random component to ensure uniqueness
            string uniqueIdentifier = $"{baseIdentifier}_{DateTime.UtcNow.Ticks}";

            return uniqueIdentifier;
        }



        private async Task ReactivateOrCreateComboIngredients(int comboId, List<ComboIngredient> ingredients)
        {
            if (ingredients == null || ingredients.Count == 0)
                return;

            // Get existing soft-deleted ingredients for this combo
            var existingSoftDeletedIngredients = await _unitOfWork.Repository<ComboIngredient>()
                .FindAll(ci => ci.ComboId == comboId && ci.IsDelete)
                .ToListAsync();

            foreach (var ingredient in ingredients)
            {
                // Validate ingredient exists
                var ingredientExists = await _unitOfWork.Repository<Ingredient>()
                    .AnyAsync(i => i.IngredientId == ingredient.IngredientId && !i.IsDelete);

                if (!ingredientExists)
                    throw new ValidationException($"Không tìm thấy nguyên liệu với ID {ingredient.IngredientId}");

                // Validate quantity is positive
                if (ingredient.Quantity <= 0)
                    throw new ValidationException("Số lượng nguyên liệu phải lớn hơn 0");

                // Check if this ingredient can be reactivated
                var existingIngredient = existingSoftDeletedIngredients
                    .FirstOrDefault(ci => ci.IngredientId == ingredient.IngredientId);

                if (existingIngredient != null)
                {
                    // Reactivate the soft-deleted ingredient
                    existingIngredient.IsDelete = false;
                    existingIngredient.Quantity = ingredient.Quantity;
                    existingIngredient.SetUpdateDate();
                    await _unitOfWork.Repository<ComboIngredient>().Update(existingIngredient, existingIngredient.ComboIngredientId);
                }
                else
                {
                    // Create new combo ingredient
                    ingredient.ComboId = comboId;
                    _unitOfWork.Repository<ComboIngredient>().Insert(ingredient);
                }
            }

            await _unitOfWork.CommitAsync();
        }

        // Helper method to reactivate or create allowed ingredient types
        private async Task ReactivateOrCreateAllowedTypes(int comboId, List<ComboAllowedIngredientType> allowedTypes)
        {
            if (allowedTypes == null || allowedTypes.Count == 0)
                return;

            // Get existing soft-deleted allowed types for this combo
            var existingSoftDeletedTypes = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                .FindAll(at => at.ComboId == comboId && at.IsDelete)
                .ToListAsync();

            foreach (var allowedType in allowedTypes)
            {
                // Validate ingredient type exists
                var typeExists = await _unitOfWork.Repository<IngredientType>()
                    .AnyAsync(it => it.IngredientTypeId == allowedType.IngredientTypeId && !it.IsDelete);

                if (!typeExists)
                    throw new ValidationException($"Không tìm thấy loại nguyên liệu với ID {allowedType.IngredientTypeId}");

                if (allowedType.MinQuantity <= 0)
                    throw new ValidationException($"Số lượng tối thiểu cho loại nguyên liệu phải lớn hơn 0");

                // Check if this type can be reactivated
                var existingType = existingSoftDeletedTypes
                    .FirstOrDefault(at => at.IngredientTypeId == allowedType.IngredientTypeId);

                if (existingType != null)
                {
                    // Reactivate the soft-deleted allowed type
                    existingType.IsDelete = false;
                    existingType.MinQuantity = allowedType.MinQuantity;
                    existingType.SetUpdateDate();
                    await _unitOfWork.Repository<ComboAllowedIngredientType>().Update(existingType, existingType.ComboAllowedIngredientTypeId);
                }
                else
                {
                    // Create new allowed type
                    allowedType.ComboId = comboId;
                    _unitOfWork.Repository<ComboAllowedIngredientType>().Insert(allowedType);
                }
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task ValidateComboIngredientsAsync(List<int> ingredientIds)
        {
            // Get all ingredients to check their types
            var ingredients = await _unitOfWork.Repository<Ingredient>()
                .FindAll(i => ingredientIds.Contains(i.IngredientId) && !i.IsDelete)
                .ToListAsync();

            // Check if all requested ingredients exist
            if (ingredients.Count != ingredientIds.Count)
            {
                var missingIds = ingredientIds.Except(ingredients.Select(i => i.IngredientId));
                throw new ValidationException($"Không tìm thấy nguyên liệu với ID: {string.Join(", ", missingIds)}");
            }

            // Check if there's at least one broth (ingredientTypeId = 1)
            bool hasBroth = ingredients.Any(i => i.IngredientTypeId == 1);
            if (!hasBroth)
            {
                throw new ValidationException("Combo phải có ít nhất một loại nước lẩu (Nước Lẩu)");
            }

            // Check if there's either meat OR seafood, but not both
            bool hasMeat = ingredients.Any(i => i.IngredientTypeId == 7);
            bool hasSeafood = ingredients.Any(i => i.IngredientTypeId == 2);

            if (hasMeat && hasSeafood)
            {
                throw new ValidationException("Combo không thể chứa cả thịt và hải sản cùng lúc");
            }
        }

        public async Task ValidateAllowedIngredientTypesAsync(List<int> allowedTypeIds)
        {
            // Remove duplicates for validation
            var distinctTypeIds = allowedTypeIds.Distinct().ToList();

            // Get all ingredient types to validate they exist
            var ingredientTypes = await _unitOfWork.Repository<IngredientType>()
                .FindAll(it => distinctTypeIds.Contains(it.IngredientTypeId) && !it.IsDelete)
                .ToListAsync();

            // Check if all requested types exist
            var foundTypeIds = ingredientTypes.Select(it => it.IngredientTypeId).ToList();
            var missingIds = distinctTypeIds.Except(foundTypeIds).ToList();

            if (missingIds.Any())
            {
                throw new ValidationException($"Không tìm thấy loại nguyên liệu với ID: {string.Join(", ", missingIds)}");
            }

            // Check if broth type (ingredientTypeId = 1) is allowed
            bool allowsBroth = distinctTypeIds.Contains(1);
            if (!allowsBroth)
            {
                throw new ValidationException("Combo tùy chỉnh phải cho phép loại nước lẩu (Nước Lẩu)");
            }

            // Check if both meat and seafood types are allowed
            bool allowsMeat = distinctTypeIds.Contains(7);
            bool allowsSeafood = distinctTypeIds.Contains(2);

            if (allowsMeat && allowsSeafood)
            {
                throw new ValidationException("Combo tùy chỉnh không thể cho phép cả thịt và hải sản cùng lúc");
            }
        }

        public async Task UpdateAsync(
             int id,
             Combo combo,
             TurtorialVideo video = null,
             List<ComboIngredient> baseIngredients = null,
             List<ComboAllowedIngredientType> allowedTypes = null)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var existingCombo = await GetByIdAsync(id);
                if (existingCombo == null)
                    throw new NotFoundException($"Không tìm thấy combo với ID {id}");

                // Validate basic properties
                if (string.IsNullOrWhiteSpace(combo.Name))
                    throw new ValidationException("Tên combo không được để trống");

                if (combo.Size <= 0 && !combo.IsCustomizable)
                    throw new ValidationException("Kích thước combo phải lớn hơn 0");

                // Validate image URLs if provided
                if (combo.ImageURLs != null && combo.ImageURLs.Length > 0)
                {
                    foreach (var url in combo.ImageURLs)
                    {
                        if (string.IsNullOrWhiteSpace(url))
                            throw new ValidationException("URL hình ảnh không được để trống");

                        if (!Uri.TryCreate(url, UriKind.Absolute, out _) && !url.StartsWith("/"))
                            throw new ValidationException($"Định dạng URL hình ảnh không hợp lệ: {url}");
                    }
                }

                // Check if combo name exists (excluding this one)
                var nameExists = await _unitOfWork.Repository<Combo>()
                    .AnyAsync(c => c.Name == combo.Name && c.ComboId != id && !c.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Đã tồn tại combo khác với tên {combo.Name}");

                // Update tutorial video if provided
                if (video != null)
                {
                    if (string.IsNullOrWhiteSpace(video.Name))
                        throw new ValidationException("Tên video không được để trống");

                    if (string.IsNullOrWhiteSpace(video.VideoURL))
                        throw new ValidationException("URL video không được để trống");

                    // Validate URL format
                    if (!Uri.TryCreate(video.VideoURL, UriKind.Absolute, out _) && !video.VideoURL.StartsWith("/"))
                        throw new ValidationException($"Định dạng URL video không hợp lệ: {video.VideoURL}");

                    // Check if we should update existing video or create a new one
                    if (existingCombo.TurtorialVideoId > 0)
                    {
                        var existingVideo = await _unitOfWork.Repository<TurtorialVideo>()
                            .FindAsync(v => v.TurtorialVideoId == existingCombo.TurtorialVideoId);

                        if (existingVideo != null)
                        {
                            // Update existing video
                            existingVideo.Name = video.Name;
                            existingVideo.VideoURL = video.VideoURL;
                            existingVideo.Description = video.Description;
                            existingVideo.SetUpdateDate();
                            await _unitOfWork.Repository<TurtorialVideo>().Update(existingVideo, existingVideo.TurtorialVideoId);
                        }
                        else
                        {
                            // Create new video
                            _unitOfWork.Repository<TurtorialVideo>().Insert(video);
                            await _unitOfWork.CommitAsync();
                            combo.TurtorialVideoId = video.TurtorialVideoId;
                        }
                    }
                    else
                    {
                        // Create new video
                        _unitOfWork.Repository<TurtorialVideo>().Insert(video);
                        await _unitOfWork.CommitAsync();
                        combo.TurtorialVideoId = video.TurtorialVideoId;
                    }
                }
                else if (combo.TurtorialVideoId != existingCombo.TurtorialVideoId)
                {
                    // If video ID is being changed but no video object is provided, validate the new ID
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

                // Update ingredients if provided
                if (baseIngredients != null)
                {
                    await UpdateComboIngredientsAsync(id, baseIngredients);
                }

                // Update allowed ingredient types if provided and combo is customizable
                if (combo.IsCustomizable && allowedTypes != null)
                {
                    await UpdateAllowedIngredientTypesAsync(id, allowedTypes);
                }
                else if (!combo.IsCustomizable && existingCombo.IsCustomizable)
                {
                    // If combo was customizable but is no longer, soft delete all allowed types
                    var existingTypes = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                        .FindAll(at => at.ComboId == id && !at.IsDelete)
                        .ToListAsync();

                    foreach (var existingType in existingTypes)
                    {
                        existingType.SoftDelete();
                        await _unitOfWork.Repository<ComboAllowedIngredientType>().Update(existingType, existingType.ComboAllowedIngredientTypeId);
                    }

                    await _unitOfWork.CommitAsync();
                }

                // Recalculate prices
                await UpdatePricesAsync(id);
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Lỗi khi cập nhật combo", ex);
                }
            });
        }

        // Helper methods for updating ingredients and allowed types
        private async Task UpdateComboIngredientsAsync(int comboId, List<ComboIngredient> ingredients)
        {
            // Get existing ingredients
            var existingIngredients = await _unitOfWork.Repository<ComboIngredient>()
                .FindAll(ci => ci.ComboId == comboId && !ci.IsDelete)
                .ToListAsync();

            // Soft delete all existing ingredients
            foreach (var existingIngredient in existingIngredients)
            {
                existingIngredient.SoftDelete();
                await _unitOfWork.Repository<ComboIngredient>().Update(existingIngredient, existingIngredient.ComboIngredientId);
            }

            // Add new ingredients
            if (ingredients != null && ingredients.Count > 0)
            {
                foreach (var ingredient in ingredients)
                {
                    // Validate ingredient exists
                    var ingredientExists = await _unitOfWork.Repository<Ingredient>()
                        .AnyAsync(i => i.IngredientId == ingredient.IngredientId && !i.IsDelete);

                    if (!ingredientExists)
                        throw new ValidationException($"Không tìm thấy nguyên liệu với ID {ingredient.IngredientId}");

                    // Validate quantity is positive
                    if (ingredient.Quantity <= 0)
                        throw new ValidationException("Số lượng nguyên liệu phải lớn hơn 0");

                    // Check if this ingredient was previously soft-deleted
                    var softDeletedIngredient = await _unitOfWork.Repository<ComboIngredient>()
                        .FindAsync(ci => ci.ComboId == comboId && ci.IngredientId == ingredient.IngredientId && ci.IsDelete);

                    if (softDeletedIngredient != null)
                    {
                        // Reactivate the soft-deleted ingredient
                        softDeletedIngredient.IsDelete = false;
                        softDeletedIngredient.Quantity = ingredient.Quantity;
                        softDeletedIngredient.SetUpdateDate();
                        await _unitOfWork.Repository<ComboIngredient>().Update(softDeletedIngredient, softDeletedIngredient.ComboIngredientId);
                    }
                    else
                    {
                        // Create new combo ingredient
                        ingredient.ComboId = comboId;
                        _unitOfWork.Repository<ComboIngredient>().Insert(ingredient);
                    }
                }
            }

            await _unitOfWork.CommitAsync();
        }

        private async Task UpdateAllowedIngredientTypesAsync(int comboId, List<ComboAllowedIngredientType> allowedTypes)
        {
            // Get existing allowed types
            var existingTypes = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                .FindAll(at => at.ComboId == comboId && !at.IsDelete)
                .ToListAsync();

            // Soft delete all existing allowed types
            foreach (var existingType in existingTypes)
            {
                existingType.SoftDelete();
                await _unitOfWork.Repository<ComboAllowedIngredientType>().Update(existingType, existingType.ComboAllowedIngredientTypeId);
            }

            // Add new allowed types
            if (allowedTypes != null && allowedTypes.Count > 0)
            {
                foreach (var allowedType in allowedTypes)
                {
                    // Validate ingredient type exists
                    var typeExists = await _unitOfWork.Repository<IngredientType>()
                        .AnyAsync(it => it.IngredientTypeId == allowedType.IngredientTypeId && !it.IsDelete);

                    if (!typeExists)
                        throw new ValidationException($"Không tìm thấy loại nguyên liệu với ID {allowedType.IngredientTypeId}");

                    if (allowedType.MinQuantity <= 0)
                        throw new ValidationException($"Số lượng tối thiểu cho loại nguyên liệu phải lớn hơn 0");

                    // Check if this type was previously soft-deleted
                    var softDeletedType = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                        .FindAsync(at => at.ComboId == comboId && at.IngredientTypeId == allowedType.IngredientTypeId && at.IsDelete);

                    if (softDeletedType != null)
                    {
                        // Reactivate the soft-deleted allowed type
                        softDeletedType.IsDelete = false;
                        softDeletedType.MinQuantity = allowedType.MinQuantity;
                        softDeletedType.SetUpdateDate();
                        await _unitOfWork.Repository<ComboAllowedIngredientType>().Update(softDeletedType, softDeletedType.ComboAllowedIngredientTypeId);
                    }
                    else
                    {
                        // Create new allowed type
                        allowedType.ComboId = comboId;
                        _unitOfWork.Repository<ComboAllowedIngredientType>().Insert(allowedType);
                    }
                }
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var combo = await GetByIdAsync(id);
                if (combo == null)
                    throw new NotFoundException($"Không tìm thấy combo với ID {id}");

                // Check if this combo is used by any customizations or orders
                var isUsedByCustomization = await _unitOfWork.Repository<Customization>()
                    .AnyAsync(c => c.ComboId == id && !c.IsDelete);

                var isUsedByOrder = await _unitOfWork.Repository<SellOrderDetail>()
                    .AnyAsync(od => od.ComboId == id && !od.IsDelete);

                if (isUsedByCustomization || isUsedByOrder)
                    throw new ValidationException("Không thể xóa combo này vì nó đang được sử dụng bởi các tùy chỉnh hoặc đơn hàng hiện có");

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
                    _logger.LogError(ex, "Lỗi khi xóa combo", ex);
                }
            });
        }

        public async Task<IEnumerable<ComboAllowedIngredientType>> GetAllowedIngredientTypesAsync(int comboId)
        {
            try
            {
                var combo = await GetByIdAsync(comboId);
                if (combo == null)
                    throw new NotFoundException($"Không tìm thấy combo với ID {comboId}");

                if (!combo.IsCustomizable)
                    throw new ValidationException($"Combo với ID {comboId} không phải là combo tùy chỉnh");

                return await _unitOfWork.Repository<ComboAllowedIngredientType>()
                    .IncludeNested(q => q.Include(ait => ait.IngredientType))
                    .Where(ait => ait.ComboId == comboId && !ait.IsDelete)
                    .ToListAsync();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách loại nguyên liệu được phép cho combo với ID {ComboId}", comboId);
                throw;
            }
        }


        public async Task<IEnumerable<Ingredient>> GetAvailableIngredientsForTypeAsync(int comboId, int ingredientTypeId)
        {
            try
            {
                var combo = await GetByIdAsync(comboId);
                if (combo == null)
                    throw new NotFoundException($"Không tìm thấy combo với ID {comboId}");

                if (!combo.IsCustomizable)
                    throw new ValidationException($"Combo với ID {comboId} không phải là combo tùy chỉnh");

                // Check if this ingredient type is allowed for this combo
                var isAllowed = await _unitOfWork.Repository<ComboAllowedIngredientType>()
                    .AnyAsync(ait => ait.ComboId == comboId && ait.IngredientTypeId == ingredientTypeId && !ait.IsDelete);

                if (!isAllowed)
                    throw new ValidationException($"Loại nguyên liệu với ID {ingredientTypeId} không được phép cho combo này");

                // Get all available ingredients of this type
                return await _unitOfWork.Repository<Ingredient>()
                    .FindAll(i => i.IngredientTypeId == ingredientTypeId && i.Quantity > 0 && !i.IsDelete)
                    .ToListAsync();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách nguyên liệu có sẵn cho loại {IngredientTypeId} và combo {ComboId}", ingredientTypeId, comboId);
                throw;
            }
        }


        public async Task<IEnumerable<ComboIngredient>> GetComboIngredientsAsync(int comboId)
        {
            try
            {
                var combo = await GetByIdAsync(comboId);
                if (combo == null)
                    throw new NotFoundException($"Không tìm thấy combo với ID {comboId}");

                return await _unitOfWork.Repository<ComboIngredient>()
                    .Include(ci => ci.Ingredient)
                    .Where(ci => ci.ComboId == comboId && !ci.IsDelete)
                    .ToListAsync();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách nguyên liệu cho combo với ID {ComboId}", comboId);
                throw;
            }
        }

        public async Task<decimal> CalculateTotalPriceAsync(int comboId, int size)
        {
            var combo = await GetByIdAsync(comboId);
            if (combo == null)
                throw new NotFoundException($"Không tìm thấy combo với ID {comboId}");

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
                finalPrice = basePrice * (1 - discountPercentage / 100m);
            }

            return finalPrice;
        }


        private async Task ValidateTurtorialVideo(int turtorialVideoId)
        {
            var turtorialVideo = await _unitOfWork.Repository<TurtorialVideo>()
                .FindAsync(tv => tv.TurtorialVideoId == turtorialVideoId && !tv.IsDelete);

            if (turtorialVideo == null)
                throw new ValidationException($"Không tìm thấy video hướng dẫn với ID {turtorialVideoId}");
        }

        public async Task<IEnumerable<Combo>> GetCombosByGroupIdentifierAsync(string groupIdentifier)
        { 
            if (string.IsNullOrEmpty(groupIdentifier))
                throw new ValidationException("Group identifier cannot be empty");

            return await _unitOfWork.Repository<Combo>()
                .IncludeNested(query =>
                    query.Include(c => c.ComboIngredients)
                         .ThenInclude(ci => ci.Ingredient)
                         .Include(c => c.AppliedDiscount)
                         .Include(c => c.TurtorialVideo)
                         .Include(c => c.AllowedIngredientTypes)
                         .ThenInclude(ait => ait.IngredientType))
                .Where(c => c.Description == groupIdentifier && c.IsCustomizable && !c.IsDelete)
                .OrderBy(c => c.Size)
                .ToListAsync();
        }

        // Method to update prices when ingredients change
        public async Task UpdatePricesAsync(int comboId)
        {
            try
            {
                var combo = await _unitOfWork.Repository<Combo>()
                    .IncludeNested(query =>
                        query.Include(c => c.ComboIngredients)
                             .ThenInclude(ci => ci.Ingredient)
                             .Include(c => c.AppliedDiscount))
                    .FirstOrDefaultAsync(c => c.ComboId == comboId && !c.IsDelete);

                if (combo == null)
                    throw new NotFoundException($"Không tìm thấy combo với ID {comboId}");

                // Calculate base price from ingredients
                decimal basePrice = 0;

                // Add prices of all ingredients
                foreach (var comboIngredient in combo.ComboIngredients.Where(ci => !ci.IsDelete))
                {
                    var ingredientPrice = await _ingredientService.GetCurrentPriceAsync(comboIngredient.IngredientId);
                    basePrice += ingredientPrice * comboIngredient.Quantity;
                }


                // Update base price
                combo.BasePrice = basePrice;

                // Calculate total price (after discount)
                decimal totalPrice = basePrice;
                if (combo.AppliedDiscount != null)
                {
                    decimal discountPercentage = combo.AppliedDiscount.DiscountPercentage;
                    totalPrice = basePrice * (1 - discountPercentage / 100m);
                }

                // Update total price
                combo.TotalPrice = totalPrice;

                // Update the combo
                combo.SetUpdateDate();
                await _unitOfWork.Repository<Combo>().Update(combo, comboId);
                await _unitOfWork.CommitAsync();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật giá cho combo với ID {ComboId}", comboId);
                throw;
            }
        }

        public async Task<int> GetComboSalesCount(int comboId)
        {
            var orderList = await _unitOfWork.Repository<Order>()
                .AsQueryable()
                .Include(o => o.SellOrder)
                .ThenInclude(so => so.SellOrderDetails)
                .ThenInclude(sod => sod.Combo)
                .ThenInclude(sodc => sodc.ComboIngredients)
                .ToListAsync();

            int quantitySold = 0;

            foreach (var order in orderList.Where(o => o.SellOrder?.SellOrderDetails != null))
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.ComboId.HasValue && detail.ComboId.Value == comboId)
                    {
                        quantitySold += detail.Quantity;
                    }
                }
            }

            return quantitySold;
        }
    }
}
