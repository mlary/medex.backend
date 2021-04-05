using AutoMapper;
using Medex.Abstractions.Business;
using Medex.Abstractions.Common;
using Medex.Abstractions.Persistence;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using Medex.Service.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medex.Service.Business
{
    public class ProductService : BasePageableService<Product, ProductDto, NameFilter>, IProductService
    {
        public ProductService(
            IApplicationDbContext dbContext,
            IMapper mapper,
            IPageQueryProvider<Product, NameFilter> queryProvider) :
            base(dbContext, mapper, queryProvider)
        {
        }

        public async Task<IEnumerable<string>> GetProductNameListAsync()
        {
            var result = await this._dbContext.Products.Select(x => x.Name)
                .OrderBy(x => x)
                .Distinct()
                .ToListAsync();
            return result;
        }
    }
}
