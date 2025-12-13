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

            services.AddScoped<ICustomerReadReposoitory, CustomerReadReposoitory>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadReposoitory, OrderReadReposoitory>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadReposoitory>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
        }
    }
}
