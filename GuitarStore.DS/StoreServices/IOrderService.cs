using GuitarStore.Entities.Entities;

namespace GuitarStore.DS.StoreServices
{
    public interface IOrderService
    {
        public Task CreateOrder(string address, string phoneNumber, string sessionId, string userLogin);
        public Task<List<Order>> GetOrders(string userLogin);
        public Task<List<ShopCartItem>> GetOrderItems(string sessionId);
    }
}

