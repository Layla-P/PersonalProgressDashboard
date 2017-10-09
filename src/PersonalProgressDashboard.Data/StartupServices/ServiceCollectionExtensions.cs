using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PersonalProgressDashboard.Data.Repositories.Implementation;
using PersonalProgressDashboard.Data.Repositories.Interfaces;

namespace PersonalProgressDashboard.Data.StartupServices
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            RegisterDataServices(services);
            return services;
        }

        private static void RegisterDataServices(IServiceCollection services)
        {
            //Using built-in dependency injection
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IPersonalMetricsRepository, PersonalMetricsRepository>();
            services.AddScoped<IPersonalGoalsRepository, PersonalGoalsRepository>();
            services.AddScoped<IPersonalMantrasRepository, PersonalMantrasRepository>();
        }
    }
}
