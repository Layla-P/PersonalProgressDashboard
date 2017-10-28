using System.Threading.Tasks;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Data.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetUserAsync(string id);
    }
}