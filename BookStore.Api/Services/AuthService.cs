using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStore.Api.DTOs;
using BookStore.Api.Models;
using BookStore.Api.Repositories;
using BookStore.Api.Settings;
using Mapster;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Api.Services
{
    public class AuthService(IAuthRepository authRepository, JwtSettings jwtSettings, ILogger<AuthService> logger) : IAuthService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings;
        private readonly IAuthRepository _authRepository = authRepository;
        private readonly ILogger<AuthService> _logger = logger;

        public async Task<string> Register(UserCreateDto userDto)
        {
            var user = await _authRepository.GetUserByUsernameAsync(userDto.Username);
            if (user != null)
            {
                throw new Exception("Username already exists");
            }
            user = userDto.Adapt<User>();
            await _authRepository.AddUserAsync(user);
            return GenerateJwtToken(user);
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await _authRepository.GetUserByUsernameAsync(username);
            if (user == null || !user.VerifyPassword(password))
            {
                throw new Exception("Invalid username or password");
            }

            return GenerateJwtToken(user);
        }

        public async Task<UserReadDto?> GetUserAsync(string token)
        {
            var userId = JwtToUserId(token);
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            _logger.LogInformation("User ID: {userId}", userId);
            var user = await _authRepository.GetUserByIdAsync(userId);
            return user?.Adapt<UserReadDto>();
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, user.Id!)
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        private string? JwtToUserId(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var token = tokenHandler.ReadJwtToken(jwt);
                return token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading JWT token");
                return null;
            }
        }

    }
}