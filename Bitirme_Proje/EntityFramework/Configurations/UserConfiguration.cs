
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitirme_Proje.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired(true);

            builder.Property(u => u.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired(true);

            builder.Property(u => u.Mail)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(u => u.Password)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired(true);

            builder.HasMany(u => u.ShoppingLists)
                .WithOne(sl => sl.User)
                .HasForeignKey(sl => sl.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
