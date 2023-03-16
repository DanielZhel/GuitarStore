using GuitarStore.Entities.Entities;

namespace GuitarStore.DS.StoreServices
{
    public interface IStoreService
    {
        public Task<IEnumerable<Item>> GetAllItems();

    }
}

