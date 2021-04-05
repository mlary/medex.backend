using Medex.Abstractions.Common;
using Medex.Data.Dto.Base.Sorting;
using Medex.Data.Dto.Filtering;
using Medex.Data.Primitives;
using Medex.Domains.Models;
using System.Collections.Generic;
using System.Linq;

namespace Medex.Service.Common.PageQueryProvider
{
    public class PriceQueryProvider : IPageQueryProvider<Price, PriceFilter>
    {
        public IQueryable<Price> Filter(IQueryable<Price> query, PriceFilter filter)
        {
            if (filter?.PublicDate?.Range?.Lte != null)
            {
                query = query.Where(x => x.PublicDate <= filter.PublicDate.Range.Lte);
            }
            if (filter?.PublicDate?.Range?.Gte != null)
            {
                query = query.Where(x => x.PublicDate >= filter.PublicDate.Range.Gte);
            }
            if (filter?.PublicDate?.Range?.Lt != null)
            {
                query = query.Where(x => x.PublicDate <= filter.PublicDate.Range.Lt);
            }
            if (filter?.PublicDate?.Range?.Gt != null)
            {
                query = query.Where(x => x.PublicDate > filter.PublicDate.Range.Gt);
            }
            return query;
        }
        public IQueryable<Price> Sort(IQueryable<Price> query, IEnumerable<SorterDescriptor> sorters)
        {
            if (sorters.Any())
            {
                foreach (var sorter in sorters)
                {
                    if (sorter.Field == "publicDate")
                    {
                        if (sorter.Direction == EnumSortDirection.Desceding)
                        {
                            query.OrderByDescending(x => x.PublicDate);
                        }
                        else
                        {
                            query.OrderBy(x => x.PublicDate);
                        }
                    }
                    if (sorter.Field == "status")
                    {
                        if (sorter.Direction == EnumSortDirection.Desceding)
                        {
                            query.OrderByDescending(x => x.Status);
                        }
                        else
                        {
                            query.OrderBy(x => x.Status);
                        }
                    }
                }
            }
            else
            {
                query = query.OrderBy(x => x.PublicDate);
            }
            return query;
        }
    }
}
