using Microsoft.EntityFrameworkCore;

namespace Book.Data.DbContexts
{
    public class BookDbContext(DbContextOptions<BookDbContext> options) : DbContext(options)
    {
        public DbSet<Domain.Models.Book> Books { get; set; } = null!;
    }
}