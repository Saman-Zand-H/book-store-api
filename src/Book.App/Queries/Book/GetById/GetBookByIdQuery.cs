using MediatR;

namespace Book.App.Queries
{
    public class GetBookByIdQuery : IRequest<GetBookByIdQueryResult>
    {
        public int Id { get; set; }
    }
}