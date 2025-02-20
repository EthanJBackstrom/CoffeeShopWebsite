using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(255)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}