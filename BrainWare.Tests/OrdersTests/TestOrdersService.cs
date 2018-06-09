using BrainWare.Logger;
using BrainWare.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrainWare.Tests.OrdersTests
{
    [TestClass]
    public class TestOrders
    {
        private IOrdersService _ordersService;
        
        [TestInitialize]
        public void Initialize()
        {
            var ordersRepository = new OrdersRepository();
            var logger = new Log();
            _ordersService = new OrdersService(ordersRepository, logger);
        }

        // todo
    }
}
