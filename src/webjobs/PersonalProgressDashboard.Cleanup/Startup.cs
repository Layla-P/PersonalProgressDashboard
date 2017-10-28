using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalProgressDashboard.Data.StartupServices;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataServices();
        }
    }
}
