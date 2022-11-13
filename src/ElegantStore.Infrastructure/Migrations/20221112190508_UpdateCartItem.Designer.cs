﻿// <auto-generated />
using ElegantStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElegantStore.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221112190508_UpdateCartItem")]
    partial class UpdateCartItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ElegantStore.Domain.Entities.Aggregates.CartAggregate.Cart", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("ElegantStore.Domain.Entities.Aggregates.CartAggregate.CartItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("ElegantStore.Domain.Entities.Aggregates.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageBase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("ElegantStore.Domain.Entities.Aggregates.ProductAggregate.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ColorId");

                    b.HasIndex("ColorId");

                    b.ToTable("ProductColors", (string)null);
                });

            modelBuilder.Entity("ElegantStore.Domain.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors", (string)null);
                });

            modelBuilder.Entity("ElegantStore.Domain.Entities.Aggregates.CartAggregate.CartItem", b =>
                {
                    b.HasOne("ElegantStore.Domain.Entities.Aggregates.CartAggregate.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElegantStore.Domain.Entities.Aggregates.ProductAggregate.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ElegantStore.Domain.Entities.Aggregates.ProductAggregate.ProductVariant", b =>
                {
                    b.HasOne("ElegantStore.Domain.Entities.Color", "Color")
                        .WithMany("ProductVariants")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElegantStore.Domain.Entities.Aggregates.ProductAggregate.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ElegantStore.Domain.Entities.Aggregates.CartAggregate.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ElegantStore.Domain.Entities.Aggregates.ProductAggregate.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("ElegantStore.Domain.Entities.Color", b =>
                {
                    b.Navigation("ProductVariants");
                });
#pragma warning restore 612, 618
        }
    }
}
