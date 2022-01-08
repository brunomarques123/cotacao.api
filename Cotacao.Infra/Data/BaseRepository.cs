using System.Data;
using System.Data.SqlClient;

namespace Cotacao.Infra.Data
{
    public abstract class BaseRepository
    {
        private string ConnectionString { get; }

        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection Connection => Setup(ConnectionString);

        private SqlConnection Setup(string connectionString)
        {
            var conn = new SqlConnection(connectionString);

            if (conn.State != ConnectionState.Open)
                conn.Open();

            return conn;
        }
    }
}
