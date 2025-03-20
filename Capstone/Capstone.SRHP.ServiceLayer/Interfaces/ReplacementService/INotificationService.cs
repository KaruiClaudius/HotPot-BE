using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService
{
    public interface INotificationService
    {
        // Replacement request notifications
        Task NotifyNewReplacementRequestAsync(ReplacementRequest request);
        Task NotifyReplacementStatusChangeAsync(ReplacementRequest request);
        Task NotifyCustomerAboutReplacementAsync(ReplacementRequest request);

        // Rental notifications
        Task NotifyCustomerRentalExtendedAsync(int userId, int rentalId, DateTime newReturnDate);
        Task NotifyCustomerRentalReturnedAsync(int userId, int rentalId);
        Task NotifyStaffNewAssignmentAsync(int staffId, int assignmentId, StaffPickupAssignmentDto assignment);
        Task NotifyStaffAssignmentCompletedAsync(int staffId, int assignmentId);
        Task NotifyManagerNewPickupRequestAsync(int rentalId, string customerName);
        Task NotifyManagerAssignmentCompletedAsync(int assignmentId, int staffId, string staffName);
        Task NotifyAllStaffNewPendingPickupAsync(int rentalId, string customerName);

    }
}
