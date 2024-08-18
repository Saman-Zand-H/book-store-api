using Book.Domain.Repositories;
using MediatR;

namespace Book.App.Queries
{
    public class GetAllBooksQueryHandler(IBookRepository bookRepository) : IRequestHandler<GetAllBooksQuery, IEnumerable<GetAllBooksQueryResult>?>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<IEnumerable<GetAllBooksQueryResult>?> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync();
            return books?.Select(book => new GetAllBooksQueryResult
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate,
            });
        }
    }
}