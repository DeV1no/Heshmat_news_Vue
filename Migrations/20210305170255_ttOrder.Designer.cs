﻿// <auto-generated />
using System;
using HeshmastNews.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dadachMovie.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210305170255_ttOrder")]
    partial class ttOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("HeshmastNews.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HeshmastNews.Entities.CategoryNews", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("NewsId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "NewsId");

                    b.HasIndex("NewsId");

                    b.ToTable("CategoryNews");
                });

            modelBuilder.Entity("HeshmastNews.Entities.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NewsBody")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Poster")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("HeshmastNews.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("HeshmastNews.Entities.SubToCat", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "SubCategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("SubToCat");
                });

            modelBuilder.Entity("HeshmastNews.Entities.CategoryNews", b =>
                {
                    b.HasOne("HeshmastNews.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeshmastNews.Entities.News", "News")
                        .WithMany("CategoryNews")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("News");
                });

            modelBuilder.Entity("HeshmastNews.Entities.SubToCat", b =>
                {
                    b.HasOne("HeshmastNews.Entities.Category", "Category")
                        .WithMany("SubToCat")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeshmastNews.Entities.SubCategory", "SubCategory")
                        .WithMany("SubToCat")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("HeshmastNews.Entities.Category", b =>
                {
                    b.Navigation("SubToCat");
                });

            modelBuilder.Entity("HeshmastNews.Entities.News", b =>
                {
                    b.Navigation("CategoryNews");
                });

            modelBuilder.Entity("HeshmastNews.Entities.SubCategory", b =>
                {
                    b.Navigation("SubToCat");
                });
#pragma warning restore 612, 618
        }
    }
}