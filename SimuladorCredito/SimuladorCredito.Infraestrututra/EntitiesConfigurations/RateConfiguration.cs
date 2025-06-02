using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infraestrututra.EntitiesConfigurations
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.PersonType)
                .WithMany(m => m.Rates)
                .HasForeignKey(p => p.PersonTypeId);
            builder.HasOne(p => p.Modality)
                .WithMany(m => m.Rates)
                .HasForeignKey(p => p.ModalityId);
            builder.HasOne(p => p.Product)
                .WithMany(m => m.Rates)
                .HasForeignKey(p => p.Product);
            builder.HasOne(p => p.Segment)
                .WithMany(m => m.Rates)
                .HasForeignKey(p => p.SegmentId);
        }
    }
}
