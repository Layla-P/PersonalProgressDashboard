using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalProgressDashboard.Data.EntitiesConfigurations;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PersonalMantras> PersonalMantras { get; set; }
        public DbSet<PersonalMetrics> PersonalMetrics { get; set; }
        public DbSet<PersonalGoals> PersonalGoals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplicationUserConfiguration.Configure(builder);
            PersonalGoalsConfiguration.Configure(builder);
            PersonalMantrasConfiguration.Configure(builder);
            PersonalGoalsConfiguration.Configure(builder);
        }
    }
}
