using Microsoft.AspNetCore.Identity;
using PersonalProgressDashboard.Data.Repositories.Interfaces;
using PersonalProgressDashboard.Domain.Enitities;
using System;
using System.Threading.Tasks;

namespace PersonalProgressDashboard.Cleanup.Services
{
    public class DataCleanup
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPersonalMantrasRepository _personalMantrasRepository;
        private readonly IPersonalGoalsRepository _personalGoalsRepository;
        private readonly IPersonalMetricsRepository _personalMetricsRepository;


        public DataCleanup(IPersonalMantrasRepository personalMantrasRepository,
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
                //If not logging this could be 'fire and forget'
                var task1 = _personalMetricsRepository.DANGER_DeleteAllMetricssAsync();
                var task2 = _personalGoalsRepository.DANGER_DeleteAllGoalsAsync();
                var task3 = _personalMantrasRepository.DANGER_DeleteAllMantrasAsync();
                await Task.WhenAll(task1, task2, task3);
                //log that all data has been deleted
            }
            catch (Exception ex)
            {
                //add in logging etc
                throw;
            }
        }
    }
}
