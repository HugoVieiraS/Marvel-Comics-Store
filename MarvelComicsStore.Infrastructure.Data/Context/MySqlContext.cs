using MarvelComicsStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarvelComicsStore.Infrastructure.Data.Context
{
    public class MySqlContext : DbContext
    {
        #region Properties
        public DbSet<Checkout> Checkout { get; set; }
        public DbSet<PurchasedItem> PurchasedItem { get; set; }
        #endregion

        #region Constructor
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Checkout>()
               .Property(x => x.TotalPrice)
               .HasPrecision(10, 2);

            modelBuilder.Entity<PurchasedItem>()
               .Property(x => x.Id)
               .HasMaxLength(80);

            modelBuilder.Entity<PurchasedItem>()
                .Property(x => x.Title)
                .HasMaxLength(80);

            modelBuilder.Entity<PurchasedItem>()
                .Property(x => x.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Checkout>()
                .HasData(
                new Checkout { Id = 1, Coupon = "R00002", TotalPrice = 4.25m });

            modelBuilder.Entity<PurchasedItem>()
               .HasData(
               new PurchasedItem { Id = 1, Title = "Teste", Price = 4.25m, Unity = 1, CheckoutId = 1 });
        }
        #endregion
    }
}
