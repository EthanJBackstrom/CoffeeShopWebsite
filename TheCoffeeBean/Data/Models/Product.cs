using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}