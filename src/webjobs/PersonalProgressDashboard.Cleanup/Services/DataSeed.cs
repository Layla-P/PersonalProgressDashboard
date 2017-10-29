using Microsoft.AspNetCore.Identity;
using PersonalProgressDashboard.Common.DataSeed;
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

       
        private async Task AddSeededGoalsToDb()
        {
            await _personalGoalsRepository.AddGoalsRangeAsync(SeedGoals.SeedGoalsList());
        }
    }
}
