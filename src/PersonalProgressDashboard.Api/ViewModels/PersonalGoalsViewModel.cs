using System;
using System.ComponentModel.DataAnnotations;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Api.ViewModels
{
    public class PersonalGoalsViewModel
    {
        public PersonalGoalsViewModel()
        {
        }

        public PersonalGoalsViewModel(PersonalGoals m)
        {
            Id = m.Id;
            GoalText = m.GoalText;
            AchieveByDate = m.AchieveByDate;
            AchievedDate = m.AchievedDate;
        }

        public int Id { get; set; }

        [Required]
        public string GoalText { get; set; }

        [Required]
        public DateTime AchieveByDate { get; set; }

        public DateTime? AchievedDate { get; set; }
        public bool IsAcheived { get; set; }
    }
}