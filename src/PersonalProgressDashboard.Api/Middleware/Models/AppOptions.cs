using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PersonalProgressDashboard.Api.Middleware.Models
{
  public class AppOptions
  {
    public string JwtSecurityTokenKey { get; set; }
    public string JwtSecurityTokenAudience { get; set; }
    public string JwtSecurityTokenIssuer { get; set; }
  }
}
