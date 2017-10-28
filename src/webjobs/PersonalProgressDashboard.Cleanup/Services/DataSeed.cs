using Microsoft.AspNetCore.Identity;
using PersonalProgressDashboard.Data.Repositories.Interfaces;
using PersonalProgressDashboard.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalProgressDashboard.Cleanup.Services
{
    public class DataSeed : IDataSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPersonalMantrasRepository _personalMantrasRepository;
        private readonly IPersonalGoalsRepository _personalGoalsRepository;
        private readonly IPersonalMetricsRepository _personalMetricsRepository;


        public DataSeed(IPersonalMantrasRepository personalMantrasRepository,
            IPersonalMetricsRepository personalMetricsRepository,
            IPersonalGoalsRepository personalGoalsRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _personalMetricsRepository = personalMetricsRepository;
            _personalMantrasRepository = personalMantrasRepository;
            _personalGoalsRepository = personalGoalsRepository;
        }

        public async Task Process()
        {
            try
            {
                var task1 = AddSeededGoalsToDb();
                await Task.WhenAll(task1);
            }
            catch (Exception ex)
            {
                //add in logging etc
                throw;
            }
        }

        private static List<PersonalGoals> SeedGoals()
        {
            var goals = new List<PersonalGoals>();
            var today = DateTime.UtcNow;
            goals.Add(new PersonalGoals
            {
                GoalText = "To learn angular",
                AchieveByDate = today.AddMonths(2),
                LastUpdated = today,
                Created= today
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
        private async Task AddSeededGoalsToDb()
        {
            await _personalGoalsRepository.AddGoalsRangeAsync(SeedGoals());
        }
    }
}
