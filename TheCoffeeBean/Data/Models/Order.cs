using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } // This should reference AspNetUsers.Id

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Required]
    public decimal TotalAmount { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = "Pending";

    // Navigation Property
    public List<OrderItem> OrderItems { get; set; }
}