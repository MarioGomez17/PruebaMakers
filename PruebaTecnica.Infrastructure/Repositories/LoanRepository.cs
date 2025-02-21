using PruebaTecnica.Domain.Models;

namespace PruebaTecnica.Infrastructure.Repositories
{
    internal class LoanRepository : Repository<LoanModel>
    {
        public LoanRepository(ApplicationDBContext DBContext) : base(DBContext)
        {
        }
    }
}
