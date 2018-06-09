using System;
using System.Diagnostics;
using BrainWare.Logger;
using Microsoft.AspNetCore.Mvc;
using BrainWare.Models;
using BrainWare.Orders;

namespace BrainWare.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly ILog _logger;

        public HomeController(IOrdersService ordersService, ILog logger)
        {
            _ordersService = ordersService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                return View(_ordersService.GetEveryCompaniesOrders());
            }
            catch (Exception e)
            {
                _logger.LogException(e);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
