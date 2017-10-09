using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalProgressDashboard.Data.Repositories.Interfaces;

namespace PersonalProgressDashboard.Api.Controllers
{
   [Route("api/[controller]")]
    public class PersonalGoalsController : Controller
    {
        private readonly IPersonalGoalsRepository _personalGoalsRepository;

        public PersonalGoalsController(IPersonalGoalsRepository personalGoalsRepository)
        {
            _personalGoalsRepository = personalGoalsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
           var results = await _personalGoalsRepository.GetAllPersonalGoals();
           return Ok(results);
        }
    }
}
