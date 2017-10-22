using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalProgressDashboard.Api.ViewModels
{
    public class PersonalGoalsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string GoalText { get; set; }
        [Required]
        public DateTime AchieveByDate { get; set; }
        public DateTime? AchievedDate { get; set; }
        public bool IsAcheived { get; set; }
    }
    public class AddPersonalGoalViewModel
    {
        [Required]
        public string GoalText { get; set; }
        [Required]
        public DateTime AchieveByDate { get; set; }
    }
}