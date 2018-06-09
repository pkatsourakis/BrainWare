using BrainWare.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrainWare.Tests.DataAccessTests
{
    [TestClass]
    public class TestConnections
    {
        [TestMethod]
        public void TestDefaultConnection()
        {
            var connectionManager = new ConnectionManager();

            var conn = connectionManager.GetBrainWareSqlConnection();

            Assert.AreEqual(System.Data.ConnectionState.Open, conn.State);

            // BrainWAre will break the test now!
            Assert.AreEqual("BrainWare", conn.Database);
        }
    }
}
