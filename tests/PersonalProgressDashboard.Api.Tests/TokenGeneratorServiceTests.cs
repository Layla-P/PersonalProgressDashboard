

using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using PersonalProgressDashboard.Api.Middleware;
using PersonalProgressDashboard.Domain.Models;
using PersonalProgressDashboard.Domain.Enitities;
using PersonalProgressDashboard.Common.DataSeed;
using System.Security.Claims;
using System.Collections.Generic;
using System.Reflection;

namespace PersonalProgressDashboard.Api.Tests
{
    [TestFixture]
    public class TokenGeneratorServiceTests
    {

        private TokenGeneratorService _tokenGeneratorService;

        public TokenGeneratorServiceTests()
        {
            var appOptions = new AppOptions
            {
                JwtSecurityTokenKey = "this is a test token key",
                JwtSecurityTokenAudience = "PersonalProgressDashboard.Api",
                JwtSecurityTokenIssuer = "PersonalProgressDashboard.Web.Angular"
            };

            IOptions<AppOptions> options = Options.Create(appOptions);

            _tokenGeneratorService = new TokenGeneratorService(options);
            

        }
        //TODO:  Progress study of unit testing...
        [Test]
        public void TokenGenerator_sShouldNotReturn_Null()
        {
            var user = SeedUser.CreateUser();
            var claims = new List<Claim>();
            var result = _tokenGeneratorService.ReturnToken(user, claims);
            // so this test isn't great, my return is a dynamic object so quite difficult to determine anything from it.
            //But at least I mocked my tokenservice!
            result.Should().NotBeNull();

        }

        [Test]
        public void TestMethod_ShouldReturn_ValueOfOne()
        {
            int result = _tokenGeneratorService.TestMethod();
            result.Should().Be(1);
        }

        //TODO:  Progress study of unit testing...
        
    }
}
