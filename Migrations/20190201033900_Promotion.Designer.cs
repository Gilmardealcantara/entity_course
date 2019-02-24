﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using entity_course;

namespace entity_course.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20190201033900_Promotion")]
    partial class Promotion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("entity_course.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Name");

                    b.Property<string>("Unity");

                    b.Property<double>("UnityPrice");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("entity_course.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("entity_course.PromotionProduct", b =>
                {
                    b.Property<int>("PromotionId");

                    b.Property<int>("ProductId");

                    b.HasKey("PromotionId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("PromotionProduct");
                });

            modelBuilder.Entity("entity_course.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Qnt");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("entity_course.PromotionProduct", b =>
                {
                    b.HasOne("entity_course.Product", "Product")
                        .WithMany("Promotions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("entity_course.Promotion", "Promotion")
                        .WithMany("Poducts")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("entity_course.Purchase", b =>
                {
                    b.HasOne("entity_course.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}