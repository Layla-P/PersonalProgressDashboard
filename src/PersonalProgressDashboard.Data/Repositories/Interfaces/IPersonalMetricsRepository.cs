using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.Repositories.Interfaces
{
    public interface IPersonalMetricsRepository
    {
        Task<List<PersonalMetrics>> GetAllPersonalMetricsAsync();
        Task AddMetricsAsync(PersonalMetrics m);
        Task DANGER_DeleteAllMetricssAsync();
    }
}