using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public abstract class Repository <TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDBContext DBContext;
        protected Repository(ApplicationDBContext DBContext)
        {
            this.DBContext = DBContext;
        }
        public async Task<TEntity?> GetByIdAsync(int Id, CancellationToken CancellationToken)
        {
            return await DBContext.Set<TEntity>().FirstOrDefaultAsync(Entidad => Entidad.Id == Id, CancellationToken);
        }
        public void Add(TEntity Entity)
        {
            DBContext.Add(Entity);
        }
    }
}
