using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BrainWare.Data;

namespace BrainWare.Tests.LoggerTests
{
    public class TestLoggerDal
    {
        private readonly ConnectionManager _connectionManager;

        public TestLoggerDal(ConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public long GetLatestErrorLogId()
        {
            long errorId = 0;

            var sqlQuery = "SELECT TOP 1 ERROR_ID FROM ERROR_LOG ORDER BY ERROR_ID DESC";

            using (var conn = _connectionManager.GetBrainWareSqlConnection())
            {
                var command = new SqlCommand(sqlQuery, conn);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    errorId = long.Parse(reader["ERROR_ID"].ToString());
                }

            }

            return errorId;
        }
    }
}
