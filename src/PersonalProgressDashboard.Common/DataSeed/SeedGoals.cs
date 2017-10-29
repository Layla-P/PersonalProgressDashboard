using PersonalProgressDashboard.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProgressDashboard.Common.DataSeed
{
    public static class SeedGoals
    {
        public static List<PersonalGoals> SeedGoalsList()
        {
            var goals = new List<PersonalGoals>();
            var today = new DateTime(2017, 01, 01);
            goals.Add(new PersonalGoals
            {
                GoalText = "To learn angular",
                AchieveByDate = today.AddMonths(2),
                LastUpdated = today,
                Created = today
            });
            goals.Add(new PersonalGoals
            {
                GoalText = "To learn react",
                AchieveByDate = today.AddMonths(3),
                LastUpdated = today,
                Created = today
            });
            goals.Add(new PersonalGoals
            {
                GoalText = "To learn dotnet core 2",
                AchieveByDate = today.AddMonths(1),
                LastUpdated = today,
                Created = today
            });
            return goals;
        }

        public static PersonalGoals SeedGoal()
        {
            var today = new DateTime(2017,01,01);

            return new PersonalGoals
            {
                GoalText = "test goal",
                AchieveByDate = today.AddMonths(1),
                LastUpdated = today,
                Created = today
            };
        }
    }
}
