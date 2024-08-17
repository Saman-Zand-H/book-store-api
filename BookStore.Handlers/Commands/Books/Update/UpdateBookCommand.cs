using MediatR;

namespace BookStore.Handlers.Commands
{
    public class UpdateBookCommand : IRequest<UpdateBookCommandResult>
    {
        public string Id { get; set; } = string.Empty;
        public string BookName { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}