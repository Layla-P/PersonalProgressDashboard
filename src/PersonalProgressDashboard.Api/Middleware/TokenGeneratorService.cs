﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonalProgressDashboard.Domain.Models;
using PersonalProgressDashboard.Domain.Enitities;
using PersonalProgressDashboard.Domain.Models.Configuration;

namespace PersonalProgressDashboard.Api.Middleware
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        private readonly IOptions<AppOptions> _options;

        public TokenGeneratorService(IOptions<AppOptions> options)
        {
            _options = options;
        }

        public BearerToken ReturnToken(ApplicationUser user, IList<Claim> userClaims)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }.Union(userClaims);

            var symmetricSecurityKey =
              new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.JwtSecurityTokenKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: _options.Value.JwtSecurityTokenIssuer,
              audience: _options.Value.JwtSecurityTokenAudience,
              claims: claims,
              notBefore: DateTime.Now,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: signingCredentials
            );
            return new BearerToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}
