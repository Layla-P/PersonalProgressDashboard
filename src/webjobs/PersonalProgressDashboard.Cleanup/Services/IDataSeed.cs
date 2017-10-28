using System.Threading.Tasks;

namespace PersonalProgressDashboard.Cleanup.Services
{
    public interface IDataSeed
    {
        Task Process();
    }
}