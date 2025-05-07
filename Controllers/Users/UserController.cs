using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    ////[Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(UserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            if (string.IsNullOrEmpty(userDto.PasswordHash))
            {
                return BadRequest("Password is required.");
            }

            var user = await _userService.CreateUserAsync(userDto );

            // Hide the password in the response
            user.PasswordHash = null;

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
       
        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
                return BadRequest("Invalid pagination parameters.");

            var users = await _userService.GetAllUsersAsync(pageNumber, pageSize);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid user ID.");

            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, UserDTO userDto)
        {
            _logger.LogInformation($"Update User request received for Id : {id}");
            if (id != userDto.Id)
            {
                _logger.LogWarning($"User ID mismatch : Route Id {id} does not match DTO ID {userDto.Id}");
                return BadRequest("User ID mismatch");
            }
            try
            {
                var existingUser = await _userService.GetUserByIdAsync(id);
                if (existingUser == null)
                {
                    _logger.LogWarning($"User with ID : {id} not fount");
                    return NotFound("User Not Found");
                }

                _logger.LogInformation($"Updating user with Id {id}");
                var user = _mapper.Map<User>(userDto);
                await _userService.UpdateUserAsync(user);

                _logger.LogInformation($"user with ID {id} successfully updated");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating User with ID {id}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }

}
