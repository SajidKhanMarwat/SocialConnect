using AutoMapper;
using SocialConnect.Application.DTOs.User;
using SocialConnect.Application.NewFolder.IServices;
using SocialConnect.Core.Entities;
using SocialConnect.Core.IRepos;

namespace SocialConnect.Application.NewFolder.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDTO> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user != null)
            {
                var userDto = _mapper.Map<User, UserDTO>(user);
                return userDto;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public ICollection<UserDTO> GetAll()
        {
            var allUsers = _userRepository.GetAllUsersAsync().Result.ToList();
            var userDtos = allUsers.Select(user => _mapper.Map<User, UserDTO>(user)).ToList();
            return userDtos;
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            var userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;
        }

        public async Task<bool> RegisterNewUser(UserDTO userDTO)
        {
            await _userRepository.RegisterUserAsync(_mapper.Map<UserDTO, User>(userDTO));
            return true;
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateOldUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
