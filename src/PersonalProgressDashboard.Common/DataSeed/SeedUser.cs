using PersonalProgressDashboard.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProgressDashboard.Common.DataSeed
{
    public static class SeedUser
    {
        public static ApplicationUser CreateUser()
        {
            var today = new DateTime(2017, 01, 01);
            var user = new ApplicationUser
            {
                UserName = "testusername",
                Email = "test@test.com",
                LastName = "lastname",
                FirstName = "firstname",
                HeightCm = 200,
                Sex = 0,
                IsMetric = true,
                Age = 30
            };
            return user;
        }
    }
}
