﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.JwtService.Interfaces;

namespace Services.JwtService.Services
{
    public class JwtService : ITokenService
    {

        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public JwtService(IConfiguration configurations)
        {
            _configuration = configurations;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]!));
        }

        public string EncodeToken()
        {
            var Issuer = _configuration["JwtConfig:Issuer"];
            var Audience = _configuration["JwtConfig:Audience"];
            //var key = _configuration["JwtConfig:Issuer"];
            var tokenValidilityMins = int.Parse(_configuration["JwtConfig:TokenValidityMins"]!);
            var tokenExpiryTimestamp = DateTime.UtcNow.AddMinutes(tokenValidilityMins);

            var claims = new List<Claim>
            {
                new Claim("Username", "APIBackend"),
                //new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpiryTimestamp,
                SigningCredentials = creds,
                Issuer = Issuer,
                Audience = Audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
