using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services
{
    public class HotpotTypeService : IHotpotTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotpotTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<HotpotType>> GetAllAsync()
        {
            return await _unitOfWork.Repository<HotpotType>()
                .Include(ht => ht.Hotpot)
                .Where(ht => !ht.IsDelete)
                .ToListAsync();
        }

        public async Task<HotpotType?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<HotpotType>()
                .Include(ht => ht.Hotpot)
                .FirstOrDefaultAsync(ht => ht.HotpotTypeId == id && !ht.IsDelete);
        }


        public async Task<HotpotType> CreateAsync(HotpotType entity)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("HotpotType name cannot be empty");

            // Check for existing type (including soft-deleted)
            var existingType = await _unitOfWork.Repository<HotpotType>()
                .FindAsync(ht => ht.Name == entity.Name);

            if (existingType != null)
            {
                if (!existingType.IsDelete)
                {
                    throw new ValidationException($"HotpotType with name {entity.Name} already exists");
                }
                else
                {
                    // Reactivate the soft-deleted type
                    existingType.IsDelete = false;
                    existingType.SetUpdateDate();
                    await _unitOfWork.CommitAsync();
                    return existingType;
                }
            }

            _unitOfWork.Repository<HotpotType>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }


        public async Task UpdateAsync(int id, HotpotType entity)
        {
            var existingType = await GetByIdAsync(id);
            if (existingType == null)
                throw new NotFoundException($"HotpotType with ID {id} not found");

            // Validate name
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("HotpotType name cannot be empty");

            // Check for duplicate names (excluding current type)
            var exists = await _unitOfWork.Repository<HotpotType>()
                .FindAsync(ht => ht.Name == entity.Name && ht.HotpotTypeId != id && !ht.IsDelete);

            if (exists != null)
                throw new ValidationException($"HotpotType with name {entity.Name} already exists");

            entity.SetUpdateDate();
            await _unitOfWork.Repository<HotpotType>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotpotType = await GetByIdAsync(id);
            if (hotpotType == null)
                throw new NotFoundException($"HotpotType with ID {id} not found");

            // Check if type has any active hotpots
            if (await IsTypeInUseAsync(id))
                throw new ValidationException("Cannot delete hotpot type that has active hotpots");

            hotpotType.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsTypeInUseAsync(int id)
        {
            var hotpot = await _unitOfWork.Repository<Hotpot>()
                .FindAsync(h => h.HotpotTypeID == id && !h.IsDelete);
            return hotpot != null;
        }

        public async Task<int> GetHotpotCountAsync(int id)
        {
            var hotpotType = await GetByIdAsync(id);
            if (hotpotType == null)
                throw new NotFoundException($"HotpotType with ID {id} not found");

            return await _unitOfWork.Repository<Hotpot>()
                .FindAll(h => h.HotpotTypeID == id && !h.IsDelete)
                .CountAsync();
        }
    }
}
