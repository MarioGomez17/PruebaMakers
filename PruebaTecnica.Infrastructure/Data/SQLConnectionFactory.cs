using Npgsql;
using System.Data;

namespace PruebaTecnica.Infrastructure.Data
{
    public class SQLConnectionFactory : ISQLConnectionFactory
    {
        private readonly string ConnectionString;
        public SQLConnectionFactory(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }
        public IDbConnection CreateConnection()
        {
            NpgsqlConnection Connection = new(ConnectionString);
            Connection.Open();
            return Connection;
        }
    }
}
