using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.Interface;
using MarvelComicsStore.Infrastructure.ApiCaller.Interface;
using MarvelComicsStore.Infrastructure.ApiCaller.Repository;
using MarvelComicsStore.Infrastructure.Data.Context;
using MarvelComicsStore.Infrastructure.Data.Repository;
using MarvelComicsStore.Service.Interface;
using MarvelComicsStore.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using apiCaller = MarvelComicsStore.Infrastructure.ApiCaller.Api;

namespace MarvelComicsStore.Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            string mySqlConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<MySqlContext>(options 
                => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddTransient<IApiCaller, apiCaller.ApiCaller>();
            services.AddTransient<IBaseRepository<Checkout>, BaseRepository<Checkout>>();
            services.AddTransient<IBaseRepository<PurchasedItem>, BaseRepository<PurchasedItem>>();

            services.AddTransient<IComicsRepository, ComicsRepository>();
            services.AddTransient<IComicsService, ComicsService>();

            services.AddTransient<ICheckoutRepository, CheckoutRepository>();
            services.AddTransient<ICheckoutService, CheckoutService>();

            services.AddTransient<IPurchasedItemRepository, PurchasedItemRepository>();
            return services;
        }
    }
}
