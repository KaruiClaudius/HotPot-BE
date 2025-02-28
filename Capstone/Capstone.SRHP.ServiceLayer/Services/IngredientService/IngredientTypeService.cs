using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.IngredientService
{
    public class IngredientTypeService : IIngredientTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<IngredientType>> GetAllAsync()
        {
            return await _unitOfWork.Repository<IngredientType>()
                .Include(t => t.Ingredients)
                .Where(t => !t.IsDelete)
                .ToListAsync();
        }

        public async Task<PagedResult<IngredientType>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<IngredientType>()
                .Include(t => t.Ingredients)
                .Where(t => !t.IsDelete);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(t => t.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<IngredientType>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<IngredientType> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<IngredientType>()
                .Include(t => t.Ingredients)
                .FirstOrDefaultAsync(t => t.IngredientTypeId == id && !t.IsDelete);
        }

        public async Task<IngredientType> CreateAsync(IngredientType entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Ingredient type name cannot be empty");

            // Check if ingredient type exists (including soft-deleted)
            var existingType = await _unitOfWork.Repository<IngredientType>()
                .FindAsync(t => t.Name == entity.Name);

            if (existingType != null)
            {
                if (!existingType.IsDelete)
                {
                    throw new ValidationException($"Ingredient type with name {entity.Name} already exists");
                }
                else
                {
                    // Reactivate the soft-deleted ingredient type
                    existingType.IsDelete = false;
                    existingType.SetUpdateDate();
                    await _unitOfWork.CommitAsync();
                    return existingType;
                }
            }

            _unitOfWork.Repository<IngredientType>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, IngredientType entity)
        {
            var existingType = await GetByIdAsync(id);
            if (existingType == null)
                throw new NotFoundException($"Ingredient type with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Ingredient type name cannot be empty");

            // Check for name uniqueness if name is changed
            if (entity.Name != existingType.Name)
            {
                var nameExists = await _unitOfWork.Repository<IngredientType>()
                    .AnyAsync(t => t.Name == entity.Name && t.IngredientTypeId != id && !t.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Ingredient type with name {entity.Name} already exists");
            }

            entity.SetUpdateDate();
            await _unitOfWork.Repository<IngredientType>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ingredientType = await GetByIdAsync(id);
            if (ingredientType == null)
                throw new NotFoundException($"Ingredient type with ID {id} not found");

            // Check if ingredient type is in use
            var isInUse = await _unitOfWork.Repository<Ingredient>()
                .AnyAsync(i => i.IngredientTypeID == id && !i.IsDelete);

            if (isInUse)
                throw new ValidationException("Cannot delete ingredient type that is in use by ingredients");

            ingredientType.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<int> GetIngredientCountByTypeAsync(int typeId)
        {
            return await _unitOfWork.Repository<Ingredient>()
                .CountAsync(i => i.IngredientTypeID == typeId && !i.IsDelete);
        }

        public async Task<Dictionary<int, int>> GetIngredientCountsByTypesAsync(IEnumerable<int> typeIds)
        {
            var idList = typeIds.ToList();

            // Get all ingredients for the specified types
            var ingredients = await _unitOfWork.Repository<Ingredient>()
                .FindAll(i => idList.Contains(i.IngredientTypeID) && !i.IsDelete)
                .ToListAsync();

            // Group by type ID and count
            var counts = ingredients
                .GroupBy(i => i.IngredientTypeID)
                .ToDictionary(g => g.Key, g => g.Count());

            // Ensure all requested type IDs are in the dictionary, even if they have no ingredients
            foreach (var typeId in idList)
            {
                if (!counts.ContainsKey(typeId))
                {
                    counts[typeId] = 0;
                }
            }

            return counts;
        }

        public async Task<PagedResult<IngredientType>> SearchAsync(string searchTerm, int pageNumber, int pageSize)
        {
            searchTerm = searchTerm?.ToLower() ?? "";

            var query = _unitOfWork.Repository<IngredientType>()
                .Include(t => t.Ingredients)
                .Where(t => !t.IsDelete && t.Name.ToLower().Contains(searchTerm));

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(t => t.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<IngredientType>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
