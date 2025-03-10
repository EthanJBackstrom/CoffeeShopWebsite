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
        // Tables in Database 
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Basket> Baskets { get; set; } = null!;
        public DbSet<BasketItem> BasketItems { get; set; } = null!;
        public DbSet<CheckoutCustomer> CheckoutCustomers { get; set; } = null!;
        public DbSet<OrderHistory> OrderHistories { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<CheckoutItem> CheckoutItems { get; set; } = null!;
             
        //Relationships between the tables 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<OrderHistory>().HasKey(oh => oh.OrderNo);

          
            modelBuilder.Entity<BasketItem>()
                .HasKey(bi => new { bi.BasketID, bi.StockID });
            
            modelBuilder.Entity<Basket>()
                .HasMany(b => b.Items)
                .WithOne(bi => bi.Basket)
                .HasForeignKey(bi => bi.BasketID);

          
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderNo, oi.StockID });

      
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.OrderHistory)
                .WithMany(oh => oh.OrderItems)
                .HasForeignKey(oi => oi.OrderNo);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.StockID);

       
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.OrderHistory)
                .WithMany()
                .HasForeignKey(p => p.OrderNo);

        // prevents rounding problem with the prices 
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

           
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

         
            modelBuilder.Entity<CheckoutItem>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
