using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema; // for [NotMapped]
using TheCoffeeBean.Data.Models; // your models

namespace TheCoffeeBean.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }

        
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<CheckoutCustomer> CheckoutCustomers { get; set; }

        
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        
        [NotMapped]
        public DbSet<CheckoutItem> CheckoutItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BasketItem>()
                .HasKey(bi => new { bi.BasketID, bi.StockID });

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderNo, oi.StockID });

            
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.OrderHistory)
                .WithMany(h => h.OrderItems)
                .HasForeignKey(oi => oi.OrderNo);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.StockID);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.OrderHistory)
                .WithMany()
                .HasForeignKey(p => p.OrderNo);
            
            modelBuilder.Entity<BasketItem>()
                .HasKey(bi => new { bi.StockID, bi.BasketID });

        }
    }
}