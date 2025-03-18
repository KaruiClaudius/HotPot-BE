using Capstone.HPTY.ModelLayer;
using Capstone.HPTY.ModelLayer.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.RepositoryLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HPTYContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(HPTYContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }


        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsQueryable().Where(predicate).ToList();
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            // Use FirstOrDefaultAsync instead of FirstAsync to handle null results
            return await query.FirstOrDefaultAsync(predicate);
        }


        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbSet;

            return _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<T>> FindList(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).CountAsync();
        }

        //public DbSet<T> GetAll()
        //{
        //    return _table;
        //}

        public IQueryable<T> IncludeNested(Func<IQueryable<T>, IQueryable<T>> includeFunc)
        {
            return includeFunc(_dbSet);
        }


        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            // Start with the DbSet directly to ensure it's an EF Core queryable
            var query = _context.Set<T>().AsQueryable();

            // Apply predicate if provided
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }


        public async Task<T> GetByIdGuid(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<T> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task HardDeleteGuid(Guid key)
        {
            var rs = await GetByIdGuid(key);
            _dbSet.Remove(rs);
        }


        public async Task HardDelete(int key)
        {
            var rs = await GetById(key);
            _dbSet.Remove(rs);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task UpdateGuid(T entity, Guid Id)
        {
            var existEntity = await GetByIdGuid(Id);
            _context.Entry(existEntity).CurrentValues.SetValues(entity);
            _dbSet.Update(existEntity);
        }

        public async Task Update(T entity, int Id)
        {
            var existEntity = await GetById(Id);
            _context.Entry(existEntity).CurrentValues.SetValues(entity);
            _dbSet.Update(existEntity);
        }


        public void UpdateRange(IQueryable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void DeleteRange(IQueryable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void InsertRange(IQueryable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public EntityEntry<T> Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        //async

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate = null)
        {
            var query = predicate != null ? _dbSet.Where(predicate) : _dbSet;
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task InsertRangeAsync(IQueryable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<T> GetAllApart()
        {
            return _dbSet.Take(100);
        }
        public async Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken = default)
        {
            return await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task UpdateDetached(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DetachEntity(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public IQueryable<T> AsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsQueryable().Where(predicate);
        }

        public IQueryable<TResult?> ObjectMapper<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbSet;
            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return query.AsNoTracking().Select(selector);
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
