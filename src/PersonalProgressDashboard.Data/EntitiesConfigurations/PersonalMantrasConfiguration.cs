using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.EntitiesConfigurations
{
    public class PersonalMantrasConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalMantras>(e =>
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
                    e.Property(c => c.MantraText)
                        .IsRequired()
                        .HasMaxLength(500);

                    //Note properties that are not required ie nullable types do not need to be entered here.
                }
            );
        }
    }
}
