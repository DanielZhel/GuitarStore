using GuitarStore.DS.Services;
using GuitarStore.EF;
using GuitarStore.Entities.Entities;
using GuitarStore.Models;
using GuitarStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Controllers
{
    public class CartController: Controller
    {
        private readonly GuitarStoreDbContext _dbContext;
        private readonly ShoppingCartService _shopService;
        
        public CartController(ShoppingCartService shopService, GuitarStoreDbContext guitarStoreDbContext)
        {
            _shopService = shopService;
            _dbContext = guitarStoreDbContext;
        }

        public IActionResult CartView()
        {
            var items = _shopService.getShopItems();
            _shopService.CartItemsList = items;


            return View(items);

        }

        public RedirectToActionResult AddToCart(int itemId)
        {
            var item = _dbContext.Items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                _shopService.AddToCart(item);
            }
            return RedirectToAction("CartView");
        }


    }
}
