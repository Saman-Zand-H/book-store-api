using Core.Domain.Repositories;

namespace Account.Domain.Repositories
{
    public interface IUserRepository<T> : IGenericRepository<T> where T : class
    {
    }
}