using System.Data.SqlClient;

namespace Finances.Business.Infra.Repositories
{
    public class BaseRepository
    {
        protected SqlConnection GetSqlConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
