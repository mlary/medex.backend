using Medex.Abstractions.Persistence;
using Medex.Domains.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medex.Persistence
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        protected IApplicationDbContext _dbContext;
        private bool _disposed;

        #region private methods

        private static string RecordNotFoundMessage(int key)
        {
            return "The record of entity " + typeof(T).Name + " with Id " + key + " not found!";
        }

        #endregion

        public RepositoryBase(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _dbContext
                .Set<T>()
                .Where(match)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> match)
        {
            return await _dbContext
                .Set<T>()
                .FirstOrDefaultAsync(match);
        }

        public async Task<T> CreateAsync(T item)
        {
            _dbContext.Set<T>().Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateAsync(T item, int id)
        {
            if (item == null)
                return null;

            var existing = await _dbContext.Set<T>().FindAsync(id);
            if (existing == null)
            {
                throw new Exception(RecordNotFoundMessage(id));
            }

            _dbContext.Entry(existing).CurrentValues.SetValues(item);
            await _dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var toRemove = await _dbContext.Set<T>().FindAsync(id);

            if (toRemove == null)
            {
                throw new Exception(RecordNotFoundMessage(id));
            }

            try
            {
                _dbContext.Set<T>().Remove(toRemove);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                // ignore
            }

            return false;
        }

        public async Task<bool> DeleteAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                var toRemove = await _dbContext.Set<T>().FindAsync(id);
                if (toRemove == null)
                {
                    continue;
                }

                try
                {
                    _dbContext.Set<T>().Remove(toRemove);
                    await _dbContext.SaveChangesAsync();
                }
                catch
                {
                    // ignore
                }
            }
            return true;
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> match)
        {
            return _dbContext
                .Set<T>()
                .Where(match)
                .AsQueryable();
        }
        public IQueryable<T> GetQuery()
        {
            return _dbContext
                .Set<T>()
                .AsQueryable();
        }

        public async Task<bool> RealodWithReferenceAsync(T item, string propertyName)
        {
            await _dbContext.Entry(item).Reference(propertyName).LoadAsync();
            return true;
        }
    }
}
