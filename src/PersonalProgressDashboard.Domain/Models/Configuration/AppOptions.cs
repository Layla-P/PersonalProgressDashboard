
namespace PersonalProgressDashboard.Domain.Models
{
  public class AppOptions
  {
    public string JwtSecurityTokenKey { get; set; }
    public string JwtSecurityTokenAudience { get; set; }
    public string JwtSecurityTokenIssuer { get; set; }
  }
}
