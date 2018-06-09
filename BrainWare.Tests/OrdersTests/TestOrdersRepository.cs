using System.Linq;
using BrainWare.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrainWare.Tests.OrdersTests
{
    [TestClass]
    public class TestOrdersRepository
    {
        private IOrdersRepository _ordersRepository;
        
        [TestInitialize]
        public void Initialize()
        {
            _ordersRepository = new OrdersRepository();
        }

        [TestMethod]
        public void TestCompaniesOrders()
        {
            var companyOrders = _ordersRepository.GetCompanyOrders().ToList();

            Assert.IsTrue(companyOrders.Count >= 3);
            Assert.IsFalse(companyOrders.Any(o => string.IsNullOrWhiteSpace(o.Company.CompanyName)));
        }

        [TestMethod]
        public void TestSpecificCompanyOrderNegative()
        {
            var companyOrders = _ordersRepository.GetCompanyOrders(-1);

            Assert.IsFalse(companyOrders.Any());
        }

        [TestMethod]
        public void TestSpecificCompanyOrder()
        {
            var companyOrders = _ordersRepository.GetCompanyOrders(1).ToList();

            Assert.IsTrue(companyOrders.Any());
            Assert.IsTrue(companyOrders.Count >= 3);
        }

        [TestMethod]
        public void TestOrderProducts()
        {
            var productOrders = _ordersRepository.GetOrderProducts();
        }
    }
}
