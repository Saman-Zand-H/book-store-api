using BookStore.Api.Data;
using BookStore.Api.Models;
using BookStore.Api.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.Api.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMongoCollection<User> _users;

        public AuthRepository(IOptions<BookStoreDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var database = mongoClient.GetDatabase(options.Value.DatabaseName);
            _users = database.GetCollection<User>(options.Value.UsersCollectionName);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }
    }
}