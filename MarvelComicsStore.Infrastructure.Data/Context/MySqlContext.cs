using MarvelComicsStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Infrastructure.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Checkout> Checkout { get; set; }
        public DbSet<PurchasedItem> PurchasedItem { get; set; }

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
           
            //HasData para inserir registros ao criar a tabela
            modelBuilder.Entity<Checkout>()
                .HasData(
                new Checkout { Id = 1, Coupon = string.Empty, TotalDiscount = 0, TotalPrice = 0 });

            //modelBuilder.Entity<PurchasedItem>()
            //   .HasData(
            //   new PurchasedItem { Id = 1, Title = "Teste", Price = 4.25, Unity = 1, Checkout = new Checkout { Id = 1} });
        }
    }
}
