using System.Data;

namespace PruebaTecnica.Infrastructure.Data
{
    public interface ISQLConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
