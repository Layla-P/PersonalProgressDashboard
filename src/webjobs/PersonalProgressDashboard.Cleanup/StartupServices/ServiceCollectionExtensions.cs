

using Microsoft.Extensions.DependencyInjection;
using PersonalProgressDashboard.Cleanup.Services;

namespace PersonalProgressDashboard.Cleanup.StartupServices
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebjobCleanupProcesses(this IServiceCollection services)
        {
            RegisterWebjobCleanupProcesses(services);
            return services;
        }

        private static void RegisterWebjobCleanupProcesses(IServiceCollection services)
        {
            //Using built-in dependency injection
            services.AddScoped<IDataCleanup, DataCleanup>();
            services.AddScoped<IDataSeed, DataSeed>();
        }
    }
}
