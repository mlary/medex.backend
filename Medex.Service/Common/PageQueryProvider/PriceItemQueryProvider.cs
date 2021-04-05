using Medex.Abstractions.Common;
using Medex.Data.Dto.Base.Sorting;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Medex.Service.Common.PageQueryProvider
{
    public class PriceItemQueryProvider : IPageQueryProvider<PriceItem, PriceItemFilter>
    {
        public IQueryable<PriceItem> Filter(IQueryable<PriceItem> query, PriceItemFilter filter)
        {
            if (filter != null)
            {
                if (filter?.Product?.Value != null)
                {
                    query = query.Where(x => x.Product.Name.Contains(filter.Product.Value));
                }
                if (filter?.Product?.Values?.Count > 0)
                {
                    query = query.Where(x => filter.Product.Values.Contains(x.Product.Name));
                }
                if (filter?.ProductId?.Value != null)
                {
                    query = query.Where(x => x.ProductId == filter.ProductId.Value);
                }
                if (filter?.Country?.Value != null)
                {
                    query = query.Where(x => x.Product.Manufacture.Country.Contains(filter.Country.Value));
                }
                if (filter?.Distributor?.Value != null)
                {
                    query = query.Where(x => x.Distributor.Name.Contains(filter.Distributor.Value));
                }
                if (filter?.Distributor?.Values?.Count > 0)
                {
                    query = query.Where(x => filter.Distributor.Values.Contains(x.Distributor.Name));
                }
                if (filter?.DistributorId?.Value != null)
                {
                    query = query.Where(x => x.DistributorId == filter.DistributorId.Value);
                }
                if (filter.Manufacturer != null && filter.Manufacturer.Value != null)
                {
                    query = query.Where(x => x.Product.Manufacture.Name.Contains(filter.Manufacturer.Value));
                }
                if (filter?.Manufacturer?.Values?.Count > 0)
                {
                    query = query.Where(x => filter.Manufacturer.Values.Contains(x.Product.Manufacture.Name));
                }
                if (filter?.Country?.Values?.Count > 0)
                {
                    query = query.Where(x => filter.Country.Values.Contains(x.Product.Manufacture.Country));
                }
                if (filter.ManufactureId != null && filter.ManufactureId.Value != null)
                {
                    query = query.Where(x => x.Product.ManufacturerId == filter.ManufactureId.Value);
                }
                if (filter.GroupName != null && filter.GroupName.Value != null)
                {
                    query = query.Where(x => x.Product.GroupName.Name.Contains(filter.GroupName.Value));
                }
                if (filter.GroupName?.Values?.Count > 0)
                {
                    query = query.Where(x => filter.GroupName.Values.Contains(x.Product.GroupName.Name));
                }
                if (filter.GroupNameId != null && filter.GroupNameId.Value != null)
                {
                    query = query.Where(x => x.Product.GroupNameId == filter.GroupNameId.Value);
                }
                if (filter.InterName != null && filter.InterName.Value != null)
                {
                    query = query.Where(x => x.Product.InterName.Name.Contains(filter.InterName.Value));
                }
                if (filter.InterName?.Values?.Count > 0)
                {
                    query = query.Where(x => filter.InterName.Values.Contains(x.Product.InterName.Name));
                }
                if (filter.InterNameId != null && filter.InterNameId.Value != null)
                {
                    query = query.Where(x => x.Product.InterNameId == filter.InterNameId.Value);
                }
                if (filter.PriceId != null && filter.PriceId.Value != null)
                {
                    query = query.Where(x => x.PriceId == filter.PriceId.Value);
                }
                if (filter?.PublicDate?.Range?.Lte != null)
                {
                    query = query.Where(x => x.Price.PublicDate <= filter.PublicDate.Range.Lte);
                }
                if (filter?.PublicDate?.Range?.Gte != null)
                {
                    query = query.Where(x => x.Price.PublicDate >= filter.PublicDate.Range.Gte);
                }
                if (filter?.Cost?.Range?.Gte != null)
                {
                    query = query.Where(x => x.Cost >= filter.Cost.Range.Gte);
                }
                if (filter?.Cost?.Range?.Lte != null)
                {
                    query = query.Where(x => x.Cost <= filter.Cost.Range.Lte);
                }
                if (filter?.CostInDollar?.Range?.Gte != null)
                {
                    query = query.Where(x => x.CostInDollar >= filter.CostInDollar.Range.Gte);
                }
                if (filter?.CostInDollar?.Range?.Lte != null)
                {
                    query = query.Where(x => x.CostInDollar <= filter.CostInDollar.Range.Lte);
                }
                if (filter?.CostInEuro?.Range?.Gte != null)
                {
                    query = query.Where(x => x.CostInEuro >= filter.CostInEuro.Range.Gte);
                }
                if (filter?.CostInEuro?.Range?.Lte != null)
                {
                    query = query.Where(x => x.CostInEuro <= filter.CostInEuro.Range.Lte);
                }
                if (filter.PublicDate != null && filter.PublicDate.Range?.Lt != null)
                {
                    query = query.Where(x => x.Price.PublicDate <= filter.PublicDate.Range.Lt);
                }
                if (filter.PublicDate != null && filter.PublicDate.Range?.Gt != null)
                {
                    query = query.Where(x => x.Price.PublicDate >= filter.PublicDate.Range.Gt);
                }

            }
            query = query.Include(x => x.Product)
                .Include(x => x.Distributor)
                .Include(x => x.Product.Manufacture)
                .Include(x => x.Product.InterName)
                .Include(x => x.Product.GroupName)
                .Include(x => x.Price);
            return query;
        }

        public IQueryable<PriceItem> Sort(IQueryable<PriceItem> query, IEnumerable<SorterDescriptor> sorters)
        {
            if (sorters != null && sorters.Any())
            {
                foreach (var sorter in sorters)
                {
                    if (sorter.Field == "cost")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Cost) : query.OrderBy(x => x.Cost);
                    }
                    if (sorter.Field == "costInDollar")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                           ? query.OrderByDescending(x => x.Cost) : query.OrderBy(x => x.Cost);
                    }
                    if (sorter.Field == "costInEuro")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.CostInEuro) : query.OrderBy(x => x.CostInEuro);
                    }
                    if (sorter.Field == "createdOn")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn);
                    }
                    if (sorter.Field == "publicDate")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Price.PublicDate) : query.OrderBy(x => x.Price.PublicDate);
                    }
                    if (sorter.Field == "date")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Date) : query.OrderBy(x => x.Date);
                    }
                    if (sorter.Field == "distributor")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Distributor.Name) : query.OrderBy(x => x.Distributor.Name);
                    }
                    if (sorter.Field == "id")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id);
                    }
                    if (sorter.Field == "margin")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Margin) : query.OrderBy(x => x.Margin);
                    }
                    if (sorter.Field == "name")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Product.Name) : query.OrderBy(x => x.Product.Name);
                    }
                    if (sorter.Field == "manufacturer")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Product.Manufacture.Name) : query.OrderBy(x => x.Product.Manufacture.Name);
                    }
                    if (sorter.Field == "groupName")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Product.GroupName.Name) : query.OrderBy(x => x.Product.GroupName.Name);
                    }
                    if (sorter.Field == "interName")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Product.InterName.Name) : query.OrderBy(x => x.Product.InterName.Name);
                    }
                    if (sorter.Field == "country")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Product.Manufacture.Country) : query.OrderBy(x => x.Product.Manufacture.Country);
                    }
                }
            }
            return query;
        }
    }
}
