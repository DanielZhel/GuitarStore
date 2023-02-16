using GuitarStore.EF;
using GuitarStore.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.DS.Services
{
    public class ShoppingCartService
    {

        private GuitarStoreDbContext _context;
        public ShoppingCartService(GuitarStoreDbContext context)
        {
            _context = context;
        }

        public string ShopCartId { get; set; }
        public List <ShopCartItem> CartItemsList { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<GuitarStoreDbContext>();
            string shopCartId = /*session.GetString("CartId") ??*/ Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);
            return new ShopCart() { ShopCartId = shopCartId };
        }

        public void AddToCart(Item item)
        {
            _context.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Item = item
            });

            _context.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return _context.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Item).ToList();
        }
    }
}
    

