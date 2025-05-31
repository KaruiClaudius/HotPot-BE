using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.BackgroundService
{
    public interface ILockService
    {
        Task<IDisposable> AcquireLockAsync(string resourceKey, TimeSpan timeout, CancellationToken cancellationToken = default);
        bool IsLocked(string resourceKey);
    }

}
