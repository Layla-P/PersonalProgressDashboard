using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.Repositories.Interfaces
{
    public interface IPersonalMantrasRepository
    {
      Task<List<PersonalMantras>> GetAllPersonalMantras();
      Task<PersonalMantras> GetPersonalMantraById(int id);
      void AddMantra(PersonalMantras m);
      Task<bool> UpdateMantra(PersonalMantras m);
      void DeleteMantra(int id);
  }
}