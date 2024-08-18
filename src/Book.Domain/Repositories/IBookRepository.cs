using Core.Domain.Repositories;

namespace Book.Domain.Repositories
{
    public interface IBookRepository : IGenericRepository<Models.Book>
    {
    }
}