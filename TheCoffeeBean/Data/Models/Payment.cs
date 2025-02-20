using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Payment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.Now;

    [Required]
    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; }
    
    public string Status { get; set; } = "COMPLETED";

    // Navigation Property
    public Order Order { get; set; }
}