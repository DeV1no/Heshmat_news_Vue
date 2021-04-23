using System.Diagnostics.CodeAnalysis;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>


    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<NewsComment> NewsComments { get; set; }
    }
}