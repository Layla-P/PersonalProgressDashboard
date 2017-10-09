using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProgressDashboard.Domain.Enitities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
