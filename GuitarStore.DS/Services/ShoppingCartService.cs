using GuitarStore.EF.GuitarStoreDb.Context;
using GuitarStore.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GuitarStore.DS.Services
{
    public class ShoppingCartItemService: IShoppingCartService
    {

        private IGuitarStoreDbContext _guitarStoreDbContext;
        public ShoppingCartItemService(IGuitarStoreDbContext context)
        {
            _guitarStoreDbContext = context;
        }
        public async Task AddToCart(string sessionId, int itemId)
        {
            var item = _guitarStoreDbContext.Items.Where(i => i.Id == itemId).Single();
            
            if (item != null)
            {
                var shopCartItem = new ShopCartItem
                {
                    SessionId = sessionId,
                    Item = item
                };
                _guitarStoreDbContext.ShopCartItems.Add(shopCartItem);
                _guitarStoreDbContext.SaveChanges();

            }
           
        }
        public async Task<List<ShopCartItem>> GetShopCartItems(string sessionId)
        {
            var shopCartItems = _guitarStoreDbContext.ShopCartItems.Where(x => x.SessionId == sessionId && x.OrderId == 0).Include(x => x.Item).ToList();
            return shopCartItems;
        }


        public async Task RemoveFromCart (int shopCartItemId)
        {
            var item = _guitarStoreDbContext.ShopCartItems.Where(i => i.Id == shopCartItemId).Single();

            _guitarStoreDbContext.ShopCartItems.Remove(item);
            _guitarStoreDbContext.SaveChanges();
        }
    }
}
    

