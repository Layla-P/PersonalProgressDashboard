using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProgressDashboard.Domain.Enitities
{
    public class PersonalMantras : EntityBase
    {
        public string ApplicationUserId { get; set; }
        public string MantraText { get; set; }
    }
}
