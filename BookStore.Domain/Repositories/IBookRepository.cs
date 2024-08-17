using BookStore.Api.Models;

namespace BookStore.Api.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>?> GetBooksAsync();
        Task<Book?> GetBookAsync(string id);
        Task<Book> AddBookAsync(Book book);
        Task UpdateBookAsync(string id, Book book);
        Task DeleteBookAsync(string id);
    }
}