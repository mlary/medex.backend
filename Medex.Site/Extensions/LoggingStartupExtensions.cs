
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace Medex.Site.Extensions
{
    public static class LoggingStartupExtensions
    {
        public static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceName = Assembly.GetExecutingAssembly().GetName().Name;
            var indexName = serviceName.ToLower().Replace('.', '-');
            var indexFormat = indexName + "-{0:yyyy.MM.dd}";

            services.AddLogging(loggingBuilder =>
              loggingBuilder.AddSerilog(dispose: true));

            var logger = new LoggerConfiguration()
                      .ReadFrom.Configuration(configuration)
                      .Enrich.WithProperty("AssebmblyName", serviceName, true)
                      .Enrich.FromLogContext()
                      .WriteTo.Console()
                      .CreateLogger();

            Log.Logger = logger;

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddSerilog(logger);
            services.AddSingleton<ILoggerFactory>(loggerFactory);

            return services;
        }
    }
}
