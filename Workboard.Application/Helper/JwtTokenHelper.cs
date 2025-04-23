using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Workboard.Domain.Entities;

namespace Workboard.Application.Helper
{
    public class JwtTokenHelper
    {
        private readonly IConfiguration configuration_;

        public JwtTokenHelper(IConfiguration configuration)
        {
            configuration_ = configuration;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration_["Jwt:SecretKey"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration_["Jwt:Issuer"],
                audience: configuration_["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credential

            );

            return await System.Threading.Tasks.Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

            
        }
    }
}
