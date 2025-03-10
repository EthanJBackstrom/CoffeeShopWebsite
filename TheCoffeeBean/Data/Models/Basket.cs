using System.ComponentModel.DataAnnotations;

namespace TheCoffeeBean.Data.Models
{
    public class Basket
    {
        // primary key for each customers basket with ID for the basket below it 
        [Key]
        public int BasketID { get; set; }
        [Required]
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>(); // Whats in the basekt 
    
    } 
}
