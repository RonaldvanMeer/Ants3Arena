using Ant3Arena.Business.HttpClients;
using Ant3Arena.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.Design;

namespace Ant3Arena.Business
{
    public static class BusinessDependenciesSetup
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHttpClients()
                .AddAnts();
            return services;
        }

        private static IServiceCollection AddAnts(this IServiceCollection services)
        {
            services.AddSingleton(provider => { 
                return provider.GetRequiredService<IAntsService>().GetAllAntsAsync().Result.ToList();
            });
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddSingleton(new Random(1337))
                .AddTransient<IAntsService, AntsService>();
            return services;
        }   

        private static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            services
                .AddHttpClient<IAntsClient, AntsClient>("AntsClient", client =>
                {
                    client.BaseAddress = new Uri("https://localhost:7178/"); // should get URL from configuration
                });
            return services;
        }
    }
}
