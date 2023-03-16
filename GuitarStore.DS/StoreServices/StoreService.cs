using GuitarStore.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using GuitarStore.EF.GuitarStoreDb.Context;

namespace GuitarStore.DS.StoreServices
{
    public class StoreService : IStoreService
    {
        private readonly IGuitarStoreDbContext _guitarStoreContext;
        public StoreService(IGuitarStoreDbContext guitarStoreContext)
        {
            _guitarStoreContext = guitarStoreContext;

        }
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            var allItems = await _guitarStoreContext.Items.ToListAsync();
            return allItems;
        }

       
    }
}
