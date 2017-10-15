using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PersonalProgressDashboard.Data.Context
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
      builder.UseSqlServer("Server=TORRENS\\STANDARD2012;Database=PersonalProgressDashboard;Trusted_Connection=True;MultipleActiveResultSets=true");
         
      return new ApplicationDbContext(builder.Options);
        }
    }
}
