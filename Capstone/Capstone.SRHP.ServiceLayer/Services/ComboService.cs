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
    public class ComboService : IComboService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int BROTH_TYPE_ID = 1; // Adjust this to match your broth type ID

        public ComboService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Combo>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Combo>()
                .Include(c => c.ComboIngredients)
                .Include(c => c.HotpotBroth)
                .Where(c => !c.IsDelete)
                .ToListAsync();
        }

        public async Task<Combo?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Combo>()
                .Include(c => c.ComboIngredients)
                .Include(c => c.HotpotBroth)
                .FirstOrDefaultAsync(c => c.ComboId == id && !c.IsDelete);
        }

        public async Task<Combo> CreateAsync(Combo entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Combo name cannot be empty");

            if (entity.Size <= 0)
                throw new ValidationException("Combo size must be greater than 0");

            // Validate HotpotBroth
            await ValidateHotpotBroth(entity.HotpotBrothID);

            // Calculate initial total price
            entity.TotalPrice = await CalculateTotalPriceAsync(entity);

            _unitOfWork.Repository<Combo>().Insert(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task UpdateAsync(int id, Combo entity)
        {
            var existingCombo = await GetByIdAsync(id);
            if (existingCombo == null)
                throw new NotFoundException($"Combo with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Combo name cannot be empty");

            if (entity.Size <= 0)
                throw new ValidationException("Combo size must be greater than 0");

            // Validate HotpotBroth if it's being changed
            if (existingCombo.HotpotBrothID != entity.HotpotBrothID)
            {
                await ValidateHotpotBroth(entity.HotpotBrothID);
            }

            // Update total price
            entity.TotalPrice = await CalculateTotalPriceAsync(entity);
            entity.SetUpdateDate();

            await _unitOfWork.Repository<Combo>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var combo = await GetByIdAsync(id);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {id} not found");

            combo.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Combo>> GetActiveAsync()
        {
            return await _unitOfWork.Repository<Combo>()
                .Include(c => c.ComboIngredients)
                .Include(c => c.HotpotBroth)
                .Where(c => !c.IsDelete)
                .ToListAsync();
        }

        public async Task<IEnumerable<ComboIngredient>> GetComboIngredientsAsync(int comboId)
        {
            return await _unitOfWork.Repository<ComboIngredient>()
                .Include(ci => ci.Ingredient)
                .Where(ci => ci.ComboID == comboId && !ci.IsDelete)
                .ToListAsync();
        }

        public async Task AddIngredientToComboAsync(int comboId, int ingredientId, int quantity)
        {
            var combo = await GetByIdAsync(comboId);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {comboId} not found");

            var ingredient = await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .FirstOrDefaultAsync(i => i.IngredientId == ingredientId && !i.IsDelete);

            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {ingredientId} not found");

            // Don't allow adding broth as a regular ingredient
            if (ingredient.IngredientTypeID == BROTH_TYPE_ID)
                throw new ValidationException("Cannot add broth as a regular ingredient. Use HotpotBroth property instead.");

            // Check if ingredient already exists in combo
            var existingIngredient = await _unitOfWork.Repository<ComboIngredient>()
                .FindAsync(ci => ci.ComboID == comboId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (existingIngredient != null)
                throw new ValidationException("Ingredient already exists in combo");

            var comboIngredient = new ComboIngredient
            {
                ComboID = comboId,
                IngredientID = ingredientId,
                Quantity = quantity
            };

            _unitOfWork.Repository<ComboIngredient>().Insert(comboIngredient);

            // Update combo total price
            combo.TotalPrice = await CalculateTotalPriceAsync(combo);
            combo.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveIngredientFromComboAsync(int comboId, int ingredientId)
        {
            var comboIngredient = await _unitOfWork.Repository<ComboIngredient>()
                .FindAsync(ci => ci.ComboID == comboId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (comboIngredient == null)
                throw new NotFoundException("Ingredient not found in combo");

            comboIngredient.SoftDelete();

            // Update combo total price
            var combo = await GetByIdAsync(comboId);
            if (combo != null)
            {
                combo.TotalPrice = await CalculateTotalPriceAsync(combo);
                combo.SetUpdateDate();
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateIngredientQuantityAsync(int comboId, int ingredientId, int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ValidationException("Quantity must be greater than 0");

            var comboIngredient = await _unitOfWork.Repository<ComboIngredient>()
                .FindAsync(ci => ci.ComboID == comboId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (comboIngredient == null)
                throw new NotFoundException("Ingredient not found in combo");

            comboIngredient.Quantity = newQuantity;
            comboIngredient.SetUpdateDate();

            // Update combo total price
            var combo = await GetByIdAsync(comboId);
            if (combo != null)
            {
                combo.TotalPrice = await CalculateTotalPriceAsync(combo);
                combo.SetUpdateDate();
            }

            await _unitOfWork.CommitAsync();
        }
        private async Task ValidateHotpotBroth(int brothId)
        {
            var broth = await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .FirstOrDefaultAsync(i => i.IngredientId == brothId && !i.IsDelete);

            if (broth == null)
                throw new ValidationException("Invalid hotpot broth selected");

            if (broth.IngredientTypeID != BROTH_TYPE_ID)
                throw new ValidationException("Selected ingredient is not a broth type");

            if (broth.Quantity <= 0)
                throw new ValidationException("Selected broth is out of stock");
        }

        public async Task<decimal> CalculateTotalPriceAsync(int comboId)
        {
            var combo = await GetByIdAsync(comboId);
            if (combo == null)
                throw new NotFoundException($"Combo with ID {comboId} not found");

            return await CalculateTotalPriceAsync(combo);
        }

        private async Task<decimal> CalculateTotalPriceAsync(Combo combo)
        {
            //decimal totalPrice = 0;

            //// Add hotpot broth price
            //var broth = await _unitOfWork.Repository<Ingredient>()
            //    .FindAsync(i => i.IngredientId == combo.HotpotBrothID && !i.IsDelete);
            //if (broth != null)
            //{
            //    totalPrice += broth.IngredientPrices.;
            //}

            //// Add ingredients prices
            //var comboIngredients = await _unitOfWork.Repository<ComboIngredient>()
            //    .Include(ci => ci.Ingredient)
            //    .Where(ci => ci.ComboID == combo.ComboId && !ci.IsDelete)
            //    .ToListAsync();

            //foreach (var comboIngredient in comboIngredients)
            //{
            //    if (comboIngredient.Ingredient != null)
            //    {
            //        totalPrice += comboIngredient.Ingredient.IngredientPrices * comboIngredient.Quantity;
            //    }
            //}

            //// Apply discount if any
            //if (combo.Discount > 0)
            //{
            //    totalPrice = totalPrice * (1 - (decimal)(combo.Discount / 100));
            //}

            return 0;
        }
    }
}
