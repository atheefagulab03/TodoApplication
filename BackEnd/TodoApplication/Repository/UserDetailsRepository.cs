using Microsoft.EntityFrameworkCore;
using TodoApplication.Interface;
using TodoApplication.Models;

namespace TodoApplication.Repository
{
    public class UserDetailsRepository(TaskContext taskContext) : IUserDetails
    {
        private readonly TaskContext taskContext = taskContext;


        public async Task<IEnumerable<User>> GetUserDetailsAsync()
        {
            var result = await taskContext.Users.ToListAsync();
            return result;

        }

        public async Task<User> GetUserDetailsByEmailAsync(string Email)
        {
            var result = await taskContext.Users.FirstOrDefaultAsync(x => x.Email == Email);
            if (result != null)
            {
                return result;
            }
            throw new KeyNotFoundException($"No TaskDetails found for the Email {Email}");

        }

        public async Task<User> GetUserDetailsByUserIdAsync(int id)
        {
            var result = await taskContext.Users.FindAsync(id);
            if (result != null)
            {
                return result;
            }
            throw new KeyNotFoundException($"No TaskDetails found for user with ID {id}");
        }



        public async Task<User> UserRegisterAsync(User user)
        {
            if (user != null)
            {
                await taskContext.Users.AddAsync(user);
                await taskContext.SaveChangesAsync();
                return user;
            }


            throw new ArgumentNullException("The User object cannot be null");
        }
    }
}
