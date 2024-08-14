using MongoDB.Driver;
using Microsoft.Extensions.Options;
using BookStore.Api.Models;

namespace BookStore.Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BookRepository(IOptions<BookStoreDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var database = mongoClient.GetDatabase(options.Value.DatabaseName);
            _books = database.GetCollection<Book>(options.Value.BooksCollectionName);
        }

        public async Task<IEnumerable<Book>?> GetBooksAsync() => await _books.Find(book => true).ToListAsync();

        public async Task<Book?> GetBookAsync(string id) => await _books.Find(book => book.Id == id).FirstOrDefaultAsync();
        public async Task<Book> AddBookAsync(Book book)
        {
            await _books.InsertOneAsync(book);
            return book;
        }
        public async Task UpdateBookAsync(string id, Book bookIn) => await _books.ReplaceOneAsync(book => book.Id == id, bookIn);
        public async Task DeleteBookAsync(string id) => await _books.DeleteOneAsync(book => book.Id == id);
    }
}
