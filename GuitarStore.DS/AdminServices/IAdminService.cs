using GuitarStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.DS.AdminServices
{
    public interface IAdminService
    {
        public Task<List<Order>> GetOrders();
        public Task<List<Item>> GetStoreItems();
        public Task AddItem(Item item);
        public Task RemoveItem(int itemId);
        public Task RemoveOrder(int orderId);
        
    }
}
