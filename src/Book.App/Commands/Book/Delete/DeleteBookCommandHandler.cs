using Book.Domain.Repositories;
using MediatR;

namespace Book.App.Commands
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, DeleteBookCommandResult>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<DeleteBookCommandResult> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(command.Id);
            if (book == null)
            {
                return new DeleteBookCommandResult
                {
                    Id = null
                };
            }

            await _bookRepository.DeleteAsync(book);

            return new DeleteBookCommandResult
            {
                Id = command.Id
            };
        }
    }
}