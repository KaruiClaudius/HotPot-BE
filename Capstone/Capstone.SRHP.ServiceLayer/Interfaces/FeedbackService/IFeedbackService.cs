using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Management;

namespace Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService
{
    public interface IFeedbackService
    {
        Task<Feedback> GetFeedbackByIdAsync(int feedbackId);
        Task<IEnumerable<Feedback>> GetAllFeedbackAsync(int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<Feedback>> GetFeedbackByUserIdAsync(int userId, int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<Feedback>> GetFeedbackByOrderIdAsync(int orderId);
        Task<IEnumerable<Feedback>> GetUnrespondedFeedbackAsync(int pageNumber = 1, int pageSize = 10);
        Task<Feedback> RespondToFeedbackAsync(int feedbackId, int managerId, string response);
        Task<int> GetTotalFeedbackCountAsync();
        Task<int> GetUnrespondedFeedbackCountAsync();
        Task<Feedback> CreateFeedbackAsync(CreateFeedbackRequest request);

        // Approval methods
        Task<Feedback> ApproveFeedbackAsync(int feedbackId, int adminUserId);
        Task<Feedback> RejectFeedbackAsync(int feedbackId, int adminUserId, string rejectionReason);
        Task<IEnumerable<Feedback>> GetPendingFeedbackAsync(int pageNumber = 1, int pageSize = 10);
        Task<int> GetPendingFeedbackCountAsync();
        Task<IEnumerable<Feedback>> GetApprovedFeedbackAsync(int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<Feedback>> GetRejectedFeedbackAsync(int pageNumber = 1, int pageSize = 10);
    }
}
