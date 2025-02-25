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
    public class CustomizationService : ICustomizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int BROTH_TYPE_ID = 1; // Same as ComboService

        public CustomizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customization>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Customization>()
                .Include(c => c.CustomizationIngredients)
                .Include(c => c.HotpotBroth)
                .Include(c => c.User)
                .Where(c => !c.IsDelete)
                .ToListAsync();
        }

        public async Task<Customization?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Customization>()
                .Include(c => c.CustomizationIngredients)
                .Include(c => c.HotpotBroth)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.CustomizationId == id && !c.IsDelete);
        }

        public async Task<Customization> CreateAsync(Customization entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Customization name cannot be empty");

            // Validate user exists
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == entity.UserID && !u.IsDelete);

            if (user == null)
                throw new ValidationException("Invalid user");

            // Validate HotpotBroth
            await ValidateHotpotBroth(entity.HotpotBrothID);

            // Calculate initial total price
            entity.TotalPrice = await CalculateTotalPriceAsync(entity);

            _unitOfWork.Repository<Customization>().Insert(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task UpdateAsync(int id, Customization entity)
        {
            var existingCustomization = await GetByIdAsync(id);
            if (existingCustomization == null)
                throw new NotFoundException($"Customization with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Customization name cannot be empty");

            // Validate HotpotBroth if it's being changed
            if (existingCustomization.HotpotBrothID != entity.HotpotBrothID)
            {
                await ValidateHotpotBroth(entity.HotpotBrothID);
            }

            // Update total price
            entity.TotalPrice = await CalculateTotalPriceAsync(entity);
            entity.SetUpdateDate();

            await _unitOfWork.Repository<Customization>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customization = await GetByIdAsync(id);
            if (customization == null)
                throw new NotFoundException($"Customization with ID {id} not found");

            customization.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Customization>> GetUserCustomizationsAsync(int userId)
        {
            return await _unitOfWork.Repository<Customization>()
                .Include(c => c.CustomizationIngredients)
                .Include(c => c.HotpotBroth)
                .Where(c => c.UserID == userId && !c.IsDelete)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomizationIngredient>> GetCustomizationIngredientsAsync(int customizationId)
        {
            return await _unitOfWork.Repository<CustomizationIngredient>()
                .Include(ci => ci.Ingredient)
                .Where(ci => ci.CustomizationID == customizationId && !ci.IsDelete)
                .ToListAsync();
        }

        public async Task AddIngredientToCustomizationAsync(int customizationId, int ingredientId, int quantity)
        {
            var customization = await GetByIdAsync(customizationId);
            if (customization == null)
                throw new NotFoundException($"Customization with ID {customizationId} not found");

            var ingredient = await _unitOfWork.Repository<Ingredient>()
                .Include(i => i.IngredientType)
                .FirstOrDefaultAsync(i => i.IngredientId == ingredientId && !i.IsDelete);

            if (ingredient == null)
                throw new NotFoundException($"Ingredient with ID {ingredientId} not found");

            // Don't allow adding broth as a regular ingredient
            if (ingredient.IngredientTypeID == BROTH_TYPE_ID)
                throw new ValidationException("Cannot add broth as a regular ingredient. Use HotpotBroth property instead.");

            // Check if ingredient already exists
            var existingIngredient = await _unitOfWork.Repository<CustomizationIngredient>()
                .FindAsync(ci => ci.CustomizationID == customizationId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (existingIngredient != null)
                throw new ValidationException("Ingredient already exists in customization");

            var customizationIngredient = new CustomizationIngredient
            {
                CustomizationID = customizationId,
                IngredientID = ingredientId,
                Quantity = quantity
            };

            _unitOfWork.Repository<CustomizationIngredient>().Insert(customizationIngredient);

            // Update total price
            customization.TotalPrice = await CalculateTotalPriceAsync(customization);
            customization.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveIngredientFromCustomizationAsync(int customizationId, int ingredientId)
        {
            var customizationIngredient = await _unitOfWork.Repository<CustomizationIngredient>()
                .FindAsync(ci => ci.CustomizationID == customizationId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (customizationIngredient == null)
                throw new NotFoundException("Ingredient not found in customization");

            customizationIngredient.SoftDelete();

            // Update total price
            var customization = await GetByIdAsync(customizationId);
            if (customization != null)
            {
                customization.TotalPrice = await CalculateTotalPriceAsync(customization);
                customization.SetUpdateDate();
            }

            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateIngredientQuantityAsync(int customizationId, int ingredientId, int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ValidationException("Quantity must be greater than 0");

            var customizationIngredient = await _unitOfWork.Repository<CustomizationIngredient>()
                .FindAsync(ci => ci.CustomizationID == customizationId && ci.IngredientID == ingredientId && !ci.IsDelete);

            if (customizationIngredient == null)
                throw new NotFoundException("Ingredient not found in customization");

            customizationIngredient.Quantity = newQuantity;
            customizationIngredient.SetUpdateDate();

            // Update total price
            var customization = await GetByIdAsync(customizationId);
            if (customization != null)
            {
                customization.TotalPrice = await CalculateTotalPriceAsync(customization);
                customization.SetUpdateDate();
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

        public async Task<decimal> CalculateTotalPriceAsync(int customizationId)
        {
            var customization = await GetByIdAsync(customizationId);
            if (customization == null)
                throw new NotFoundException($"Customization with ID {customizationId} not found");

            return await CalculateTotalPriceAsync(customization);
        }

        private async Task<decimal> CalculateTotalPriceAsync(Customization customization)
        {
            //decimal totalPrice = 0;

            //// Add hotpot broth price
            //var broth = await _unitOfWork.Repository<Ingredient>()
            //    .FindAsync(i => i.IngredientId == customization.HotpotBrothID && !i.IsDelete);
            //if (broth != null)
            //{
            //    totalPrice += broth.Price;
            //}

            //// Add ingredients prices
            //var customizationIngredients = await _unitOfWork.Repository<CustomizationIngredient>()
            //    .Include(ci => ci.Ingredient)
            //    .Where(ci => ci.CustomizationID == customization.CustomizationId && !ci.IsDelete)
            //    .ToListAsync();

            //foreach (var customizationIngredient in customizationIngredients)
            //{
            //    if (customizationIngredient.Ingredient != null)
            //    {
            //        totalPrice += customizationIngredient.Ingredient.IngredientPrices.Price * customizationIngredient.Quantity;
            //    }
            //}

            //return totalPrice;
            return 0;
        }
    }
}
