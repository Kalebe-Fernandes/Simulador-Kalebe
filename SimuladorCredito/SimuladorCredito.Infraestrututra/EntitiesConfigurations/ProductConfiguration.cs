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

            builder.HasData(
                new Product { Id = 1, Name = "Crédito Rural", PersonTypeId = 2, CreatedAt = DateTime.Now },
                new Product { Id = 2, Name = "Empréstimo Pessoal", PersonTypeId = 1, CreatedAt = DateTime.Now },
                new Product { Id = 3, Name = "Financiamento", PersonTypeId = 1, CreatedAt = DateTime.Now },
                new Product { Id = 4, Name = "Imóveis", PersonTypeId = 1, CreatedAt = DateTime.Now },
                new Product { Id = 5, Name = "Empréstimo Pessoal", PersonTypeId = 2, CreatedAt = DateTime.Now },
                new Product { Id = 6, Name = "Financiamento", PersonTypeId = 2, CreatedAt = DateTime.Now },
                new Product { Id = 7, Name = "Imóveis", PersonTypeId = 2, CreatedAt = DateTime.Now },
                new Product { Id = 8, Name = "Sicoob Engecred Consignado", PersonTypeId = 1, CreatedAt = DateTime.Now }
            );
        }
    }
}
