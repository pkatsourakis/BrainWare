using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrainWare.Logger;
using BrainWare.Models;

namespace BrainWare.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILog _logger;

        public OrdersService(IOrdersRepository ordersDal, ILog logger)
        {
            _ordersRepository = ordersDal;
            _logger = logger;
        }

        public OrdersService()
        {
            _ordersRepository = new OrdersRepository();
            _logger = new Log();
        }

        public List<CompanyOrder> GetEveryCompaniesOrders()
        {
            var companyOrders = new List<CompanyOrder>();

            try
            {
                companyOrders = _ordersRepository.GetCompanyOrders().ToList();

                foreach (var companyOrder in companyOrders)
                {
                    var orderProducts = _ordersRepository.GetOrderProducts(companyOrder.OrderId).ToList();

                    companyOrder.OrderProducts = orderProducts;
                }
            }
            catch (Exception e)
            {
                _logger.LogException(e);
            }

            return companyOrders;
        }

        public List<CompanyOrder> GetAllOrdersForCompany(long companyId)
        {
            var companyOrders = new List<CompanyOrder>();

            try
            {
                companyOrders = _ordersRepository.GetCompanyOrders(companyId).ToList();
                companyOrders = GetCompanyOrderProducts(companyOrders);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
            }

            return companyOrders;
        }

        public List<CompanyOrder> GetCompanyOrderProducts(List<CompanyOrder> companyOrders)
        {
            foreach (var companyOrder in companyOrders)
            {
                var orderProducts = _ordersRepository.GetOrderProducts(companyOrder.OrderId).ToList();

                companyOrder.OrderProducts = orderProducts;
            }

            return companyOrders;
        }
    }
}
