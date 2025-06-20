using System;
using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderNo { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        
        [Required]
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = "COMPLETED";


        public OrderHistory OrderHistory { get; set; } = null!;
    }
}