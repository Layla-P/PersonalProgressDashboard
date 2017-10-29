using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PersonalProgressDashboard.Api.Middleware;
using PersonalProgressDashboard.Api.ViewModels;
using PersonalProgressDashboard.Domain.Enitities;
using Newtonsoft.Json;

namespace PersonalProgressDashboard.Api.Controllers
{
  [AllowAnonymous]
  [Route("api/[controller]")]
  public class LoginController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

    public LoginController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, ITokenGeneratorService tokenGeneratorService, IPasswordHasher<ApplicationUser> passwordHasher)
    {
      _userManager = userManager;
      _passwordHasher = passwordHasher;
     // _signInManager = signInManager;
      _tokenGeneratorService = tokenGeneratorService;
    }
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get(string returnUrl = null)
    {
      // Clear the existing external cookie to ensure a clean login process
      // await HttpContext.Authentication.SignOutAsync(_externalCookieScheme);

      return Ok();
    }

    //
    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    // [ValidateAntiForgeryToken]
    public async Task<IActionResult> Post([FromBody]LoginViewModel model)
    {
      try
      {
        var user = await _userManager.FindByNameAsync(model.Email);
        if (user == null)
        {
          return Unauthorized();
        }
        if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) ==
            PasswordVerificationResult.Success)
        {
          var userClaims = await _userManager.GetClaimsAsync(user);
          var token = _tokenGeneratorService.ReturnToken(user, userClaims);
          return Ok(JsonConvert.SerializeObject(token));
        }
        return Unauthorized();
      }
      catch (Exception ex)
      {
        //todo
      }
      return Unauthorized();
    }
  }
}
