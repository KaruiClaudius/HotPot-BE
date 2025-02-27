using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Management;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IManagerFeedbackService
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
    }
}
