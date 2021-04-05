using AutoMapper;
using Medex.Abstractions.Common;
using Medex.Abstractions.Persistence;
using Medex.Data.Infrastructure;
using Medex.Persistence;
using Medex.Service.Common;
using Medex.Site.Extensions;
using Medex.Site.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medex.Site
{
    public class Startup
    {
        private readonly Assembly _assemblyApplication = typeof(BaseService).GetTypeInfo().Assembly;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }
        private readonly string _notificationHubPath = "/notification";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddInfrastructure(Configuration, Environment)
                .AddPersistence(Configuration)
                .AddLogging(Configuration)
                .AddAutoMapper(_assemblyApplication)
                .AddAppSwagger(Configuration)
                .AddQuartz();
            
            services.Configure<AuthConfiguration>(Configuration.GetSection("Auth"));
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = Configuration.GetValue<string>("Auth:Issuer"),
                        ValidIssuer = Configuration.GetValue<string>("Auth:Issuer"),
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Auth:Secret")))
                    };
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {                            
                            return Task.CompletedTask;
                        }
                    };

                });
            var corsParams = Configuration.GetSection("Cors").Get<List<string>>();
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", $"swagger by {_assemblyApplication.GetName().Name} V1");
            });

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            DefineEnvironment(app, env);
        }
        private void DefineEnvironment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var environmentService = app.ApplicationServices.GetRequiredService<IHostingEnvironmentService>();
            environmentService.SetEnvironment(env.IsProduction());
        }
    }
}
