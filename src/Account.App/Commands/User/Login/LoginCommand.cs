using MediatR;

namespace Account.App.Commands
{
    public class LoginCommand : IRequest<LoginCommandResult>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}