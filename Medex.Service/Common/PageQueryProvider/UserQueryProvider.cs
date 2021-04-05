using Medex.Abstractions.Common;
using Medex.Data.Dto.Base.Sorting;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using System.Collections.Generic;
using System.Linq;

namespace Medex.Service.Common.PageQueryProvider
{
    public class UserQueryProvider : IPageQueryProvider<User, UserFilter>
    {
        public IQueryable<User> Filter(IQueryable<User> query, UserFilter filter)
        {
            if (filter != null)
            {
                if (filter != null && filter.FullName != null)
                {
                    query = query.Where(x => x.FirstName.Contains(filter.FullName.Value) ||
                   x.LastName.Contains(filter.FullName.Value) ||
                   x.MiddleName.Contains(filter.FullName.Value));
                }
                if (filter != null && filter.Email != null)
                {
                    query = query.Where(x => x.Email.Contains(filter.Email.Value));
                }
                if (filter != null && filter.Phone != null)
                {
                    query = query.Where(x => x.Phone.Contains(filter.Phone.Value));
                }
                if (filter != null && filter.Login != null)
                {
                    query = query.Where(x => x.Login.Contains(filter.Login.Value));
                }
                if (filter?.UserRole?.Values?.Count>0)
                {
                    query = query.Where(x => filter.UserRole.Values.Select(x=>x.Id).Contains(x.UserRole));
                }
                if (filter != null && filter.IsConfirmed != null)
                {
                    query = query.Where(x => x.IsConfirmed == filter.IsConfirmed.Value);
                }
                if (filter != null && filter.IsEmailSent != null)
                {
                    query = query.Where(x => x.IsEmailSent == filter.IsEmailSent.Value);
                }
                if (filter?.CreatedOn?.Range?.Lt != null)
                {
                    query = query.Where(x => x.CreatedOn < filter.CreatedOn.Range.Lt);
                }
                if (filter?.CreatedOn?.Range?.Gt != null)
                {
                    query = query.Where(x => x.CreatedOn > filter.CreatedOn.Range.Gt);
                }
                if (filter?.CreatedOn?.Range?.Lte != null)
                {
                    query = query.Where(x => x.CreatedOn <= filter.CreatedOn.Range.Lte);
                }
                if (filter?.CreatedOn?.Range?.Gte != null)
                {
                    query = query.Where(x => x.CreatedOn >= filter.CreatedOn.Range.Gte);
                }
            }
            return query;
        }
        public IQueryable<User> Sort(IQueryable<User> query, IEnumerable<SorterDescriptor> sorters)
        {

            if (sorters != null && sorters.Any())
            {
                foreach (var sorter in sorters)
                {
                    if (sorter.Field == "fullName")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.LastName)
                            .ThenByDescending(x => x.FirstName)
                            .ThenByDescending(x => x.MiddleName)
                            : query.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ThenBy(x => x.MiddleName);
                    }
                    if (sorter.Field == "email")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Email)
                            : query.OrderBy(x => x.Email);
                    }
                    if (sorter.Field == "login")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Login)
                            : query.OrderBy(x => x.Login);
                    }
                    if (sorter.Field == "isEmailSent")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.IsEmailSent)
                            : query.OrderBy(x => x.IsEmailSent);
                    }
                    if (sorter.Field == "createdOn")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.CreatedOn)
                            : query.OrderBy(x => x.CreatedOn);
                    }
                    if (sorter.Field == "phone")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.Phone)
                            : query.OrderBy(x => x.Phone);
                    }
                    if (sorter.Field == "userRole")
                    {
                        query = sorter.Direction == Data.Primitives.EnumSortDirection.Desceding
                            ? query.OrderByDescending(x => x.UserRole)
                            : query.OrderBy(x => x.UserRole);
                    }
                }
            }
            return query;
        }
    }
}
