using GuitarStore.DS.Services;
using GuitarStore.EF;
using GuitarStore.Entities.Entities;
using GuitarStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Controllers
{
    [Authorize]
    public class CartController: Controller
    {
        private readonly IShoppingCartService _shopService;
        
        public CartController(IShoppingCartService shopService)
        {
            _shopService = shopService;
        }
        public async Task<IActionResult> CartView()
        {
            var sessionId = HttpContext.Session.GetString("SessionId");
            var items = await _shopService.GetShopCartItems(sessionId);
            return View(items);

        }

        public async Task<RedirectToActionResult> AddToCart(int itemId)
        {
            if (HttpContext.Session.GetString("SessionId") == null)
            {
                Guid sessionId = Guid.NewGuid();
                HttpContext.Session.SetString("SessionId", sessionId.ToString());
                await _shopService.AddToCart(sessionId.ToString(), itemId);
            }
            else
            {
                var cartId = HttpContext.Session.GetString("SessionId");
                await _shopService.AddToCart(cartId, itemId);
            }
            
            return RedirectToAction("CartView");
        }
        public async Task<RedirectToActionResult> RemoveFromCart(int shopCartItemId)
        {
            await _shopService.RemoveFromCart(shopCartItemId);
            return RedirectToAction("CartView");
        }
       

    }
}
