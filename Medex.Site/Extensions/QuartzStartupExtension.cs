using Medex.Service.Jobs;
using Medex.Site.Quartz;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace Medex.Site.Extensions
{
    public static class QuartzStartupExtension
    {
        public static IServiceCollection AddQuartz(
                 this IServiceCollection services)
        {
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            //Jobs configuring
            services.AddSingleton<PriceProcessingJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(PriceProcessingJob), cronExpression: "0/5 * * * * ?"));
            
            //register quartz hosted service
            services.AddHostedService<QuartzHostedService>();
            return services;
        }
    }
}
