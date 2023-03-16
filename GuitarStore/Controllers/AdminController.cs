using GuitarStore.DS.AdminServices;
using GuitarStore.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> AdminView()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OrdersView()
        {
            var orders = await _adminService.GetOrders();
            return View(orders);
        }
        public async Task<IActionResult> AdminItemsView()
        {
            var items = await _adminService.GetStoreItems();
            return View("AdminItemsView", items);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> AddItem(Item item)
        {
            await _adminService.AddItem(item);
            return RedirectToAction("AdminItemsView");
        }

        [HttpGet]
        public async Task<IActionResult> AddItemView()
        {
            return View();
        }
        public async Task<RedirectToActionResult> RemoveItem(int itemId)
        {
            await _adminService.RemoveItem(itemId);
            return RedirectToAction("AdminItemsView");
        }
        public async Task<RedirectToActionResult> RemoveOrder(int orderId)
        {
            await _adminService.RemoveOrder(orderId);
            return RedirectToAction("OrdersView");
        }

    }
}
