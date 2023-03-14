using GuitarStore.EF.GuitarStoreDb.Context;
using GuitarStore.Entities.Entities;
using GuitarStore.Models.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace GuitarStore.DS.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGuitarStoreDbContext _guitarStoreDbContext;
        public OrderService(IGuitarStoreDbContext guitarStoreDbContext)
        {
            _guitarStoreDbContext = guitarStoreDbContext;
        }

        public async Task CreateOrder(string address, string phoneNumber, string sessionId)
        {
            var order = new Order();
            order.Address = address;
            order.PhoneNumber = phoneNumber;
            order.SessionId = sessionId;
            
            foreach (var orderItem in _guitarStoreDbContext.ShopCartItems.Where(x => x.SessionId == sessionId && x.OrderId == 0).Include(x => x.Item))
            {
                order.OrderItems.Add(orderItem);
                order.Price += orderItem.Item.Price;
            }
            _guitarStoreDbContext.Orders.Add(order);
            _guitarStoreDbContext.SaveChanges();

        }
        public async Task<List<ShopCartItem>> GetOrderItems(string sessionId)
        {
            List<ShopCartItem> orderItems = new List<ShopCartItem>();
            foreach (var item in _guitarStoreDbContext.ShopCartItems.Where(x => x.SessionId == sessionId && x.OrderId == 0).Include(x => x.Item).ToList())
            {
                orderItems.Add(item);
            }
            
            return orderItems;
        }

        public async Task<List<Order>> GetOrders(string sessionId)
        {
            var orders = _guitarStoreDbContext.Orders.Where(x => x.SessionId == sessionId).Include(x => x.OrderItems).ThenInclude(x => x.Item).ToList();
           
            return orders;
        }

        
    }
}
