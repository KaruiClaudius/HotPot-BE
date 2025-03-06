using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.FeedbackService
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;


        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int feedbackId)
        {
            return await _unitOfWork.Repository<Feedback>()
                .AsQueryable(f => f.FeedbackId == feedbackId)
                .Include(f => f.User)
                .Include(f => f.Order)
                .Include(f => f.Manager)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll()
                .Include(f => f.User)
                .Include(f => f.Order)
                .Include(f => f.Manager)
                .OrderByDescending(f => f.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackByUserIdAsync(int userId, int pageNumber = 1, int pageSize = 10)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.UserID == userId)
                .Include(f => f.Order)
                .Include(f => f.Manager)
                .OrderByDescending(f => f.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackByOrderIdAsync(int orderId)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.OrderID == orderId)
                .Include(f => f.User)
                .Include(f => f.Manager)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetUnrespondedFeedbackAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.Response == null)
                .Include(f => f.User)
                .Include(f => f.Order)
                .OrderByDescending(f => f.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Feedback> RespondToFeedbackAsync(int feedbackId, int managerId, string response)
        {
            // Verify feedback exists
            var feedback = await _unitOfWork.Repository<Feedback>()
                .FindAsync(f => f.FeedbackId == feedbackId);

            if (feedback == null)
                throw new KeyNotFoundException($"Feedback with ID {feedbackId} not found");

            // Verify manager exists
            var manager = await _unitOfWork.Repository<Manager>()
                .FindAsync(m => m.ManagerId == managerId);

            if (manager == null)
                throw new KeyNotFoundException($"Manager with ID {managerId} not found");

            // Update the feedback with the response
            feedback.Response = response;
            feedback.ResponseDate = DateTime.UtcNow;
            feedback.ManagerId = managerId;
            feedback.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            // Load the manager for the response
            feedback.Manager = manager;

            return feedback;
        }

        public async Task<int> GetTotalFeedbackCountAsync()
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll()
                .CountAsync();
        }

        public async Task<int> GetUnrespondedFeedbackCountAsync()
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.Response == null)
                .CountAsync();
        }

        public async Task<Feedback> CreateFeedbackAsync(CreateFeedbackRequest request)
        {
            // First, verify that the OrderId exists
            var orderExists = await _unitOfWork.Repository<Order>().GetById(request.OrderId) != null;
            if (!orderExists)
            {
                throw new InvalidOperationException($"Order with ID {request.OrderId} does not exist. Cannot create feedback for a non-existent order.");
            }

            // Also verify that the UserId exists
            var userExists = await _unitOfWork.Repository<User>().GetById(request.UserId) != null;
            if (!userExists)
            {
                throw new InvalidOperationException($"User with ID {request.UserId} does not exist. Cannot create feedback for a non-existent user.");
            }

            // Create a new feedback entity
            var feedback = new Feedback
            {
                Title = request.Title,
                Comment = request.Comment,
                ImageURLs = request.ImageURLs,
                OrderID = request.OrderId,
                UserID = request.UserId,
                CreatedAt = DateTime.UtcNow
            };

            // Save the feedback
            _unitOfWork.Repository<Feedback>().Insert(feedback);
            await _unitOfWork.CommitAsync();

            // Load related entities for the response
            feedback = await GetFeedbackByIdAsync(feedback.FeedbackId);

            return feedback;
        }


    }
}
