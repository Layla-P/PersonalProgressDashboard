using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.Repositories.Interfaces
{
    public interface IPersonalGoalsRepository
    {
        Task<List<PersonalGoals>> GetAllPersonalGoalsAsync();
        Task<PersonalGoals> GetPersonalGoalByIdAsync(int id);
        Task AddGoalAsync(PersonalGoals m);
        Task<bool> UpdateGoalAsync(PersonalGoals m);
        Task DeleteGoalAsync(int id);
        Task DANGER_DeleteAllGoalsAsync();
    }
}