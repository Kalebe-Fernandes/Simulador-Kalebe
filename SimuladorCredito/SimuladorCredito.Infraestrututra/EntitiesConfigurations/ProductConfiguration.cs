using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimuladorCredito.Domain.Entities;

namespace SimuladorCredito.Infraestrututra.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(p => p.PersonType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.PersonTypeId);
        }
    }
}
