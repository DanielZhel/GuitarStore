using GuitarStore.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using GuitarStore.EF.GuitarStoreDb.Context;

namespace GuitarStore.DS.Services
{
    public class StoreService : IStoreService
    {
        private readonly IGuitarStoreDbContext _guitarStoreContext;
        public StoreService(IGuitarStoreDbContext context)
        {
            _guitarStoreContext = context;

        }


        public async Task<IEnumerable<Item>> GetAllItems()
        {
            var allItems = await _guitarStoreContext.Items.ToListAsync();
            return allItems;
        }

        
    }
}
