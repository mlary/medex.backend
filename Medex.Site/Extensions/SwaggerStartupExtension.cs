﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;

namespace Medex.Site.Extensions
{
    public static class SwaggerStartupExtension
    {
        public static IServiceCollection AddAppSwagger(this IServiceCollection services,
           IConfiguration configuration)
        {
            var serviceName = Assembly.GetExecutingAssembly().GetName().Name;

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"swagger {serviceName}",
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.CustomSchemaIds(x => x.FullName);
                c.EnableAnnotations();
            });

            return services;
        }
    }
}
