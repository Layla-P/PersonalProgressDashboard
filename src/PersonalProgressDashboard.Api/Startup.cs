using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PersonalProgressDashboard.Api.Middleware;
using PersonalProgressDashboard.Api.Middleware.Models;
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

      if (env.IsDevelopment())
      {
        builder.AddUserSecrets<Startup>();
      }

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

      services.Configure<AppOptions>(options => Configuration.Bind(options));

      services.AddAuthentication(options =>
      {
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })

        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidIssuer = Configuration["JwtSecurityTokenIssuer"],
            ValidAudience = Configuration["JwtSecurityTokenAudience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityTokenKey"])),
            ValidateLifetime = true
          };
          options.RequireHttpsMetadata = false;
        });

     

      //Below is the dependency injection for the repos found in the domain project.
      services.AddDataServices();

      services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      //todo: Add application services.
      //services.AddTransient<IEmailSender, AuthMessageSender>();
      //services.AddTransient<ISmsSender, AuthMessageSender>();

      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseCors(builder =>
        builder.WithOrigins("http://localhost:49978", "'http://personal-progress-dashboard-web.azurewebsites.net", "http://localhost:49911/")
            .AllowCredentials()
          .AllowAnyMethod()
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

#region Potential links


//https://pioneercode.com/post/authentication-in-an-asp-dot-net-core-api-part-3-json-web-token
//services.ConfigureApplicationCookie(options => options.Events = new CookieAuthenticationEvents
//{
//  OnRedirectToLogin = ctx =>
//  {
//    if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
//    {
//      ctx.Response.StatusCode = 401;
//      return Task.FromResult<object>(null);
//    }

//    ctx.Response.Redirect(ctx.RedirectUri);
//    return Task.FromResult<object>(null);
//  }
//});


//https://stackoverflow.com/questions/45904955/dotnet-core-2-0-use-identity-with-jwtbearer-authentication
//services.AddAuthentication(o => {
//    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//  })
//  .AddJwtBearer(options =>
//  {
//    options.Authority = "localhost:4200";
//    options.Audience = "localhost:4200";
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//      ValidateIssuerSigningKey = true,
//      ValidateIssuer = true,
//      ValidateLifetime = true,
//      ValidIssuer = "localhost:4200",
//      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey_GetThisFromAppSettings"))
//    };
//  });

//services.ConfigureApplicationCookie(options =>
//{
//  options.LoginPath = "/api/login";
//  options.Events = new CookieAuthenticationEvents
//  {
//    OnRedirectToLogin = ctx =>
//    {
//      if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200 && !ctx.HttpContext.User.Identity.IsAuthenticated)
//      {
//        ctx.Response.StatusCode = 401;
//        return Task.FromResult<object>(null);
//      }

//      ctx.Response.Redirect(ctx.RedirectUri);
//      return Task.FromResult<object>(null);
//    }
//  };
//});

#endregion