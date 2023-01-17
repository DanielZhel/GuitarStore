using Microsoft.EntityFrameworkCore;
using StoreDb.StoreDbContext.Entities.Item;
using StoreDb.StoreDbContext.Entities.User;
using System.Numerics;

namespace StoreDb.StoreDbContext
{
    public class GuitarStoreDbContext : DbContext
    {
        public GuitarStoreDbContext(DbContextOptions opts) : base(opts)
        {
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=GuitarStoreDb;Integrated Security = True; MultipleActiveResultSets =True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Item>().HasKey(k => k.Id);
            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items");
                entity.Property(p => p.Id).ValueGeneratedNever();
                entity.Property(p => p.Price).IsRequired();
                entity.Property(p => p.Type).IsRequired();
                entity.Property(p => p.Manufacturer).IsRequired();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(p => p.Id).ValueGeneratedNever();
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.DateOfBirth).IsRequired();
                entity.Property(p => p.Login).IsRequired();
                entity.Property(p => p.Password).IsRequired().HasMaxLength(20);
            });

        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<User> Users { get; set; }
        
    }
}
