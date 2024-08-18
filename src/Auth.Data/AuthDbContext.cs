using Auth.Domain;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data
{
    public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}