using GuitarStore.Entities.Entities;

namespace GuitarStore.DS.Services
{
    public interface IStoreService
    {
        public Task<IEnumerable<Item>> GetAllItems();

    }
}

