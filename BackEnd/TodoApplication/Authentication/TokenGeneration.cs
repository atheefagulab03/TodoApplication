using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoApplication.Models;

namespace TodoApplication.Authentication
{
    public class TokenGeneration(IOptionsSnapshot<JwtConfig> jwtConfig) : ITokenGeneration
    {
        private readonly JwtConfig jwtConfig = jwtConfig.Value;

        public string GenerateToken(User user)
        {
            var claims = new Claim[]
                    {
                new (JwtClaims.Subject, jwtConfig.Subject),
                new (JwtClaims.JwtId, Guid.NewGuid().ToString()),
                new (JwtClaims.IssuedAt, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new (JwtClaims.UserEmail, user.Email),
                new (JwtClaims.UserId, user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               jwtConfig.Issuer,
                jwtConfig.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

