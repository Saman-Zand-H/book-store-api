using MongoDB.Driver;
using Microsoft.Extensions.Options;
using BookStore.Api.Models;
using BookStore.Api.Settings;
using BookStore.Domain.Repositories;
using System.Linq.Expressions;

namespace BookStore.Data.Repositories
{
    public class BookRepository(IMongoCollection<Book> books) : IBookRepository
    {
        private readonly IMongoCollection<Book> _books = books;

        public async Task<IEnumerable<Book>> GetAllAsync() => await _books.Find(book => true).ToListAsync();

        public async Task<Book> GetByIdAsync(string id) => await _books.Find(book => book.Id == id).FirstOrDefaultAsync();
        public async Task<Book> AddAsync(Book book)
        {
            await _books.InsertOneAsync(book);
            return book;
        }
        public async Task UpdateAsync(Book bookIn) => await _books.ReplaceOneAsync(book => book.Id == bookIn.Id, bookIn);
        public async Task DeleteAsync(string id) => await _books.DeleteOneAsync(book => book.Id == id);
        public async Task<IEnumerable<Book>> FindAsync(Expression<Func<Book, bool>> predicate) => await _books.Find(predicate).ToListAsync();
    }
}
