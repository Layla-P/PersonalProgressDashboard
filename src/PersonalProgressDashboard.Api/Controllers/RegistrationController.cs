using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalProgressDashboard.Api.Middleware;
using PersonalProgressDashboard.Api.ViewModels;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Api.Controllers
{
  
  [Route("api/[controller]")]
  public class RegistrationController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
    public RegistrationController(UserManager<ApplicationUser> userManager,
      SignInManager<ApplicationUser> signInManager, ITokenGeneratorService tokenGeneratorService, IPasswordHasher<ApplicationUser> passwordHasher)
    {
      _userManager = userManager;
      _passwordHasher = passwordHasher;
      _signInManager = signInManager;
      _tokenGeneratorService = tokenGeneratorService;
    }
    //[HttpGet]
    //[AllowAnonymous]
    //public IActionResult Register(string returnUrl = null)
    //{
    //  return Ok();
    //}

    //
    // POST: /Account/Register
    [HttpPost]
    [AllowAnonymous]
 
    public async Task<IActionResult> Post([FromBody]RegisterViewModel model)
    {
      if (ModelState.IsValid)
      {
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
        if (result.Succeeded)
        {
          // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
          // Send an email with this link
          //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
          //var callbackUrl = Url.Action(nameof(ConfirmEmail), "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
          //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
          //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
          await _signInManager.SignInAsync(user, isPersistent: false);
          var userClaims = await _userManager.GetClaimsAsync(user);
          var token = _tokenGeneratorService.ReturnToken(user, userClaims);
          return Ok(token);

        }
        //AddErrors(result);
      }

      // If we got this far, something failed, redisplay form
      return Unauthorized();
    }
  }
}
