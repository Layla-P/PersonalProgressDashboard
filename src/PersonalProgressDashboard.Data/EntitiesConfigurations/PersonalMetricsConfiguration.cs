using System;
using Microsoft.EntityFrameworkCore;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.EntitiesConfigurations
{
    public class PersonalMetricsConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonalMetrics>(e =>
                {
                    // relationships
                    e.HasKey(c => c.Id);
                    // common properties
                    e.Property(c => c.Id)
                     .IsRequired();
                    e.Property(c => c.Created)
                        .IsRequired();
                    e.Property(c => c.LastUpdated)
                        .IsRequired();
                    // properties
                    e.Property(c => c.WeightKg)
                        .IsRequired();

                    //Note properties that are not required ie nullable types do not need to be entered here.
                }
            );
        }
    }
}
