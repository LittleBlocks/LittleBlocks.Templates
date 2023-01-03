using System;
using LittleBlocks.AspNetCore.Bootstrap;
using LittleBlocks.AspNetCore.Bootstrap.Extensions;
using LittleBlocks.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LittleBlocks.Template.Core.Shared.Exceptions;
using LittleBlocks.Template.Core.Shared.Profiles;
using LittleBlocks.Template.WebApi.Configurations;
using LittleBlocks.Template.WebApi.Extensions;

namespace LittleBlocks.Template.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.BootstrapApp<Startup>(Configuration,
                app => app
                    .AddConfigSection<Clients>()
                    .HandleApplicationException<AppException>()
                    .UseDetailedErrors()
                    .ConfigureCorrelation(m => m.AutoCorrelateRequests())
                    .ConfigureMappings(m => m.AddProfile<MappingProfile>())
                    .AddServices((container, config) => AddServices(container, config)));
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory)
        {
            app.UseDefaultApiPipeline(Configuration, env, loggerFactory);
        }

        protected virtual IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddCoreServices()
                .AddRestClients()
                .AddDbServices(configuration);
        }
    }
}