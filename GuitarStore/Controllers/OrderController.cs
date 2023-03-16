using GuitarStore.DS.StoreServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers
{
    [Authorize]
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
            var userLogin  = HttpContext.User.Identity.Name;
            var orders = await _orderService.GetOrders(userLogin);
            return View("OrderView",orders);
        }
        
        public async Task<RedirectToActionResult> CreateOrder(string address, string phoneNumber)
        {
            var userLogin = HttpContext.User.Identity.Name;
            var sessionId = HttpContext.Session.GetString("SessionId");
            await _orderService.CreateOrder(address, phoneNumber, sessionId, userLogin);
            
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
