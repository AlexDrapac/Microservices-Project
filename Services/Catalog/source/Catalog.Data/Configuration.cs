using Catalog.Data.Interfaces;
using Catalog.Data.Persistance;
using Catalog.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Catalog.Data
{
    public static class Configuration
	{
        public static IServiceCollection AddDataConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Database
            services.AddDbContext<DataContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("CatalogDB"), b => b.MigrationsAssembly("Catalog.Api")));

            //Add Services
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IDataContext, DataContext>();


            return services;
        }
	}
}

