using MediatR;

namespace Account.App.Queries
{
    public class GetUserByTokenQuery : IRequest<GetUserByTokenQueryResult>
    {
        public string Token { get; set; } = string.Empty;
    }
}