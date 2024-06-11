using SocialConnect.Application.DTOs.User;
using SocialConnect.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Application.IServices
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task<List<UserDTO>> FindUserByNameAsync(string userName);
        ICollection<UserDTO> GetAll();
        Task<UserDTO> GetUserByEmail(string email);
        Task<bool> RegisterNewUser(UserDTO userDTO);
        Task<UserDTO> UpdateOldUser(UserDTO userDTO);
        void DeleteUser(int userId);
    }
}
