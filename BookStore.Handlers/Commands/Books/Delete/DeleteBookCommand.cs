using MediatR;

namespace BookStore.Handlers.Commands
{
    public class DeleteBookCommand : IRequest<DeleteBookCommandResult>
    {
        public string Id { get; set; } = string.Empty;
    }
}