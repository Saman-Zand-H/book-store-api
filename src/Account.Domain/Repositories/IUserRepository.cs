using Account.Domain.Models;
using Core.Domain.Repositories;

namespace Account.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}