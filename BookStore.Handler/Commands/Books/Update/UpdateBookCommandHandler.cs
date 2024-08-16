using BookStore.Api.Models;
using BookStore.Api.Repositories;
using MediatR;

namespace BookStore.Handlers.Commands
{
    public class UpdateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<UpdateBookCommand, UpdateBookCommandResult>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<UpdateBookCommandResult> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = command.Id,
                BookName = command.BookName,
                Author = command.Author,
                Price = command.Price,
                Category = command.Category
            };

            await _bookRepository.UpdateBookAsync(command.Id, book);

            return new UpdateBookCommandResult
            {
                Id = book.Id!
            };
        }
    }
}