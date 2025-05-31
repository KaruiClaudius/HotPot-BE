using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.Interfaces.BackgroundService;

namespace Capstone.HPTY.ServiceLayer.Services.BackgroundServices
{
    public class InMemoryLockService : ILockService
    {
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> _locks = new();
        private static readonly ConcurrentDictionary<string, bool> _activeLocks = new();

        public async Task<IDisposable> AcquireLockAsync(string resourceKey, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            var semaphore = _locks.GetOrAdd(resourceKey, _ => new SemaphoreSlim(1, 1));

            bool acquired = await semaphore.WaitAsync(timeout, cancellationToken);
            if (!acquired)
            {
                throw new TimeoutException($"Failed to acquire lock '{resourceKey}' within timeout period.");
            }

            // Mark this resource as locked
            _activeLocks[resourceKey] = true;

            return new LockReleaser(resourceKey, semaphore, _activeLocks);
        }

        public bool IsLocked(string resourceKey)
        {
            return _activeLocks.ContainsKey(resourceKey) && _activeLocks[resourceKey];
        }

        private class LockReleaser : IDisposable
        {
            private readonly string _resourceKey;
            private readonly SemaphoreSlim _semaphore;
            private readonly ConcurrentDictionary<string, bool> _activeLocks;
            private bool _disposed;

            public LockReleaser(string resourceKey, SemaphoreSlim semaphore, ConcurrentDictionary<string, bool> activeLocks)
            {
                _resourceKey = resourceKey;
                _semaphore = semaphore;
                _activeLocks = activeLocks;
            }

            public void Dispose()
            {
                if (_disposed) return;

                _semaphore.Release();
                _activeLocks.TryRemove(_resourceKey, out _);
                _disposed = true;
            }
        }
    }
}
