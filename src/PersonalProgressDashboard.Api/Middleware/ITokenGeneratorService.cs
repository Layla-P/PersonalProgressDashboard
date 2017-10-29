using System.Collections.Generic;
using System.Security.Claims;
using PersonalProgressDashboard.Domain.Models;
using PersonalProgressDashboard.Domain.Enitities;
using PersonalProgressDashboard.Domain.Models.Configuration;

namespace PersonalProgressDashboard.Api.Middleware
{
    public interface ITokenGeneratorService
    {
        BearerToken ReturnToken(ApplicationUser user, IList<Claim> userClaims);
    }
}
