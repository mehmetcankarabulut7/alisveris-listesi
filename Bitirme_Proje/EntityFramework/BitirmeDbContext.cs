
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bitirme_Proje.EntityFramework
{
    public class BitirmeDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ListProduct> ListProducts { get; set; }

        public BitirmeDbContext()
        {

        }

        public BitirmeDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-STMQID3;Database=BitirmeDatabase;Trusted_Connection=True");
            }   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
