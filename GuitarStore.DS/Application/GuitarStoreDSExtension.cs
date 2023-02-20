using GuitarStore.DS.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.DS.Application
{
    public static  class GuitarStoreDSExtension
    {
       
        public static void  Services(this IServiceCollection service)
        { 
            service.AddTransient<IStoreService, StoreService>();
            service.AddTransient<IShoppingCartService, ShoppingCartService>();

        }
    }       
}
