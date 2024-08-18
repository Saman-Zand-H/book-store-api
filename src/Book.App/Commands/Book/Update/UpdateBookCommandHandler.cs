using Book.Domain.Repositories;
using MediatR;

namespace Book.App.Commands
{
    public class UpdateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<UpdateBookCommand, UpdateBookCommandResult>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<UpdateBookCommandResult> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(command.Id);
            if (book == null)
            {
                return new UpdateBookCommandResult
                {
                    Id = null
                };
            }

            var updatedBook = new Domain.Models.Book
            {
                Id = command.Id,
                Title = command.Title,
                Author = command.Author,
                Price = command.Price,
                ISBN = command.ISBN,
                PublishedDate = command.PublishedDate,
            };

            await _bookRepository.UpdateAsync(updatedBook);

            return new UpdateBookCommandResult
            {
                Id = updatedBook.Id!
            };
        }
    }
}