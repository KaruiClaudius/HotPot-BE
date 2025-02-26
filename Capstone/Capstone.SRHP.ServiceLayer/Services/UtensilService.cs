using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
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
    public class UtensilService : IUtensilService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UtensilService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Utensil>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Utensil>()
                .Include(u => u.UtensilType)
                .Where(u => !u.IsDelete)
                .ToListAsync();
        }

        public async Task<Utensil?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Utensil>()
                .Include(u => u.UtensilType)
                .FirstOrDefaultAsync(u => u.UtensilId == id && !u.IsDelete);
        }

        public async Task<Utensil> CreateAsync(Utensil entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Utensil name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.Material))
                throw new ValidationException("Utensil material cannot be empty");

            if (entity.Price <= 0)
                throw new ValidationException("Price must be greater than 0");

            if (entity.Quantity < 0)
                throw new ValidationException("Quantity cannot be negative");

            // Check if utensil exists (including soft-deleted)
            var existingUtensil = await _unitOfWork.Repository<Utensil>()
                .FindAsync(u => u.Name == entity.Name);

            if (existingUtensil != null)
            {
                if (!existingUtensil.IsDelete)
                {
                    throw new ValidationException($"Utensil with name {entity.Name} already exists");
                }
                else
                {
                    // Reactivate and update the soft-deleted utensil
                    existingUtensil.IsDelete = false;
                    existingUtensil.Material = entity.Material;
                    existingUtensil.Price = entity.Price;
                    existingUtensil.Quantity = entity.Quantity;
                    existingUtensil.UtensilTypeID = entity.UtensilTypeID;
                    existingUtensil.LastMaintainDate = DateTime.UtcNow;
                    existingUtensil.SetUpdateDate();
                    await _unitOfWork.CommitAsync();
                    return existingUtensil;
                }
            }

            entity.LastMaintainDate = DateTime.UtcNow;
            _unitOfWork.Repository<Utensil>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, Utensil entity)
        {
            var existingUtensil = await GetByIdAsync(id);
            if (existingUtensil == null)
                throw new NotFoundException($"Utensil with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Utensil name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.Material))
                throw new ValidationException("Utensil material cannot be empty");

            if (entity.Price <= 0)
                throw new ValidationException("Price must be greater than 0");

            if (entity.Quantity < 0)
                throw new ValidationException("Quantity cannot be negative");

            // Validate UtensilType exists
            var utensilType = await _unitOfWork.Repository<UtensilType>()
                .FindAsync(ut => ut.UtensilTypeId == entity.UtensilTypeID && !ut.IsDelete);

            if (utensilType == null)
                throw new ValidationException("Invalid utensil type");

            entity.SetUpdateDate();
            await _unitOfWork.Repository<Utensil>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var utensil = await GetByIdAsync(id);
            if (utensil == null)
                throw new NotFoundException($"Utensil with ID {id} not found");

            utensil.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Utensil>> GetAvailableUtensilsAsync()
        {
            return await _unitOfWork.Repository<Utensil>()
                .Include(u => u.UtensilType)
                .Where(u => !u.IsDelete && u.Status && u.Quantity > 0)
                .ToListAsync();
        }

        public async Task<IEnumerable<Utensil>> GetByTypeAsync(int typeId)
        {
            return await _unitOfWork.Repository<Utensil>()
                .Include(u => u.UtensilType)
                .Where(u => u.UtensilTypeID == typeId && !u.IsDelete)
                .ToListAsync();
        }

        public async Task UpdateStatusAsync(int id, bool status)
        {
            var utensil = await GetByIdAsync(id);
            if (utensil == null)
                throw new NotFoundException($"Utensil with ID {id} not found");

            utensil.Status = status;
            utensil.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateQuantityAsync(int id, int quantity)
        {
            var utensil = await GetByIdAsync(id);
            if (utensil == null)
                throw new NotFoundException($"Utensil with ID {id} not found");

            if (utensil.Quantity + quantity < 0)
                throw new ValidationException("Cannot reduce quantity below 0");

            utensil.Quantity += quantity;
            utensil.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsAvailableAsync(int id)
        {
            var utensil = await GetByIdAsync(id);
            return utensil != null && utensil.Status && utensil.Quantity > 0;
        }

    }
}
