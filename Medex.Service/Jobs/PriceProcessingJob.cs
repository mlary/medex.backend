using Medex.Abstractions.Business;
using Medex.Abstractions.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Medex.Service.Jobs
{
    [DisallowConcurrentExecution]
    public class PriceProcessingJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;        

        public PriceProcessingJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;            
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var priceService = scope.ServiceProvider.GetService<IPriceService>();
                var priceLoaderService = scope.ServiceProvider.GetService<IPriceLoaderService>();
                var prices = await priceService.GetAllNewPricesAsync();
                foreach (var p in prices)
                {
                    Log.Debug("Logging price priceId {0}", p.Id);
                    await priceLoaderService.LoadPriceAsync(p.Id);
                }
            }
        }
    }
}
