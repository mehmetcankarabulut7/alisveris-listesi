
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitirme_Proje.EntityFramework.Configurations
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasKey(sl => sl.Id);

            builder.Property(sl => sl.Name)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired(true);

            builder.Property(sl => sl.OnShopping)
                .IsRequired(true);

            builder.HasMany(sl => sl.ListProducts)
                .WithOne(lp => lp.ShoppingList)
                .HasForeignKey(lp => lp.ShoppingListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
