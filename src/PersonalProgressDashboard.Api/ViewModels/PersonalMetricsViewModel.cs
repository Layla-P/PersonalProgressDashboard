using System.ComponentModel.DataAnnotations;

namespace PersonalProgressDashboard.Api.ViewModels
{
  public class PersonalMetricsViewModel
  {
    [Required]
    public double WeightKg { get; set; }
    public double? NeckCm { get; set; } // Measurements are optional but weight is not
    public double? ChestCm { get; set; }
    public double? WaistCm { get; set; }
    public double? HipsCm { get; set; }
  }
}
