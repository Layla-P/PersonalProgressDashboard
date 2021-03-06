﻿using System;
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
            var results = await _personalGoalsRepository.GetAllPersonalGoalsAsync();
      return Ok(results);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody]PersonalGoalsViewModel vm)
    {
      var user = await GetCurrentUserId();
      vm.AchievedDate = await IsAchieved(vm);
      var isUpdated = _personalGoalsRepository.UpdateGoalAsync(MapModel(vm, user));
      return Ok(isUpdated);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]AddPersonalGoalViewModel vm)
    {
      var user = await GetCurrentUserId();
        var g = MapNewModel(vm);
        if (g == null) return BadRequest();
        await _personalGoalsRepository.AddGoalAsync(g);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]int id)
    {
      await GetCurrentUserId();
      await _personalGoalsRepository.DeleteGoalAsync(id);
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
    private static PersonalGoals MapNewModel(AddPersonalGoalViewModel m)
    {
        if (m != null)
        {
            return new PersonalGoals
            {
                GoalText = m.GoalText,
                AchieveByDate = m.AchieveByDate
            };
        }
        return null;
    }

    private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    private async Task<string> GetCurrentUserId()
    {
      var usr = await GetCurrentUserAsync();
      return usr?.Id;
    }

    private async Task<DateTime?> IsAchieved(PersonalGoalsViewModel vm)
    {
      var goal = await _personalGoalsRepository.GetPersonalGoalByIdAsync(vm.Id);
      if (goal.AchievedDate == null && vm.IsAcheived)
      {
        return DateTime.UtcNow;
      }
      return goal.AchievedDate;
    }
    #endregion
  }
}
