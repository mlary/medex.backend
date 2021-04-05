using Medex.Abstractions.Persistence;
using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Medex.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbContext AppDbContext => this;

        public DbSet<User> Users { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<GroupName> GroupNames { get; set; }
        public DbSet<InterName> InterNames { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceItem> PriceItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
        public async Task BulkAddAsync<T>(IEnumerable<object> entities, CancellationToken cancellationToken = default) where T : class
        {
            await this.BulkInsertAsync<T>(entities, cancellationToken).ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseLoggerFactory(GetDbLoggerFactory()).EnableSensitiveDataLogging();
#endif
        }

        private static ILoggerFactory GetDbLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                builder.AddDebug()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information));
            return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        }
    }
}
