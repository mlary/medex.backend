using Medex.Abstractions.Common;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Abstractions.Business
{
    public interface IManufacturerService : IReadService<Manufacturer, ManufacturerDto, NameFilter>,
        IUpdateService<Manufacturer, ManufacturerDto>,
        ICreateService<Manufacturer, ManufacturerDto>,
        IDeleteService
    {

        Task<IEnumerable<string>> GetCountriesAsync();
    }
}
