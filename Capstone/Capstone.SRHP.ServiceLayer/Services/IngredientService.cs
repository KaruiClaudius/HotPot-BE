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
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices)
                .Where(i => !i.IsDelete)
                .ToListAsync();
        }

        public async Task<Ingredient?> GetByIdAsync(int id)
        {
            var ingredient = await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .Include(i => i.IngredientPrices)
                .FirstOrDefaultAsync(i => i.IngredientId == id && !i.IsDelete);

            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {id} not found");

            return ingredient;
        }

        public async Task<Ingredient> CreateAsync(Ingredient entity)
        {
            // Validate minimum stock level
            if (entity.MinStockLevel < 0)
                throw new ValidationException("Minimum stock level cannot be negative");

            // Validate initial quantity
            if (entity.Quantity < 0)
                throw new ValidationException("Quantity cannot be negative");


            // Create initial price history
            var priceHistory = new IngredientPrice
            {
                EffectiveDate = DateTime.UtcNow,
                IngredientID = entity.IngredientId
            };

            _unitOfWork.Repository<Ingredient>().Insert(entity);
            await _unitOfWork.CommitAsync();

            // Add price history after ingredient is created
            priceHistory.IngredientID = entity.IngredientId;
            _unitOfWork.Repository<IngredientPrice>().Insert(priceHistory);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task UpdateAsync(int id, Ingredient entity)
        {
            var existingIngredient = await GetByIdAsync(id);

            if (existingIngredient == null)
                throw new NotFoundException($"Ingredient with ID {id} not found");



            entity.SetUpdateDate();
            await _unitOfWork.Repository<Ingredient>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ingredient = await GetByIdAsync(id);

            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {id} not found");

            // Check if ingredient is used in any active combos
            var usedInCombos = await _unitOfWork.Repository<ComboIngredient>()
                .AnyAsync(ci => ci.IngredientID == id && !ci.IsDelete);

            if (usedInCombos)
                throw new ValidationException("Cannot delete ingredient that is used in active combos");

            ingredient.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetByTypeAsync(int typeId)
        {
            return await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientPrices)
                .Where(i => i.IngredientTypeID == typeId && !i.IsDelete)
                .ToListAsync();
        }

        public async Task<bool> UpdateStockAsync(int id, int quantity)
        {
            var ingredient = await GetByIdAsync(id);

            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {id} not found");

            // Prevent negative stock
            if (ingredient.Quantity + quantity < 0)
                throw new ValidationException("Cannot reduce stock below zero");

            ingredient.Quantity += quantity;
            ingredient.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            // Return true if stock is below minimum level
            return ingredient.Quantity <= ingredient.MinStockLevel;
        }

        public async Task<IEnumerable<Ingredient>> GetLowStockIngredientsAsync()
        {
            return await _unitOfWork.Repository<Ingredient>()
                .FindAll(i => !i.IsDelete && i.Quantity <= i.MinStockLevel)
                .ToListAsync();
        }

        public async Task<decimal> GetCurrentPriceAsync(int id)
        {
            //var ingredient = await GetByIdAsync(id);

            //if (ingredient == null)
            //    throw new NotFoundException($"Ingredient with ID {id} not found");

            //return ingredient.Price;
            return 0;
        }

        public async Task UpdatePriceAsync(int id, decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ValidationException("Price must be greater than zero");

            var ingredient = await GetByIdAsync(id);

            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {id} not found");

            // Create price history record
            var priceHistory = new IngredientPrice
            {
                IngredientID = id,
                Price = newPrice,
                EffectiveDate = DateTime.UtcNow
            };

            //ingredient.Price = newPrice;
            ingredient.SetUpdateDate();

            _unitOfWork.Repository<IngredientPrice>().Insert(priceHistory);
            await _unitOfWork.CommitAsync();
        }
    }
}
