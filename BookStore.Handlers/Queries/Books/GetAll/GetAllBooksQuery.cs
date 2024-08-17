using MediatR;

namespace BookStore.Handlers.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<GetAllBooksQueryResult>> { }
}