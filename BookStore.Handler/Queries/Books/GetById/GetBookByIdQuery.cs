using MediatR;

namespace BookStore.Handlers.Queries
{
    public class GetBookByIdQuery : IRequest<GetBookByIdQueryResult>
    {
        public string Id { get; set; } = string.Empty;
    }
}