using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalProgressDashboard.Data.Context;
using PersonalProgressDashboard.Data.StartupServices;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)// requires in project.json: "Microsoft.Extensions.Configuration.FileExtensions"
                .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)// requires in project.json: "Microsoft.Extensions.Configuration.Json"
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true)
                .AddEnvironmentVariables(); // requires in project.json: "Microsoft.Extensions.Configuration.EnvironmentVariables"
            Configuration = builder.Build();
        }

        //// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer(Configuration.GetValue<string>("ConnectionStringConfiguration:DefaultSQLConnectionString"))); // requires in project.json "Microsoft.EntityFrameworkCore.SqlServer"

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDataServices();
        }

    }
}
