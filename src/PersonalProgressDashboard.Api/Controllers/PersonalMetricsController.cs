using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalProgressDashboard.Data.Repositories.Interfaces;

namespace PersonalProgressDashboard.Api.Controllers
{
   [Route("api/[controller]")]
    public class PersonalMetricsController : Controller
    {
        private readonly IPersonalMetricsRepository _personalMetricsRepository;

        public PersonalMetricsController (IPersonalMetricsRepository personalMetricsRepository)
        {
            _personalMetricsRepository = personalMetricsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
           var results = await _personalMetricsRepository.GetAllPersonalMetrics();
           return Ok(results);
        }
    }
}
