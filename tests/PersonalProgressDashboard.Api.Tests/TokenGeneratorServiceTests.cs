

using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using PersonalProgressDashboard.Api.Middleware;
using PersonalProgressDashboard.Domain.Models;
using PersonalProgressDashboard.Domain.Enitities;

namespace PersonalProgressDashboard.Api.Tests
{
    [TestFixture]
    public class TokenGeneratorServiceTests
    {

        private TokenGeneratorService _tokenGeneratorService;

        public TokenGeneratorServiceTests()
        {
            Mock<IOptions<AppOptions>> options = new Mock<IOptions<AppOptions>>();
            _tokenGeneratorService = new TokenGeneratorService(options.Object);
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
