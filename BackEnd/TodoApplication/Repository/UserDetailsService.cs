using TodoApplication.Dto;
using TodoApplication.Interface;
using TodoApplication.Models;

namespace TodoApplication.Repository
{
    public class UserDetailsService(IUserDetails userDetails) : IUserDetailsService
    {
        private readonly IUserDetails userDetails = userDetails;

        public async Task<IEnumerable<User>> GetUserDetailsAsync()
        {
            return await userDetails.GetUserDetailsAsync();

        }

        public async Task<User> GetUserDetailsByUserIdAsync(int id)
        {
            return await userDetails.GetUserDetailsByUserIdAsync(id);

        }

        public async Task<User> LoginUserDetailsAsync(UserLoginDto loginDto)
        {
            var result = await userDetails.GetUserDetailsByEmailAsync(loginDto.Email);
            if (result != null)
            {
                return result;
            }
            throw new ArgumentNullException("The User object cannot be null");


        }

        public async Task<User> UserRegisterAsync(User user)
        {
            return await userDetails.UserRegisterAsync(user);

        }
    }
}
