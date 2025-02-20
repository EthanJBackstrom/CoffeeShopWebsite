using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TheCoffeeBean.Data.Models
{
    public class OrderItem
    {
        [Key] public int Id { get; set; }

        [Required] public int OrderId { get; set; }

        [Required] public int ProductId { get; set; }

        [Required] [Range(1, 100)] public int Quantity { get; set; }

        [Required] public decimal Price { get; set; }

        // Navigation Properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}