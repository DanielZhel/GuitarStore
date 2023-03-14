using GuitarStore.EF.AuthDb.Context;
using GuitarStore.EF.GuitarStoreDb.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuitarStore.EF.Application
{
    public static class GuitarStoreEFExtention
    {
        public static void GuitarStoreDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAuthDbContext, AuthDbContext>();
            services.AddDbContext<IGuitarStoreDbContext, GuitarStoreDbContext>();
            
        }
    }
}
