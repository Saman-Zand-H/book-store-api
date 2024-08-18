using System.IdentityModel.Tokens.Jwt;
using Account.App.Settings;
using Account.Domain.Repositories;
using MediatR;

namespace Account.App.Queries
{
    public class GetUserByTokenQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByTokenQuery, GetUserByTokenQueryResult?>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<GetUserByTokenQueryResult?> Handle(GetUserByTokenQuery request, CancellationToken cancellationToken)
        {
            var userId = JwtToUserId(request.Token);
            if (userId == null)
            {
                return null;
            }

            var user = await _userRepository.GetByIdAsync(userId!.Value);
            if (user == null)
            {
                return null;
            }

            return new GetUserByTokenQueryResult
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName
            };
        }

        private static int? JwtToUserId(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var token = tokenHandler.ReadJwtToken(jwt);
                return int.TryParse(token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value, out var userId) ? userId : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
