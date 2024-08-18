using Book.Data.DbContexts;
using Book.Domain.Repositories;

namespace Book.Data.Repositories
{
    public class UnitOfWork(BookDbContext context)
    {
        private readonly BookDbContext _context = context;

        public IBookRepository<Domain.Models.Book> Books => new BookRepository(_context);
    }
}