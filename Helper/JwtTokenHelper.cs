using Microsoft.IdentityModel.Tokens;
using QuizApp.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuizApp.Helper
{
    public static class JwtTokenHelper
    {
        public static string GenerateJwtToken(UserDTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("31f96020f2dfdc5491555c77f666161973303b213661e7c77405d35972890aef"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(issuer: "http://localhost:5277", audience: "http://localhost:5277", claims: claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
