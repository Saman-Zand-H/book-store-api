using MediatR;

namespace Book.App.Commands
{
    public class CreateBookCommand : IRequest<CreateBookCommandResult>
    {
        public string BookName { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}