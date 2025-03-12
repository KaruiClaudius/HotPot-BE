using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
{
    public class DiscountService : IDiscountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(
            IUnitOfWork unitOfWork,
            ILogger<DiscountService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PagedResult<Discount>> GetDiscountsAsync(
            string searchTerm = null,
            decimal? minDiscountPercentage = null,
            decimal? maxDiscountPercentage = null,
            double? minPointCost = null,
            double? maxPointCost = null,
            DateTime? startDateFrom = null,
            DateTime? startDateTo = null,
            DateTime? endDateFrom = null,
            DateTime? endDateTo = null,
            bool? isActive = null,
            bool? isUpcoming = null,
            bool? isExpired = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "CreatedAt",
            bool ascending = false)
        {
            try
            {
                // Start with base query
                var query = _unitOfWork.Repository<Discount>()
                    .Include(d => d.Order)
                    .Where(d => !d.IsDelete);

                // Apply search filter
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(d =>
                        d.Title.ToLower().Contains(searchTerm) ||
                        (d.Description != null && d.Description.ToLower().Contains(searchTerm)));
                }

                // Apply discount percentage filters
                if (minDiscountPercentage.HasValue)
                {
                    query = query.Where(d => d.DiscountPercentage >= minDiscountPercentage.Value);
                }

                if (maxDiscountPercentage.HasValue)
                {
                    query = query.Where(d => d.DiscountPercentage <= maxDiscountPercentage.Value);
                }

                // Apply point cost filters
                if (minPointCost.HasValue)
                {
                    query = query.Where(d => d.PointCost >= minPointCost.Value);
                }

                if (maxPointCost.HasValue)
                {
                    query = query.Where(d => d.PointCost <= maxPointCost.Value);
                }

                // Apply date filters
                if (startDateFrom.HasValue)
                {
                    query = query.Where(d => d.Date >= startDateFrom.Value);
                }

                if (startDateTo.HasValue)
                {
                    query = query.Where(d => d.Date <= startDateTo.Value);
                }

                if (endDateFrom.HasValue)
                {
                    query = query.Where(d => d.Duration >= endDateFrom.Value);
                }

                if (endDateTo.HasValue)
                {
                    query = query.Where(d => d.Duration <= endDateTo.Value);
                }

                // Apply status filters
                var now = DateTime.UtcNow;

                if (isActive.HasValue && isActive.Value)
                {
                    query = query.Where(d => d.Date <= now && d.Duration >= now);
                }

                if (isUpcoming.HasValue && isUpcoming.Value)
                {
                    query = query.Where(d => d.Date > now);
                }

                if (isExpired.HasValue && isExpired.Value)
                {
                    query = query.Where(d => d.Duration < now);
                }

                // Get total count before applying pagination
                var totalCount = await query.CountAsync();

                // Apply sorting
                IOrderedQueryable<Discount> orderedQuery;

                switch (sortBy?.ToLower())
                {
                    case "title":
                        orderedQuery = ascending
                            ? query.OrderBy(d => d.Title)
                            : query.OrderByDescending(d => d.Title);
                        break;
                    case "discountpercentage":
                        orderedQuery = ascending
                            ? query.OrderBy(d => d.DiscountPercentage)
                            : query.OrderByDescending(d => d.DiscountPercentage);
                        break;
                    case "pointcost":
                        orderedQuery = ascending
                            ? query.OrderBy(d => d.PointCost)
                            : query.OrderByDescending(d => d.PointCost);
                        break;
                    case "startdate":
                    case "date":
                        orderedQuery = ascending
                            ? query.OrderBy(d => d.Date)
                            : query.OrderByDescending(d => d.Date);
                        break;
                    case "enddate":
                    case "duration":
                        orderedQuery = ascending
                            ? query.OrderBy(d => d.Duration)
                            : query.OrderByDescending(d => d.Duration);
                        break;
                    case "updatedat":
                        orderedQuery = ascending
                            ? query.OrderBy(d => d.UpdatedAt)
                            : query.OrderByDescending(d => d.UpdatedAt);
                        break;
                    default: // Default to CreatedAt
                        orderedQuery = ascending
                            ? query.OrderBy(d => d.CreatedAt)
                            : query.OrderByDescending(d => d.CreatedAt);
                        break;
                }

                // Apply pagination
                var items = await orderedQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PagedResult<Discount>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving discounts with filters");
                throw;
            }
        }

        public async Task<Discount?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Discount>()
                .Include(d => d.Order)
                .FirstOrDefaultAsync(d => d.DiscountId == id && !d.IsDelete);
        }

        public async Task<Discount> CreateAsync(Discount entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Title))
                throw new ValidationException("Discount title cannot be empty");

            if (entity.DiscountPercentage < 0 || entity.DiscountPercentage > 100)
                throw new ValidationException("Discount percentage must be between 0 and 100");

            if (entity.PointCost < 0)
                throw new ValidationException("Point cost cannot be negative");

            if (entity.Date >= entity.Duration)
                throw new ValidationException("Start date must be before duration end date");

            // Check if discount exists (including soft-deleted)
            var existingDiscount = await _unitOfWork.Repository<Discount>()
                .FindAsync(d => d.Title == entity.Title);

            if (existingDiscount != null)
            {
                if (!existingDiscount.IsDelete)
                {
                    throw new ValidationException($"Discount with title {entity.Title} already exists");
                }
                else
                {
                    // Reactivate and update the soft-deleted discount
                    existingDiscount.IsDelete = false;
                    existingDiscount.Description = entity.Description;
                    existingDiscount.DiscountPercentage = entity.DiscountPercentage;
                    existingDiscount.Date = entity.Date;
                    existingDiscount.Duration = entity.Duration;
                    existingDiscount.PointCost = entity.PointCost;
                    existingDiscount.SetUpdateDate();
                    await _unitOfWork.CommitAsync();
                    return existingDiscount;
                }
            }

            _unitOfWork.Repository<Discount>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, Discount entity)
        {
            var existingDiscount = await GetByIdAsync(id);
            if (existingDiscount == null)
                throw new NotFoundException($"Discount with ID {id} not found");

            // Validate basic properties
            ValidateDiscount(entity);

            // Additional validation for dates
            if (entity.Date >= entity.Duration)
                throw new ValidationException("Start date must be before end date");

            // Check if discount is already in use
            if (existingDiscount.Order != null)
                throw new ValidationException("Cannot update discount that is already in use");

            entity.SetUpdateDate();
            await _unitOfWork.Repository<Discount>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var discount = await GetByIdAsync(id);
            if (discount == null)
                throw new NotFoundException($"Discount with ID {id} not found");

            // Check if discount is in use
            if (discount.Order != null)
                throw new ValidationException("Cannot delete discount that is in use");

            discount.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Discount>> GetActiveDiscountsAsync()
        {
            var now = DateTime.UtcNow;
            return await _unitOfWork.Repository<Discount>()
                .FindAll(d => !d.IsDelete &&
                             d.Date <= now &&
                             d.Duration >= now)
                .ToListAsync();
        }

        public async Task<IEnumerable<Discount>> GetUpcomingDiscountsAsync()
        {
            var now = DateTime.UtcNow;
            return await _unitOfWork.Repository<Discount>()
                .FindAll(d => !d.IsDelete && d.Date > now)
                .ToListAsync();
        }

        public async Task<IEnumerable<Discount>> GetExpiredDiscountsAsync()
        {
            var now = DateTime.UtcNow;
            return await _unitOfWork.Repository<Discount>()
                .FindAll(d => !d.IsDelete && d.Duration < now)
                .ToListAsync();
        }

        public async Task<bool> IsDiscountValidAsync(int discountId)
        {
            var discount = await _unitOfWork.Repository<Discount>()
            .FindAsync(d => d.DiscountId == discountId && !d.IsDelete);
            if (discount == null)
                return false;

            var now = DateTime.UtcNow;
            return discount.Date <= now &&
                   discount.Duration >= now &&
                   discount.Order == null;
        }

        public async Task<decimal> CalculateDiscountAmountAsync(int discountId, decimal originalPrice)
        {
            var discount = await GetByIdAsync(discountId);
            if (discount == null)
                throw new NotFoundException($"Discount with ID {discountId} not found");

            if (!await IsDiscountValidAsync(discountId))
                throw new ValidationException("Discount is not valid");

            return originalPrice * discount.DiscountPercentage / 100;
        }

        public async Task<bool> HasSufficientPointsAsync(int discountId, double userPoints)
        {
            var discount = await GetByIdAsync(discountId);
            if (discount == null)
                throw new NotFoundException($"Discount with ID {discountId} not found");

            return userPoints >= discount.PointCost;
        }

        public async Task<int> GetOrderCountByDiscountAsync(int discountId)
        {
            return await _unitOfWork.Repository<Order>()
                .CountAsync(o => !o.IsDelete && o.DiscountID == discountId);
        }

        public async Task<Dictionary<int, int>> GetOrderCountsByDiscountsAsync(IEnumerable<int> discountIds)
        {
            var counts = await _unitOfWork.Repository<Order>()
                .FindAll(o => !o.IsDelete && discountIds.Contains(o.DiscountID.Value))
                .GroupBy(o => o.DiscountID.Value)
                .Select(g => new { DiscountId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.DiscountId, x => x.Count);

            // Ensure all requested discount IDs are in the dictionary, even if they have no orders
            foreach (var discountId in discountIds)
            {
                if (!counts.ContainsKey(discountId))
                {
                    counts[discountId] = 0;
                }
            }

            return counts;
        }

        private void ValidateDiscount(Discount discount)
        {
            if (string.IsNullOrWhiteSpace(discount.Title))
                throw new ValidationException("Discount title cannot be empty");

            if (string.IsNullOrWhiteSpace(discount.Description))
                throw new ValidationException("Discount description cannot be empty");

            if (discount.DiscountPercentage < 0 || discount.DiscountPercentage > 100)
                throw new ValidationException("Discount percentage must be between 0 and 100");

            if (discount.PointCost < 0)
                throw new ValidationException("Point cost cannot be negative");

            if (discount.Date == default)
                throw new ValidationException("Start date must be set");

            if (discount.Duration == default)
                throw new ValidationException("End date must be set");
        }

        public Task<IEnumerable<Discount>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
