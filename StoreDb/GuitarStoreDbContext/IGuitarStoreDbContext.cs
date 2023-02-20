using GuitarStore.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.EF.GuitarStoreDb.Context
{
    public interface IGuitarStoreDbContext: IDisposable
    {
        public  DbSet<Item> Items { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public int SaveChanges();


    }
}
