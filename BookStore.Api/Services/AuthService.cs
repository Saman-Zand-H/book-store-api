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
    public class AuthService(IAuthRepository authRepository, JwtSettings jwtSettings) : IAuthService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings;
        private readonly IAuthRepository _authRepository = authRepository;

        public async Task<string> Register(UserCreateDto userDto)
        {
            var user = userDto.Adapt<User>();
            await _authRepository.AddUserAsync(user);
            return GenerateJwtToken(user);
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await _authRepository.GetUserByUsernameAsync(username);
            if (user == null || !user.VerifyPassword(password))
            {
                return null;
            }

            return GenerateJwtToken(user);
        }

        public async Task<UserReadDto?> GetUserAsync(string username)
        {
            var user = await _authRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return null;
            }

            return user.Adapt<UserReadDto>();
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}