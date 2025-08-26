using Ants3Arena.Api.Data.Contexts;
using Ants3Arena.Api.Data.Repositories;
using Ants3Arena.Api.Models.Dtos;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<Ant3ArenaContext>(options =>
            {
                options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .UseLazyLoadingProxies();
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IBaseRepository<AntDto>, AntsRepository>()
                .AddTransient<IBaseRepository<AntColorDto>, AntColorsRepository>()
                .AddTransient<IBaseRepository<DirectionDto>, DirectionRepository>();
            return services;
        }
    }
}
