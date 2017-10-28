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
            goals.Add(new PersonalGoals
            {
                GoalText = "To learn angular",
                AchieveByDate = DateTime.UtcNow.AddMonths(2)
            });
            goals.Add(new PersonalGoals
            {
                GoalText = "To learn react",
                AchieveByDate = DateTime.UtcNow.AddMonths(3)
            });
            goals.Add(new PersonalGoals
            {
                GoalText = "To learn dotnet core 2",
                AchieveByDate = DateTime.UtcNow.AddMonths(1)
            });
            return goals;
        }
        private async Task AddSeededGoalsToDb()
        {
            await _personalGoalsRepository.AddGoalsRangeAsync(SeedGoals());
        }
    }
}
