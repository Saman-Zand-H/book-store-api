using Account.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Account.Data
{
    public class AccountDbContext(DbContextOptions<AccountDbContext> options) : DbContext(options)
    {

        // Define your DbSets here
        public DbSet<User> Users { get; set; }
    }
}
