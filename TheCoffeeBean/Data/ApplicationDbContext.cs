using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheCoffeeBean.Data.Models;

namespace TheCoffeeBean.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

   
        public DbSet<Product> Products { get; set; } = default!;

       
        public DbSet<OrderHistory> OrderHistories { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;

        
        public DbSet<Payment> Payments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
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
        }
    }
}