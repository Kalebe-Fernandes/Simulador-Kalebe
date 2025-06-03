using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Application.Mappers;
using SimuladorCredito.Application.Services;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Infraestrututra.Context;
using SimuladorCredito.Infraestrututra.Repositories.UnitOfWork;

namespace SimuladorCredito.Testes.UnitTestsController
{
    public class UnitTestController
    {
        public IUnitOfWork repository;
        public IMapper mapper;

        public IPersonTypeService personTypeService;
        public IModalityService modalityService;
        public IProductService productService;
        public ISegmentService segmentService;
        public IRateService rateService;

        public static DbContextOptions<ApplicationDbContext> DbContextOptions { get; }
        public static string connectionString =
          "Server=KALEBE\\SQLEXPRESS;Database=SimuladorCredito;Trusted_Connection=True;TrustServerCertificate=True;";

        static UnitTestController()
        {
            DbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseSqlServer(connectionString, 
               ob => ob.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
               .Options;
        }

        public UnitTestController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDTOMappingProfile());
            });

            mapper = config.CreateMapper();

            var context = new ApplicationDbContext(DbContextOptions);
            repository = new UnitOfWork(context);

            personTypeService = new PersonTypeService(repository, mapper);
            modalityService = new ModalityService(repository, mapper);
            productService = new ProductService(repository, mapper);
            segmentService = new SegmentService(repository, mapper);
            rateService = new RateService(repository, mapper);
        }
    }
}
