using MediatR;

namespace Book.App.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<GetAllBooksQueryResult>>
    {
    }
}