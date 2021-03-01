using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContext
{
    public class DataBaseContext:DbContext
    {
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=ProductCatalogue;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasOne<Category>(s => s.category).WithMany(c => c.product).HasForeignKey(cs => cs.CategoryId);

        }

    }
}
