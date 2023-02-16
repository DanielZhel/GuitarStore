using GuitarStore.Entities.Entities;
using GuitarStore.EF;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.DS.Services
{
    public class StoreService : IStoreService
    {
        private readonly GuitarStoreDbContext _guitarStoreContext;
        public StoreService(GuitarStoreDbContext context)
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
