using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static Capstone.HPTY.ModelLayer.Exceptions.ValidationException;

namespace Capstone.HPTY.ServiceLayer.Services.FeedbackService
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int MANAGER_ROLE_ID = 2; // Manager role ID


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
                .GetAll(f => f.UserId == userId)
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
                .GetAll(f => f.OrderId == orderId)
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
                OrderId = request.OrderId,
                UserId = request.UserId,
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
            try
            {
                // Verify feedback exists
                var feedback = await _unitOfWork.Repository<Feedback>()
                    .FindAsync(f => f.FeedbackId == feedbackId);

                if (feedback == null)
                    throw new NotFoundException($"Feedback with ID {feedbackId} not found");

                // Verify manager exists (user with manager role)
                var manager = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == managerId && u.RoleId == MANAGER_ROLE_ID && !u.IsDelete);

                if (manager == null)
                    throw new NotFoundException($"Manager with ID {managerId} not found");

                // Check if feedback is approved
                if (feedback.ApprovalStatus != FeedbackApprovalStatus.Approved)
                    throw new ValidationException($"Cannot respond to feedback with ID {feedbackId} because it has not been approved");

                // Update the feedback with the response
                feedback.Response = response;
                feedback.ResponseDate = DateTime.UtcNow;
                feedback.ManagerId = managerId;
                feedback.SetUpdateDate();

                await _unitOfWork.CommitAsync();

                // Load the manager for the response
                feedback.Manager = manager;

                return feedback;
            }
            catch (NotFoundException)
            {
                // Re-throw NotFoundException to be handled by the caller
                throw;
            }
            catch (ValidationException)
            {
                // Re-throw ValidationException to be handled by the caller
                throw;
            }
            catch (Exception ex)
            {
                // Log the exception and throw a more specific exception
                // _logger.LogError(ex, "Error responding to feedback {FeedbackId} by manager {ManagerId}", feedbackId, managerId);
                throw new ServiceException($"An error occurred while responding to feedback: {ex.Message}", ex);
            }
        }
        public async Task<int> GetFeedbackCountByStatusAsync(FeedbackApprovalStatus status)
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.ApprovalStatus == status)
                .CountAsync();
        }
        public async Task<PagedResult<Feedback>> GetFilteredFeedbackAsync(FeedbackFilterRequest request)
        {
            // Start with base query
            var query = _unitOfWork.Repository<Feedback>()
                .AsQueryable()
                .Include(f => f.User)
                .Include(f => f.Order)
                .Include(f => f.Manager)
                .Include(f => f.ApprovedByUser)
                .AsQueryable(); 

            // Apply filters (only if provided)
            if (request.ApprovalStatus.HasValue)
            {
                query = query.Where(f => f.ApprovalStatus == request.ApprovalStatus.Value);
            }

            if (request.UserId.HasValue)
            {
                query = query.Where(f => f.UserId == request.UserId.Value);
            }

            if (request.OrderId.HasValue)
            {
                query = query.Where(f => f.OrderId == request.OrderId.Value);
            }

            if (request.FromDate.HasValue)
            {
                query = query.Where(f => f.CreatedAt >= request.FromDate.Value);
            }

            if (request.ToDate.HasValue)
            {
                // Add one day to include the entire end date
                var endDate = request.ToDate.Value.AddDays(1).AddTicks(-1);
                query = query.Where(f => f.CreatedAt <= endDate);
            }

            if (request.HasResponse.HasValue)
            {
                if (request.HasResponse.Value)
                {
                    query = query.Where(f => !string.IsNullOrEmpty(f.Response));
                }
                else
                {
                    query = query.Where(f => string.IsNullOrEmpty(f.Response));
                }
            }

            // Apply search (only if provided)
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(f =>
                    f.Title.ToLower().Contains(searchTerm) ||
                    f.Comment.ToLower().Contains(searchTerm) ||
                    (f.Response != null && f.Response.ToLower().Contains(searchTerm)) ||
                    (f.User != null && f.User.Name.ToLower().Contains(searchTerm))
                );
            }

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Apply sorting
            query = ApplySorting(query, request.SortBy, !request.Ascending);

            // Apply pagination
            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            // Return paged result
            return new PagedResult<Feedback>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

        private IQueryable<Feedback> ApplySorting(IQueryable<Feedback> query, string sortBy, bool sortDescending)
        {
            // Default to CreatedAt if sortBy is invalid
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "CreatedAt";
            }

            // Apply sorting based on property name
            switch (sortBy.ToLower())
            {
                case "title":
                    return sortDescending
                        ? query.OrderByDescending(f => f.Title)
                        : query.OrderBy(f => f.Title);
                case "username":
                    return sortDescending
                        ? query.OrderByDescending(f => f.User.Name)
                        : query.OrderBy(f => f.User.Name);
                case "orderid":
                    return sortDescending
                        ? query.OrderByDescending(f => f.OrderId)
                        : query.OrderBy(f => f.OrderId);
                case "approvalstatus":
                    return sortDescending
                        ? query.OrderByDescending(f => f.ApprovalStatus)
                        : query.OrderBy(f => f.ApprovalStatus);
                case "responsedate":
                    return sortDescending
                        ? query.OrderByDescending(f => f.ResponseDate)
                        : query.OrderBy(f => f.ResponseDate);
                case "approvaldate":
                    return sortDescending
                        ? query.OrderByDescending(f => f.ApprovalDate)
                        : query.OrderBy(f => f.ApprovalDate);
                case "createdat":
                default:
                    return sortDescending
                        ? query.OrderByDescending(f => f.CreatedAt)
                        : query.OrderBy(f => f.CreatedAt);
            }
        }

    }
}
