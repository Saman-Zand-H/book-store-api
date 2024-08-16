using BookStore.Api.Repositories;
using MediatR;

namespace BookStore.Handlers.Queries
{
    public class GetAllBooksQueryHandler(IBookRepository bookRepository) : IRequestHandler<GetAllBooksQuery, IEnumerable<GetAllBooksQueryResult>?>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<IEnumerable<GetAllBooksQueryResult>?> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksAsync();
            return books?.Select(book => new GetAllBooksQueryResult
            {
                Id = book.Id!,
                BookName = book.BookName,
                Price = book.Price,
                Category = book.Category,
                Author = book.Author
            });
        }
    }
}