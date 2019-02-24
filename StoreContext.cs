using System;
using Microsoft.EntityFrameworkCore;

namespace entity_course
{
    internal class StoreContext : DbContext
    {
        public StoreContext()
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;user id=admin;password=123456;port=3306;database=db;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromotionProduct>().HasKey(pp => new {pp.PromotionId, pp.ProductId});
            base.OnModelCreating(modelBuilder);
        }
    }
}