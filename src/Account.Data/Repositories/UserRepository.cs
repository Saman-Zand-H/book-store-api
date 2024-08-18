using Account.Data.DbContexts;
using Account.Domain.Models;
using Account.Domain.Repositories;
using Core.Data.Repositories;

namespace Account.Data.Repositories
{
    public class UserRepository(AccountDbContext context) : GenericRepository<User, AccountDbContext>(context), IUserRepository
    {
    }
}