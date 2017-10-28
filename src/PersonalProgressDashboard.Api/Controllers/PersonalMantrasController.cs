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
  [Route("api/[controller]")]
  public class PersonalMantrasController : Controller
  {
    private readonly IPersonalMantrasRepository _personalMantrasRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public PersonalMantrasController(IPersonalMantrasRepository personalMantrasRepository, UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
      _personalMantrasRepository = personalMantrasRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
      var results = await _personalMantrasRepository.GetAllPersonalMantrasAsync();
      return Ok(results);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody]PersonalMantrasViewModel vm)
    {
      var user = await GetCurrentUserId();
      var isUpdated = _personalMantrasRepository.UpdateMantraAsync(MapModel(vm, user));
      return Ok(isUpdated);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]PersonalMantrasViewModel vm)
    {
      var user = await GetCurrentUserId();
      _personalMantrasRepository.AddMantraAsync(MapNewModel(vm, user));
      return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]int id)
    {
      await GetCurrentUserId();
      _personalMantrasRepository.DeleteMantraAsync(id);
      return Ok();
    }
    #region Private methods

    private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    private async Task<string> GetCurrentUserId()
    {
      var usr = await GetCurrentUserAsync();
      return usr?.Id;
    }
    private static PersonalMantras MapModel(PersonalMantrasViewModel m, string applicationUserId)
    {
      return new PersonalMantras
      {
        Id = m.Id,
        MantraText = m.MantraText,
        ApplicationUserId = applicationUserId,
      };
    }
    private static PersonalMantras MapNewModel(PersonalMantrasViewModel m, string applicationUserId)
    {
      return new PersonalMantras
      {
        ApplicationUserId = applicationUserId,
        MantraText = m.MantraText,
        Created = DateTime.UtcNow,
        LastUpdated = DateTime.UtcNow
      };
    }
    #endregion
  }
}
