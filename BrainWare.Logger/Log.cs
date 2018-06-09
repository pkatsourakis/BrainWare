using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using BrainWare.Data;
using Dapper;

namespace BrainWare.Logger
{
    public class Log : ILog
    {
        private readonly IConnectionManager _connectionManager;

        public static string Exception = "EXCEPTION";
        public static string Warning = "WARNING";
        public static string Message = "MESSAGE";

        public Log(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public Log()
        {
            _connectionManager = new ConnectionManager();
        }

        public void LogException(Exception e)
        {
            try
            {
                InsertLog(e, Exception);

                while (e.InnerException != null)
                {
                    InsertLog(e, Exception);

                    e = e.InnerException;
                }
            }
            catch (Exception exception)
            {
                LogToFile(e, Exception);
                LogToFile(exception, Exception);
            }
        }

        public void LogWarning(Exception e)
        {
            try
            {
                InsertLog(e, Warning);

                while (e.InnerException != null)
                {
                    InsertLog(e, Warning);

                    e = e.InnerException;
                }
            }
            catch (Exception exception)
            {
                LogToFile(e, Warning);
                LogToFile(exception, Exception);
            }
        }

        public void LogMessage(string message)
        {
            try
            {
                var ex = new Exception(message);
                InsertLog(ex, Message);
            }
            catch (Exception e)
            {
                LogToFile(e, Exception);
            }
        }

        private void InsertLog(Exception e, string errorLevel)
        {
            using (var conn = _connectionManager.GetBrainWareSqlConnection())
            {
                var sqlParameters = 
                    new {message = e.Message, stacktrace = e.StackTrace, source = e.Source, errorLevel};

                conn.Execute("ERROR_ADD", sqlParameters, commandType: CommandType.StoredProcedure);
            }
        }

        private void LogToFile(Exception e, string errorLevel)
        {
            try
            {
                var sw = new StreamWriter("C:\\BrainWareLogger.txt");

                sw.WriteLine($"Error Message: { e.Message }");
                sw.WriteLine($"Stack Trace: { e.StackTrace }");
                sw.WriteLine($"Source: { e.Source }");
                sw.WriteLine($"Date: { DateTime.Now }");
                sw.WriteLine($"Error Level: { errorLevel }");

                sw.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
