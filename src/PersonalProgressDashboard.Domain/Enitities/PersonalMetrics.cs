using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProgressDashboard.Domain.Enitities
{
    public class PersonalMetrics : EntityBase
    {
        public Guid ApplicationUserId { get; set; }
        public double WeightKg { get; set; }
        public double? NeckCm { get; set; } // Measurements are optional but weight is not
        public double? ChestCm { get; set; }
        public double? WaistCm { get; set; }
        public double? HipsCm { get; set; }
    }
}
