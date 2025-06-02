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
        }
    }
}
