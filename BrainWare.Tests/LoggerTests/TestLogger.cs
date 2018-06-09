using System;
using BrainWare.Data;
using BrainWare.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrainWare.Tests.LoggerTests
{
    [TestClass]
    public class TestLogger
    {
        private ILog _logger;
        private TestLoggerDal testLoggerDal;

        private Exception _mockException;
        
        [TestInitialize]
        public void Initialize()
        {
            _logger = new Log();
            _mockException = new Exception("unit test");

            testLoggerDal = new TestLoggerDal(new ConnectionManager());
        }

        [TestMethod]
        public void TestLogException()
        {
            var lastErrorId = testLoggerDal.GetLatestErrorLogId();

            _logger.LogException(_mockException);

            var currentErrorId = testLoggerDal.GetLatestErrorLogId();

            Assert.IsTrue(currentErrorId > lastErrorId);
        }

        [TestMethod]
        public void TestLogWarning()
        {
            var lastErrorId = testLoggerDal.GetLatestErrorLogId();

            _logger.LogWarning(_mockException);

            var currentErrorId = testLoggerDal.GetLatestErrorLogId();

            Assert.IsTrue(currentErrorId > lastErrorId);
        }

        [TestMethod]
        public void TestLogMessage()
        {
            var lastErrorId = testLoggerDal.GetLatestErrorLogId();

            _logger.LogMessage("unit test");

            var currentErrorId = testLoggerDal.GetLatestErrorLogId();

            Assert.IsTrue(currentErrorId > lastErrorId);
        }
    }
}
