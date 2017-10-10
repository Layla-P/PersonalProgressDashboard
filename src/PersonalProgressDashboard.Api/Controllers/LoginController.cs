using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalProgressDashboard.Api.ViewModels;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(
            SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
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
        public async Task<IActionResult> Post([FromBody]LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //_logger.LogInformation(1, "User logged in.");
                    return Ok(returnUrl);
                }
                //if (result.IsLockedOut)
                //{
                //    //_logger.LogWarning(2, "User account locked out.");
                //    return View("Lockout");
                //}
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(model);
        }
    }
}
