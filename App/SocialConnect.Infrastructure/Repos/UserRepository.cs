using Microsoft.EntityFrameworkCore;
using SocialConnect.Core.Context;
using SocialConnect.Core.Entities;
using SocialConnect.Core.IRepos;

namespace SocialConnect.Infrastructure.Repos
{
    public class UserRepository : IUserRepository
    {
        private SocialDbContext _context;
        private ILogsRepository _logs;
        public UserRepository(SocialDbContext context, ILogsRepository logs)
        {
            _context = context;
            _logs = logs;
        }
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            try
            {
                return await _context.Users.FindAsync(userId);
            }
            catch (Exception)
            {
                await _logs.AddMessage($"Error while Finding the User by id = {userId}");
                throw;
            }
        }
        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.AsQueryable().ToListAsync();
            return users;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                return user;
            }
            catch (Exception)
            {
                await _logs.AddMessage($"Error while Finding the User by id = {email}");
                throw;
            }
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                if (_context.Users.AddAsync(user).IsCompletedSuccessfully)
                {
                    if (SaveAsync().IsCompletedSuccessfully)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            if (_context.SaveChangesAsync().IsCompletedSuccessfully)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
