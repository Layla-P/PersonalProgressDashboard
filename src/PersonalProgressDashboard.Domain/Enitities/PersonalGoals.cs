using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProgressDashboard.Domain.Enitities
{
    public class PersonalGoals : EntityBase
    {
        public Guid ApplicationUserId { get; set; }
        public string GoalText { get; set; }
        public DateTime AchieveByDate { get; set; }
        public DateTime? AcheivedDate { get; set; }
    }
}
