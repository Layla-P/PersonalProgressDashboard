using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalProgressDashboard.Api.ViewModels;
using PersonalProgressDashboard.Data.Repositories.Interfaces;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Api.Controllers
{
  [Authorize]
  //[Authorize(ActiveAuthenticationSchemes="Jwt")]
  [Route("api/[controller]")]
  public class PersonalMetricsController : Controller
  {
    private readonly IPersonalMetricsRepository _personalMetricsRepository;

    private readonly UserManager<ApplicationUser> _userManager;

    public PersonalMetricsController(IPersonalMetricsRepository personalMetricsRepository, UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
      _personalMetricsRepository = personalMetricsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
      var results = await _personalMetricsRepository.GetAllPersonalMetricsAsync();
      return Ok(results);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]PersonalMetricsViewModel vm)
    {
      var user = await GetCurrentUserId();
       _personalMetricsRepository.AddMetricsAsync(MapNewModel(vm, user));
      return Ok();
    }

    #region Private methods

    private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    private async Task<string> GetCurrentUserId()
    {
      var usr = await GetCurrentUserAsync();
      return usr?.Id;
    }
  
    private static PersonalMetrics MapNewModel(PersonalMetricsViewModel m, string applicationUserId)
    {
      return new PersonalMetrics
      {
        ApplicationUserId = applicationUserId,
        WeightKg = m.WeightKg,
        ChestCm = m.ChestCm,
        NeckCm = m.NeckCm,
        WaistCm = m.WaistCm,
        HipsCm = m.HipsCm,
        Created = DateTime.UtcNow,
        LastUpdated = DateTime.UtcNow
      };
    }
    #endregion
  }
}
