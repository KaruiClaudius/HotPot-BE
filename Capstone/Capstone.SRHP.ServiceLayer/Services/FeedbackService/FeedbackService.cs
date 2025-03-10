using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
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
                .Include(f => f.ApprovedByUser)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll()
                .Include(f => f.User)
                .Include(f => f.Order)
                .Include(f => f.Manager)
                .Include(f => f.ApprovedByUser)
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
                .Include(f => f.ApprovedByUser)
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
                .Include(f => f.ApprovedByUser)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetTotalFeedbackCountAsync()
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll()
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

        public async Task<Feedback> ApproveFeedbackAsync(int feedbackId, int adminUserId)
        {
            // Verify feedback exists
            var feedback = await _unitOfWork.Repository<Feedback>()
                .FindAsync(f => f.FeedbackId == feedbackId);

            if (feedback == null)
                throw new KeyNotFoundException($"Feedback with ID {feedbackId} not found");

            // Verify user exists and has admin role
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == adminUserId);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {adminUserId} not found");

            // Update the feedback approval status
            feedback.ApprovalStatus = FeedbackApprovalStatus.Approved;
            feedback.ApprovalDate = DateTime.UtcNow;
            feedback.ApprovedByUserId = adminUserId;
            feedback.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            // Load the admin user for the response
            feedback.ApprovedByUser = user;

            return feedback;
        }

        public async Task<Feedback> RejectFeedbackAsync(int feedbackId, int adminUserId, string rejectionReason)
        {
            // Verify feedback exists
            var feedback = await _unitOfWork.Repository<Feedback>()
                .FindAsync(f => f.FeedbackId == feedbackId);

            if (feedback == null)
                throw new KeyNotFoundException($"Feedback with ID {feedbackId} not found");

            // Verify user exists and has admin role
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == adminUserId);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {adminUserId} not found");

            // Update the feedback approval status
            feedback.ApprovalStatus = FeedbackApprovalStatus.Rejected;
            feedback.ApprovalDate = DateTime.UtcNow;
            feedback.ApprovedByUserId = adminUserId;
            feedback.RejectionReason = rejectionReason;
            feedback.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            // Load the admin user for the response
            feedback.ApprovedByUser = user;

            return feedback;
        }

        public async Task<IEnumerable<Feedback>> GetPendingFeedbackAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.ApprovalStatus == FeedbackApprovalStatus.Pending)
                .Include(f => f.User)
                .Include(f => f.Order)
                .OrderByDescending(f => f.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<IEnumerable<Feedback>> GetFeedbackByStatusAsync(FeedbackApprovalStatus status, int pageNumber = 1, int pageSize = 10)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.ApprovalStatus == status)
                .Include(f => f.User)
                .Include(f => f.Order)
                .Include(f => f.Manager)
                .Include(f => f.ApprovedByUser)
                .OrderByDescending(f => f.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }



        // Update existing methods to respect approval status
        public async Task<IEnumerable<Feedback>> GetUnrespondedFeedbackAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.Response == null && f.ApprovalStatus == FeedbackApprovalStatus.Approved)
                .Include(f => f.User)
                .Include(f => f.Order)
                .OrderByDescending(f => f.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetUnrespondedFeedbackCountAsync()
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.Response == null && f.ApprovalStatus == FeedbackApprovalStatus.Approved)
                .CountAsync();
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

            // Check if feedback is approved
            if (feedback.ApprovalStatus != FeedbackApprovalStatus.Approved)
                throw new InvalidOperationException($"Cannot respond to feedback with ID {feedbackId} because it has not been approved");

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
        public async Task<int> GetFeedbackCountByStatusAsync(FeedbackApprovalStatus status)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.ApprovalStatus == status)
                .CountAsync();
        }
    }
}
