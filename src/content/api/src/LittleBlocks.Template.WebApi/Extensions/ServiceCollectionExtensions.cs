using System;
using LittleBlocks.Ef;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LittleBlocks.Template.Core.Data;

namespace LittleBlocks.Template.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return services;
        }

        public static IServiceCollection AddRestClients(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDbServices(this IServiceCollection services,
            IConfiguration configuration)

        {
            services.AddSqlDbContext<AppDbContext>(
                configuration.GetConnectionString("AppDatabase"));

            return services;
        }
    }
}