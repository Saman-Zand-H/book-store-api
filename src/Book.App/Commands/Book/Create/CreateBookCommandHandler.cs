using Book.Domain.Repositories;
using MediatR;

namespace Book.App.Commands
{
    public class CreateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, CreateBookCommandResult>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<CreateBookCommandResult> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Domain.Models.Book
            {
                Title = command.BookName,
                Author = command.Author,
                Price = command.Price,
            };

            await _bookRepository.AddAsync(book);

            return new CreateBookCommandResult
            {
                Id = book.Id!
            };
        }
    }
}