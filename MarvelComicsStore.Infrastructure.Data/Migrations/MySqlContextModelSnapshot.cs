﻿// <auto-generated />
using MarvelComicsStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarvelComicsStore.Infrastructure.Data.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("MarvelComicsStore.Domain.Entities.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Coupon")
                        .HasColumnType("longtext");

                    b.Property<decimal>("TotalDiscount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Checkout");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Coupon = "",
                            TotalDiscount = 0m,
                            TotalPrice = 0m
                        });
                });

            modelBuilder.Entity("MarvelComicsStore.Domain.Entities.PurchasedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80)
                        .HasColumnType("int");

                    b.Property<int>("CheckoutId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<bool>("Rare")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("Unity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CheckoutId");

                    b.ToTable("PurchasedItem");
                });

            modelBuilder.Entity("MarvelComicsStore.Domain.Entities.PurchasedItem", b =>
                {
                    b.HasOne("MarvelComicsStore.Domain.Entities.Checkout", "Checkout")
                        .WithMany("PurchasedItems")
                        .HasForeignKey("CheckoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Checkout");
                });

            modelBuilder.Entity("MarvelComicsStore.Domain.Entities.Checkout", b =>
                {
                    b.Navigation("PurchasedItems");
                });
#pragma warning restore 612, 618
        }
    }
}
