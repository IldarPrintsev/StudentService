using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentService.BLL.Interfaces;
using StudentService.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentService.BLL.Managers
{
    public class TokenManager : ITokenManager
    {
        private readonly IConfiguration _configuration;
        public TokenManager(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("secretKey")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("appUrl"),
                audience: _configuration.GetValue<string>("appUrl"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
