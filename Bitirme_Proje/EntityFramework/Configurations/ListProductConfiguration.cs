
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitirme_Proje.EntityFramework.Configurations
{
    public class ListProductConfiguration : IEntityTypeConfiguration<ListProduct>
    {
        public void Configure(EntityTypeBuilder<ListProduct> builder)
        {
            builder.HasKey("ProductId", "ShoppingListId");

            builder.Property(lp => lp.Description)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired(false);
        }
    }
}
