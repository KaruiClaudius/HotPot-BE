using Capstone.HPTY.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces
{
    public interface IFeedbackService : IBaseService<Feedback>
    {
        Task<IEnumerable<Feedback>> GetByUserAsync(int userId);
        Task<IEnumerable<Feedback>> GetByOrderAsync(int orderId);
        Task<IEnumerable<Feedback>> GetRecentFeedbackAsync(int count);
        Task UpdateImagesAsync(int feedbackId, string[] imageUrls);
    }
}
