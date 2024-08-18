using Book.Domain.Repositories;
using MediatR;

namespace Book.App.Queries
{
    public class GetBookByIdQueryHandler(IBookRepository bookRepository) : IRequestHandler<GetBookByIdQuery, GetBookByIdQueryResult?>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<GetBookByIdQueryResult?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            return book is not null ? new GetBookByIdQueryResult
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate,
            } : null;
        }
    }
}