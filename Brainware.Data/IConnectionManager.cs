using System.Data.SqlClient;

namespace BrainWare.Data
{
    public interface IConnectionManager
    {
        SqlConnection GetBrainWareSqlConnection();
    }
}
