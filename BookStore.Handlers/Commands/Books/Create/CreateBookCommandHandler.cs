using BookStore.Api.Repositories;
using BookStore.Api.Models;
using MediatR;

namespace BookStore.Handlers.Commands
{
    public class CreateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, CreateBookCommandResult>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<CreateBookCommandResult> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                BookName = command.BookName,
                Author = command.Author,
                Price = command.Price,
                Category = command.Category
            };

            await _bookRepository.AddBookAsync(book);

            return new CreateBookCommandResult
            {
                Id = book.Id!
            };
        }
    }
}