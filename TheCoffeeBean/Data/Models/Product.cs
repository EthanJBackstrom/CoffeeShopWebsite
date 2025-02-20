using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(255)]
    public string Description { get; set; }

    [Required]
    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}