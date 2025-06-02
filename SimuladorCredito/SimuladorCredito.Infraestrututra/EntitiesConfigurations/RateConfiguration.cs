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

            builder.HasData(
                new Rate { Id = 1, Value = 10f, PersonTypeId = 1, ProductId = 3, SegmentId = 1, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 2, Value = 9f, PersonTypeId = 1, ProductId = 3, SegmentId = 2, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 3, Value = 8f, PersonTypeId = 1, ProductId = 3, SegmentId = 3, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 4, Value = 7f, PersonTypeId = 1, ProductId = 3, SegmentId = 4, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 5, Value = 0f, PersonTypeId = 1, ProductId = 8, SegmentId = 1, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 6, Value = 0f, PersonTypeId = 1, ProductId = 8, SegmentId = 2, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 7, Value = 0f, PersonTypeId = 1, ProductId = 8, SegmentId = 3, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 8, Value = 0f, PersonTypeId = 1, ProductId = 8, SegmentId = 4, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 9, Value = 9f, PersonTypeId = 1, ProductId = 2, SegmentId = 1, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 10, Value = 8f, PersonTypeId = 1, ProductId = 2, SegmentId = 2, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 11, Value = 7f, PersonTypeId = 1, ProductId = 2, SegmentId = 3, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 12, Value = 6f, PersonTypeId = 1, ProductId = 2, SegmentId = 4, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 13, Value = 20f, PersonTypeId = 1, ProductId = 4, SegmentId = 1, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 14, Value = 25f, PersonTypeId = 1, ProductId = 4, SegmentId = 2, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 15, Value = 30f, PersonTypeId = 1, ProductId = 4, SegmentId = 3, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 16, Value = 35f, PersonTypeId = 1, ProductId = 4, SegmentId = 4, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 17, Value = 6f, PersonTypeId = 1, ProductId = 3, SegmentId = 1, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 18, Value = 5f, PersonTypeId = 1, ProductId = 3, SegmentId = 2, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 19, Value = 4f, PersonTypeId = 1, ProductId = 3, SegmentId = 3, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 20, Value = 3f, PersonTypeId = 1, ProductId = 3, SegmentId = 4, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 21, Value = 5f, PersonTypeId = 1, ProductId = 8, SegmentId = 1, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 22, Value = 4f, PersonTypeId = 1, ProductId = 8, SegmentId = 2, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 23, Value = 3f, PersonTypeId = 1, ProductId = 8, SegmentId = 3, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 24, Value = 2f, PersonTypeId = 1, ProductId = 8, SegmentId = 4, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 25, Value = 5f, PersonTypeId = 1, ProductId = 2, SegmentId = 1, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 26, Value = 4f, PersonTypeId = 1, ProductId = 2, SegmentId = 3, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 27, Value = 3f, PersonTypeId = 1, ProductId = 2, SegmentId = 2, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 28, Value = 2f, PersonTypeId = 1, ProductId = 2, SegmentId = 4, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 29, Value = 40f, PersonTypeId = 1, ProductId = 4, SegmentId = 1, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 30, Value = 45f, PersonTypeId = 1, ProductId = 4, SegmentId = 2, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 31, Value = 50f, PersonTypeId = 1, ProductId = 4, SegmentId = 3, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 32, Value = 55f, PersonTypeId = 1, ProductId = 4, SegmentId = 4, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 33, Value = 10f, PersonTypeId = 2, ProductId = 6, SegmentId = 1, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 34, Value = 9f, PersonTypeId = 2, ProductId = 6, SegmentId = 2, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 35, Value = 8f, PersonTypeId = 2, ProductId = 6, SegmentId = 3, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 36, Value = 7f, PersonTypeId = 2, ProductId = 6, SegmentId = 4, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 37, Value = 5f, PersonTypeId = 2, ProductId = 1, SegmentId = 1, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 38, Value = 4f, PersonTypeId = 2, ProductId = 1, SegmentId = 2, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 39, Value = 3f, PersonTypeId = 2, ProductId = 1, SegmentId = 3, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 40, Value = 2f, PersonTypeId = 2, ProductId = 1, SegmentId = 4, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 41, Value = 9f, PersonTypeId = 2, ProductId = 5, SegmentId = 1, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 42, Value = 8f, PersonTypeId = 2, ProductId = 5, SegmentId = 2, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 43, Value = 7f, PersonTypeId = 2, ProductId = 5, SegmentId = 3, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 44, Value = 6f, PersonTypeId = 2, ProductId = 5, SegmentId = 4, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 45, Value = 20f, PersonTypeId = 2, ProductId = 7, SegmentId = 1, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 46, Value = 25f, PersonTypeId = 2, ProductId = 7, SegmentId = 2, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 47, Value = 30f, PersonTypeId = 2, ProductId = 7, SegmentId = 3, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 48, Value = 35f, PersonTypeId = 2, ProductId = 7, SegmentId = 4, ModalityId = 1, CreatedAt = DateTime.Now },
                new Rate { Id = 49, Value = 6f, PersonTypeId = 2, ProductId = 6, SegmentId = 1, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 50, Value = 5f, PersonTypeId = 2, ProductId = 6, SegmentId = 2, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 51, Value = 4f, PersonTypeId = 2, ProductId = 6, SegmentId = 3, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 52, Value = 3f, PersonTypeId = 2, ProductId = 6, SegmentId = 4, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 53, Value = 1f, PersonTypeId = 2, ProductId = 1, SegmentId = 1, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 54, Value = 0.5f, PersonTypeId = 2, ProductId = 1, SegmentId = 2, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 55, Value = 0.5f, PersonTypeId = 2, ProductId = 1, SegmentId = 3, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 56, Value = 0.3f, PersonTypeId = 2, ProductId = 1, SegmentId = 4, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 57, Value = 5f, PersonTypeId = 2, ProductId = 5, SegmentId = 1, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 58, Value = 4f, PersonTypeId = 2, ProductId = 5, SegmentId = 3, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 59, Value = 3f, PersonTypeId = 2, ProductId = 5, SegmentId = 2, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 60, Value = 2f, PersonTypeId = 2, ProductId = 5, SegmentId = 4, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 61, Value = 40f, PersonTypeId = 2, ProductId = 7, SegmentId = 1, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 62, Value = 45f, PersonTypeId = 2, ProductId = 7, SegmentId = 2, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 63, Value = 50f, PersonTypeId = 2, ProductId = 7, SegmentId = 3, ModalityId = 2, CreatedAt = DateTime.Now },
                new Rate { Id = 64, Value = 55f, PersonTypeId = 2, ProductId = 7, SegmentId = 4, ModalityId = 2, CreatedAt = DateTime.Now }
            );
        }
    }
}
