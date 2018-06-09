using System.Collections.Generic;
using BrainWare.Models;

namespace BrainWare.Orders
{
    public interface IOrdersRepository
    {
        IEnumerable<CompanyOrder> GetCompanyOrders();
        IEnumerable<CompanyOrder> GetCompanyOrders(long companyId);

        IEnumerable<OrderProduct> GetOrderProducts();
        IEnumerable<OrderProduct> GetOrderProducts(long orderId);
    }
}
