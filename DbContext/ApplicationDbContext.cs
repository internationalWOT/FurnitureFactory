using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureFactory.DbContext
{
    public sealed class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public Microsoft.EntityFrameworkCore.DbSet<Product> Product { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Template> Template { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTemplate>()
                .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<ProductTemplate>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.Templates)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<ProductTemplate>()
                .HasOne(pt => pt.Template)
                .WithMany(t => t.Products)
                .HasForeignKey(pt => pt.TagId);
        }
    }

}
