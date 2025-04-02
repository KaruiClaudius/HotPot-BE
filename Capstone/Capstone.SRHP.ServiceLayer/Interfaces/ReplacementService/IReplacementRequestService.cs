using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService
{
    public interface IReplacementRequestService
    {
        // Manager methods
        Task<IEnumerable<ReplacementRequest>> GetAllReplacementRequestsAsync();
        Task<IEnumerable<ReplacementRequest>> GetReplacementRequestsByStatusAsync(ReplacementRequestStatus status);
        Task<ReplacementRequest> GetReplacementRequestByIdAsync(int requestId);
        Task<ReplacementRequest> ReviewReplacementRequestAsync(int requestId, bool isApproved, string reviewNotes);
        Task<ReplacementRequest> AssignStaffToReplacementAsync(int requestId, int staffId);
        Task<ReplacementRequest> MarkReplacementAsCompletedAsync(int requestId, string completionNotes);

        // Staff methods
        Task<IEnumerable<ReplacementRequest>> GetAssignedReplacementRequestsAsync(int staffId);
        Task<ReplacementRequest> UpdateReplacementStatusAsync(int requestId, ReplacementRequestStatus status, string notes);
        Task<ReplacementRequest> VerifyEquipmentFaultyAsync(int requestId, bool isFaulty, string verificationNotes, int staffId);

        // Customer methods
        Task<ReplacementRequest> CreateReplacementRequestAsync(ReplacementRequest request);
        Task<IEnumerable<ReplacementRequest>> GetCustomerReplacementRequestsAsync(int customerId);
        Task<ReplacementRequest> CancelReplacementRequestAsync(int requestId, int customerId);
    }
}
