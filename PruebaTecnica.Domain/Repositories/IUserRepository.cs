using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel?> GetByIdAsync(string Id, CancellationToken cancellationToken = default);
        Task<UserModel?> GetByEmailAsync(string Email, CancellationToken cancellationToken = default);
        void Add(UserModel user);
        Task<bool> IsUserExist(string Email, CancellationToken cancellationToken = default);
    }
}
