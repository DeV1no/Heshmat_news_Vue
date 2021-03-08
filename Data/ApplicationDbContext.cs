using System.Diagnostics.CodeAnalysis;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubToCat>().HasKey(x => new {x.CategoryId, x.SubCategoryId});
            modelBuilder.Entity<CategoryNews>().HasKey(x => new {x.CategoryId, x.NewsId});
            modelBuilder.Entity<ComentNews>().HasKey(x => new {x.CommentId, x.NewsId});
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubToCat> SubToCat { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<CategoryNews> CategoryNews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ComentNews> ComentNews { get; set; }
    }
}