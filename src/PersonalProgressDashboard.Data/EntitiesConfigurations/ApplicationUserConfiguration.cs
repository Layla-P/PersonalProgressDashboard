using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.EntitiesConfigurations
{
    public class ApplicationUserConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(e =>
                {
                    // relationships
                    e.HasKey(c => c.Id);
                    e.HasMany<PersonalGoals>(f => f.PersonalGoals);
                    e.HasMany<PersonalMetrics>(f => f.PersonalMetrics);
                    e.HasMany<PersonalMantras>(f => f.PersonalMantras);

                    // common properties
                    e.Property(c => c.Id)
                        .IsRequired();
                    e.Property(c => c.Created)
                        .IsRequired();
                    e.Property(c => c.LastUpdated)
                        .IsRequired();

                    // properties
                    e.Property(c => c.FirstName)
                        .IsRequired()
                        .HasMaxLength(85);
                    e.Property(c => c.LastName)
                        .IsRequired()
                        .HasMaxLength(85);
                    e.Property(c => c.Age)
                        .IsRequired();
                    e.Property(c => c.HeightCm)
                        .IsRequired();
                    e.Property(c => c.Sex)
                        .IsRequired();
                    e.Property(c => c.IsMetric)
                        .IsRequired();

                    //Note properties that are not required ie nullable types do not need to be entered here.
                }
            );
        }
    }
}
