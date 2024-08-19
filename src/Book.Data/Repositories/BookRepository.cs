using Core.Data.Repositories;
using Book.Domain.Repositories;

namespace Book.Data.Repositories
{
    public class BookRepository(BookDbContext context) : GenericRepository<Domain.Models.Book, BookDbContext>(context), IBookRepository
    {
    }
}