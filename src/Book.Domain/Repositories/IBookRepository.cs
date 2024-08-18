using Core.Domain.Repositories;

namespace Book.Domain.Repositories
{
    public interface IBookRepository<T> : IGenericRepository<T> where T : class
    {
    }
}