using Capstone.HPTY.RepositoryLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.RepositoryLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        public IGenericRepository<T> Repository<T>()
          where T : class;

        int Commit();

        Task<int> CommitAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<int> CommitAsync(string userId = null);
        IExecutionStrategy CreateExecutionStrategy();

        Task ExecuteInTransactionAsync(Func<Task> operation, Action<Exception> exceptionHandler = null);
        Task<TResult> ExecuteInTransactionAsync<TResult>(Func<Task<TResult>> operation, Action<Exception> exceptionHandler = null);

    }
}
