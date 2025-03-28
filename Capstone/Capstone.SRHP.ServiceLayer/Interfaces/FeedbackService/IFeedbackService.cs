using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService
{
    public interface IFeedbackService
    {
        // Customer methods
        Task<ManagerFeedbackDetailDto> CreateFeedbackAsync(CreateFeedbackRequest request);
        Task<PagedResult<ManagerFeedbackListDto>> GetFeedbackByUserIdAsync(int userId, int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<ManagerFeedbackListDto>> GetFeedbackByOrderIdAsync(int orderId);

        // Manager methods
        Task<PagedResult<ManagerFeedbackListDto>> GetFeedbackByStatusAsync(FeedbackApprovalStatus status, int pageNumber = 1, int pageSize = 10);
        Task<PagedResult<ManagerFeedbackListDto>> GetUnrespondedFeedbackAsync(int pageNumber = 1, int pageSize = 10);
        Task<ManagerFeedbackDetailDto> RespondToFeedbackAsync(int feedbackId, int managerId, string response);
        Task<ManagerFeedbackStats> GetManagerFeedbackStatsAsync();

        // Admin methods
        Task<PagedResult<FeedbackListDto>> GetFilteredFeedbackAsync(FeedbackFilterRequest request);
        Task<FeedbackDetailDto> GetFeedbackDetailByIdAsync(int feedbackId);
        Task<FeedbackDetailDto> ApproveFeedbackAsync(int feedbackId, int adminUserId);
        Task<FeedbackDetailDto> RejectFeedbackAsync(int feedbackId, int adminUserId, string rejectionReason);
        Task<FeedbackStats> GetFeedbackStatsAsync();

        // Common methods
        Task<ManagerFeedbackDetailDto> GetFeedbackByIdAsync(int feedbackId);
        Task<int> GetFeedbackCountByStatusAsync(FeedbackApprovalStatus status);
        Task<int> GetUnrespondedFeedbackCountAsync();
        Task<int> GetTotalFeedbackCountAsync();
    }
}