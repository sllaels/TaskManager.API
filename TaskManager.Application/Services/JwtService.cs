using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using TaskManager.Domain;
using TaskManager.Contracts;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using TaskManager.Application.ServiceInterfaces;
namespace TaskManager.Application.Services
{
    public class JwtService:IJwtService
    {
        private JwtOptions _jwtOptions;
        public JwtService(IOptions<JwtOptions> options) { _jwtOptions = options.Value; }
        public string GeneratToken(User user)
        {
            var claims = new List<Claim>
            { 
               
                  new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                  new Claim(ClaimTypes.Name, user.Name),
                  new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiresHours),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), 
                SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
