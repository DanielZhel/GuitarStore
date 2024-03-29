﻿using GuitarStore.DS.AdminServices;
using GuitarStore.DS.StoreServices;
using Microsoft.Extensions.DependencyInjection;

namespace GuitarStore.DS.Application
{
    public static class GuitarStoreDSExtension
    {
        public static void  GuitarStoreDSServices(this IServiceCollection services)
        { 
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IShoppingCartService, ShoppingCartItemService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IAdminService, AdminService>();
        }
    }       
}
