using GuitarStore.EF.GuitarStoreDb.Context;
using GuitarStore.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.DS.Services
{
    public class ShoppingCartService: IShoppingCartService
    {

        private IGuitarStoreDbContext _context;
        public ShoppingCartService(IGuitarStoreDbContext context)
        {
            _context = context;
        }
        public async Task AddToCart(string shopCartId, int itemId)
        {
            var item = _context.Items.Where(i => i.Id == itemId).Single();
            if (item != null)
            {
                var shopCartItem = new ShopCartItem
                { 
                    ShopCartId = shopCartId,
                    Image = item.Image,
                    ModelName = item.ModelName,
                    Descripton = item.Descripton,
                    Manufacturer =item.Manufacturer,
                    Price = item.Price,
                    ItemId = item.Id
                };
                _context.ShopCartItems.Add(shopCartItem);
                
            }
            _context.SaveChanges();
        }
        public async Task<List<ShopCartItem>> GetShopCartItems(string id)
        {
            
            var shopCartItemList = _context.ShopCartItems.Where(c => c.ShopCartId == id).ToList();
            
            return shopCartItemList;
        }

        public async Task RemoveFromCart (int shopCartItemId)
        {
            var item = _context.ShopCartItems.Where(i => i.Id == shopCartItemId).Single();

            _context.ShopCartItems.Remove(item);
            _context.SaveChanges();
        }
    }
}
    

