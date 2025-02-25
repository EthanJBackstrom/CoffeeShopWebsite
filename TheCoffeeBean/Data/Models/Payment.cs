using System;
using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        [Required]
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = "COMPLETED";
        public Order Order { get; set; } = null!;
    }
}