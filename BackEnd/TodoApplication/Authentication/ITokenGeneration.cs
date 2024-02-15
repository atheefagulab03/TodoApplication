using TodoApplication.Dto;
using TodoApplication.Models;

namespace TodoApplication.Authentication
{
    public interface ITokenGeneration
    {
        string GenerateToken(User user);
    }
}
