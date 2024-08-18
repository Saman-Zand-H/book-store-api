using Account.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Account.Data.DbContexts
{
    public class AccountDbContext(DbContextOptions<AccountDbContext> options) : DbContext(options)
    {
        public DbSet<User> Accounts { get; set; }
    }
}