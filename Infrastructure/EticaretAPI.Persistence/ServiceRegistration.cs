using EticaretAPI.Application.Repositories;
using EticaretAPI.Persistence.Contexts;
using EticaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EticaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options =>
                options.UseNpgsql(Configuration.ConnectionString),ServiceLifetime.Singleton);

            services.AddSingleton<ICustomerReadReposoitory, CustomerReadReposoitory>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderReadReposoitory, OrderReadReposoitory>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadReposoitory>();
            services.AddSingleton<IProductWriteRepository,ProductWriteRepository>();


        }
    }
}
