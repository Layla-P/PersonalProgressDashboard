using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace PersonalProgressDashboard.Domain.Enitities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMetric { get; set; }
        public int Sex { get; set; }//convert to enum
        public int Age { get; set; }
        public int HeightCm { get; set; }

        public virtual ICollection<PersonalGoals> PersonalGoals { get; set; }
        public virtual ICollection<PersonalMantras> PersonalMantras { get; set; }
        public virtual ICollection<PersonalMetrics> PersonalMetrics { get; set; }
    }
}
