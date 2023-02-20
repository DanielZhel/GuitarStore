using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.EF.AuthDb.Context
{
    public class AuthDbContext : IdentityDbContext, IAuthDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=localhost;Database=AuthServer;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate = True");

        }
    }
}
