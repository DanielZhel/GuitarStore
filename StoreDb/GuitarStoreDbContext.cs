using Microsoft.EntityFrameworkCore;
using GuitarStore.Entities.Entities;
using System.Numerics;

namespace GuitarStore.EF
{
    public class GuitarStoreDbContext : DbContext
    {
        public GuitarStoreDbContext(DbContextOptions opts) : base(opts)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=GuitarStoreDataBase;Integrated Security = True; MultipleActiveResultSets =True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ShopCartItem> ShopCartItems { get; set; }

    }
}
