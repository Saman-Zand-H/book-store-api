using BookStore.Api.DTOs;
using BookStore.Api.Models;

namespace BookStore.Api.Services
{
    public interface IAuthService
    {
        Task<string> Register(UserCreateDto user);
        Task<string> Authenticate(string username, string password);
        Task<UserReadDto?> GetUserAsync(string username);
    }
}