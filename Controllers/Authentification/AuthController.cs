using InventoryTrackApi.DTOs;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryTrackApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _configuration;
        /*
        private readonly string _jwtSecretKey;
        // 🔹 Extracting JWT secret key in the constructor to improve performance and reduce repeated code
        public AuthController(UserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _jwtSecretKey = configuration["JwtSettings:JwtSecretKey"] ?? throw new ArgumentNullException("JWT secret key is missing");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDto)
        {
            // 🔹 Validate request data to avoid null references
            if (userDto == null || string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.PasswordHash))
            {
                return BadRequest(new { message = "Invalid request" });
            }

            // 🔹 Fetch the user from the database by username
            var user = await _userService.GetUserByUsernameAsync(userDto.Username);
            if (user == null)
            {
                // ❌ Changed message to prevent user enumeration attacks
                return Unauthorized(new { message = "Authentication failed" });
            }

            // 🔹 Secure password verification: Don't compare raw passwords directly, use proper hashing (e.g., BCrypt)
            if (!_userService.VerifyPassword(user.PasswordHash, userDto.PasswordHash))
            {
                // ❌ Prevents attackers from knowing if username or password is incorrect
                return Unauthorized(new { message = "Authentication failed" });
            }

            // 🔹 Securely retrieve and validate the JWT secret key
            var key = Encoding.UTF8.GetBytes(_jwtSecretKey);
            if (key.Length < 16) // Ensure at least 128 bits (16 bytes) of security
            {
                return StatusCode(500, "JWT secret key is too short. It must be at least 128 bits (16 bytes).");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    // 🔹 Add claims: Username & Role, useful for role-based authentication
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1), // 🔹 Token expiration set to 1 day
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            // 🔹 Generate and return the JWT token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString }); // 🔹 Return a JSON response instead of a raw string
        }
        */
        
        public AuthController(UserService userService, IConfiguration configuration)
        {
            _userService = userService?? throw new ArgumentNullException(nameof(userService));
            _configuration = configuration?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.PasswordHash))
            {
                return BadRequest("Invalid request");
            }

            // Get user by username from UserService
            var user = await _userService.GetUserByUsernameAsync(userDto.Username);
            if (user == null)
                return Unauthorized("Invalid username or password");

            // Verify password using UserService
            if (!_userService.VerifyPassword(user.PasswordHash, userDto.PasswordHash))
                return Unauthorized("Invalid username or password");

            // Generate JWT token
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["JwtSecretKey"]);

            if (key.Length < 16)
            {
                return StatusCode(500, "JWT secret key is too short. It must be at least 128 bits (16 bytes).");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                //Expires = DateTime.UtcNow.AddHours(1),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }
    }
}
