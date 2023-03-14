using GuitarStore.DS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Net;

namespace GuitarStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> OrderView()
        {
            var sessionId = HttpContext.Session.GetString("SessionId");
            var orders = await _orderService.GetOrders(sessionId);
            return View("OrderView",orders);
        }
        
        public async Task<RedirectToActionResult> CreateOrder(string address, string phoneNumber)
        {
            var sessionId = HttpContext.Session.GetString("SessionId");
            await _orderService.CreateOrder(address, phoneNumber, sessionId);
            
            return RedirectToAction("OrderView");
        } 
        public async Task<IActionResult> OrderCreateView()
        {
            var sessionId = HttpContext.Session.GetString("SessionId");
            var orderItems = await _orderService.GetOrderItems(sessionId);
            return View("OrderCreateView", orderItems);
        }
    }
}
