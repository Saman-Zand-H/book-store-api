using MongoDB.Driver;
using BookStore.Api.Models;

namespace BookStore.Api.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("BookStore");
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books");
    }
}