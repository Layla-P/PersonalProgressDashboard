using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProgressDashboard.Domain.Models.Configuration
{
    public class BearerToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
