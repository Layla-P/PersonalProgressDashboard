using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace PersonalProgressDashboard.Domain.Enitities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float WeightInKg { get; set; }
        public bool IsMetric { get; set; } = true;
        public List<string> Mantras { get; set; } = new List<string>();
    }
}
