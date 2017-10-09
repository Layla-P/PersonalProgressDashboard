using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.Repositories.Interfaces
{
    public interface IPersonalGoalsRepository
    {
        Task<List<PersonalGoals>> GetAllPersonalGoals();
    }
}