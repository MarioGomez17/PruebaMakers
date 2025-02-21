using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class UserRepository : Repository<UserModel>
    {
        public UserRepository(ApplicationDBContext DBContext) : base(DBContext)
        {
        }
        public async Task<UserModel?> GetByEmailAsync(string Email, CancellationToken CancellationToken = default)
        {
            return await DBContext.Set<UserModel>().FirstOrDefaultAsync(User => User.UserEmail == Email, CancellationToken);
        }
        public async Task<bool> IsUserExist(string Email, CancellationToken CancellationToken = default)
        {
            return await DBContext.Set<UserModel>().AnyAsync(User => User.UserEmail == Email);
        }
    }
}
