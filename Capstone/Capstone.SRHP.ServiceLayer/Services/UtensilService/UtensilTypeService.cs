using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.UtensilService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.UtensilService
{
    public class UtensilTypeService : IUtensilTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UtensilTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UtensilType>> GetAllAsync()
        {
            return await _unitOfWork.Repository<UtensilType>()
                .FindAll(ut => !ut.IsDelete)
                .ToListAsync();
        }

        public async Task<PagedResult<UtensilType>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<UtensilType>()
                .FindAll(ut => !ut.IsDelete);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(ut => ut.UtensilTypeId) // Ensure consistent ordering
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<UtensilType>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Dictionary<int, int>> GetUtensilCountsByTypesAsync(IEnumerable<int> typeIds)
        {
            var counts = await _unitOfWork.Repository<Utensil>()
                .FindAll(u => !u.IsDelete && typeIds.Contains(u.UtensilTypeID))
                .GroupBy(u => u.UtensilTypeID)
                .Select(g => new { TypeId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.TypeId, x => x.Count);

            // Ensure all requested type IDs are in the dictionary, even if they have no utensils
            foreach (var typeId in typeIds)
            {
                if (!counts.ContainsKey(typeId))
                {
                    counts[typeId] = 0;
                }
            }

            return counts;
        }

        public async Task<UtensilType> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<UtensilType>()
                .FindAsync(ut => ut.UtensilTypeId == id && !ut.IsDelete);
        }

        public async Task<UtensilType> CreateAsync(UtensilType entity)
        {
            // Check if name is unique
            if (!await IsNameUniqueAsync(entity.Name))
            {
                throw new ValidationException($"Utensil type with name '{entity.Name}' already exists");
            }

            _unitOfWork.Repository<UtensilType>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, UtensilType entity)
        {
            var existingType = await GetByIdAsync(id);
            if (existingType == null)
            {
                throw new NotFoundException($"Utensil type with ID {id} not found");
            }

            // Check if name is unique (excluding current entity)
            if (!await IsNameUniqueAsync(entity.Name, id))
            {
                throw new ValidationException($"Another utensil type with name '{entity.Name}' already exists");
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
                throw new NotFoundException($"Utensil type with ID {id} not found");
            }

            // Check if type is in use
            if (await IsTypeInUseAsync(id))
            {
                throw new ValidationException("Cannot delete utensil type that is in use by utensils");
            }

            type.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<int> GetUtensilCountByTypeAsync(int typeId)
        {
            return await _unitOfWork.Repository<Utensil>()
                .AsQueryable(u => u.UtensilTypeID == typeId && !u.IsDelete)
                .CountAsync();
        }

        public async Task<bool> IsTypeInUseAsync(int typeId)
        {
            return await _unitOfWork.Repository<Utensil>()
                .AnyAsync(u => u.UtensilTypeID == typeId && !u.IsDelete);
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return !await _unitOfWork.Repository<UtensilType>()
                    .AnyAsync(ut => ut.Name == name && ut.UtensilTypeId != excludeId && !ut.IsDelete);
            }
            else
            {
                return !await _unitOfWork.Repository<UtensilType>()
                    .AnyAsync(ut => ut.Name == name && !ut.IsDelete);
            }
        }
    }
}
