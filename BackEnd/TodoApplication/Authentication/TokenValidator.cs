using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TodoApplication.Authentication
{
    public class TokenValidator(IOptionsSnapshot<JwtConfig> jwtConfig) : ITokenValidator
    {
        private readonly JwtConfig jwtConfig = jwtConfig.Value;

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfig.Issuer,
                ValidAudience = jwtConfig.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key))
            };
        }
    }
}
