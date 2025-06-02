using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infraestrututra.EntitiesConfigurations
{
    public class SegmentConfiguration : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.MinimumIncome)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.HasOne(p => p.PersonType)
                .WithMany(m => m.Segments)
                .HasForeignKey(p => p.PersonTypeId);

            builder.HasData(
                new Segment { Id = 1, Name = "PF1", PersonTypeId = 1, MinimumIncome = 0m, CreatedAt = DateTime.Now },
                new Segment { Id = 2, Name = "PF2", PersonTypeId = 1, MinimumIncome = 2000m, CreatedAt = DateTime.Now },
                new Segment { Id = 3, Name = "PF3", PersonTypeId = 1, MinimumIncome = 20000m, CreatedAt = DateTime.Now },
                new Segment { Id = 4, Name = "PF4", PersonTypeId = 1, MinimumIncome = 200000m, CreatedAt = DateTime.Now },
                new Segment { Id = 5, Name = "PJ1", PersonTypeId = 2, MinimumIncome = 0m, CreatedAt = DateTime.Now },
                new Segment { Id = 6, Name = "PJ2", PersonTypeId = 2, MinimumIncome = 4000m, CreatedAt = DateTime.Now },
                new Segment { Id = 7, Name = "PJ3", PersonTypeId = 2, MinimumIncome = 400000m, CreatedAt = DateTime.Now },
                new Segment { Id = 8, Name = "PJ4", PersonTypeId = 2, MinimumIncome = 40000000m, CreatedAt = DateTime.Now }
            );
        }
    }
}
