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
            var cartId = HttpContext.Session.GetString("CartId");
            var items = await _shopService.GetShopCartItems(cartId);

            return View(items);

        }

        public async Task<RedirectToActionResult> AddToCart(int itemId)
        {
            
            if (HttpContext.Session.GetString("CartId") == null)
            {
                Guid newCartId = Guid.NewGuid();
                HttpContext.Session.SetString("CartId", newCartId.ToString());
                await _shopService.AddToCart(newCartId.ToString(), itemId);
                
            }
            else
            {
                var cartId = HttpContext.Session.GetString("CartId");
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
