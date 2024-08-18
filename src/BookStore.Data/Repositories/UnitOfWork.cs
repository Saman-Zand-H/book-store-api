using BookStore.Api.Settings;
using BookStore.Domain.Repositories;
using Microsoft.Extensions.Options;

namespace BookStore.Data.Repositories
{
    public class UnitOfWork(BookDbContext context) : IUnitOfWork
    {
        private readonly BookDbContext _context = context;
    }
}