using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService
{
    public interface INotificationService
    {
        Task NotifyNewReplacementRequestAsync(ReplacementRequest request);
        Task NotifyReplacementStatusChangeAsync(ReplacementRequest request);
        Task NotifyCustomerAboutReplacementAsync(ReplacementRequest request);
    }
}
