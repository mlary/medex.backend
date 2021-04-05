using Medex.Domains.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medex.Abstractions.Persistence
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        IQueryable<T> GetQuery();

        Task<IList<T>> GetAllAsync();

        Task<IList<T>> FindAsync(Expression<Func<T, bool>> match);

        Task<T> GetByIdAsync(int id);

        Task<T> FirstAsync(Expression<Func<T, bool>> match);

        Task<T> CreateAsync(T item);

        Task<T> UpdateAsync(T item, int id);

        Task<bool> DeleteAsync(int id);

        Task<bool> DeleteAsync(IEnumerable<int> ids);

        IQueryable<T> GetQuery(Expression<Func<T, bool>> match);

        Task<bool> RealodWithReferenceAsync(T item, string propertyName);
    }
}
