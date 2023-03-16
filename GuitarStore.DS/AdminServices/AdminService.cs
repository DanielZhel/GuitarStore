using GuitarStore.EF.GuitarStoreDb.Context;
using GuitarStore.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.DS.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IGuitarStoreDbContext _guitarStoreDbContext;
        public AdminService(IGuitarStoreDbContext guitarStoreDbContext)
        {
            _guitarStoreDbContext = guitarStoreDbContext;
        }
        public async Task AddItem(Item item)
        {
            _guitarStoreDbContext.Items.Add(item);
            _guitarStoreDbContext.SaveChanges();
        }

        public async Task RemoveItem(int itemId)
        {
            var item = _guitarStoreDbContext.Items.Where(x => x.Id == itemId).Single();
            _guitarStoreDbContext.Items.Remove(item);
            _guitarStoreDbContext.SaveChanges();
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = _guitarStoreDbContext.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Item).ToList();
            return orders;
        }

        public async Task<List<Item>> GetStoreItems()
        {
            var items = _guitarStoreDbContext.Items.ToList();
            return items;
        }

        public async Task RemoveOrder(int orderId)
        {
            var orderItems = _guitarStoreDbContext.ShopCartItems.Where(x => x.OrderId == orderId).ToList();
            foreach(var orderItem in orderItems)
            {
                _guitarStoreDbContext.ShopCartItems.Remove(orderItem);
                _guitarStoreDbContext.SaveChanges();
            }

            var order = _guitarStoreDbContext.Orders.Where(x => x.OrderId == orderId).Single();
            _guitarStoreDbContext.Orders.Remove(order);
            _guitarStoreDbContext.SaveChanges();
        }
    }
}
