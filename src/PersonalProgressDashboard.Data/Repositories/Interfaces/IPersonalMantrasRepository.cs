using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.Repositories.Interfaces
{
    public interface IPersonalMantrasRepository
    {
        Task<List<PersonalMantras>> GetAllPersonalMantrasAsync();
        Task<PersonalMantras> GetPersonalMantraByIdAsync(int id);
        Task AddMantraAsync(PersonalMantras m);
        Task<bool> UpdateMantraAsync(PersonalMantras m);
        Task DeleteMantraAsync(int id);
        Task DANGER_DeleteAllMantrasAsync();
    }
}