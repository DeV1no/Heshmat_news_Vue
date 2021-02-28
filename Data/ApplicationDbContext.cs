using System.Diagnostics.CodeAnalysis;
using HeshmastNews.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeshmastNews.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            //  base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}