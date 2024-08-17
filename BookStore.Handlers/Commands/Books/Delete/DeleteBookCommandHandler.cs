using BookStore.Api.Repositories;
using MediatR;

namespace BookStore.Handlers.Commands
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, DeleteBookCommandResult>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<DeleteBookCommandResult> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            await _bookRepository.DeleteBookAsync(command.Id);

            return new DeleteBookCommandResult
            {
                Id = command.Id
            };
        }
    }
}