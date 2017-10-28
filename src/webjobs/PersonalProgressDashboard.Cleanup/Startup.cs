using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalProgressDashboard.Cleanup.StartupServices;
using PersonalProgressDashboard.Data.Context;
using PersonalProgressDashboard.Data.StartupServices;
using PersonalProgressDashboard.Domain.Enitities;
using System;
using System.IO;

namespace PersonalProgressDashboard.Cleanup
{

    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory()) // requires: "Microsoft.Extensions.Configuration.FileExtensions" //gotcha:  make sure we have context of where to find the subsequent appsettings.json file!
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)// requires: "Microsoft.Extensions.Configuration.Json"
                            .AddEnvironmentVariables();// requires: "Microsoft.Extensions.Configuration.EnvironmentVariables"

            Configuration = builder.Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                            options.UseSqlServer(Configuration.GetValue<string>("ConnectionStringConfiguration:DefaultSQLConnectionString")));


            services.AddIdentity<ApplicationUser, IdentityRole>()
                                      .AddEntityFrameworkStores<ApplicationDbContext>();
                                      


            services.AddDataServices();
            services.AddWebjobCleanupProcesses();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
