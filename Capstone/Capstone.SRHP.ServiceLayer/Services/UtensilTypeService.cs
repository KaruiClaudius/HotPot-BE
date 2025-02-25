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
                .Include(ut => ut.Utensils)
                .Where(ut => !ut.IsDelete)
                .ToListAsync();
        }

        public async Task<UtensilType?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<UtensilType>()
                .Include(ut => ut.Utensils)
                .FirstOrDefaultAsync(ut => ut.UtensilTypeId == id && !ut.IsDelete);
        }


        public async Task<UtensilType> CreateAsync(UtensilType entity)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("UtensilType name cannot be empty");

            // Check for existing type (including soft-deleted)
            var existingType = await _unitOfWork.Repository<UtensilType>()
                .FindAsync(ut => ut.Name == entity.Name);

            if (existingType != null)
            {
                if (!existingType.IsDelete)
                {
                    throw new ValidationException($"UtensilType with name {entity.Name} already exists");
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

            _unitOfWork.Repository<UtensilType>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }


        public async Task UpdateAsync(int id, UtensilType entity)
        {
            var existingType = await GetByIdAsync(id);
            if (existingType == null)
                throw new NotFoundException($"UtensilType with ID {id} not found");

            // Validate name
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("UtensilType name cannot be empty");

            // Check for duplicate names (excluding current type)
            var exists = await _unitOfWork.Repository<UtensilType>()
                .FindAsync(ut => ut.Name == entity.Name && ut.UtensilTypeId != id && !ut.IsDelete);

            if (exists != null)
                throw new ValidationException($"UtensilType with name {entity.Name} already exists");

            entity.SetUpdateDate();
            await _unitOfWork.Repository<UtensilType>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var utensilType = await GetByIdAsync(id);
            if (utensilType == null)
                throw new NotFoundException($"UtensilType with ID {id} not found");

            // Check if type has any active utensils
            if (await IsTypeInUseAsync(id))
                throw new ValidationException("Cannot delete utensil type that has active utensils");

            utensilType.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsTypeInUseAsync(int id)
        {
            var utensil = await _unitOfWork.Repository<Utensil>()
                .FindAsync(u => u.UtensilTypeID == id && !u.IsDelete);
            return utensil != null;
        }

        public async Task<int> GetUtensilCountAsync(int id)
        {
            var utensilType = await GetByIdAsync(id);
            if (utensilType == null)
                throw new NotFoundException($"UtensilType with ID {id} not found");

            return await _unitOfWork.Repository<Utensil>()
                .FindAll(u => u.UtensilTypeID == id && !u.IsDelete)
                .CountAsync();
        }
    }
}
