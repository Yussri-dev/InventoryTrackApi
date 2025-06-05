using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using BCrypt.Net;
using InventoryTrackApi.Services.Interfaces;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetSaasClientInUser()
        {
            Expression<Func<SaasClient, bool>> filter = c => c.SubscriptionType == "Free";

            var clientSaas = await _unitOfWork.SaasClients.GetByConditionAsync(filter);
            return _mapper.Map<IEnumerable<UserDTO>>(clientSaas);

        }
        // Add a new user
        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);

            user.PasswordHash = HashPassword(userDto.PasswordHash);

            await _unitOfWork.Users.CreateAsync(user);
            return _mapper.Map<UserDTO>(user);
        }
        // Get all users
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            var users = await _unitOfWork.Users.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        // Get a user by ID
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        // Get user by username (for login purposes)
        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            var user = await _unitOfWork.Users.GetByConditionAsync(
                u => u.Username == username); // Assuming 'Username' is a property of User

            return user.FirstOrDefault() != null ? _mapper.Map<UserDTO>(user.FirstOrDefault()) : null;
        }

        // Verify the password against the stored hash
        public bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }

        //Update an existing product
        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _unitOfWork.Users.GetByIdAsync(user.Id);

            if (existingUser == null)
            {
                throw new InvalidOperationException("User Not Found");
            }
            existingUser.Id = user.Id;
            existingUser.Username = user.Username;
            //existingUser.PasswordHash = user.PasswordHash;
            existingUser.Email = user.Email;
            existingUser.Role = user.Role;
            existingUser.SaasClientId = user.SaasClientId;

            await _unitOfWork.Users.UpdateAsync(existingUser);
        }


        // Helper function to hash passwords
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
