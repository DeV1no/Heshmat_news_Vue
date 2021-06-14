using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public DbSet<NewsComment> NewsComments { get; set; }
        public DbSet<Permission> Permission { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        #region seadData

        //permissions
        private void SeedData(ModelBuilder modelBuilder)
        {
            var adminPanel = new Permission() {PermissionId = 1, permissionTitle = "پنل مدیریت",};
            var userManagment = new Permission() {PermissionId = 2, permissionTitle = "مدیریت کاربران", ParentId = 1};
            var roleManagment = new Permission() {PermissionId = 6, permissionTitle = "مدیریت  نقش ها", ParentId = 1};
            var addRole = new Permission() {PermissionId = 7, permissionTitle = "افزودن نقش", ParentId = 6};
            var editRole = new Permission() {PermissionId = 8, permissionTitle = "ویرایش نقش", ParentId = 6};

            modelBuilder.Entity<Permission>()
                .HasData(new List<Permission>
                {
                    adminPanel, userManagment, roleManagment, addRole, editRole,
                });
        }

        #endregion
    }
}