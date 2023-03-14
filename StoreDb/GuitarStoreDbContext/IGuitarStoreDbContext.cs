using GuitarStore.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.EF.GuitarStoreDb.Context
{
    public interface IGuitarStoreDbContext
    {
        public  DbSet<Item> Items { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public int SaveChanges();

        


    }
}
