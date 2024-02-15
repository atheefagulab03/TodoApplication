using TodoApplication.Models;

namespace TodoApplication.Interface
{
    public interface IUserDetails
    {
         Task<IEnumerable<User>> GetUserDetailsAsync();

         Task<User> GetUserDetailsByUserIdAsync(int id);

         Task<User> UserRegisterAsync(User user);

         Task<User> GetUserDetailsByEmailAsync(string Email);


    }
}
