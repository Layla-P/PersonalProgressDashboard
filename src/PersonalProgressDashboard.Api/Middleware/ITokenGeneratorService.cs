using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using PersonalProgressDashboard.Api.Middleware.Models;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Api.Middleware
{
    public interface ITokenGeneratorService
    {
    object ReturnToken(ApplicationUser user, IList<Claim> userClaims);
    }
}
