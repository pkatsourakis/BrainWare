using System;
using System.Collections.Generic;
using System.Text;
using BrainWare.Models;
namespace BrainWare.Orders
{
    public interface IOrdersService
    {
        List<CompanyOrder> GetEveryCompaniesOrders();

        List<CompanyOrder> GetAllOrdersForCompany(long companyId);

    }
}
