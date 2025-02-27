using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
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

        public DiscountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Discount>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Discount>()
                .Include(d => d.Order)
                .Where(d => !d.IsDelete)
                .ToListAsync();
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

            if (entity.Percent < 0 || entity.Percent > 100)
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
                    existingDiscount.Percent = entity.Percent;
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


        public async Task<double> CalculateDiscountAmountAsync(int discountId, double originalPrice)
        {
            var discount = await GetByIdAsync(discountId);
            if (discount == null)
                throw new NotFoundException($"Discount with ID {discountId} not found");

            if (!await IsDiscountValidAsync(discountId))
                throw new ValidationException("Discount is not valid");

            return originalPrice * discount.Percent / 100;
        }

        public async Task<bool> HasSufficientPointsAsync(int discountId, double userPoints)
        {
            var discount = await GetByIdAsync(discountId);
            if (discount == null)
                throw new NotFoundException($"Discount with ID {discountId} not found");

            return userPoints >= discount.PointCost;
        }

        private void ValidateDiscount(Discount discount)
        {
            if (string.IsNullOrWhiteSpace(discount.Title))
                throw new ValidationException("Discount title cannot be empty");

            if (string.IsNullOrWhiteSpace(discount.Description))
                throw new ValidationException("Discount description cannot be empty");

            if (discount.Percent < 0 || discount.Percent > 100)
                throw new ValidationException("Discount percentage must be between 0 and 100");

            if (discount.PointCost < 0)
                throw new ValidationException("Point cost cannot be negative");

            if (discount.Date == default)
                throw new ValidationException("Start date must be set");

            if (discount.Duration == default)
                throw new ValidationException("End date must be set");
        }
    }
}
