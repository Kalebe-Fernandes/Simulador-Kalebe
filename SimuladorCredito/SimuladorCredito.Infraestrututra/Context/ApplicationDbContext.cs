using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infraestrututra.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
