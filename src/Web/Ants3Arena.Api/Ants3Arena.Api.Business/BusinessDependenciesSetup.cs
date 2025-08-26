using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Data;
using Ants3Arena.Api.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ants3Arena.Api.Business
{
    public static class BusinessDependenciesSetup
    {
        public static IServiceCollection AddBusinessDependencies(
            this IServiceCollection services,
            IConfiguration configuration,
            params Assembly[] assemblies)
        {
            services
                .AddMediatRConfiguration()
                .AddAutomapperConfiguration(assemblies)
                .AddServices();

            return services.AddDataDependencies(configuration);
        }


        private static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }

        private static IServiceCollection AddAutomapperConfiguration(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register other services here
            services
                .AddTransient<IBaseService<AntDto>, BaseService<AntDto>>()
                .AddTransient<IBaseService<AntColorDto>, BaseService<AntColorDto>>()
                .AddTransient<IBaseService<DirectionDto>, BaseService<DirectionDto>>();
            return services;
        }
    }
}
