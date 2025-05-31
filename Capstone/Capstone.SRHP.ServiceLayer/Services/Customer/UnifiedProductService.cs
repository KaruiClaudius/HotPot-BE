using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Capstone.HPTY.ServiceLayer.Services.Customer
{
    public class UnifiedProductService : IUnifiedProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UnifiedProductService> _logger;

        public UnifiedProductService(
            IUnitOfWork unitOfWork,
            ILogger<UnifiedProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PagedUnifiedProductResult> GetAllProductsAsync(
        string productType = null,
        string searchTerm = null,
        int? typeId = null,
        string material = null,
        string size = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        bool? onlyAvailable = true,
        int? minQuantity = null,
        int pageNumber = 1,
        int pageSize = 10,
        string sortBy = "Name",
        bool ascending = true)
        {
            try
            {
                // Normalize product type
                productType = productType?.ToLower();

                // Default to showing only available products
                bool isAvailable = onlyAvailable ?? true;

                // Handle special case for "broth" which is a filtered ingredient
                if (productType == "broth")
                {
                    return await GetProductsByTypeAsync(
                        "ingredient", searchTerm, 1, // Type ID 1 for broths
                        material, size, minPrice, maxPrice, isAvailable, minQuantity,
                        pageNumber, pageSize, sortBy, ascending);
                }

                // If a specific product type is requested, only query that type
                if (!string.IsNullOrEmpty(productType))
                {
                    return await GetProductsByTypeAsync(
                        productType, searchTerm, typeId,
                        material, size, minPrice, maxPrice, isAvailable, minQuantity,
                        pageNumber, pageSize, sortBy, ascending);
                }

                // If no specific type is requested, combine results from all types
                return await GetAllProductTypesAsync(
                    searchTerm, typeId, material, size, minPrice, maxPrice, isAvailable, minQuantity,
                    pageNumber, pageSize, sortBy, ascending);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving unified products");
                throw;
            }
        }

        public async Task<UnifiedProductDto> GetProductByIdAsync(string productType, int id)
        {
            try
            {
                // Normalize product type
                productType = productType?.ToLower();

                switch (productType)
                {
                    case "hotpot":
                        return await GetHotpotByIdAsync(id);

                    case "utensil":
                        return await GetUtensilByIdAsync(id);

                    case "ingredient":
                    case "broth":
                        return await GetIngredientByIdAsync(id);

                    default:
                        throw new ArgumentException($"Loại sản phẩm không xác định: {productType}, phải là hotpot, utensil, ingredient hoặc broth");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product by ID");
                throw;
            }
        }

        public async Task<List<object>> GetProductTypesAsync(string productType)
        {
            try
            {
                // Normalize product type
                productType = productType?.ToLower();

                switch (productType)
                {
                    case "utensil":
                        var utensilTypes = await _unitOfWork.Repository<UtensilType>()
                            .FindAll(t => !t.IsDelete)
                            .OrderBy(t => t.Name)
                            .Select(t => new { Id = t.UtensilTypeId, Name = t.Name })
                            .ToListAsync();
                        return utensilTypes.Cast<object>().ToList();

                    case "ingredient":
                        var ingredientTypes = await _unitOfWork.Repository<IngredientType>()
                            .FindAll(t => !t.IsDelete)
                            .OrderBy(t => t.Name)
                            .Select(t => new { Id = t.IngredientTypeId, Name = t.Name })
                            .ToListAsync();
                        return ingredientTypes.Cast<object>().ToList();

                    default:
                        throw new ArgumentException($"Không có loại sản phẩm phụ cho loại sản phẩm: {productType}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product types");
                throw;
            }
        }


        #region Helper Methods for Querying Products

       private async Task<PagedUnifiedProductResult> GetProductsByTypeAsync(
       string productType,
       string searchTerm,
       int? typeId,
       string material,
       string size,
       decimal? minPrice,
       decimal? maxPrice,
       bool onlyAvailable,
       int? minQuantity,
       int pageNumber,
       int pageSize,
       string sortBy,
       bool ascending)
        {
            switch (productType)
            {
                case "hotpot":
                    return await GetHotpotsAsync(
                        searchTerm, material, size, minPrice, maxPrice, onlyAvailable, minQuantity,
                        pageNumber, pageSize, sortBy, ascending);

                case "utensil":
                    return await GetUtensilsAsync(
                        searchTerm, typeId, material, minPrice, maxPrice, onlyAvailable, minQuantity,
                        pageNumber, pageSize, sortBy, ascending);

                case "ingredient":
                    return await GetIngredientsAsync(
                        searchTerm, typeId, minPrice, maxPrice, onlyAvailable, minQuantity,
                        pageNumber, pageSize, sortBy, ascending);

                default:
                    throw new ArgumentException($"Loại sản phẩm không xác định: {productType}");
            }
        }


        private async Task<PagedUnifiedProductResult> GetAllProductTypesAsync(
            string searchTerm,
            int? typeId,
            string material,
            string size,
            decimal? minPrice,
            decimal? maxPrice,
            bool onlyAvailable,
            int? minQuantity,
            int pageNumber,
            int pageSize,
            string sortBy,
            bool ascending)
        {
            // Create a union query of all product types
            var currentDate = DateTime.UtcNow.AddHours(7);

            // Hotpot query
            var hotpotQuery = await _unitOfWork.Repository<Hotpot>()
                .AsQueryable()
                .Include(h => h.InventoryUnits.Where(hi => !hi.IsDelete &&
                    (hi.Status == HotpotStatus.Available || hi.Status == HotpotStatus.Reserved)))
                .Where(h => !h.IsDelete)
                .ToListAsync();

            // Then filter in memory
            if (onlyAvailable)
            {
                hotpotQuery = hotpotQuery.Where(h => h.Quantity > 0).ToList();
            }

            if (minQuantity.HasValue)
            {
                hotpotQuery = hotpotQuery.Where(h => h.Quantity >= minQuantity.Value).ToList();
            }

            var hotpotDtoQuery = hotpotQuery.Select(h => new UnifiedProductDto
            {
                Id = h.HotpotId,
                Name = h.Name,
                Description = h.Description ?? string.Empty,
                Price = h.Price,
                ImageURLs = h.ImageURLs ?? new string[0],
                IsAvailable = h.Quantity > 0,
                ProductType = "Hotpot",
                Material = h.Material,
                Size = h.Size,
                Quantity = h.InventoryUnits.Count(i => !i.IsDelete && (i.Status == HotpotStatus.Available || i.Status == HotpotStatus.Reserved))
            });

            // Apply hotpot-specific filters
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                hotpotDtoQuery = hotpotDtoQuery.Where(i =>
                    EF.Functions.Collate(i.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    i.Description != null && EF.Functions.Collate(i.Description.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    i.Material != null && EF.Functions.Collate(i.Material.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    i.Size != null && EF.Functions.Collate(i.Size.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm)
                    );
            }

            if (!string.IsNullOrWhiteSpace(material))
            {
                material = material.ToLower();
                hotpotDtoQuery = hotpotDtoQuery.Where(p => p.Material.ToLower().Contains(material));
            }

            if (!string.IsNullOrWhiteSpace(size))
            {
                size = size.ToLower();
                hotpotDtoQuery = hotpotDtoQuery.Where(p => p.Size.ToLower().Contains(size));
            }

            if (minPrice.HasValue)
            {
                hotpotDtoQuery = hotpotDtoQuery.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                hotpotDtoQuery = hotpotDtoQuery.Where(p => p.Price <= maxPrice.Value);
            }

            // Utensil query
            var utensilQuery = _unitOfWork.Repository<Utensil>()
                .AsQueryable()
                .Include(u => u.UtensilType)
                .Where(u => !u.IsDelete);

            // Apply availability filter
            if (onlyAvailable)
            {
                utensilQuery = utensilQuery.Where(u => u.Status && u.Quantity > 0);
            }

            // Apply quantity filter
            if (minQuantity.HasValue)
            {
                utensilQuery = utensilQuery.Where(u => u.Quantity >= minQuantity.Value);
            }

            var utensilDtoQuery = utensilQuery.Select(u => new UnifiedProductDto
            {
                Id = u.UtensilId,
                Name = u.Name,
                Description = u.Description ?? string.Empty,
                Price = u.Price,
                ImageURLs = u.ImageURL != null ? new[] { u.ImageURL } : new string[0],
                IsAvailable = u.Status && u.Quantity > 0,
                ProductType = "Utensil",
                Material = u.Material,
                TypeId = u.UtensilTypeId,
                TypeName = u.UtensilType.Name,
                Quantity = u.Quantity
            });

            // Apply utensil-specific filters
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                utensilDtoQuery = utensilDtoQuery.Where(p =>
                    EF.Functions.Collate(p.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    p.Description != null && EF.Functions.Collate(p.Description.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    p.Material != null && EF.Functions.Collate(p.Material.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    p.TypeName != null && EF.Functions.Collate(p.TypeName.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm)
                );
            }

            if (typeId.HasValue)
            {
                utensilDtoQuery = utensilDtoQuery.Where(p => p.TypeId == typeId.Value);
            }

            if (!string.IsNullOrWhiteSpace(material))
            {
                material = material.ToLower();
                utensilDtoQuery = utensilDtoQuery.Where(p => p.Material.ToLower().Contains(material));
            }

            if (minPrice.HasValue)
            {
                utensilDtoQuery = utensilDtoQuery.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                utensilDtoQuery = utensilDtoQuery.Where(p => p.Price <= maxPrice.Value);
            }

            // Ingredient query
            var ingredientQuery = _unitOfWork.Repository<Ingredient>()
                .AsQueryable()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientBatches.Where(b => !b.IsDelete && b.BestBeforeDate > currentDate))
                .Where(i => !i.IsDelete);

            // Apply search filter 
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                ingredientQuery = ingredientQuery.Where(i =>
                    EF.Functions.Collate(i.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    i.Description != null && EF.Functions.Collate(i.Description.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    i.IngredientType.Name != null && EF.Functions.Collate(i.IngredientType.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm)
                );
            }

            // Apply type filter
            if (typeId.HasValue)
            {
                ingredientQuery = ingredientQuery.Where(i => i.IngredientTypeId == typeId.Value);
            }

            var hotpots = hotpotDtoQuery.ToList();
            var utensils = await utensilDtoQuery.ToListAsync();
            var ingredients = await ingredientQuery.ToListAsync();

            // Load ingredient prices separately
            foreach (var ingredient in ingredients)
            {
                await _unitOfWork.Repository<IngredientPrice>()
                    .FindAll(p => p.IngredientId == ingredient.IngredientId &&
                                 !p.IsDelete &&
                                 p.EffectiveDate <= currentDate)
                    .LoadAsync();
            }

            // Process ingredients in memory
            var ingredientDtos = new List<UnifiedProductDto>();
            foreach (var ingredient in ingredients)
            {
                // Skip if not available and onlyAvailable is true
                if (onlyAvailable && ingredient.Quantity <= 0)
                    continue;

                // Skip if below minimum quantity
                if (minQuantity.HasValue && ingredient.Quantity < minQuantity.Value)
                    continue;

                var latestPrice = ingredient.IngredientPrices != null && ingredient.IngredientPrices.Any()
                    ? ingredient.IngredientPrices
                        .OrderByDescending(p => p.EffectiveDate)
                        .FirstOrDefault()?.Price ?? 0
                    : 0;

                // Skip if below minimum price
                if (minPrice.HasValue && latestPrice < minPrice.Value)
                    continue;

                // Skip if above maximum price
                if (maxPrice.HasValue && latestPrice > maxPrice.Value)
                    continue;

                ingredientDtos.Add(new UnifiedProductDto
                {
                    Id = ingredient.IngredientId,
                    Name = ingredient.Name,
                    Description = ingredient.Description ?? string.Empty,
                    Price = latestPrice,
                    ImageURLs = !string.IsNullOrEmpty(ingredient.ImageURL) ? new[] { ingredient.ImageURL } : Array.Empty<string>(),
                    IsAvailable = ingredient.Quantity > 0,
                    ProductType = "Ingredient",
                    TypeId = ingredient.IngredientTypeId,
                    TypeName = ingredient.IngredientType?.Name ?? "Unknown",
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit,
                    MeasurementValue = ingredient.MeasurementValue,
                    FormattedQuantity = FormatQuantity(ingredient.MeasurementValue, ingredient.Unit)
                });
            }

            // Combine the results
            var allProducts = new List<UnifiedProductDto>();
            allProducts.AddRange(hotpots);
            allProducts.AddRange(utensils);
            allProducts.AddRange(ingredientDtos);

            // Get total count
            var totalCount = allProducts.Count;

            // Apply sorting
            IEnumerable<UnifiedProductDto> sortedProducts;

            switch (sortBy?.ToLower())
            {
                case "price":
                    sortedProducts = ascending
                        ? allProducts.OrderBy(p => p.Price)
                        : allProducts.OrderByDescending(p => p.Price);
                    break;
                case "type":
                case "typename":
                    sortedProducts = ascending
                        ? allProducts.OrderBy(p => p.TypeName ?? string.Empty).ThenBy(p => p.Name)
                        : allProducts.OrderByDescending(p => p.TypeName ?? string.Empty).ThenBy(p => p.Name);
                    break;
                case "producttype":
                    sortedProducts = ascending
                        ? allProducts.OrderBy(p => p.ProductType).ThenBy(p => p.Name)
                        : allProducts.OrderByDescending(p => p.ProductType).ThenBy(p => p.Name);
                    break;
                case "quantity":
                    sortedProducts = ascending
                        ? allProducts.OrderBy(p => p.Quantity).ThenBy(p => p.Name)
                        : allProducts.OrderByDescending(p => p.Quantity).ThenBy(p => p.Name);
                    break;
                default: // Default to Name
                    sortedProducts = ascending
                        ? allProducts.OrderBy(p => p.Name)
                        : allProducts.OrderByDescending(p => p.Name);
                    break;
            }

            // Apply pagination
            var pagedProducts = sortedProducts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedUnifiedProductResult
            {
                Items = pagedProducts,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        #endregion

        #region Helper Methods for Hotpots

        private async Task<PagedUnifiedProductResult> GetHotpotsAsync(
       string searchTerm,
       string material,
       string size,
       decimal? minPrice,
       decimal? maxPrice,
       bool onlyAvailable,
       int? minQuantity,
       int pageNumber,
       int pageSize,
       string sortBy,
       bool ascending)
        {
            // Start with base query
            var query = _unitOfWork.Repository<Hotpot>()
                .AsQueryable()
                .Include(h => h.InventoryUnits.Where(hi => hi.Status == HotpotStatus.Available || hi.Status == HotpotStatus.Reserved))
                .Where(h => !h.IsDelete);

            var hotpots = await query.ToListAsync();

            var filteredHotpots = hotpots;

            var totalCount = hotpots.Count;

            // Apply availability filter
            if (onlyAvailable)
            {
                filteredHotpots = filteredHotpots.Where(h => h.Quantity > 0).ToList();
            }

            // Apply quantity filter
            if (minQuantity.HasValue)
            {
                filteredHotpots = filteredHotpots.Where(h => h.Quantity >= minQuantity.Value).ToList();
            }

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                filteredHotpots = filteredHotpots.Where(h =>
                    h.Name.ToLower().Contains(searchTerm) ||
                    (h.Description != null && h.Description.ToLower().Contains(searchTerm)) ||
                    (h.Material != null && h.Material.ToLower().Contains(searchTerm)) ||
                    (h.Size != null && h.Size.ToLower().Contains(size))).ToList();
            }
            // Apply material filter
            if (!string.IsNullOrWhiteSpace(material))
            {
                material = material.ToLower();
                filteredHotpots = filteredHotpots.Where(h =>
                    h.Material != null && h.Material.ToLower().Contains(material)).ToList();
            }

            // Apply size filter
            if (!string.IsNullOrWhiteSpace(size))
            {
                size = size.ToLower();
                filteredHotpots = filteredHotpots.Where(h =>
                    h.Size != null && h.Size.ToLower().Contains(size)).ToList();
            }

            // Apply price filters
            if (minPrice.HasValue)
            {
                filteredHotpots = filteredHotpots.Where(h => h.Price >= minPrice.Value).ToList();
            }

            if (maxPrice.HasValue)
            {
                filteredHotpots = filteredHotpots.Where(h => h.Price <= maxPrice.Value).ToList();
            }


            // Apply sorting
            // Apply sorting in memory
            IEnumerable<Hotpot> sortedHotpots;

            switch (sortBy?.ToLower())
            {
                case "price":
                    sortedHotpots = ascending
                        ? filteredHotpots.OrderBy(h => h.Price)
                        : filteredHotpots.OrderByDescending(h => h.Price);
                    break;
                case "material":
                    sortedHotpots = ascending
                        ? filteredHotpots.OrderBy(h => h.Material).ThenBy(h => h.Name)
                        : filteredHotpots.OrderByDescending(h => h.Material).ThenBy(h => h.Name);
                    break;
                case "size":
                    sortedHotpots = ascending
                        ? filteredHotpots.OrderBy(h => h.Size).ThenBy(h => h.Name)
                        : filteredHotpots.OrderByDescending(h => h.Size).ThenBy(h => h.Name);
                    break;
                case "quantity":
                    sortedHotpots = ascending
                        ? filteredHotpots.OrderBy(h => h.Quantity).ThenBy(h => h.Name)
                        : filteredHotpots.OrderByDescending(h => h.Quantity).ThenBy(h => h.Name);
                    break;
                default: // Default to Name
                    sortedHotpots = ascending
                        ? filteredHotpots.OrderBy(h => h.Name)
                        : filteredHotpots.OrderByDescending(h => h.Name);
                    break;
            }

            // Apply pagination in memory
            var pagedHotpots = sortedHotpots
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Map to DTOs
            var dtos = pagedHotpots.Select(h => new UnifiedProductDto
            {
                Id = h.HotpotId,
                Name = h.Name,
                Description = h.Description ?? string.Empty,
                Price = h.Price,
                ImageURLs = h.ImageURLs ?? new string[0],
                IsAvailable = h.Quantity > 0,
                ProductType = "Hotpot",
                Material = h.Material,
                Size = h.Size,
                Quantity = h.Quantity
            }).ToList();

            return new PagedUnifiedProductResult
            {
                Items = dtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        private async Task<UnifiedProductDto> GetHotpotByIdAsync(int id)
        {
            var hotpot = await _unitOfWork.Repository<Hotpot>()
                .Include(h => h.InventoryUnits.Where(hi => hi.Status == HotpotStatus.Available || hi.Status == HotpotStatus.Reserved))
                .FirstOrDefaultAsync(h => h.HotpotId == id && !h.IsDelete);

            if (hotpot == null)
                return null;

            return new UnifiedProductDto
            {
                Id = hotpot.HotpotId,
                Name = hotpot.Name,
                Description = hotpot.Description ?? string.Empty,
                Price = hotpot.Price,
                ImageURLs = hotpot.ImageURLs ?? new string[0],
                IsAvailable = hotpot.Quantity > 0,
                ProductType = "Hotpot",
                Material = hotpot.Material,
                Size = hotpot.Size,
                Quantity = hotpot.Quantity
            };
        }

        #endregion

        #region Helper Methods for Utensils

        private async Task<PagedUnifiedProductResult> GetUtensilsAsync(
      string searchTerm,
      int? typeId,
      string material,
      decimal? minPrice,
      decimal? maxPrice,
      bool onlyAvailable,
      int? minQuantity,
      int pageNumber,
      int pageSize,
      string sortBy,
      bool ascending)
        {
            // Start with base query
            var query = _unitOfWork.Repository<Utensil>()
                .AsQueryable()
                .Include(u => u.UtensilType)
                .Where(u => !u.IsDelete);

            // Apply availability filter
            if (onlyAvailable)
            {
                query = query.Where(u => u.Status && u.Quantity > 0);
            }

            // Apply quantity filter
            if (minQuantity.HasValue)
            {
                query = query.Where(u => u.Quantity >= minQuantity.Value);
            }

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(u =>
                    EF.Functions.Collate(u.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    u.Description != null && EF.Functions.Collate(u.Description.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    u.Material != null && EF.Functions.Collate(u.Material.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    EF.Functions.Collate(u.UtensilType.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm)
                );
            }

            // Apply type filter
            if (typeId.HasValue)
            {
                query = query.Where(u => u.UtensilTypeId == typeId.Value);
            }

            // Apply material filter
            if (!string.IsNullOrWhiteSpace(material))
            {
                material = material.ToLower();
                query = query.Where(u =>
                    u.Material != null && EF.Functions.Collate(u.Material.ToLower(), "Latin1_General_CI_AI").Contains(material)
                );
            }

            // Apply price filters
            if (minPrice.HasValue)
            {
                query = query.Where(u => u.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(u => u.Price <= maxPrice.Value);
            }

            // Get total count before applying pagination
            var totalCount = await query.CountAsync();

            // Apply sorting
            IOrderedQueryable<Utensil> orderedQuery;

            switch (sortBy?.ToLower())
            {
                case "price":
                    orderedQuery = ascending
                        ? query.OrderBy(u => u.Price)
                        : query.OrderByDescending(u => u.Price);
                    break;
                case "material":
                    orderedQuery = ascending
                        ? query.OrderBy(u => u.Material).ThenBy(u => u.Name)
                        : query.OrderByDescending(u => u.Material).ThenBy(u => u.Name);
                    break;
                case "type":
                case "typename":
                    orderedQuery = ascending
                        ? query.OrderBy(u => u.UtensilType.Name).ThenBy(u => u.Name)
                        : query.OrderByDescending(u => u.UtensilType.Name).ThenBy(u => u.Name);
                    break;
                case "quantity":
                    orderedQuery = ascending
                        ? query.OrderBy(u => u.Quantity).ThenBy(u => u.Name)
                        : query.OrderByDescending(u => u.Quantity).ThenBy(u => u.Name);
                    break;
                default: // Default to Name
                    orderedQuery = ascending
                        ? query.OrderBy(u => u.Name)
                        : query.OrderByDescending(u => u.Name);
                    break;
            }

            // Apply pagination
            var utensils = await orderedQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to DTOs
            var dtos = utensils.Select(u => new UnifiedProductDto
            {
                Id = u.UtensilId,
                Name = u.Name,
                Description = u.Description ?? string.Empty,
                Price = u.Price,
                ImageURLs = u.ImageURL != null ? new[] { u.ImageURL } : new string[0],
                IsAvailable = u.Status && u.Quantity > 0,
                ProductType = "Utensil",
                Material = u.Material,
                TypeId = u.UtensilTypeId,
                TypeName = u.UtensilType?.Name ?? "Unknown",
                Quantity = u.Quantity
            }).ToList();

            return new PagedUnifiedProductResult
            {
                Items = dtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        private async Task<UnifiedProductDto> GetUtensilByIdAsync(int id)
        {
            var utensil = await _unitOfWork.Repository<Utensil>()
                .Include(u => u.UtensilType)
                .FirstOrDefaultAsync(u => u.UtensilId == id && !u.IsDelete);

            if (utensil == null)
                return null;

            return new UnifiedProductDto
            {
                Id = utensil.UtensilId,
                Name = utensil.Name,
                Description = utensil.Description ?? string.Empty,
                Price = utensil.Price,
                ImageURLs = utensil.ImageURL != null ? new[] { utensil.ImageURL } : new string[0],
                IsAvailable = utensil.Status && utensil.Quantity > 0,
                ProductType = "Utensil",
                Material = utensil.Material,
                TypeId = utensil.UtensilTypeId,
                TypeName = utensil.UtensilType?.Name ?? "Unknown",
                Quantity = utensil.Quantity
            };
        }

        #endregion

        #region Helper Methods for Ingredients

        private string FormatQuantity(double quantity, string unit)
        {
            if (string.IsNullOrEmpty(unit))
                return quantity.ToString("0.##");

            return $"{quantity.ToString("0.##")} {unit}";
        }

        private async Task<PagedUnifiedProductResult> GetIngredientsAsync(
            string searchTerm,
            int? typeId,
            decimal? minPrice,
            decimal? maxPrice,
            bool onlyAvailable,
            int? minQuantity,
            int pageNumber,
            int pageSize,
            string sortBy,
            bool ascending)
        {
            var currentDate = DateTime.UtcNow.AddHours(7);

            // Start with base query that includes the latest price and batches
            var query = _unitOfWork.Repository<Ingredient>()
                .AsQueryable()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientBatches.Where(b => !b.IsDelete && b.BestBeforeDate > currentDate))
                .Where(i => !i.IsDelete);

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(i =>
                    EF.Functions.Collate(i.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    i.Description != null && EF.Functions.Collate(i.Description.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                    EF.Functions.Collate(i.IngredientType.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm)
                );
            }

            // Apply type filter
            if (typeId.HasValue)
            {
                query = query.Where(i => i.IngredientTypeId == typeId.Value);
            }

            // Get total count before applying pagination and price filters
            var totalCount = await query.CountAsync();

            // Execute the database query to get the ingredients
            var ingredients = await query.ToListAsync();

            // Load ingredient prices separately
            foreach (var ingredient in ingredients)
            {
                await _unitOfWork.Repository<IngredientPrice>()
                    .FindAll(p => p.IngredientId == ingredient.IngredientId &&
                                 !p.IsDelete &&
                                 p.EffectiveDate <= currentDate)
                    .LoadAsync();
            }

            // Process ingredients in memory
            var filteredIngredients = new List<(Ingredient Ingredient, decimal LatestPrice)>();
            foreach (var ingredient in ingredients)
            {
                // Skip if not available and onlyAvailable is true
                if (onlyAvailable && ingredient.Quantity <= 0)
                    continue;

                // Skip if below minimum quantity
                if (minQuantity.HasValue && ingredient.Quantity < minQuantity.Value)
                    continue;

                var latestPrice = ingredient.IngredientPrices != null && ingredient.IngredientPrices.Any()
                    ? ingredient.IngredientPrices
                        .OrderByDescending(p => p.EffectiveDate)
                        .FirstOrDefault()?.Price ?? 0
                    : 0;

                // Skip if below minimum price
                if (minPrice.HasValue && latestPrice < minPrice.Value)
                    continue;

                // Skip if above maximum price
                if (maxPrice.HasValue && latestPrice > maxPrice.Value)
                    continue;

                filteredIngredients.Add((ingredient, latestPrice));
            }

            // Apply sorting in memory
            IEnumerable<(Ingredient Ingredient, decimal LatestPrice)> orderedIngredients;

            switch (sortBy?.ToLower())
            {
                case "price":
                    orderedIngredients = ascending
                        ? filteredIngredients.OrderBy(i => i.LatestPrice)
                        : filteredIngredients.OrderByDescending(i => i.LatestPrice);
                    break;
                case "type":
                case "typename":
                    orderedIngredients = ascending
                        ? filteredIngredients.OrderBy(i => i.Ingredient.IngredientType.Name).ThenBy(i => i.Ingredient.Name)
                        : filteredIngredients.OrderByDescending(i => i.Ingredient.IngredientType.Name).ThenBy(i => i.Ingredient.Name);
                    break;
                case "quantity":
                    orderedIngredients = ascending
                        ? filteredIngredients.OrderBy(i => i.Ingredient.Quantity).ThenBy(i => i.Ingredient.Name)
                        : filteredIngredients.OrderByDescending(i => i.Ingredient.Quantity).ThenBy(i => i.Ingredient.Name);
                    break;
                default: // Default to Name
                    orderedIngredients = ascending
                        ? filteredIngredients.OrderBy(i => i.Ingredient.Name)
                        : filteredIngredients.OrderByDescending(i => i.Ingredient.Name);
                    break;
            }

            // Apply pagination in memory
            var pagedIngredients = orderedIngredients
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Map to DTOs
            var dtos = pagedIngredients.Select(i => new UnifiedProductDto
            {
                Id = i.Ingredient.IngredientId,
                Name = i.Ingredient.Name,
                Description = i.Ingredient.Description ?? string.Empty,
                Price = i.LatestPrice,
                ImageURLs = !string.IsNullOrEmpty(i.Ingredient.ImageURL) ? new[] { i.Ingredient.ImageURL } : Array.Empty<string>(),
                IsAvailable = i.Ingredient.Quantity > 0,
                ProductType = "Ingredient",
                TypeId = i.Ingredient.IngredientTypeId,
                TypeName = i.Ingredient.IngredientType?.Name ?? "Unknown",
                Quantity = i.Ingredient.Quantity,
                Unit = i.Ingredient.Unit,
                MeasurementValue = i.Ingredient.MeasurementValue,
                FormattedQuantity = FormatQuantity(i.Ingredient.MeasurementValue, i.Ingredient.Unit)
            }).ToList();

            return new PagedUnifiedProductResult
            {
                Items = dtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        private async Task<UnifiedProductDto> GetIngredientByIdAsync(int id)
        {
            var currentDate = DateTime.UtcNow.AddHours(7);

            var ingredient = await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientBatches.Where(b => !b.IsDelete))
                .FirstOrDefaultAsync(i => i.IngredientId == id && !i.IsDelete);

            if (ingredient == null)
                return null;

            // Load ingredient prices separately
            await _unitOfWork.Repository<IngredientPrice>()
                .FindAll(p => p.IngredientId == ingredient.IngredientId &&
                             !p.IsDelete &&
                             p.EffectiveDate <= currentDate)
                .LoadAsync();

            var latestPrice = ingredient.IngredientPrices
                .OrderByDescending(p => p.EffectiveDate)
                .FirstOrDefault()?.Price ?? 0;

            return new UnifiedProductDto
            {
                Id = ingredient.IngredientId,
                Name = ingredient.Name,
                Description = ingredient.Description ?? string.Empty,
                Price = latestPrice,
                ImageURLs = !string.IsNullOrEmpty(ingredient.ImageURL) ? new[] { ingredient.ImageURL } : Array.Empty<string>(),
                IsAvailable = ingredient.Quantity > 0,
                ProductType = "Ingredient",
                TypeId = ingredient.IngredientTypeId,
                TypeName = ingredient.IngredientType?.Name ?? "Unknown",
                Quantity = ingredient.Quantity,
                Unit = ingredient.Unit,
                MeasurementValue = ingredient.MeasurementValue,
                FormattedQuantity = FormatQuantity(ingredient.MeasurementValue, ingredient.Unit)
            };
        }

        // Helper method to format quantity with measurement unit



        #endregion

    }
}
