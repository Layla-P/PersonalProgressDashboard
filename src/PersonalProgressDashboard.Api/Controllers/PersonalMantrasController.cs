using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalProgressDashboard.Data.Repositories.Interfaces;

namespace PersonalProgressDashboard.Api.Controllers
{
   [Route("api/[controller]")]
    public class PersonalMantrasController : Controller
    {
        private readonly IPersonalMantrasRepository _personalMantrasRepository;

        public PersonalMantrasController(IPersonalMantrasRepository personalMantrasRepository)
        {
            _personalMantrasRepository = personalMantrasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
           var results = await _personalMantrasRepository.GetAllPersonalMantras();
           return Ok(results);
        }
    }
}
