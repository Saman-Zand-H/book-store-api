using BookStore.Api.DTOs;

namespace BookStore.Api.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookReadDto>> GetBooksAsync();
        Task<BookReadDto?> GetBookAsync(string id);
        Task<BookReadDto> AddBookAsync(BookCreateDto book);
        Task UpdateBookAsync(string id, BookUpdateDto book);
        Task DeleteBookAsync(string id);
    }
}