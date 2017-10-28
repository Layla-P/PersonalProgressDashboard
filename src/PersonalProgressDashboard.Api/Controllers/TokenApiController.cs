using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonalProgressDashboard.Domain.Models;
using PersonalProgressDashboard.Api.ViewModels;
using PersonalProgressDashboard.Domain.Enitities;
using Remotion.Linq.Utilities;
using PersonalProgressDashboard.Common.Logging;

namespace PersonalProgressDashboard.Api.Controllers
{

    [Route("api/[controller]")]
    public class TokenApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IOptions<AppOptions> _options;

        public TokenApiController(
          UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher, IOptions<AppOptions> options)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _options = options;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginViewModel model)
        {
            try
            {
                LogHelper.Debug($"[TokenApiController].[Post] Begin controller post, getting Auth Token");
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    return Unauthorized();
                }
                if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) ==
                    PasswordVerificationResult.Success)
                {
                    var userClaims = await _userManager.GetClaimsAsync(user);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    }.Union(userClaims);

                    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.JwtSecurityTokenKey));
                    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                      issuer: _options.Value.JwtSecurityTokenIssuer,
                      audience: _options.Value.JwtSecurityTokenAudience,
                      claims: claims,
                      notBefore: DateTime.Now,
                      expires: DateTime.Now.AddDays(1),
                      signingCredentials: signingCredentials
                    );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"[TokenApiController].[Post] Exception : '{ex.Message}'");
            }

            return Unauthorized();
        }
    }
}
