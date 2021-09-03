using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using dadachMovie.Entities;
using dadachMovie.Entities.News;
using dadachMovie.Entities.Users;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CategoryNews> CategoryNews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserRateNews> UserRateNews { get; set; }
        public DbSet<UserViewCategoryCount> UserViewCategoryCounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CategoryNews
            modelBuilder.Entity<CategoryNews>().HasKey(x => new { x.CategoryId, x.NewsId });

            modelBuilder.Entity<CategoryNews>().HasOne(x => x.Category)
                .WithMany(x => x.CategoryNews).HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<CategoryNews>().HasOne(x => x.News)
                .WithMany(x => x.CategoryNews).HasForeignKey(x => x.NewsId);

            modelBuilder.Entity<CategoryNews>().HasIndex(x => x.NewsId);
            modelBuilder.Entity<CategoryNews>().HasIndex(x => x.CategoryId);

            modelBuilder.Entity<CategoryNews>().Property(x => x.NewsId);
            modelBuilder.Entity<CategoryNews>().Property(x => x.CategoryId);
            //UserRateNews
            modelBuilder.Entity<UserRateNews>().HasKey(x => new { x.NewsId, x.UserId });
            modelBuilder.Entity<UserRateNews>().HasOne(x => x.User)
                .WithMany(x => x.UserRateNews).HasForeignKey(x => x.NewsId);
            modelBuilder.Entity<UserRateNews>().HasOne(x => x.News)
               .WithMany(x => x.UserRateNews).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserRateNews>().HasIndex(x => x.NewsId);
            modelBuilder.Entity<UserRateNews>().HasIndex(x => x.UserId);

            modelBuilder.Entity<UserRateNews>().Property(x => x.NewsId);
            modelBuilder.Entity<UserRateNews>().Property(x => x.UserId);
            //UserViewCategoryCount
            modelBuilder.Entity<UserViewCategoryCount>().HasKey(x => new { x.CategoryId, x.UserId });
            modelBuilder.Entity<UserViewCategoryCount>().HasOne(x => x.User)
                .WithMany(x => x.UserViewCategoryCounts).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserViewCategoryCount>().HasOne(x => x.Category)
                .WithMany(x => x.UserViewCategoryCounts).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<UserViewCategoryCount>().HasIndex(x => x.CategoryId);
            modelBuilder.Entity<UserViewCategoryCount>().HasIndex(x => x.UserId);

            modelBuilder.Entity<UserViewCategoryCount>().Property(x => x.CategoryId);
            modelBuilder.Entity<UserViewCategoryCount>().Property(x => x.UserId);

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        #region seadData

        //permissions
        private void SeedData(ModelBuilder modelBuilder)
        {
            var adminPanel = new Permission() { PermissionId = 1, permissionTitle = "پنل مدیریت", };
            var userManagment = new Permission() { PermissionId = 2, permissionTitle = "مدیریت کاربران", ParentId = 1 };
            var roleManagment = new Permission() { PermissionId = 6, permissionTitle = "مدیریت  نقش ها", ParentId = 1 };
            var addRole = new Permission() { PermissionId = 7, permissionTitle = "افزودن نقش", ParentId = 6 };
            var editRole = new Permission() { PermissionId = 8, permissionTitle = "ویرایش نقش", ParentId = 6 };

            modelBuilder.Entity<Permission>()
                .HasData(new List<Permission>
                {
                    adminPanel, userManagment, roleManagment, addRole, editRole,
                });
        }

        #endregion
    }
}