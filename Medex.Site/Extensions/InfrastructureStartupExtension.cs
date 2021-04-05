using Medex.Abstractions.Business;
using Medex.Abstractions.Common;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using Medex.Service.Business;
using Medex.Service.Common;
using Medex.Service.Common.PageQueryProvider;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medex.Site.Extensions
{
    public static class InfrastructureStartupExtension
    {
        public static IServiceCollection AddInfrastructure(
              this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddSingleton<IHostingEnvironmentService, HostingEnvironmentService>();
            services.AddTransient<IPageQueryProvider<Product, NameFilter>, ProductQueryProvider>();
            services.AddTransient<IPageQueryProvider<Price, PriceFilter>, PriceQueryProvider>();
            services.AddTransient<IPageQueryProvider<User, UserFilter>, UserQueryProvider>();
            services.AddTransient<IPageQueryProvider<PriceItem, PriceItemFilter>, PriceItemQueryProvider>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IPriceItemService, PriceItemService>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IInterNameService, InterNameService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IDistributorService, DistributorService>();
            services.AddTransient<IManufacturerService, ManufactureService>();
            services.AddTransient<IGroupNameService, GroupNameService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPriceLoaderService, PriceLoaderService>();
            return services;
        }
    }
}
