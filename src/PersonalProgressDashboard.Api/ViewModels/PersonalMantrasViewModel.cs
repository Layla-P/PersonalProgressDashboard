using System.ComponentModel.DataAnnotations;

namespace PersonalProgressDashboard.Api.ViewModels
{
  public class PersonalMantrasViewModel
  {
    public int Id { get; set; }
    [Required]
    public string MantraText { get; set; }
  }
}
