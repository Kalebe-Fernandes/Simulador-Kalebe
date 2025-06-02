using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infraestrututra.EntitiesConfigurations
{
    public class ModalityConfiguration : IEntityTypeConfiguration<Modality>
    {
        public void Configure(EntityTypeBuilder<Modality> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new Modality { Id = 1, Name = "Pré-Fixado", CreatedAt = new DateTime(2025, 06, 02) },
                new Modality { Id = 2, Name = "Pós-Fixado", CreatedAt = new DateTime(2025, 06, 02) }
            );
        }
    }
}
