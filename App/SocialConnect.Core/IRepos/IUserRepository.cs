using Microsoft.EntityFrameworkCore;
using SocialConnect.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.IRepos
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<ICollection<User>> GetAllUsersAsync();
        Task<bool> RegisterUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        void DeleteUserAsync(int userId);
        Task<bool> SaveAsync();
    }
}
