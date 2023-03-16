using GuitarStore.EF.GuitarStoreDb.Context;
using GuitarStore.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.DS.StoreServices
{
    public class OrderService : IOrderService
    {
        private readonly IGuitarStoreDbContext _guitarStoreDbContext;
        public OrderService(IGuitarStoreDbContext guitarStoreDbContext)
        {
            _guitarStoreDbContext = guitarStoreDbContext;
        }

        public async Task CreateOrder(string address, string phoneNumber, string sessionId, string userLogin)
        {
            var order = new Order();
            order.Address = address;
            order.PhoneNumber = phoneNumber;
            order.UserLogin = userLogin;
            
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
            var orderItemList = _guitarStoreDbContext.ShopCartItems.Where(x => x.SessionId == sessionId && x.OrderId == 0).Include(x => x.Item).ToList();
            return orderItemList;
        }

        public async Task<List<Order>> GetOrders(string userLogin)
        {
            var orders = _guitarStoreDbContext.Orders.Where(x => x.UserLogin == userLogin).Include(x => x.OrderItems).ThenInclude(x => x.Item).ToList();
           
            return orders;
        }

    }
}
