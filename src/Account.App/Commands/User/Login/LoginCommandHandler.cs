using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Account.Domain.Models;
using Account.Domain.Repositories;
using Account.App.Settings;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Account.App.Commands
{
    public class LoginCommandHandler(IUserRepository accountRepository, JwtSettings jwtSettings) : IRequestHandler<LoginCommand, LoginCommandResult>
    {
        private readonly IUserRepository _accountRepository = accountRepository;
        private readonly JwtSettings _jwtSettings = jwtSettings;

        public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await Authenticate(request.Email, request.Password);

            return new LoginCommandResult
            {
                Token = token
            };
        }

        public async Task<string?> Authenticate(string username, string password)
        {
            var userQs = await _accountRepository.FindAsync(x => x.UserName == username);
            if (userQs == null)
            {
                return null;
            }

            var user = userQs.FirstOrDefault();
            if (user == null || !VerifyPassword(password, user.HashedPassword))
            {
                return null;
            }

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        private static bool VerifyPassword(string password, string HashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, HashedPassword);
        }
    }
}