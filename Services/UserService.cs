using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using BCrypt.Net;

namespace InventoryTrackApi.Services
{
    public class UserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // Add a new user
        public async Task<UserDTO> CreateUserAsync(UserDTO userDto, string password)
        {
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = HashPassword(password); 

            await _userRepository.CreateAsync(user);
            return _mapper.Map<UserDTO>(user);
        }
        // Get all users
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            var users = await _userRepository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        // Get a user by ID
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        // Get user by username (for login purposes)
        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByConditionAsync(
                u => u.Username == username); // Assuming 'Username' is a property of User

            return user.FirstOrDefault() != null ? _mapper.Map<UserDTO>(user.FirstOrDefault()) : null;
        }

        // Verify the password against the stored hash
        public bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }

        // Helper function to hash passwords
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
