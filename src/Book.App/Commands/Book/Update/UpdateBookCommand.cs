using MediatR;

namespace Book.App.Commands
{
    public class UpdateBookCommand : IRequest<UpdateBookCommandResult>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}