using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using PersonalProgressDashboard.Api.Middleware;
using PersonalProgressDashboard.Domain.Models;
using PersonalProgressDashboard.Common.DataSeed;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace PersonalProgressDashboard.Api.Tests
{
    [TestFixture]
    public class TokenGeneratorServiceTests
    {

        private TokenGeneratorService _tokenGeneratorService;

        private AppOptions _options;

        public TokenGeneratorServiceTests()
        {
            _options = new AppOptions
            {
                JwtSecurityTokenKey = "this is a test token key",
                JwtSecurityTokenAudience = "issuer",
                JwtSecurityTokenIssuer = "audience"
            };

            IOptions<AppOptions> options = Options.Create(_options);

            _tokenGeneratorService = new TokenGeneratorService(options);


        }
        //TODO:  Progress study of unit testing...
        [Test]
        public void TokenGenerator_sShouldNotReturn_Null()
        {
            var user = SeedUser.CreateUser();
            var claims = new List<Claim>();
            var result = _tokenGeneratorService.ReturnToken(user, claims);
            result.Should().NotBeNull();
        }
        [Test]
        public void TokenGenerator_sShouldReturn_BearerToken()
        {
            var user = SeedUser.CreateUser();
            var claims = new List<Claim>();
            var result = _tokenGeneratorService.ReturnToken(user, claims);
            result.Token.Should().BeOfType<string>();
        }

        [Test]
        public void TokenGenerator_ShouldReturn_Expiration()
        {
            var user = SeedUser.CreateUser();
            var claims = new List<Claim>();
            var result = _tokenGeneratorService.ReturnToken(user, claims);
            var expiry = DateTime.Now.AddDays(1);
            result.Expiration.Should().BeCloseTo(expiry, precision: 6000);
        }

        [Test]
        public void TokenGenerator_ShouldReturn_Issuer()
        {
            var user = SeedUser.CreateUser();
            var claims = new List<Claim>();
            var result = _tokenGeneratorService.ReturnToken(user, claims);

            var handler = new JwtSecurityTokenHandler();

            var tokenS = handler.ReadToken(result.Token) as JwtSecurityToken;
            var issuer = tokenS.Issuer;
            issuer.Should().Be(_options.JwtSecurityTokenIssuer);
        }

        //[Test]
        //public void TokenGenerator_ShouldReturn_Key()
        //{
        //    var symmetricSecurityKey =
        //     new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JwtSecurityTokenKey));
        //    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        //    var user = SeedUser.CreateUser();
        //    var claims = new List<Claim>();
        //    var result = _tokenGeneratorService.ReturnToken(user, claims);

        //    var handler = new JwtSecurityTokenHandler();

        //    var tokenS = handler.ReadToken(result.Token) as JwtSecurityToken;
        //    var returnedSigningCredentials = tokenS.SigningCredentials;

        //    returnedSigningCredentials.Should().Be(signingCredentials);
        //}

    }
}
