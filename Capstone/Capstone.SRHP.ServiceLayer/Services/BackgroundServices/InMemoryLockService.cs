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
        private static readonly ConcurrentDictionary<string, int> _activeLocks = new();

        public async Task<IDisposable> AcquireLockAsync(string resourceKey, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            var semaphore = _locks.GetOrAdd(resourceKey, _ => new SemaphoreSlim(1, 1));

            bool acquired = await semaphore.WaitAsync(timeout, cancellationToken);
            if (!acquired)
            {
                throw new TimeoutException($"Failed to acquire lock '{resourceKey}' within timeout period.");
            }

            // Track that this lock is currently held
            _activeLocks.AddOrUpdate(resourceKey, 1, (key, value) => value + 1);

            return new LockReleaser(resourceKey, semaphore, _activeLocks);
        }

        public bool IsLocked(string resourceKey)
        {
            return _activeLocks.ContainsKey(resourceKey) && _activeLocks[resourceKey] > 0;
        }

        private class LockReleaser : IDisposable
        {
            private readonly string _resourceKey;
            private readonly SemaphoreSlim _semaphore;
            private readonly ConcurrentDictionary<string, int> _activeLocks;
            private bool _disposed;

            public LockReleaser(string resourceKey, SemaphoreSlim semaphore, ConcurrentDictionary<string, int> activeLocks)
            {
                _resourceKey = resourceKey;
                _semaphore = semaphore;
                _activeLocks = activeLocks;
            }

            public void Dispose()
            {
                if (_disposed) return;

                _semaphore.Release();

                // Update the active locks count
                _activeLocks.AddOrUpdate(_resourceKey, 0, (key, value) => value - 1);
                if (_activeLocks[_resourceKey] <= 0)
                {
                    _activeLocks.TryRemove(_resourceKey, out _);
                }

                _disposed = true;
            }
        }
    }
}
