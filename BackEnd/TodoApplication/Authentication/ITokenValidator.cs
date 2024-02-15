using Microsoft.IdentityModel.Tokens;

namespace TodoApplication.Authentication
{
    public interface ITokenValidator
    {
        TokenValidationParameters GetTokenValidationParameters();
    }
}
