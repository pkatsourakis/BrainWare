using System;
using System.Data.SqlClient;

namespace BrainWare.Data
{
    public class ConnectionManager : IConnectionManager
    {
        public readonly string BrainwareSqlConnectionString;

        /// <summary>
        /// Sets data source to the default configured data source
        /// </summary>
        public ConnectionManager()
        {
            // todo: configurable 
            BrainwareSqlConnectionString = "Data Source = (LocalDb)\\ProjectsV13;Initial Catalog = BrainWare; Integrated Security = SSPI; AttachDBFilename=C:\\Users\\pk\\OneDrive\\Projects\\BrainWare\\BrainWare.Data\\App_Data\\BrainWare_Primary.mdf";
        }

        /// <summary>
        /// Sets data source based on the provided connection string
        /// </summary>
        /// <param name="brainwareSqlConnectionString"></param>
        public ConnectionManager(string brainwareSqlConnectionString)
        {
            BrainwareSqlConnectionString = brainwareSqlConnectionString;
        }

        public SqlConnection GetBrainWareSqlConnection()
        {
            try
            {
                var brainwareSqlConnection = new SqlConnection(BrainwareSqlConnectionString);

                if (brainwareSqlConnection.State != System.Data.ConnectionState.Open)
                {
                    brainwareSqlConnection.Open();
                }

                return brainwareSqlConnection;
            }
            catch (Exception e)
            {
                var e1 = new Exception("Error getting BrainWare sql connection", e);
                throw e1;
            }
        }
    }
}
