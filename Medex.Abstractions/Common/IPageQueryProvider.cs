using Medex.Data.Dto.Base.Sorting;
using System.Collections.Generic;
using System.Linq;

namespace Medex.Abstractions.Common
{
    public interface IPageQueryProvider<TEntity, TFilter>
    {
        IQueryable<TEntity> Filter(IQueryable<TEntity> query, TFilter filter);
        IQueryable<TEntity> Sort(IQueryable<TEntity> query, IEnumerable<SorterDescriptor> sorters);
    }
}
