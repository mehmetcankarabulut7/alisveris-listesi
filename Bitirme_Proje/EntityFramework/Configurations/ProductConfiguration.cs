
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitirme_Proje.EntityFramework.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired(true);

            builder.HasMany(p => p.ListProducts)
                .WithOne(lp => lp.Product)
                .HasForeignKey(lp => lp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
