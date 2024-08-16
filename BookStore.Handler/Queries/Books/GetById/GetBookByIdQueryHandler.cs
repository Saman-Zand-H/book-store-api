using BookStore.Api.Repositories;
using MediatR;

namespace BookStore.Handlers.Queries
{
    public class GetBookByIdQueryHandler(IBookRepository bookRepository) : IRequestHandler<GetBookByIdQuery, GetBookByIdQueryResult?>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<GetBookByIdQueryResult?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookAsync(request.Id);
            return book is not null ? new GetBookByIdQueryResult
            {
                Id = book.Id!,
                BookName = book.BookName,
                Price = book.Price,
                Category = book.Category,
                Author = book.Author
            } : null;
        }
    }
}