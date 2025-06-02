using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infraestrututra.EntitiesConfigurations
{
    public class PersonTypeConfiguration : IEntityTypeConfiguration<PersonType>
    {
        public void Configure(EntityTypeBuilder<PersonType> builder)
        {
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new PersonType { Id = 1, Name = "Pessoa Física", CreatedAt = new DateTime(2025, 06, 02) },
                new PersonType { Id = 2, Name = "Pessoa Jurídica", CreatedAt = new DateTime(2025, 06, 02) }
            );
        }
    }
}
