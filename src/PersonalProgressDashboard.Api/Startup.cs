using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalProgressDashboard.Data.Context;
using PersonalProgressDashboard.Data.StartupServices;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Api
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)// requires in project.json: "Microsoft.Extensions.Configuration.FileExtensions"
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)// requires in project.json: "Microsoft.Extensions.Configuration.Json"
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables(); // requires in project.json: "Microsoft.Extensions.Configuration.EnvironmentVariables"
      Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();

      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(Configuration.GetValue<string>("ConnectionStringConfiguration:DefaultSQLConnectionString"))); // requires in project.json "Microsoft.EntityFrameworkCore.SqlServer"
                                                                                                                             // When using Identity, one needs the addIdentity too.
                                                                                                                             //https://stackoverflow.com/questions/40900414/asp-net-core-1-0-0-dependency-injection-error-unable-to-resolve-service-for-typ
      services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

      services.AddAuthentication(options =>
      {
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      });
      //Below is the dependency injection for the repos found in the domain project.
      services.AddDataServices();

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      // Add application services.
      //services.AddTransient<IEmailSender, AuthMessageSender>();
      //services.AddTransient<ISmsSender, AuthMessageSender>();

      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseCors(builder =>
        builder.WithOrigins("http://localhost:49978")
          .AllowAnyHeader()
      );
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseAuthentication();
      app.UseMvc();
    }
  }
}
