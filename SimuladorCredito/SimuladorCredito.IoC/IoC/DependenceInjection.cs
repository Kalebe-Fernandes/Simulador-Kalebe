using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimuladorCredito.Application.Mappers;
using SimuladorCredito.Application.Services;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Context;
using SimuladorCredito.Infraestrututra.Repositories;
using SimuladorCredito.Infraestrututra.Repositories.Interfaces;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.IoC.IoC
{
    public static class DependenceInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                                                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPersonTypeRepository, PersonTypeRepository>();
            services.AddScoped<IModalityRepository, ModalityRepository>();
            services.AddScoped<ISegmentRepository, SegmentRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPersonTypeService, PersonTypeService>();
            services.AddScoped<IModalityService, ModalityService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISegmentService, SegmentService>();
            services.AddScoped<IRateService, RateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
