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
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Feedback>()
                .Include(f => f.User)
                .Include(f => f.Order)
                .Where(f => !f.IsDelete)
                .ToListAsync();
        }

        public async Task<Feedback?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Feedback>()
                .Include(f => f.User)
                .Include(f => f.Order)
                .FirstOrDefaultAsync(f => f.FeedbackId == id && !f.IsDelete);
        }

        public async Task<Feedback> CreateAsync(Feedback entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Title))
                throw new ValidationException("Feedback title cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.Comment))
                throw new ValidationException("Feedback comment cannot be empty");

            // Check if user has already provided feedback for this order
            var existingFeedback = await _unitOfWork.Repository<Feedback>()
                .FindAsync(f => f.UserID == entity.UserID && f.OrderID == entity.OrderID);

            if (existingFeedback != null)
            {
                if (!existingFeedback.IsDelete)
                {
                    throw new ValidationException("User has already provided feedback for this order");
                }
                else
                {
                    // Reactivate and update the soft-deleted feedback
                    existingFeedback.IsDelete = false;
                    existingFeedback.Title = entity.Title;
                    existingFeedback.Comment = entity.Comment;
                    existingFeedback.ImageURL = entity.ImageURL;
                    existingFeedback.SetUpdateDate();
                    await _unitOfWork.CommitAsync();
                    return existingFeedback;
                }
            }

            // Validate Order exists
            var order = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.OrderId == entity.OrderID && !o.IsDelete);
            if (order == null)
                throw new ValidationException("Order not found");

            _unitOfWork.Repository<Feedback>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, Feedback entity)
        {
            var existingFeedback = await GetByIdAsync(id);
            if (existingFeedback == null)
                throw new NotFoundException($"Feedback with ID {id} not found");

            // Validate basic properties
            ValidateFeedback(entity);

            // Validate User exists if changed
            if (existingFeedback.UserID != entity.UserID)
            {
                var user = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == entity.UserID && !u.IsDelete);

                if (user == null)
                    throw new ValidationException("Invalid user selected");
            }

            // Validate Order exists if changed
            if (existingFeedback.OrderID != entity.OrderID)
            {
                var order = await _unitOfWork.Repository<Order>()
                    .FindAsync(o => o.OrderId == entity.OrderID && !o.IsDelete);

                if (order == null)
                    throw new ValidationException("Invalid order selected");

                // Check if feedback already exists for new order
                var duplicateFeedback = await _unitOfWork.Repository<Feedback>()
                    .FindAsync(f => f.OrderID == entity.OrderID && f.FeedbackId != id && !f.IsDelete);

                if (duplicateFeedback != null)
                    throw new ValidationException("Feedback already exists for this order");
            }

            entity.SetUpdateDate();
            await _unitOfWork.Repository<Feedback>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var feedback = await GetByIdAsync(id);
            if (feedback == null)
                throw new NotFoundException($"Feedback with ID {id} not found");

            feedback.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByUserAsync(int userId)
        {
            return await _unitOfWork.Repository<Feedback>()
                .Include(f => f.User)
                .Include(f => f.Order)
                .Where(f => f.UserID == userId && !f.IsDelete)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByOrderAsync(int orderId)
        {
            return await _unitOfWork.Repository<Feedback>()
                .Include(f => f.User)
                .Include(f => f.Order)
                .Where(f => f.OrderID == orderId && !f.IsDelete)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetRecentFeedbackAsync(int count)
        {
            return await _unitOfWork.Repository<Feedback>()
                .Include(f => f.User)
                .Include(f => f.Order)
                .Where(f => !f.IsDelete)
                .OrderByDescending(f => f.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task UpdateImagesAsync(int feedbackId, string[] imageUrls)
        {
            var feedback = await GetByIdAsync(feedbackId);
            if (feedback == null)
                throw new NotFoundException($"Feedback with ID {feedbackId} not found");

            // Validate image URLs
            if (imageUrls != null && imageUrls.Any())
            {
                foreach (var url in imageUrls)
                {
                    if (!Uri.TryCreate(url, UriKind.Absolute, out _))
                        throw new ValidationException($"Invalid image URL: {url}");
                }
            }

            feedback.ImageURLs = imageUrls;
            feedback.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        private void ValidateFeedback(Feedback feedback)
        {
            if (string.IsNullOrWhiteSpace(feedback.Title))
                throw new ValidationException("Feedback title cannot be empty");

            if (feedback.Title.Length > 200)
                throw new ValidationException("Feedback title cannot exceed 200 characters");

            if (string.IsNullOrWhiteSpace(feedback.Comment))
                throw new ValidationException("Feedback comment cannot be empty");

            if (feedback.Comment.Length > 2000)
                throw new ValidationException("Feedback comment cannot exceed 2000 characters");

            if (feedback.UserID <= 0)
                throw new ValidationException("Invalid user ID");

            if (feedback.OrderID <= 0)
                throw new ValidationException("Invalid order ID");

            // Validate image URLs if present
            if (feedback.ImageURLs != null && feedback.ImageURLs.Any())
            {
                foreach (var url in feedback.ImageURLs)
                {
                    if (!Uri.TryCreate(url, UriKind.Absolute, out _))
                        throw new ValidationException($"Invalid image URL: {url}");
                }
            }
        }
    }
}
