using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BrainWare.Models;
using Dapper;

namespace BrainWare.Orders
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly Func<SqlConnection> _sqlConnectionFactory;

        public OrdersRepository(Func<SqlConnection> sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public OrdersRepository()
        {
            var connectionManager = new BrainWare.Data.ConnectionManager();
            _sqlConnectionFactory = () => connectionManager.GetBrainWareSqlConnection();
        }

        public IEnumerable<CompanyOrder> GetCompanyOrders()
        {
            return GetCompanyOrders(null);
        }

        public IEnumerable<CompanyOrder> GetCompanyOrders(long companyId)
        {
            var queryParameters = new {companyId};

            return GetCompanyOrders(queryParameters);
        }

        private IEnumerable<CompanyOrder> GetCompanyOrders(object queryParameters)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            IEnumerable<CompanyOrder> companyOrders;

            using (var conn = _sqlConnectionFactory())
            {
                companyOrders = conn.Query<CompanyOrder, Company, CompanyOrder>("COMPANY_ORDERS_GET",
                    (order, company) =>
                    {
                        order.Company = company;
                        return order;
                    }, queryParameters,
                    splitOn: "COMPANY_ID",
                    commandType: CommandType.StoredProcedure);
            }

            return companyOrders;
        }

        public IEnumerable<OrderProduct> GetOrderProducts()
        {
            return GetOrderProducts(null);
        }

        public IEnumerable<OrderProduct> GetOrderProducts(long orderId)
        {
            var queryParameters = new {orderId};

            return GetOrderProducts(queryParameters);
        }

        private IEnumerable<OrderProduct> GetOrderProducts(object queryParameters)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            IEnumerable<OrderProduct> orderProducts;

            using (var conn = _sqlConnectionFactory())
            {
                orderProducts = conn.Query<OrderProduct, Product, OrderProduct>("ORDER_PRODUCTS_GET",
                    (order, product) =>
                    {
                        order.Product = product;
                        return order;
                    }, queryParameters,
                    splitOn: "PRODUCT_ID",
                    commandType: CommandType.StoredProcedure);
            }

            return orderProducts;
        }
    }
}
