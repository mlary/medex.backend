using Medex.Abstractions.Common;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Abstractions.Business
{
    public interface IPriceService : IReadService<Price, PriceDto, PriceFilter>,
        ICreateService<Price, PriceDto>,
        IUpdateService<Price, PriceDto>,
        IDeleteService,
        IPaginationService<PriceDto, PriceFilter>
    {
        Task<PriceDto> GetLastPriceAsync();
        Task<IList<PriceDto>> GetAllNewPricesAsync();
        Task<PriceDto> UpdatePriceAsync(PriceUpdateDto data);

        Task<PriceDto> ChangePriceStatusAsync(ChangePriceStatusDto data);
    }
}
