using MarvelComicsStore.Domain.Interface;
using MarvelComicsStore.Infrastructure.ApiCaller.Interface;
using MarvelComicsStore.Infrastructure.ApiCaller.Repository;
using MarvelComicsStore.Infrastructure.Data.Context;
using MarvelComicsStore.Service.Interface;
using MarvelComicsStore.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarvelComicsStore.Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            string mySqlConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<MySqlContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddTransient<IApiCaller, ApiCaller.Api.ApiCaller>();
            services.AddTransient<IComicsRepository, ComicsRepository>();
            services.AddTransient<IComicsService, ComicsService>();
            return services;
        }
    }
}
