using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.EntityFrameworkCore;
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

        public SizeDiscountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SizeDiscount>> GetAllAsync()
        {
            return await _unitOfWork.Repository<SizeDiscount>()
                .FindAll(sd => !sd.IsDelete)
                .OrderBy(sd => sd.MinSize)
                .ToListAsync();
        }

        public async Task<SizeDiscount> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<SizeDiscount>()
                .FindAsync(sd => sd.SizeDiscountId == id && !sd.IsDelete);
        }

        public async Task<SizeDiscount> CreateAsync(SizeDiscount sizeDiscount)
        {
            // Validate
            if (sizeDiscount.MinSize <= 0)
                throw new ValidationException("Minimum size must be greater than 0");

            if (sizeDiscount.DiscountPercentage < 0 || sizeDiscount.DiscountPercentage > 100)
                throw new ValidationException("Discount percentage must be between 0 and 100");

            // Check for overlapping date ranges
            if (sizeDiscount.StartDate.HasValue && sizeDiscount.EndDate.HasValue)
            {
                if (sizeDiscount.StartDate > sizeDiscount.EndDate)
                    throw new ValidationException("Start date must be before end date");
            }

            // Check for existing discount with same min size
            var existingDiscount = await _unitOfWork.Repository<SizeDiscount>()
                .FindAsync(sd => sd.MinSize == sizeDiscount.MinSize && !sd.IsDelete);

            if (existingDiscount != null)
                throw new ValidationException($"A discount for size {sizeDiscount.MinSize} already exists");

            _unitOfWork.Repository<SizeDiscount>().Insert(sizeDiscount);
            await _unitOfWork.CommitAsync();

            return sizeDiscount;
        }

        public async Task UpdateAsync(int id, SizeDiscount sizeDiscount)
        {
            var existingDiscount = await GetByIdAsync(id);
            if (existingDiscount == null)
                throw new NotFoundException($"Size discount with ID {id} not found");

            // Validate
            if (sizeDiscount.MinSize <= 0)
                throw new ValidationException("Minimum size must be greater than 0");

            if (sizeDiscount.DiscountPercentage < 0 || sizeDiscount.DiscountPercentage > 100)
                throw new ValidationException("Discount percentage must be between 0 and 100");

            // Check for overlapping date ranges
            if (sizeDiscount.StartDate.HasValue && sizeDiscount.EndDate.HasValue)
            {
                if (sizeDiscount.StartDate > sizeDiscount.EndDate)
                    throw new ValidationException("Start date must be before end date");
            }

            // Check for existing discount with same min size (excluding this one)
            var existingWithSameSize = await _unitOfWork.Repository<SizeDiscount>()
                .FindAsync(sd => sd.MinSize == sizeDiscount.MinSize && sd.SizeDiscountId != id && !sd.IsDelete);

            if (existingWithSameSize != null)
                throw new ValidationException($"Another discount for size {sizeDiscount.MinSize} already exists");

            sizeDiscount.SetUpdateDate();
            await _unitOfWork.Repository<SizeDiscount>().Update(sizeDiscount, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var discount = await GetByIdAsync(id);
            if (discount == null)
                throw new NotFoundException($"Size discount with ID {id} not found");

            // Check if this discount is used by any customizations or combos
            var isUsedByCustomization = await _unitOfWork.Repository<Customization>()
                .AnyAsync(c => c.AppliedDiscountID == id && !c.IsDelete);

            var isUsedByCombo = await _unitOfWork.Repository<Combo>()
                .AnyAsync(c => c.AppliedDiscountID == id && !c.IsDelete);

            if (isUsedByCustomization || isUsedByCombo)
                throw new ValidationException("Cannot delete this discount as it is used by existing customizations or combos");

            discount.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<SizeDiscount> GetApplicableDiscountAsync(int size)
        {
            if (size <= 0)
                throw new ValidationException("Size must be greater than 0");

            // Get the highest applicable discount tier for this size
            var now = DateTime.UtcNow;

            return await _unitOfWork.Repository<SizeDiscount>()
                .FindAll(sd => sd.MinSize <= size &&
                            (sd.StartDate == null || sd.StartDate <= now) &&
                            (sd.EndDate == null || sd.EndDate >= now) &&
                            !sd.IsDelete)
                .OrderByDescending(sd => sd.MinSize)
                .FirstOrDefaultAsync();
        }
    }
}
