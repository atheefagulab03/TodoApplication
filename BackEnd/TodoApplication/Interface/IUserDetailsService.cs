using TodoApplication.Dto;
using TodoApplication.Models;

namespace TodoApplication.Interface
{
    public interface IUserDetailsService
    {
         Task<IEnumerable<User>> GetUserDetailsAsync();

         Task<User> GetUserDetailsByUserIdAsync(int id);

         Task<User> UserRegisterAsync(User user);

         Task<User> LoginUserDetailsAsync(UserLoginDto loginDto);
    }
}
