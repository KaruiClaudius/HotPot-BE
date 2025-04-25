using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
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
    public class SizeDiscountService : ISizeDiscountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SizeDiscountService> _logger;

        public SizeDiscountService(
            IUnitOfWork unitOfWork,
            ILogger<SizeDiscountService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PagedResult<SizeDiscount>> GetSizeDiscountsAsync(
            int? minSize = null,
            int? maxSize = null,
            decimal? minDiscount = null,
            decimal? maxDiscount = null,
            DateTime? activeDate = null,
            bool? isActive = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "MinSize",
            bool ascending = true)
        {
            try
            {
                // Start with base query
                var query = _unitOfWork.Repository<SizeDiscount>()
                    .FindAll(sd => !sd.IsDelete);

                // Apply filters
                if (minSize.HasValue)
                {
                    query = query.Where(sd => sd.MinSize >= minSize.Value);
                }

                if (maxSize.HasValue)
                {
                    query = query.Where(sd => sd.MinSize <= maxSize.Value);
                }

                if (minDiscount.HasValue)
                {
                    query = query.Where(sd => sd.DiscountPercentage >= minDiscount.Value);
                }

                if (maxDiscount.HasValue)
                {
                    query = query.Where(sd => sd.DiscountPercentage <= maxDiscount.Value);
                }

                if (activeDate.HasValue)
                {
                    var date = activeDate.Value;
                    query = query.Where(sd =>
                        (sd.StartDate == null || sd.StartDate <= date) &&
                        (sd.EndDate == null || sd.EndDate >= date));
                }

                if (isActive.HasValue)
                {
                    var now = DateTime.UtcNow;
                    if (isActive.Value)
                    {
                        // Active discounts: either no dates specified or current date is within range
                        query = query.Where(sd =>
                            (sd.StartDate == null || sd.StartDate <= now) &&
                            (sd.EndDate == null || sd.EndDate >= now));
                    }
                    else
                    {
                        // Inactive discounts: current date is outside the range
                        query = query.Where(sd =>
                            (sd.StartDate != null && sd.StartDate > now) ||
                            (sd.EndDate != null && sd.EndDate < now));
                    }
                }

                // Get total count before applying pagination
                var totalCount = await query.CountAsync();

                // Apply sorting
                IOrderedQueryable<SizeDiscount> orderedQuery;

                switch (sortBy?.ToLower())
                {
                    case "discount":
                    case "discountpercentage":
                        orderedQuery = ascending
                            ? query.OrderBy(sd => sd.DiscountPercentage)
                            : query.OrderByDescending(sd => sd.DiscountPercentage);
                        break;
                    case "startdate":
                        orderedQuery = ascending
                            ? query.OrderBy(sd => sd.StartDate)
                            : query.OrderByDescending(sd => sd.StartDate);
                        break;
                    case "enddate":
                        orderedQuery = ascending
                            ? query.OrderBy(sd => sd.EndDate)
                            : query.OrderByDescending(sd => sd.EndDate);
                        break;
                    case "updatedat":
                        orderedQuery = ascending
                            ? query.OrderBy(sd => sd.UpdatedAt)
                            : query.OrderByDescending(sd => sd.UpdatedAt);
                        break;
                    case "createdat":
                        orderedQuery = ascending
                            ? query.OrderBy(sd => sd.CreatedAt)
                            : query.OrderByDescending(sd => sd.CreatedAt);
                        break;
                    default: // Default to MinSize
                        orderedQuery = ascending
                            ? query.OrderBy(sd => sd.MinSize)
                            : query.OrderByDescending(sd => sd.MinSize);
                        break;
                }

                // Apply pagination
                var items = await orderedQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PagedResult<SizeDiscount>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving size discounts with filters");
                throw;
            }
        }

        public async Task<SizeDiscount> GetByIdAsync(int id)
        {
            try
            {
                var discount = await _unitOfWork.Repository<SizeDiscount>()
                    .FindAsync(sd => sd.SizeDiscountId == id && !sd.IsDelete);

                if (discount == null)
                    throw new NotFoundException($"Không tìm thấy giảm giá với ID {id}");

                return discount;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy giảm giá theo kích thước với ID {DiscountId}", id);
                throw;
            }
        }

        public async Task<SizeDiscount> CreateAsync(SizeDiscount sizeDiscount)
        {
            try
            {
                // Validate
                if (sizeDiscount.MinSize <= 0)
                    throw new ValidationException("Kích thước tối thiểu phải lớn hơn 0");

                if (sizeDiscount.DiscountPercentage < 0 || sizeDiscount.DiscountPercentage > 100)
                    throw new ValidationException("Phần trăm giảm giá phải nằm trong khoảng từ 0 đến 100");

                // Check for overlapping date ranges
                if (sizeDiscount.StartDate.HasValue && sizeDiscount.EndDate.HasValue)
                {
                    if (sizeDiscount.StartDate > sizeDiscount.EndDate)
                        throw new ValidationException("Ngày bắt đầu phải trước ngày kết thúc");
                }

                // Check for existing discount with same min size
                var existingDiscount = await _unitOfWork.Repository<SizeDiscount>()
                    .FindAsync(sd => sd.MinSize == sizeDiscount.MinSize && !sd.IsDelete);

                if (existingDiscount != null)
                    throw new ValidationException($"Đã tồn tại giảm giá cho kích thước {sizeDiscount.MinSize}");

                // Check for soft-deleted discount with same min size
                var softDeletedDiscount = await _unitOfWork.Repository<SizeDiscount>()
                    .FindAsync(sd => sd.MinSize == sizeDiscount.MinSize && sd.IsDelete);

                if (softDeletedDiscount != null)
                {
                    // Reactivate the soft-deleted discount
                    softDeletedDiscount.IsDelete = false;
                    softDeletedDiscount.DiscountPercentage = sizeDiscount.DiscountPercentage;
                    softDeletedDiscount.StartDate = sizeDiscount.StartDate;
                    softDeletedDiscount.EndDate = sizeDiscount.EndDate;
                    softDeletedDiscount.SetUpdateDate();

                    await _unitOfWork.Repository<SizeDiscount>().Update(softDeletedDiscount, softDeletedDiscount.SizeDiscountId);
                    await _unitOfWork.CommitAsync();

                    return softDeletedDiscount;
                }

                _unitOfWork.Repository<SizeDiscount>().Insert(sizeDiscount);
                await _unitOfWork.CommitAsync();

                return sizeDiscount;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo giảm giá theo kích thước");
                throw;
            }
        }

        public async Task UpdateAsync(int id, SizeDiscount sizeDiscount)
        {
            try
            {
                var existingDiscount = await GetByIdAsync(id);
                if (existingDiscount == null)
                    throw new NotFoundException($"Không tìm thấy giảm giá với ID {id}");

                // Validate
                if (sizeDiscount.MinSize <= 0)
                    throw new ValidationException("Kích thước tối thiểu phải lớn hơn 0");

                if (sizeDiscount.DiscountPercentage < 0 || sizeDiscount.DiscountPercentage > 100)
                    throw new ValidationException("Phần trăm giảm giá phải nằm trong khoảng từ 0 đến 100");

                // Check for overlapping date ranges
                if (sizeDiscount.StartDate.HasValue && sizeDiscount.EndDate.HasValue)
                {
                    if (sizeDiscount.StartDate > sizeDiscount.EndDate)
                        throw new ValidationException("Ngày bắt đầu phải trước ngày kết thúc");
                }

                // Check for existing discount with same min size (excluding this one)
                var existingWithSameSize = await _unitOfWork.Repository<SizeDiscount>()
                    .FindAsync(sd => sd.MinSize == sizeDiscount.MinSize && sd.SizeDiscountId != id && !sd.IsDelete);

                if (existingWithSameSize != null)
                    throw new ValidationException($"Đã tồn tại giảm giá khác cho kích thước {sizeDiscount.MinSize}");

                sizeDiscount.SetUpdateDate();
                await _unitOfWork.Repository<SizeDiscount>().Update(sizeDiscount, id);
                await _unitOfWork.CommitAsync();
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
                _logger.LogError(ex, "Lỗi khi cập nhật giảm giá theo kích thước với ID {DiscountId}", id);
                throw;
            }
        }


        public async Task DeleteAsync(int id)
        {
            try
            {
                var discount = await GetByIdAsync(id);
                if (discount == null)
                    throw new NotFoundException($"Không tìm thấy giảm giá với ID {id}");

                // Check if this discount is used by any customizations or combos
                var isUsedByCustomization = await _unitOfWork.Repository<Customization>()
                    .AnyAsync(c => c.AppliedDiscountId == id && !c.IsDelete);

                var isUsedByCombo = await _unitOfWork.Repository<Combo>()
                    .AnyAsync(c => c.AppliedDiscountId == id && !c.IsDelete);

                if (isUsedByCustomization || isUsedByCombo)
                    throw new ValidationException("Không thể xóa giảm giá này vì nó đang được sử dụng bởi các tùy chỉnh hoặc combo hiện có");

                discount.SoftDelete();
                await _unitOfWork.CommitAsync();
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
                _logger.LogError(ex, "Lỗi khi xóa giảm giá theo kích thước với ID {DiscountId}", id);
                throw;
            }
        }

        public async Task<SizeDiscount> GetApplicableDiscountAsync(int size)
        {
            try
            {
                if (size <= 0)
                    throw new ValidationException("Kích thước phải lớn hơn 0");

                // Get the highest applicable discount tier for this size
                var now = DateTime.UtcNow;

                // Use a try-catch block specifically for the database query
                try
                {
                    return await _unitOfWork.Repository<SizeDiscount>()
                        .FindAll(sd => sd.MinSize <= size &&
                                    (sd.StartDate == null || sd.StartDate <= now) &&
                                    (sd.EndDate == null || sd.EndDate >= now) &&
                                    !sd.IsDelete)
                        .OrderByDescending(sd => sd.MinSize)
                        .FirstOrDefaultAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Lỗi cơ sở dữ liệu khi tìm giảm giá áp dụng cho kích thước {Size}", size);

                    // In case of database error, try a more resilient approach with explicit loading
                    var allDiscounts = await _unitOfWork.Repository<SizeDiscount>()
                        .FindAll(sd => !sd.IsDelete)
                        .ToListAsync();

                    return allDiscounts
                        .Where(sd => sd.MinSize <= size &&
                                (sd.StartDate == null || sd.StartDate <= now) &&
                                (sd.EndDate == null || sd.EndDate >= now))
                        .OrderByDescending(sd => sd.MinSize)
                        .FirstOrDefault();
                }
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi không xác định khi tìm giảm giá áp dụng cho kích thước {Size}", size);

                // In case of any other error, return null instead of throwing
                // This ensures that the combo and customization services can continue to function
                return null;
            }
        }

        public Task<IEnumerable<SizeDiscount>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}

