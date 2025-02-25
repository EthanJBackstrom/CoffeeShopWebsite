using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public decimal TotalAmount { get; set; }
        [StringLength(50)]
        public string Status { get; set; } = "Pending";
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}