using GuitarStore.Entities.Entities;
using GuitarStore.Models.Mapping;

namespace GuitarStore.DS.Services
{
    public interface IOrderService
    {
        public Task CreateOrder(string address, string phoneNumber, string sessionId);
        public Task<List<Order>> GetOrders(string sessionId);
        public Task<List<ShopCartItem>> GetOrderItems(string sessionId);
    }
}

