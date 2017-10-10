using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.Repositories.Interfaces
{
    public interface IPersonalGoalsRepository
    {
        Task<List<PersonalGoals>> GetAllPersonalGoals();
        Task<PersonalGoals> GetPersonalGoalById(int id);
        void AddGoal(PersonalGoals m);
        Task<bool> UpdateGoal(PersonalGoals m);
        void DeleteGoal(int id);
    }
}