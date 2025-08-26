using Ants3Arena.Api.Data;
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
            return services;
        }
    }
}
