using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PersonalProgressDashboard.Data.Context
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        //GOTCHA:   EFCore does not currenty support class libraries - as well as having a app, we need to create a dbContext with an empty deafult constructor  !!   http://benjii.me/2016/05/dotnet-ef-migrations-for-asp-net-core/

        //  Not entirely happy with this, as this way of working is a bit "too much magic" - this class is discovered if it is in the same assembly, and is an alternative way of defining a service (as opposed to putting it into the Startup->ConfigureServices)
        // it is needed for certain design-time features - i.e. Migrations
        //http://ef.readthedocs.io/en/latest/miscellaneous/configuring-dbcontext.html

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Server=TORRENS\\STANDARD2012;Database=PersonalProgressDashboard;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new ApplicationDbContext(builder.Options);
        }
    }
}
