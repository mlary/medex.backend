using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medex.Abstractions.Business;
using Medex.Abstractions.Common;
using Medex.Abstractions.Persistence;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Data.Primitives;
using Medex.Domains.Models;
using Medex.Service.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medex.Service.Business
{
    public class PriceService : BasePageableService<Price, PriceDto, PriceFilter>, IPriceService
    {
        public PriceService(
            IApplicationDbContext dbContext,
            IMapper mapper,
            IPageQueryProvider<Price, PriceFilter> queryProvider) : base(dbContext, mapper, queryProvider)
        {
        }
        public override async Task<IList<PriceDto>> GetAllAsync(PriceFilter filter = null)
        {
            return await _dbContext.Prices.Include(x => x.Document).ProjectTo<PriceDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PriceDto> GetLastPriceAsync()
        {
            var result = await _dbContext.Prices.Where(x => x.Status == (int)EnumPriceStatusCode.Active)
                .OrderByDescending(x => x.PublicDate)
                .FirstOrDefaultAsync();
            return _mapper.Map<PriceDto>(result);
        }
        public override Task<PriceDto> CreateAsync(PriceDto dto)
        {
            dto.Status = Data.Primitives.EnumPriceStatusCode.New;
            return base.CreateAsync(dto);
        }

        public async Task<IList<PriceDto>> GetAllNewPricesAsync()
        {
            var result = await _dbContext.Prices
                .Where(x => x.Status == (int)EnumPriceStatusCode.New)
                .ProjectTo<PriceDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return result;
        }
        public override Task<PriceDto> UpdateAsync(Price entity)
        {
            throw new NotImplementedException();
        }
        public async Task<PriceDto> UpdatePriceAsync(PriceUpdateDto data)
        {
            var price = await _dbContext.Prices.FirstOrDefaultAsync(x => x.Id == data.Id);
            price.EuroRate = data.EuroRate;
            price.DollarRate = data.DollarRate;
            price.PublicDate = data.PublicDate;
            await _dbContext.SaveChangesAsync();
            return await GetDtoByIdAsync(data.Id);
        }

        public async Task<PriceDto> ChangePriceStatusAsync(ChangePriceStatusDto data)
        {
            var price = await _dbContext.Prices.FirstOrDefaultAsync(x => x.Id == data.Id);
            price.Status = (int)data.Status;
            await _dbContext.SaveChangesAsync();
            return await GetDtoByIdAsync(data.Id);

        }
    }
}
