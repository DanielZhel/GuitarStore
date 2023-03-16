using GuitarStore.EF;
using GuitarStore.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.DS.StoreServices
{
    public interface IShoppingCartService
    {
        public Task AddToCart(string shopCartId, int itemId);
        public Task RemoveFromCart( int itemId);
        public Task<List<ShopCartItem>> GetShopCartItems(string id);
    }
 }
