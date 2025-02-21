namespace PruebaTecnica.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken CancellationToken = default);
    }
}
