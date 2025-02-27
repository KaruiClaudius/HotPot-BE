using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.HotpotService
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
                .FindAll(ht => !ht.IsDelete)
                .ToListAsync();
        }
        public async Task<PagedResult<HotpotType>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<HotpotType>()
                .FindAll(ht => !ht.IsDelete);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(ht => ht.HotpotTypeId) // Ensure consistent ordering
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<HotpotType>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<HotpotType> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<HotpotType>()
                .FindAsync(ht => ht.HotpotTypeId == id && !ht.IsDelete);
        }

        public async Task<HotpotType> CreateAsync(HotpotType entity)
        {
            // Check if name is unique
            if (!await IsNameUniqueAsync(entity.Name))
            {
                throw new ValidationException($"Hotpot type with name '{entity.Name}' already exists");
            }

            _unitOfWork.Repository<HotpotType>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, HotpotType entity)
        {
            var existingType = await GetByIdAsync(id);
            if (existingType == null)
            {
                throw new NotFoundException($"Hotpot type with ID {id} not found");
            }

            // Check if name is unique (excluding current entity)
            if (!await IsNameUniqueAsync(entity.Name, id))
            {
                throw new ValidationException($"Another hotpot type with name '{entity.Name}' already exists");
            }

            existingType.Name = entity.Name;
            existingType.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var type = await GetByIdAsync(id);
            if (type == null)
            {
                throw new NotFoundException($"Hotpot type with ID {id} not found");
            }

            // Check if type is in use
            if (await IsTypeInUseAsync(id))
            {
                throw new ValidationException("Cannot delete hotpot type that is in use by hotpots");
            }

            type.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<int> GetHotpotCountByTypeAsync(int typeId)
        {
            return await _unitOfWork.Repository<Hotpot>()
                .AsQueryable(h => h.HotpotTypeID == typeId && !h.IsDelete)
                .CountAsync();
        }

        public async Task<bool> IsTypeInUseAsync(int typeId)
        {
            return await _unitOfWork.Repository<Hotpot>()
                .AnyAsync(h => h.HotpotTypeID == typeId && !h.IsDelete);
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return !await _unitOfWork.Repository<HotpotType>()
                    .AnyAsync(ht => ht.Name == name && ht.HotpotTypeId != excludeId && !ht.IsDelete);
            }
            else
            {
                return !await _unitOfWork.Repository<HotpotType>()
                    .AnyAsync(ht => ht.Name == name && !ht.IsDelete);
            }
        }
    }
}
