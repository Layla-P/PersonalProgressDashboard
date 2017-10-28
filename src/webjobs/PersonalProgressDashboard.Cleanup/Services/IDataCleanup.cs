using System.Threading.Tasks;

namespace PersonalProgressDashboard.Cleanup.Services
{
    public interface IDataCleanup
    {
        Task Process();
    }
}