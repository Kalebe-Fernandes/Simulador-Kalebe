using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimuladorCredito.Infraestrututra.Context;

namespace SimuladorCredito.IoC.IoC
{
    public static class DependenceInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                                                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Register other services, repositories, etc.
            // services.AddScoped<IProductRepository, ProductRepository>();
            // services.AddScoped<IProductService, ProductService>();
        }
    }
}
