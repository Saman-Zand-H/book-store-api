using BookStore.Api.Models;


namespace BookStore.Api.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByIdAsync(string id);
        Task AddUserAsync(User user);
    }
}