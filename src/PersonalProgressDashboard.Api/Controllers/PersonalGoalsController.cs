using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalProgressDashboard.Api.ViewModels;
using PersonalProgressDashboard.Data.Repositories.Interfaces;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Api.Controllers
{
  //[Authorize(AuthenticationSchemes = "Bearer")]
  [Route("api/[controller]")]
  public class PersonalGoalsController : Controller
  {
    private readonly IPersonalGoalsRepository _personalGoalsRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public PersonalGoalsController(IPersonalGoalsRepository personalGoalsRepository, UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
      _personalGoalsRepository = personalGoalsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
            //var userId = await GetCurrentUserId();
            var results = await _personalGoalsRepository.GetAllPersonalGoals();
      return Ok(results);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody]PersonalGoalsViewModel vm)
    {
      var user = await GetCurrentUserId();
      vm.AchievedDate = await IsAchieved(vm);
      var isUpdated = _personalGoalsRepository.UpdateGoal(MapModel(vm, user));
      return Ok(isUpdated);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]PersonalGoalsViewModel vm)
    {
      var user = await GetCurrentUserId();
      _personalGoalsRepository.AddGoal(MapNewModel(vm));
      return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]int id)
    {
      await GetCurrentUserId();
      _personalGoalsRepository.DeleteGoal(id);
      return Ok();
    }



    #region Private methods
    private static PersonalGoals MapModel(PersonalGoalsViewModel m, string applicationUserId)
    {
      return new PersonalGoals
      {
        Id = m.Id,
        ApplicationUserId = applicationUserId,
        GoalText = m.GoalText,
        AchieveByDate = m.AchieveByDate,
        AchievedDate = m.AchievedDate
      };
    }
    private static PersonalGoals MapNewModel(PersonalGoalsViewModel m)
    {
      return new PersonalGoals
      {
        GoalText = m.GoalText,
        AchieveByDate = m.AchieveByDate,
        AchievedDate = m.AchievedDate,
        Created = DateTime.UtcNow,
        LastUpdated = DateTime.UtcNow
      };
    }

    private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    private async Task<string> GetCurrentUserId()
    {
      var usr = await GetCurrentUserAsync();
      return usr?.Id;
    }

    private async Task<DateTime?> IsAchieved(PersonalGoalsViewModel vm)
    {
      var goal = await _personalGoalsRepository.GetPersonalGoalById(vm.Id);
      if (goal.AchievedDate == null && vm.IsAcheived)
      {
        return DateTime.UtcNow;
      }
      return goal.AchievedDate;
    }
    #endregion
  }
}
