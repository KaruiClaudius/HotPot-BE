using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
    public class ManagerFeedbackService : IManagerFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerFeedbackService(IUnitOfWork unitOfWork)
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
    }
}
