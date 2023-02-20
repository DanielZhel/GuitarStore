using GuitarStore.EF.AuthDb.Context;
using GuitarStore.EF.GuitarStoreDb.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.EF.Application
{
    public class GuitarStoreEFExtention
    {
        public static void Services(IServiceCollection services)
        {
            services.AddTransient<IGuitarStoreDbContext,GuitarStoreDbContext>();
            services.AddTransient<IAuthDbContext, AuthDbContext>();
            services.AddDbContext<AuthDbContext>();
            services.AddDbContext<GuitarStoreDbContext>();
            
        }
    }
}
