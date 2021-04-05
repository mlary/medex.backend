using Medex.Abstractions.Common;
using Medex.Data.Dto.Base.Sorting;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Medex.Service.Common.PageQueryProvider
{
    public class ProductQueryProvider : IPageQueryProvider<Product, NameFilter>
    {
        public IQueryable<Product> Filter(IQueryable<Product> query, NameFilter filter)
        {
            if (filter != null && filter.Name != null)
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }
            query = query
                .Include(x => x.Manufacture)
                .Include(x => x.InterName)
                .Include(x => x.GroupName);
            return query;
        }
        public IQueryable<Product> Sort(IQueryable<Product> query, IEnumerable<SorterDescriptor> sorters)
        {
            return query.OrderBy(x => x.Name);
        }
    }
}
