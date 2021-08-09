using MarvelComicsStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Infrastructure.Data.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<Checkout> Checkout { get; set; }
        public DbSet<PurchasedItem> PurchasedItem { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Checkout>()
               .Property(x => x.TotalDiscount)
               .HasPrecision(10, 2);

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
                new Checkout { Id = 1, Coupon = string.Empty, TotalDiscount = 0, TotalPrice = 0 });

            modelBuilder.Entity<PurchasedItem>()
               .HasData(
               new PurchasedItem { Id = 1, Title = "Teste", Price = 4.25m, Unity = 1, CheckoutId = 1 });
        }
    }
}
