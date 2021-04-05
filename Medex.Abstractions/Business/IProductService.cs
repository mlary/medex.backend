using Medex.Abstractions.Common;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Abstractions.Business
{
    public interface IProductService : IReadService<Product, ProductDto, NameFilter>,
        ICreateService<Product, ProductDto>,
        IUpdateService<Product, ProductDto>,
        IDeleteService, IPaginationService<ProductDto, NameFilter>
    {
        Task<IEnumerable<string>> GetProductNameListAsync();
    }
}
