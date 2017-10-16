using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalProgressDashboard.Api.ViewModels;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Api.Controllers
{
   
    [Route("api/[controller]")]
    public class AccountApiController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
      private readonly UserManager<ApplicationUser> _userManager;

    public AccountApiController(
            SignInManager<ApplicationUser> signInManager,
          UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
          _userManager = userManager;
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
      }

      var user = new ApplicationUser
      {
        UserName = model.Username,
        Email = model.Email,
        LastName = model.LastName,
        FirstName = model.FirstName,
        HeightCm = model.HeightCm,
        Sex = model.Sex,
        IsMetric = model.IsMetric,
        Created = DateTime.UtcNow,
        LastUpdated = DateTime.UtcNow
      };
      var result = await _userManager.CreateAsync(user, model.Password);

      if (!result.Succeeded)
      {
        return BadRequest(result.Errors.Select(x => x.Description).ToList());
      }

      await _signInManager.SignInAsync(user, false);

      return Ok();
    }

      [HttpPost("login")]
      public async Task<IActionResult> Login([FromBody] LoginViewModel model)
      {
        if (!ModelState.IsValid)
        {
          return BadRequest();
        }

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
          return BadRequest();
        }

        return Ok();
      }
  }
}
