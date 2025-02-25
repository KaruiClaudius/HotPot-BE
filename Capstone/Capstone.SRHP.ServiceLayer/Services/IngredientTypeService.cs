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
                .Include(it => it.Ingredients)
                .Where(it => !it.IsDelete)
                .ToListAsync();
        }

        public async Task<IngredientType?> GetByIdAsync(int id)
        {
            var ingredientType = await _unitOfWork.Repository<IngredientType>()
                .Include(it => it.Ingredients)
                .FirstOrDefaultAsync(it => it.IngredientTypeId == id && !it.IsDelete);

            if (ingredientType == null)
                throw new NotFoundException($"IngredientType with ID {id} not found");

            return ingredientType;
        }

        public async Task<IngredientType> CreateAsync(IngredientType entity)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("IngredientType name cannot be empty");

            // Check for duplicate names
            var exists = await _unitOfWork.Repository<IngredientType>()
                .AnyAsync(it => it.Name == entity.Name && !it.IsDelete);

            if (exists)
                throw new ValidationException($"IngredientType with name {entity.Name} already exists");

            _unitOfWork.Repository<IngredientType>().Insert(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task UpdateAsync(int id, IngredientType entity)
        {
            var existingType = await GetByIdAsync(id);

            if (existingType == null)
                throw new NotFoundException($"IngredientType with ID {id} not found");

            // Validate name
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("IngredientType name cannot be empty");

            // Check for duplicate names (excluding current type)
            var exists = await _unitOfWork.Repository<IngredientType>()
                .AnyAsync(it => it.Name == entity.Name && it.IngredientTypeId != id && !it.IsDelete);

            if (exists)
                throw new ValidationException($"IngredientType with name {entity.Name} already exists");

            entity.SetUpdateDate();
            await _unitOfWork.Repository<IngredientType>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ingredientType = await GetByIdAsync(id);

            if (ingredientType == null)
                throw new NotFoundException($"IngredientType with ID {id} not found");

            // Check if type has any active ingredients
            if (await IsTypeInUseAsync(id))
                throw new ValidationException("Cannot delete ingredient type that has active ingredients");

            ingredientType.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsTypeInUseAsync(int id)
        {
            return await _unitOfWork.Repository<Ingredient>()
                .AnyAsync(i => i.IngredientTypeID == id && !i.IsDelete);
        }

        public async Task<int> GetIngredientCountAsync(int id)
        {
            var ingredientType = await GetByIdAsync(id);

            if (ingredientType == null)
                throw new NotFoundException($"IngredientType with ID {id} not found");

            return await _unitOfWork.Repository<Ingredient>()
                .FindAll(i => i.IngredientTypeID == id && !i.IsDelete)
                .CountAsync();
        }
    }
}
