using Medex.Abstractions.Common;
using Medex.Data.Dto.Base.Filtering;
using Medex.Data.Dto.Base.Paging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medex.Service.Extensions
{
    internal static class PageQueryExtension
    {
        public static IQueryable<TEntity> UsePageContext<TEntity, TFilter>(this IQueryable<TEntity> query,
            IPageQueryProvider<TEntity, TFilter> provider, PageContext<TFilter> context) where TFilter : BaseFilter, new()
        {
            query = provider.Filter(query, context.Filter);
            query = provider.Sort(query, context.SortList);
            return query;
        }
        public static async Task<(IList<TEntity>, int)> GetPageAsync<TEntity, TFilter>(this IQueryable<TEntity> query,
            IPageQueryProvider<TEntity, TFilter> provider,
            PageContext<TFilter> context) where TFilter : BaseFilter, new()
        {
            query = query.UsePageContext<TEntity, TFilter>(provider, context);

            var (data, count) = (await query.Skip(context.Skip).Take(context.Take).ToListAsync(), await query.CountAsync());
            return (data, count);
        }
    }
}
