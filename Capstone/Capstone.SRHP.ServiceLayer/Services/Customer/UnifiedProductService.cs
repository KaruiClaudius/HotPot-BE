using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
                        material, size, minPrice, maxPrice, isAvailable,
                        pageNumber, pageSize, sortBy, ascending);
                }

                // If a specific product type is requested, only query that type
                if (!string.IsNullOrEmpty(productType))
                {
                    return await GetProductsByTypeAsync(
                        productType, searchTerm, typeId,
                        material, size, minPrice, maxPrice, isAvailable,
                        pageNumber, pageSize, sortBy, ascending);
                }

                // If no specific type is requested, combine results from all types
                return await GetAllProductTypesAsync(
                    searchTerm, typeId, material, size, minPrice, maxPrice, isAvailable,
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
                        throw new ArgumentException($"Unknown product type: {productType}");
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
                        throw new ArgumentException($"No types available for product type: {productType}");
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
            int pageNumber,
            int pageSize,
            string sortBy,
            bool ascending)
        {
            switch (productType)
            {
                case "hotpot":
                    return await GetHotpotsAsync(
                        searchTerm, material, size, minPrice, maxPrice, onlyAvailable,
                        pageNumber, pageSize, sortBy, ascending);

                case "utensil":
                    return await GetUtensilsAsync(
                        searchTerm, typeId, material, minPrice, maxPrice, onlyAvailable,
                        pageNumber, pageSize, sortBy, ascending);

                case "ingredient":
                    return await GetIngredientsAsync(
                        searchTerm, typeId, minPrice, maxPrice, onlyAvailable,
                        pageNumber, pageSize, sortBy, ascending);

                default:
                    throw new ArgumentException($"Unknown product type: {productType}");
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
            int pageNumber,
            int pageSize,
            string sortBy,
            bool ascending)
        {
            // Create a union query of all product types
            var currentDate = DateTime.UtcNow;

            // Hotpot query
            var hotpotQuery = _unitOfWork.Repository<Hotpot>()
                .AsQueryable()
                .Where(h => !h.IsDelete)
                .Where(h => !onlyAvailable || (h.Status && h.Quantity > 0))
                .Select(h => new UnifiedProductDto
                {
                    Id = h.HotpotId,
                    Name = h.Name,
                    Description = h.Description ?? string.Empty,
                    Price = h.Price,
                    ImageURLs = h.ImageURLs ?? new string[0],
                    IsAvailable = h.Status && h.Quantity > 0,
                    ProductType = "Hotpot",
                    Material = h.Material,
                    Size = h.Size
                });

            // Apply hotpot-specific filters
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                hotpotQuery = hotpotQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    (p.Description != null && p.Description.ToLower().Contains(searchTerm)) ||
                    (p.Material != null && p.Material.ToLower().Contains(searchTerm)) ||
                    (p.Size != null && p.Size.ToLower().Contains(searchTerm)));
            }

            if (!string.IsNullOrWhiteSpace(material))
            {
                material = material.ToLower();
                hotpotQuery = hotpotQuery.Where(p => p.Material.ToLower().Contains(material));
            }

            if (!string.IsNullOrWhiteSpace(size))
            {
                size = size.ToLower();
                hotpotQuery = hotpotQuery.Where(p => p.Size.ToLower().Contains(size));
            }

            if (minPrice.HasValue)
            {
                hotpotQuery = hotpotQuery.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                hotpotQuery = hotpotQuery.Where(p => p.Price <= maxPrice.Value);
            }

            // Utensil query
            var utensilQuery = _unitOfWork.Repository<Utensil>()
                .AsQueryable()
                .Where(u => !u.IsDelete)
                .Where(u => !onlyAvailable || (u.Status && u.Quantity > 0))
                .Select(u => new UnifiedProductDto
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
                    TypeName = u.UtensilType.Name
                });

            // Apply utensil-specific filters
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                utensilQuery = utensilQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    (p.Description != null && p.Description.ToLower().Contains(searchTerm)) ||
                    (p.Material != null && p.Material.ToLower().Contains(searchTerm)) ||
                    (p.TypeName != null && p.TypeName.ToLower().Contains(searchTerm)));
            }

            if (typeId.HasValue)
            {
                utensilQuery = utensilQuery.Where(p => p.TypeId == typeId.Value);
            }

            if (!string.IsNullOrWhiteSpace(material))
            {
                material = material.ToLower();
                utensilQuery = utensilQuery.Where(p => p.Material.ToLower().Contains(material));
            }

            if (minPrice.HasValue)
            {
                utensilQuery = utensilQuery.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                utensilQuery = utensilQuery.Where(p => p.Price <= maxPrice.Value);
            }

            // Ingredient query with latest prices
            var ingredientQuery = _unitOfWork.Repository<Ingredient>()
                .AsQueryable()
                .Where(i => !i.IsDelete)
                .Where(i => !onlyAvailable || i.Quantity > 0)
                .Select(i => new
                {
                    Ingredient = i,
                    LatestPrice = i.IngredientPrices
                        .Where(p => !p.IsDelete && p.EffectiveDate <= currentDate)
                        .OrderByDescending(p => p.EffectiveDate)
                        .FirstOrDefault()
                })
                .Select(x => new UnifiedProductDto
                {
                    Id = x.Ingredient.IngredientId,
                    Name = x.Ingredient.Name,
                    Description = x.Ingredient.Description ?? string.Empty,
                    Price = x.LatestPrice != null ? x.LatestPrice.Price : 0,
                    ImageURLs = x.Ingredient.ImageURL != null ? new[] { x.Ingredient.ImageURL } : new string[0],
                    IsAvailable = x.Ingredient.Quantity > 0,
                    ProductType = "Ingredient",
                    MeasurementUnit = x.Ingredient.MeasurementUnit,
                    TypeId = x.Ingredient.IngredientTypeId,
                    TypeName = x.Ingredient.IngredientType.Name
                });

            // Apply ingredient-specific filters
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                ingredientQuery = ingredientQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    (p.Description != null && p.Description.ToLower().Contains(searchTerm)) ||
                    (p.TypeName != null && p.TypeName.ToLower().Contains(searchTerm)) ||
                    (p.MeasurementUnit != null && p.MeasurementUnit.ToLower().Contains(searchTerm)));
            }

            if (typeId.HasValue)
            {
                ingredientQuery = ingredientQuery.Where(p => p.TypeId == typeId.Value);
            }

            if (minPrice.HasValue)
            {
                ingredientQuery = ingredientQuery.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                ingredientQuery = ingredientQuery.Where(p => p.Price <= maxPrice.Value);
            }

            // Combine all queries
            // Note: We need to materialize each query separately because
            var hotpots = await hotpotQuery.ToListAsync();
            var utensils = await utensilQuery.ToListAsync();
            var ingredients = await ingredientQuery.ToListAsync();

            // Combine the results
            var allProducts = new List<UnifiedProductDto>();
            allProducts.AddRange(hotpots);
            allProducts.AddRange(utensils);
            allProducts.AddRange(ingredients);

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
            int pageNumber,
            int pageSize,
            string sortBy,
            bool ascending)
        {
            // Start with base query
            var query = _unitOfWork.Repository<Hotpot>()
                .AsQueryable()
                .Where(h => !h.IsDelete);

            // Apply availability filter
            if (onlyAvailable)
            {
                query = query.Where(h => h.Status && h.Quantity > 0);
            }

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(h =>
                    h.Name.ToLower().Contains(searchTerm) ||
                    (h.Description != null && h.Description.ToLower().Contains(searchTerm)) ||
                    (h.Material != null && h.Material.ToLower().Contains(searchTerm)) ||
                    (h.Size != null && h.Size.ToLower().Contains(searchTerm)));
            }

            // Apply material filter
            if (!string.IsNullOrWhiteSpace(material))
            {
                material = material.ToLower();
                query = query.Where(h => h.Material.ToLower().Contains(material));
            }

            // Apply size filter
            if (!string.IsNullOrWhiteSpace(size))
            {
                size = size.ToLower();
                query = query.Where(h => h.Size.ToLower().Contains(size));
            }

            // Apply price filters
            if (minPrice.HasValue)
            {
                query = query.Where(h => h.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(h => h.Price <= maxPrice.Value);
            }

            // Get total count before applying pagination
            var totalCount = await query.CountAsync();

            // Apply sorting
            IOrderedQueryable<Hotpot> orderedQuery;

            switch (sortBy?.ToLower())
            {
                case "price":
                    orderedQuery = ascending
                        ? query.OrderBy(h => h.Price)
                        : query.OrderByDescending(h => h.Price);
                    break;
                case "material":
                    orderedQuery = ascending
                        ? query.OrderBy(h => h.Material).ThenBy(h => h.Name)
                        : query.OrderByDescending(h => h.Material).ThenBy(h => h.Name);
                    break;
                case "size":
                    orderedQuery = ascending
                        ? query.OrderBy(h => h.Size).ThenBy(h => h.Name)
                        : query.OrderByDescending(h => h.Size).ThenBy(h => h.Name);
                    break;
                default: // Default to Name
                    orderedQuery = ascending
                        ? query.OrderBy(h => h.Name)
                        : query.OrderByDescending(h => h.Name);
                    break;
            }

            // Apply pagination
            var hotpots = await orderedQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to DTOs
            var dtos = hotpots.Select(h => new UnifiedProductDto
            {
                Id = h.HotpotId,
                Name = h.Name,
                Description = h.Description ?? string.Empty,
                Price = h.Price,
                ImageURLs = h.ImageURLs ?? new string[0],
                IsAvailable = h.Status && h.Quantity > 0,
                ProductType = "Hotpot",
                Material = h.Material,
                Size = h.Size
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
                .FindAsync(h => h.HotpotId == id && !h.IsDelete);

            if (hotpot == null)
                return null;

            return new UnifiedProductDto
            {
                Id = hotpot.HotpotId,
                Name = hotpot.Name,
                Description = hotpot.Description ?? string.Empty,
                Price = hotpot.Price,
                ImageURLs = hotpot.ImageURLs ?? new string[0],
                IsAvailable = hotpot.Status && hotpot.Quantity > 0,
                ProductType = "Hotpot",
                Material = hotpot.Material,
                Size = hotpot.Size
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

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(u =>
                    u.Name.ToLower().Contains(searchTerm) ||
                    (u.Description != null && u.Description.ToLower().Contains(searchTerm)) ||
                    (u.Material != null && u.Material.ToLower().Contains(searchTerm)) ||
                    u.UtensilType.Name.ToLower().Contains(searchTerm));
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
                query = query.Where(u => u.Material.ToLower().Contains(material));
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
                TypeName = u.UtensilType?.Name ?? "Unknown"
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
                TypeName = utensil.UtensilType?.Name ?? "Unknown"
            };
        }

        #endregion

        #region Helper Methods for Ingredients

        private async Task<PagedUnifiedProductResult> GetIngredientsAsync(
            string searchTerm,
            int? typeId,
            decimal? minPrice,
            decimal? maxPrice,
            bool onlyAvailable,
            int pageNumber,
            int pageSize,
            string sortBy,
            bool ascending)
        {
            var currentDate = DateTime.UtcNow;

            // Start with base query that includes the latest price
            var query = _unitOfWork.Repository<Ingredient>()
                .AsQueryable()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices.Where(p => !p.IsDelete && p.EffectiveDate <= currentDate))
                .Where(i => !i.IsDelete);

            // Apply availability filter
            if (onlyAvailable)
            {
                query = query.Where(i => i.Quantity > 0);
            }

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(i =>
                    i.Name.ToLower().Contains(searchTerm) ||
                    (i.Description != null && i.Description.ToLower().Contains(searchTerm)) ||
                    i.IngredientType.Name.ToLower().Contains(searchTerm) ||
                    i.MeasurementUnit.ToLower().Contains(searchTerm));
            }

            // Apply type filter
            if (typeId.HasValue)
            {
                query = query.Where(i => i.IngredientTypeId == typeId.Value);
            }

            // Get total count before applying pagination and price filters
            var totalCount = await query.CountAsync();

            // We need to materialize the query to work with the latest prices
            var ingredients = await query.ToListAsync();

            // Apply price filters (we need to do this in memory because we need the latest price)
            var filteredIngredients = ingredients.Select(i => new
            {
                Ingredient = i,
                LatestPrice = i.IngredientPrices
                    .OrderByDescending(p => p.EffectiveDate)
                    .FirstOrDefault()?.Price ?? 0
            });

            if (minPrice.HasValue)
            {
                filteredIngredients = filteredIngredients.Where(i => i.LatestPrice >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                filteredIngredients = filteredIngredients.Where(i => i.LatestPrice <= maxPrice.Value);
            }

            // Apply sorting
            IEnumerable<dynamic> orderedIngredients;

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
                case "measurementunit":
                    orderedIngredients = ascending
                        ? filteredIngredients.OrderBy(i => i.Ingredient.MeasurementUnit).ThenBy(i => i.Ingredient.Name)
                        : filteredIngredients.OrderByDescending(i => i.Ingredient.MeasurementUnit).ThenBy(i => i.Ingredient.Name);
                    break;
                default: // Default to Name
                    orderedIngredients = ascending
                        ? filteredIngredients.OrderBy(i => i.Ingredient.Name)
                        : filteredIngredients.OrderByDescending(i => i.Ingredient.Name);
                    break;
            }

            // Apply pagination
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
                ImageURLs = i.Ingredient.ImageURL != null ? new string[] { i.Ingredient.ImageURL } : new string[0],
                IsAvailable = i.Ingredient.Quantity > 0,
                ProductType = "Ingredient",
                MeasurementUnit = i.Ingredient.MeasurementUnit,
                TypeId = i.Ingredient.IngredientTypeId,
                TypeName = i.Ingredient.IngredientType?.Name ?? "Unknown"
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
            var currentDate = DateTime.UtcNow;

            var ingredient = await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices.Where(p => !p.IsDelete && p.EffectiveDate <= currentDate))
                .FirstOrDefaultAsync(i => i.IngredientId == id && !i.IsDelete);

            if (ingredient == null)
                return null;

            var latestPrice = ingredient.IngredientPrices
                .OrderByDescending(p => p.EffectiveDate)
                .FirstOrDefault()?.Price ?? 0;

            return new UnifiedProductDto
            {
                Id = ingredient.IngredientId,
                Name = ingredient.Name,
                Description = ingredient.Description ?? string.Empty,
                Price = latestPrice,
                ImageURLs = ingredient.ImageURL != null ? new[] { ingredient.ImageURL } : new string[0],
                IsAvailable = ingredient.Quantity > 0,
                ProductType = "Ingredient",
                MeasurementUnit = ingredient.MeasurementUnit,
                TypeId = ingredient.IngredientTypeId,
                TypeName = ingredient.IngredientType?.Name ?? "Unknown"
            };
        }

        #endregion
    }
}
