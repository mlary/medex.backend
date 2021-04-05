using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Medex.Abstractions.Persistence
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<T> Set<T>()
              where T : class;

        DatabaseFacade Database { get; }

        DbContext AppDbContext { get; }
        DbSet<User> Users { get; set; }
        DbSet<Distributor> Distributors { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<GroupName> GroupNames { get; set; }
        DbSet<InterName> InterNames { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<Price> Prices { get; set; }
        DbSet<PriceItem> PriceItems { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task BulkAddAsync<T>(IEnumerable<object> entities, CancellationToken cancellationToken = default) where T : class;
    }
}
