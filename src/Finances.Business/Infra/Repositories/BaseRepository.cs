using System.Data;
using System.Data.SqlClient;

namespace Finances.Business.Infra.Repositories
{
    public class BaseRepository
    {
        protected IDbConnection _connectionDB;

        public BaseRepository(string connectionString)
        {
            _connectionDB = new SqlConnection(connectionString);
        }
    }
}
