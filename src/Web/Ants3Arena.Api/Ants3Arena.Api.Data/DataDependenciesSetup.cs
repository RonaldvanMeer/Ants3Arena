using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ants3Arena.Api.Data
{
    public static class DataDependenciesSetup
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext(configuration)
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ExternalAuthenticationDbContext>(options =>
            //{
            //    options
            //        .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            //        .UseLazyLoadingProxies();
            //});

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}
