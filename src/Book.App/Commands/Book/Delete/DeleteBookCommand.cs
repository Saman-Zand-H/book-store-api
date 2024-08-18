using MediatR;

namespace Book.App.Commands
{
    public class DeleteBookCommand : IRequest<DeleteBookCommandResult>
    {
        public int Id { get; set; }
    }
}