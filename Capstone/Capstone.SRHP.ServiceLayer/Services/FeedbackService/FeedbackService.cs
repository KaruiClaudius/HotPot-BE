using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.RepositoryLayer.Utils;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.FeedbackService
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;


        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Common Methods

        public async Task<ManagerFeedbackDetailDto> GetFeedbackByIdAsync(int feedbackId)
        {
            var feedback = await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.FeedbackId == feedbackId)
                .Include(f => f.User)
                .Include(f => f.Order)
                .Include(f => f.Manager)
                .FirstOrDefaultAsync();

            if (feedback == null)
                return null;

            return MapToFeedbackDetailDto(feedback);
        }

        public async Task<FeedbackDetailDto> GetFeedbackDetailByIdAsync(int feedbackId)
        {
            var feedback = await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.FeedbackId == feedbackId)
                .Include(f => f.User)
                .Include(f => f.Order)
                .Include(f => f.Manager)
                .FirstOrDefaultAsync();

            if (feedback == null)
                return null;

            return MapToAdminFeedbackDetailDto(feedback);
        }

        public async Task<int> GetTotalFeedbackCountAsync()
        {
            return await _unitOfWork.Repository<Feedback>()
                .GetAll()
                .CountAsync();
        }

        #endregion

        #region Customer Methods

        public async Task<ManagerFeedbackDetailDto> CreateFeedbackAsync(CreateFeedbackRequest request)
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
                Comment = request.Comment,
                OrderId = request.OrderId,
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow.AddHours(7),
            };

            // Save the feedback
            _unitOfWork.Repository<Feedback>().Insert(feedback);
            await _unitOfWork.CommitAsync();

            // Load related entities and return as DTO
            return await GetFeedbackByIdAsync(feedback.FeedbackId);
        }

        public async Task<IEnumerable<ManagerFeedbackListDto>> GetFeedbackByOrderIdAsync(int orderId)
        {
            var feedbacks = await _unitOfWork.Repository<Feedback>()
                .GetAll(f => f.OrderId == orderId)
                .Include(f => f.User)
                .Include(f => f.Manager)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();

            return feedbacks.Select(MapToFeedbackListDto).ToList();
        }


        #endregion

        #region Admin Methods

        public async Task<PagedResult<FeedbackListDto>> GetFilteredFeedbackAsync(FeedbackFilterRequest request)
        {
            // Start with base query - use AsQueryable() to ensure we have a standard IQueryable
            var query = _unitOfWork.Repository<Feedback>().GetAll().AsQueryable();

            // Apply includes
            query = query.Include(f => f.User)
                        .Include(f => f.Order)
                        .Include(f => f.Manager);


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

            // Apply search (only if provided)
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(i =>
                    i.Comment.ToLower().Contains(searchTerm) ||
                    (i.User != null && i.User.Name.ToLower().Contains(searchTerm))
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

            // Map to DTOs
            var dtoItems = items.Select(MapToAdminFeedbackListDto).ToList();

            // Return paged result
            return new PagedResult<FeedbackListDto>
            {
                Items = dtoItems,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

        //public async Task<FeedbackDetailDto> ApproveFeedbackAsync(int feedbackId, int adminUserId)
        //{
        //    // Verify feedback exists
        //    var feedback = await _unitOfWork.Repository<Feedback>()
        //        .FindAsync(f => f.FeedbackId == feedbackId);

        //    if (feedback == null)
        //        throw new KeyNotFoundException($"Feedback with ID {feedbackId} not found");

        //    // Verify user exists and has admin role
        //    var admin = await _unitOfWork.Repository<User>()
        //        .FindAsync(u => u.UserId == adminUserId && u.RoleId == ADMIN_ROLE_ID);

        //    if (admin == null)
        //        throw new KeyNotFoundException($"Admin with ID {adminUserId} not found");

        //    // Update the feedback approval status
        //    feedback.ApprovalStatus = FeedbackApprovalStatus.Approved;
        //    feedback.ApprovalDate = DateTime.UtcNow.AddHours(7);
        //    feedback.ApprovedByUserId = adminUserId;
        //    feedback.UpdatedAt = DateTime.UtcNow.AddHours(7);

        //    await _unitOfWork.CommitAsync();

        //    // Load the complete feedback with related entities
        //    var updatedFeedback = await _unitOfWork.Repository<Feedback>()
        //        .GetAll(f => f.FeedbackId == feedbackId)
        //        .Include(f => f.User)
        //        .Include(f => f.Order)
        //        .Include(f => f.Manager)
        //        .Include(f => f.ApprovedByUser)
        //        .FirstOrDefaultAsync();

        //    return MapToAdminFeedbackDetailDto(updatedFeedback);
        //}

        //public async Task<FeedbackDetailDto> RejectFeedbackAsync(int feedbackId, int adminUserId, string rejectionReason)
        //{
        //    // Verify feedback exists
        //    var feedback = await _unitOfWork.Repository<Feedback>()
        //        .FindAsync(f => f.FeedbackId == feedbackId);

        //    if (feedback == null)
        //        throw new KeyNotFoundException($"Feedback with ID {feedbackId} not found");

        //    // Verify user exists and has admin role
        //    var admin = await _unitOfWork.Repository<User>()
        //        .FindAsync(u => u.UserId == adminUserId && u.RoleId == ADMIN_ROLE_ID);

        //    if (admin == null)
        //        throw new KeyNotFoundException($"Admin with ID {adminUserId} not found");

        //    // Update the feedback approval status
        //    feedback.ApprovalStatus = FeedbackApprovalStatus.Rejected;
        //    feedback.ApprovalDate = DateTime.UtcNow.AddHours(7);
        //    feedback.ApprovedByUserId = adminUserId;
        //    feedback.RejectionReason = rejectionReason;
        //    feedback.UpdatedAt = DateTime.UtcNow.AddHours(7);

        //    await _unitOfWork.CommitAsync();

        //    // Load the complete feedback with related entities
        //    var updatedFeedback = await _unitOfWork.Repository<Feedback>()
        //        .GetAll(f => f.FeedbackId == feedbackId)
        //        .Include(f => f.User)
        //        .Include(f => f.Order)
        //        .Include(f => f.Manager)
        //        .Include(f => f.ApprovedByUser)
        //        .FirstOrDefaultAsync();

        //    return MapToAdminFeedbackDetailDto(updatedFeedback);
        //}

        public async Task<FeedbackStats> GetFeedbackStatsAsync()
        {
            // Get counts for different feedback statuses
            var totalCount = await GetTotalFeedbackCountAsync();


            return new FeedbackStats
            {
                TotalFeedbackCount = totalCount,

            };
        }

        #endregion

        #region Helper Methods

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
                case "username":
                    return sortDescending
                        ? query.OrderByDescending(f => f.User.Name)
                        : query.OrderBy(f => f.User.Name);
                case "orderid":
                    return sortDescending
                        ? query.OrderByDescending(f => f.OrderId)
                        : query.OrderBy(f => f.OrderId);
                case "createdat":
                default:
                    return sortDescending
                        ? query.OrderByDescending(f => f.CreatedAt)
                        : query.OrderBy(f => f.CreatedAt);
            }
        }

        private ManagerFeedbackListDto MapToFeedbackListDto(Feedback feedback)
        {
            return new ManagerFeedbackListDto
            {
                FeedbackId = feedback.FeedbackId,
                Comment = feedback.Comment,
                CreatedAt = feedback.CreatedAt,
                User = feedback.User != null ? new UserInfoDto
                {
                    UserId = feedback.User.UserId,
                    Name = feedback.User.Name,
                    Email = feedback.User.Email
                } : null,
                Order = feedback.Order != null ? new OrderInfoDto
                {
                    OrderId = feedback.Order.OrderId,
                } : null
            };
        }

        private ManagerFeedbackDetailDto MapToFeedbackDetailDto(Feedback feedback)
        {
            return new ManagerFeedbackDetailDto
            {
                FeedbackId = feedback.FeedbackId,
                Comment = feedback.Comment,
                ImageURLs = feedback.ImageURLs,
                CreatedAt = feedback.CreatedAt,

                User = feedback.User != null ? new UserInfoDto
                {
                    UserId = feedback.User.UserId,
                    Name = feedback.User.Name,
                    Email = feedback.User.Email
                } : null,
                Manager = feedback.Manager != null ? new UserInfoDto
                {
                    UserId = feedback.Manager.UserId,
                    Name = feedback.Manager.Name,
                    Email = feedback.Manager.Email
                } : null,
                Order = feedback.Order != null ? new OrderInfoDto
                {
                    OrderId = feedback.Order.OrderId,
                } : null
            };
        }

        private FeedbackListDto MapToAdminFeedbackListDto(Feedback feedback)
        {
            return new FeedbackListDto
            {
                FeedbackId = feedback.FeedbackId,
                UserName = feedback.User?.Name ?? "Unknown",
                OrderId = feedback.OrderId,
                CreatedAt = feedback.CreatedAt,
            };
        }

        private FeedbackDetailDto MapToAdminFeedbackDetailDto(Feedback feedback)
        {
            return new FeedbackDetailDto
            {
                FeedbackId = feedback.FeedbackId,
                Comment = feedback.Comment,
                ImageURLs = feedback.ImageURLs ?? Array.Empty<string>(),
                ManagerId = feedback.ManagerId,
                ManagerName = feedback.Manager?.Name,
                OrderId = feedback.OrderId,
                UserId = feedback.UserId,
                UserName = feedback.User?.Name,
                CreatedAt = feedback.CreatedAt,
                UpdatedAt = feedback.UpdatedAt
            };
        }

        #endregion
    }
}