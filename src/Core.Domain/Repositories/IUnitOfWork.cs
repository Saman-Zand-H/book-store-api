namespace Core.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}