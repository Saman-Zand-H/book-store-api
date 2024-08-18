using Account.Domain.Models;
using Account.Domain.Repositories;
using MediatR;

namespace Account.App.Commands
{
    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email
            };

            await _userRepository.AddAsync(user);

            return new CreateUserCommandResult
            {
                Id = user.Id.ToString()
            };
        }
    }
}