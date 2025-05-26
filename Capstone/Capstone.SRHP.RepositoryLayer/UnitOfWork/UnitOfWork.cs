using Capstone.HPTY.ModelLayer;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.RepositoryLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HPTYContext _context;
        private IDbContextTransaction _currentTransaction;
        private Dictionary<string, object> _repositories;
        private bool _disposed;


        public UnitOfWork(HPTYContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();

        }

        private readonly Dictionary<Type, object> reposotories = new Dictionary<Type, object>();

        public DbContext Context => _context;

        public IGenericRepository<T> Repository<T>()
            where T : class
        {
            Type type = typeof(T);
            if (!reposotories.TryGetValue(type, out object value))
            {
                var genericRepos = new GenericRepository<T>(_context);
                reposotories.Add(type, genericRepos);
                return genericRepos;
            }
            return value as GenericRepository<T>;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            TrackChanges();
            return _context.SaveChangesAsync();
        }
        public async Task<int> CommitAsync(string userId = null)
        {
            await SetAuditProperties(userId);
            return await _context.SaveChangesAsync();
        }

        private async Task SetAuditProperties(string userId)
        {
            var entries = _context.ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow.AddHours(7);
                }
                else
                {
                    entity.UpdatedAt = DateTime.UtcNow.AddHours(7);
                }
            }
        }

        private void TrackChanges()
        {
            var validationErrors = _context.ChangeTracker.Entries<IValidatableObject>()
                .SelectMany(e => e.Entity.Validate(null))
                .Where(e => e != ValidationResult.Success)
                .ToArray();
            if (validationErrors.Any())
            {
                var exceptionMessage = string.Join(Environment.NewLine,
                    validationErrors.Select(error => $"Properties {error.MemberNames} Error: {error.ErrorMessage}"));
                throw new Exception(exceptionMessage);
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _context.Database.CreateExecutionStrategy();
        }

        public async Task ExecuteInTransactionAsync(Func<Task> operation, Action<Exception> exceptionHandler = null)
        {
            await Context.Database.CreateExecutionStrategy().ExecuteAsync(async () =>
            {
                using var transaction = await BeginTransactionAsync();
                try
                {
                    await operation();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    exceptionHandler?.Invoke(ex);
                    throw;
                }
            });
        }

        public async Task<TResult> ExecuteInTransactionAsync<TResult>(Func<Task<TResult>> operation, Action<Exception> exceptionHandler = null)
        {
            return await Context.Database.CreateExecutionStrategy().ExecuteAsync(async () =>
            {
                using var transaction = await BeginTransactionAsync();
                try
                {
                    var result = await operation();
                    await transaction.CommitAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    exceptionHandler?.Invoke(ex);
                    throw;
                }
            });
        }


    }
}
